using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //-------------------�⺻����-------------------
    [Header("PlayerSet")]
    public GameObject Player;
    public GameObject Player_Body;
    public GameObject Line;
    public float speed;
    //-------------------�̵�����-------------------
    [Header("TouchMoved")]
    Touch touch1; // �̵� ��ġ
    Touch touch2; // ���� ��ġ
    Vector2 smoothedDirection;
    Vector3 previousPosition;
    Vector3 lastPosition;
   //-------------------���ݰ���-------------------
   [Header("TouchAtk")]
    public LineRenderer lineRenderer;
    Vector3 AtkRange; //
    public static bool atkState = false;
    //-------------------ü�°���-------------------
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
    //-------------------����� ������Ʈ-------------------
    EdgeCollider2D lineCollider; // ���η������� ����� �ݶ��̴�
    Rigidbody2D lineRigid;
   public SpriteRenderer spriteRenderer;
   public Material material;
    //---------------------bool--------------------------
    bool isAtk = false; // �������϶��� ������x
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
            Debug.Log("Į");
            isHit = true;
        }

        if (collision.gameObject.tag == "Stage1_Kunai")
        {
            Debug.Log("����");
            isHit = true;
        }
        if (collision.gameObject.tag == "Stage1_Bullet")
        {
            Debug.Log("��");
            isHit = true;
        }
        if (collision.gameObject.tag == "Stage1_Arrow")
        {
            Debug.Log("Ȱ");
            isHit = true;
        }
        if (collision.gameObject.tag == "Stage1_SpinSword")
        {
            Debug.Log("ȸ��Į");
            isHit = true;
        }
    }


    void Update()
    {
        if (Input.touchCount > 0) // ù �Է�
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
                    float mindistance = 3f; // �� ���� �������� ��ġ�ΰ��� ������
                    float smoothFactor = 0.5f; // �Է� ���� ���� ���
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
                smoothedDirection = Vector2.zero; // �Է� ���� ���� �ʱ�ȭ
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
                    // atktxt.text = "atkx : " + AtkRange.x + "atky : " + AtkRange.y; �׽�Ʈ

                    Vector3 dir = AtkRange.normalized;

                    isRender = true;
                    if (isRender)
                    {
                        // �߽��� �ű��
                        float r = (Player.transform.localScale.x / 2) + 5f; // �������� ���ڸ� �����ϸ��
                        Vector3 center = Player.transform.position; // ����

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
            if (isRender && isTouch) // �׷ȴ� ������ ����� ����
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
        } // ��ġ �������� finger id�� ����            

        if (isRay) // ���Ͱ� �ǰ����϶�
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
