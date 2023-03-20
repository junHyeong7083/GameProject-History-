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

    //-------------------�̵�����-------------------
    [Header("TouchMoved")]
    Touch touch1; // �̵� ��ġ
    Touch touch2; // ���� ��ġ
    Vector2 dir; // �̵��� ����� ����

    //-------------------���ݰ���-------------------
    [Header("TouchAtk")]
    public LineRenderer lineRenderer;
    public Transform playerTransform;
    public float lineDrawSpeed;
    Vector3 AtkRange; //

    bool isAtk = false; // �������϶��� ������x
    bool isRender = false; 
    bool isMoving = false;
    void Start()
    {
    }

    int EndedFinger = 0;
    void Update()
    {
        if (Input.touchCount > 0) // ù �Է�
        {
            touch1 = FindTouchById(0);
            if (FindTouchById(0).phase == TouchPhase.Moved || FindTouchById(0).phase == TouchPhase.Began)
            {
                if (!isAtk)
                {

                    dir = (touch1.position - touch1.rawPosition).normalized / 3;
                    // dirtxt.text = "x : " + dir.x + "y : " + dir.y; �׽�Ʈ
                    isMoving = true;
                    Player.transform.Translate(dir * speed * Time.deltaTime);
                }
            }
 
            if (Input.touchCount >= 1) // 2��° �Է�
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
                       // atktxt.text = "atkx : " + AtkRange.x + "atky : " + AtkRange.y; �׽�Ʈ

                        Vector3 dir = AtkRange.normalized;

                        isRender = true;
                        if (isRender)
                        {
                            // �߽��� �ű��
                            float r = (playerTransform.localScale.x / 2) + 0.8f; // ������ 0.8�� �����ϸ��
                            Vector3 drag = AtkRange;
                            Vector3 center = playerTransform.position; // ����
                            
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
                           // positions[0] = playerTransform.position; // �÷��̾� ��ǥ
                           // positions[1] = AtkRange; // ���� �巡�� ����ǥ
                           // lineRenderer.enabled = true;
                           // lineRenderer.SetPositions(positions);
                        }
                    }

                    // AtkRnage : �巡�׽� ��ǥ�� - �巡���Ҷ����� ���ŵ�
                    // LaserPoint�� AtkRange�� �̿��ؼ� ���η����� ����ϸ��
                }
                else if (FindTouchById(0).phase == TouchPhase.Ended || FindTouchById(1).phase == TouchPhase.Ended) // ���� ������
                {
                    isAtk = false;

                    if (isRender) // �׷ȴ� ������ ����� ����
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

