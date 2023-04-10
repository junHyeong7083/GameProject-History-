using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSelect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [Header("-------JoyStickRect-------")]
    [SerializeField]
    private RectTransform rectBackground;
    [SerializeField]
    private RectTransform rectJoystick;

    public Image JoystickImage;
    [Header("-------Select Stage-------")]
    public Image SelectPanel;
    public Image Stage1_image;
    public Image Stage2_image;
    public Image Stage3_image;
    

    int SelectIcon;
    private float radius; // Background밖을 joystick가 못나가도록 background의 반지름을 저장할 변수
    Vector2 value;
    bool touch = false;

    void Start()
    {
        radius = rectBackground.rect.width / 2;
        SelectPanel.gameObject.SetActive(false);
    }



    public void OnDrag(PointerEventData eventData)
    {
        touch = true;
        // Time.timeScale = 0.3f;
        value = eventData.position - (Vector2)rectBackground.position;

        value = Vector2.ClampMagnitude(value, radius);
        //( 1, 4 ) value의 값  ( 1 -4 = -3 )------------(1+4 = 5) 사이의 값

        rectJoystick.localPosition = value;


        value = value.normalized;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData) // 손뗏을떄
    {
        rectJoystick.localPosition = new Vector3(0, 0, 0);
        // 지정한 범위안에 숫자따라 행동하게 
       switch(SelectIcon)
        {
            case 1:
                JoystickImage.color = Color.red;
                SelectPanel.gameObject.SetActive(true);
                break;
            case 2:
                JoystickImage.color = Color.green;
                print("right");
                break;
            case 3:
                JoystickImage.color = Color.yellow;
                print("bottom");
                break;
            case 4:
                JoystickImage.color = Color.blue;
                print("left");
                break;
            default:
                break;
        }

    }
    public void stage1_change()
    {
        SceneManager.LoadScene("Stage1");
    }
    // Update is called once per frame
    void Update()
    {
      //  print(value);
;       if (touch)
        {
            if (value.x > -0.75 && value.x < 0.75 && value.y < 1 && value.y > 0)  // 1사분면
            {
                SelectIcon = 1;
              //  print("Top");
            }
            else if (value.x > 0 && value.x < 1 &&  value.y > -0.75 && value.y < 0.75) //2사
            {
                SelectIcon = 2;
             //   print("right");
            }
            else if (value.x > -0.75 && value.x < 0.75 && value.y > -1 && value.y < 0) // 3사
            {
                SelectIcon = 3;
                //print("bottom");
            }
            else if (value.x < 0 && value.x > -1 && value.y > -0.75 && value.y < 0.75) // 4사
            {
                SelectIcon = 4;
                // print("left");  
            }
         }
    }
}
