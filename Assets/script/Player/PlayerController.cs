using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public float speed;


    [Header("Test Debug")]
    public Text dirtxt;
    public Text atktxt;

    //-------------------이동관련-------------------
    Touch touch1; // 이동 터치
    Touch touch2; // 공격 터치
    Vector2 dir; // 이동에 적용될 벡터
    Vector2 AtkRange; // 


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
             if(Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touch1 = Input.GetTouch(0);
                dir = (touch1.position - touch1.rawPosition).normalized;
                dirtxt.text = "x : " + dir.x + "y : " + dir.y;

                Player.transform.Translate(dir * speed * Time.deltaTime);   
            }

             if(Input.touchCount > 1)
            {
                if (Input.GetTouch(1).phase == TouchPhase.Moved)
                {
                    touch2 = Input.GetTouch(1);
                    AtkRange = Camera.main.ScreenToWorldPoint(touch2.position);
                    atktxt.text = "atkx : " + AtkRange.x + "atky : " + AtkRange.y;

                    // AtkRnage : 드래그시 좌표값 - 드래그할때마다 갱신됨
                    // LaserPoint랑 AtkRange값 이용해서 라인렌더러 사용하면삘
                }
                else if (Input.GetTouch(1).phase == TouchPhase.Ended) // 손을 뗏을때
                {
                    Vector3 touchWorldPosition = Camera.main.ScreenToWorldPoint(touch2.position);
                    Player.transform.position = new Vector2(touchWorldPosition.x, touchWorldPosition.y);
                }

            }

        }

    }

  

}

