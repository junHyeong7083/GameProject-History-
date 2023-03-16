using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public float speed;
    public List<touchLocation> touches = new List<touchLocation>();


    public Text dirtxt;
    public Text atktxt;

    Touch touch1; // �̵� ��ġ
    Touch touch2; // ���� ��ġ
    Vector2 dir; // �̵��� ����� ����
    Vector2 AtkRange;

    void Start()
    {
    }
     Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 0));

    }
   
    void Update()
    {
        if(Input.touchCount > 0) // ù �Է�
        {
             if(Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touch1 = Input.GetTouch(0);
                dir = (touch1.position - touch1.rawPosition).normalized;
                dirtxt.text = "x : " + dir.x + "y : " + dir.y;

                Player.transform.Translate(dir * speed * Time.deltaTime);

                if (Input.GetTouch(1).phase == TouchPhase.Moved)
                {
                    touch2 = Input.GetTouch(1);
                    AtkRange =Camera.main.ScreenToWorldPoint( touch2.position); // �巡�� �� ��ǥ��
                    atktxt.text = "atkx : " + AtkRange.x + "atky : " + AtkRange.y;
                }
            }
            else if(Input.GetTouch(1).phase == TouchPhase.Ended ) // ���� ������
            {
                Vector3 touchWorldPosition = Camera.main.ScreenToWorldPoint(touch2.position);
                Player.transform.position = new Vector2(touchWorldPosition.x, touchWorldPosition.y);
            }

        }

       

    }

}
