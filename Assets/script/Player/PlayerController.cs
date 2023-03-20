using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("PlayerSet")]
    public GameObject Player;
    public float speed;

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
    bool isMoving = false;
    void Start()
    {
    }

    int EndedFinger = 0;
    void Update()
    {
        if (Input.touchCount > 0) // 첫 입력
        {
            touch1 = FindTouchById(0);
            if (FindTouchById(0).phase == TouchPhase.Moved || FindTouchById(0).phase == TouchPhase.Began)
            {
                if (!isAtk)
                {

                    dir = (touch1.position - touch1.rawPosition).normalized / 3;
                    // dirtxt.text = "x : " + dir.x + "y : " + dir.y; 테스트
                    isMoving = true;
                    Player.transform.Translate(dir * speed * Time.deltaTime);
                }
            }
 
            if (Input.touchCount >= 1) // 2번째 입력
            {
                touch2 = FindTouchById(1);
                if (Input.GetTouch(1).phase == TouchPhase.Moved)
                {
                    isAtk = true;
                    isMoving = false;
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
                            float r = (playerTransform.localScale.x / 2) + 0.8f; // 반지름 0.8을 수정하면됨
                            Vector3 drag = AtkRange;
                            Vector3 center = playerTransform.position; // 중점
                            
                            float theta = Mathf.Atan2(drag.y - center.y, drag.x - center.x);
                            Vector3 edge = new Vector3(center.x + r * Mathf.Cos(theta), center.y + r * Mathf.Sin(theta));

                            Vector3[] positions = new Vector3[lineRenderer.positionCount];
                            lineRenderer.GetPositions(positions);
                            positions[0] = edge;
                            positions[1] = AtkRange;

                            lineRenderer.SetPositions(positions);
                            lineRenderer.enabled = true;
                           
                            
                           // Vector3[] positions = new Vector3[lineRenderer.positionCount];
                           // lineRenderer.GetPositions(positions);
                           // positions[0] = playerTransform.position; // 플레이어 좌표
                           // positions[1] = AtkRange; // 공격 드래그 끝좌표
                           // lineRenderer.enabled = true;
                           // lineRenderer.SetPositions(positions);
                        }
                    }

                    // AtkRnage : 드래그시 좌표값 - 드래그할때마다 갱신됨
                    // LaserPoint랑 AtkRange값 이용해서 라인렌더러 사용하면삘
                }
                else if (FindTouchById(0).phase == TouchPhase.Ended || FindTouchById(1).phase == TouchPhase.Ended) // 손을 뗏을때
                {
                    isAtk = false;

                    if (isRender) // 그렸던 라인을 지우는 과정
                    {
                        Vector3 touchWorldPosition = Camera.main.ScreenToWorldPoint(touch2.position);
                        Player.transform.position = new Vector2(touchWorldPosition.x, touchWorldPosition.y);
                        isRender = false;
                        lineRenderer.enabled = false;
                        lineRenderer.SetPositions(new Vector3[0]);
                    }
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
            }
        }
    }


}

