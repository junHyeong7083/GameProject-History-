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


    [Header("Test Debug")]
    public Text dirtxt;
    public Text atktxt;

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
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (!isAtk)
                {

                    dir = (touch1.position - touch1.rawPosition).normalized / 3;
                    dirtxt.text = "x : " + dir.x + "y : " + dir.y;
                    isMoving = true;
                    Player.transform.Translate(dir * speed * Time.deltaTime);
                }
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                if(!isAtk)
                {
                    dir = new Vector2(0, 0);
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
                        atktxt.text = "atkx : " + AtkRange.x + "atky : " + AtkRange.y;

                        Vector3 dir = AtkRange.normalized;

                        isRender = true;
                        if (isRender)
                        {
                            Vector3 offset = dir.normalized * 0.5f;
                            Vector3[] positions = new Vector3[lineRenderer.positionCount];
                            lineRenderer.GetPositions(positions);
                            positions[0] = playerTransform.position + offset; // �÷��̾� ��ǥ
                            positions[1] = AtkRange; // ���� �巡�� ����ǥ
                            lineRenderer.enabled = true;
                            lineRenderer.SetPositions(positions);
                        }
                    }

                    // AtkRnage : �巡�׽� ��ǥ�� - �巡���Ҷ����� ���ŵ�
                    // LaserPoint�� AtkRange�� �̿��ؼ� ���η����� ����ϸ��
                }
                else if (Input.GetTouch(1).phase == TouchPhase.Ended && Input.GetTouch(0).phase == TouchPhase.Ended) // ���� ������
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

