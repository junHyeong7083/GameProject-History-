using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //-------------------기본설정-------------------
    [Header("PlayerSet")]
    public GameObject Player;
    public GameObject Player_Body;
    public GameObject Line;
    public float speed;
    //-------------------이동관련-------------------
    [Header("TouchMoved")]
    Touch touch1; // 이동 터치
    Touch touch2; // 공격 터치
    Vector2 smoothedDirection;
    Vector3 previousPosition;
    Vector3 lastPosition;
   //-------------------공격관련-------------------
   [Header("TouchAtk")]
    public LineRenderer lineRenderer;
    Vector3 AtkRange; //
    public static bool atkState = false;
    //-------------------체력관련-------------------
    [Header("PlayerHP")]
    public GameObject topHp;
    public GameObject rightHp;
    public GameObject bottomHp;
    public GameObject leftHp;

    public static int Hp;
    bool isHit;
    float hitCoolTime = 2f;
    float hitTimer;
    float shaderOffset;
    //-------------------사용할 컴포넌트-------------------
    EdgeCollider2D lineCollider; // 라인렌더러시 사용할 콜라이더
    Rigidbody2D lineRigid;
   public SpriteRenderer spriteRenderer;
   public Material material;
    //---------------------bool--------------------------
    bool isAtk = false; // 공격중일때는 움직임x
    bool isRender = false;
    bool isRay = false;
    bool isTouch = false;
    public static bool isDie = false;
    //---------------------Els--------------------------
    void Start()
    {
        isDie = false;
        Hp = 4;
        hitTimer = 0f;
        shaderOffset = 1f;
        Time.timeScale = 1f;

        material.SetFloat("_Fade", 1f);
        lineCollider = Line.GetComponent<EdgeCollider2D>();
        lineRigid = Line.GetComponent<Rigidbody2D>();
        lineRenderer.startWidth = 3f;
        lineRenderer.endWidth = 3f;
    }

    public void DecreaseHp()
    {
        Hp--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stage1_Sword")
        {
            Debug.Log("칼");
            isHit = true;
        }

        if (collision.gameObject.tag == "Stage1_Kunai")
        {
            Debug.Log("쿠나이");
            isHit = true;
        }
        if (collision.gameObject.tag == "Stage1_Bullet")
        {
            Debug.Log("총");
            isHit = true;
        }
        if (collision.gameObject.tag == "Stage1_Arrow")
        {
            Debug.Log("활");
            isHit = true;
        }
        if (collision.gameObject.tag == "Stage1_SpinSword")
        {
            Debug.Log("회전칼");
            isHit = true;
        }
    }


    void Update()
    {
        if (Input.touchCount > 0) // 첫 입력
        {
            isTouch = true;
            touch1 = FindTouchById(0);

            if (FindTouchById(0).phase == TouchPhase.Began)
            {
                previousPosition = touch1.position;
                smoothedDirection = Vector2.zero;
            }
            else if (FindTouchById(0).phase == TouchPhase.Moved)
            {
                if (!isAtk)
                {
                    Vector3 touchPosition = touch1.position;
                    Vector2 newDirection = (touchPosition - previousPosition).normalized;
                    float distance = Vector2.Distance(touchPosition, previousPosition);
                    float mindistance = 3f; // 이 값이 높아지면 터치민감도 낮아짐
                    float smoothFactor = 0.5f; // 입력 방향 보정 계수
                    if (distance > mindistance)
                    {
                        smoothedDirection = Vector2.Lerp(smoothedDirection, newDirection, smoothFactor);
                        Player.transform.Translate(smoothedDirection * speed * Time.deltaTime);
                        previousPosition = touchPosition;
                    }

                }
            }
            else if (FindTouchById(0).phase == TouchPhase.Stationary)
            {
                Player.transform.Translate(Vector2.zero * speed * Time.deltaTime);
                smoothedDirection = Vector2.zero; // 입력 방향 보정 초기화
            }

            touch2 = FindTouchById(1);
            Vector2 touch2prePoisition = FindTouchById(1).position;

             if (FindTouchById(1).phase == TouchPhase.Moved)
            {
                isAtk = true;
                if (isAtk)
                {
                    AtkRange = Camera.main.ScreenToWorldPoint(touch2.position);

                    AtkRange.z = 0f;
                    // atktxt.text = "atkx : " + AtkRange.x + "atky : " + AtkRange.y; 테스트

                    Vector3 dir = AtkRange.normalized;

                    isRender = true;
                    if (isRender)
                    {
                        // 중심점 옮기기
                        float r = (Player.transform.localScale.x / 2) + 5f; // 반지름뒤 숫자를 수정하면됨
                        Vector3 center = Player.transform.position; // 중점

                        float theta = Mathf.Atan2(AtkRange.y - center.y, AtkRange.x - center.x);
                        Vector3 edge = new Vector3(center.x + r * Mathf.Cos(theta), center.y + r * Mathf.Sin(theta));

                        Vector3[] positions = new Vector3[lineRenderer.positionCount];
                        lineRenderer.GetPositions(positions);
                        positions[0] = edge;
                        positions[1] = AtkRange;

                        lineRenderer.enabled = true;
                        lineRenderer.SetPositions(positions);

                        #region RayCast
                        float maxRaydistance = Vector3.Distance(edge, AtkRange);
                        Vector3 rayDir = (AtkRange - edge).normalized;
                        RaycastHit2D hit = Physics2D.Raycast(edge, rayDir, maxRaydistance);
                        if (hit == GameObject.FindGameObjectWithTag("Boss"))
                        {
                            isRay = true;
                        }
                        else
                            isRay = false;
                        #endregion

                    }
                }
            }
             if(FindTouchById(1).phase == TouchPhase.Ended)
            {
                lastPosition = touch2prePoisition;
            }
        }

        if (Input.touchCount == 0) 
        {
            isAtk = false;
            isRay = false;
            if (isRender && isTouch) // 그렸던 라인을 지우는 과정
            {
                isTouch = false;
                Vector3 touchWorldPosition = Camera.main.ScreenToWorldPoint(lastPosition);

                Player.transform.position = new Vector2(touchWorldPosition.x, touchWorldPosition.y);
                isRender = false;
                lineRenderer.enabled = false;
                lineRenderer.SetPositions(new Vector3[0]);
            }
        }
        Touch FindTouchById(int id)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                Touch t = Input.GetTouch(i);
                if (t.fingerId == id) return t;
            }

            return default(Touch);
        } // 터치 순서따라 finger id값 저장            

        if (isRay) // 몬스터가 피격중일때
        {
            atkState = true;
        }
        if (!isRay) 
        {
            atkState = false;
        }
        #region Hp Image Change
        if (Hp == 3)
        {
            topHp.SetActive(false);
        }
        if (Hp == 2)
        {
            rightHp.SetActive(false);
        }
        if (Hp == 1)
        {
            bottomHp.SetActive(false);
        }
        if (Hp <= 0)
        {
            leftHp.SetActive(false);
            material.SetFloat("_Fade", shaderOffset);
           // Player_Body.SetActive(false);
            shaderOffset -= Time.deltaTime * 1.5f;

            if(shaderOffset <= 0)
            {
                Time.timeScale = 0f;
                shaderOffset = 0;
                isDie = true;
            }
        }
        #endregion
        #region Player Hit
        if (isHit)
        {
            isHit = false;
            if(hitTimer >= hitCoolTime)
            {
                Debug.Log(Hp);
                Hp--;
                hitTimer = 0;
            }
        }
        if(!isHit)
        {
            hitTimer += Time.deltaTime;
            if (hitTimer > 5)
                hitTimer = 5;
        }
        #endregion

    }


}
