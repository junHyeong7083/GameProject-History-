using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("PlayerSet")]
    public GameObject Player;
    public float speed;


    [Header("Test Debug")]
    public Text dirtxt;
    public Text atktxt;

    //-------------------이동관련-------------------
    [Header("TouchMoved")]
    Touch touch1; // 이동 터치
    Touch touch2; // 공격 터치
    Vector2 dir; // 이동에 적용될 벡터

    //-------------------공격관련-------------------
    [Header("TouchAtk")]
    public LineRenderer lineRenderer;
    public Transform playerTransform;
    public float lineDrawSpeed;
    Vector3 AtkRange; //

    bool isAtk = false; // 공격중일때는 움직임x
    bool isRender = false;
    void Start()
    {
    }
     Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 0));

    }
   
    void Update()
    {
       if (Input.touchCount > 0) // 첫 입력
        {
            touch1 = FindTouchById(0);
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if(!isAtk)
                {
                  
                    dir = (touch1.position - touch1.rawPosition).normalized;
                    dirtxt.text = "x : " + dir.x + "y : " + dir.y;

                    Player.transform.Translate(dir * speed * Time.deltaTime);
                }
            }
            if (Input.touchCount > 1) // 2번째 입력
            {
                touch2 = FindTouchById(1);
                if (Input.GetTouch(1).phase == TouchPhase.Moved)
                {
                    isAtk = true;
                    if(isAtk)
                    {
                        AtkRange = Camera.main.ScreenToWorldPoint(touch2.position);
                        AtkRange.z = 0f;
                        atktxt.text = "atkx : " + AtkRange.x + "atky : " + AtkRange.y;

                        isRender = true;
                        if (isRender)
                        {
                            Vector3[] positions = new Vector3[lineRenderer.positionCount];
                            lineRenderer.GetPositions(positions);
                            positions[0] = playerTransform.position;
                            positions[1] = AtkRange;
                            lineRenderer.SetPositions(positions);
                        }
                    }

                    // AtkRnage : 드래그시 좌표값 - 드래그할때마다 갱신됨
                    // LaserPoint랑 AtkRange값 이용해서 라인렌더러 사용하면삘
                }
                else if (Input.GetTouch(1).phase == TouchPhase.Ended) // 손을 뗏을때
                {
                    isAtk = false;
                    if (isRender)
                    {
                        Vector3 touchWorldPosition = Camera.main.ScreenToWorldPoint(touch2.position);
                        Player.transform.position = new Vector2(touchWorldPosition.x, touchWorldPosition.y);
                        isRender = false;
                     //   lineRenderer.enabled = false;
                        lineRenderer.SetPositions(new Vector3[0]);
                    } 
                }

            }

            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                lineRenderer.enabled = false;
                lineRenderer.SetPositions(new Vector3[0]);
            }
        }
      
       Touch FindTouchById(int id)
        {
            for(int i = 0; i<Input.touchCount; ++i)
            {
                Touch t = Input.GetTouch(i);
                if (t.fingerId == id) return t;
            }

            return default (Touch);
        }
    }



}

