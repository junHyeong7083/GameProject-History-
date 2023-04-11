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

    [Header("-------SelectEffect-------")]
    public Image select_1;
    public Image select_2;
    public Image select_3;
    public Image select_4;


    int SelectIcon;
    private float radius; // Background���� joystick�� ���������� background�� �������� ������ ����
    Vector2 value;
    bool touch = false;

    void Start()
    {
        radius = rectBackground.rect.width / 2;
        SelectPanel.gameObject.SetActive(false);


        Color image1_color = select_1.color;
        Color image2_color = select_2.color;
        Color image3_color = select_3.color;
        Color image4_color = select_4.color;

        image1_color.a = 0.3f;
        image2_color.a = 0.3f;
        image3_color.a = 0.3f;
        image4_color.a = 0.3f;
        select_1.color = image1_color;
        select_2.color = image2_color;
        select_3.color = image3_color;
        select_4.color = image4_color;
    }



    public void OnDrag(PointerEventData eventData)
    {
        touch = true;
        // Time.timeScale = 0.3f;
        value = eventData.position - (Vector2)rectBackground.position;

        value = Vector2.ClampMagnitude(value, radius);
        //( 1, 4 ) value�� ��  ( 1 -4 = -3 )------------(1+4 = 5) ������ ��

        rectJoystick.localPosition = value;


        value = value.normalized;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData) // �ն�����
    {
        rectJoystick.localPosition = new Vector3(0, 0, 0);

        // ������ �����ȿ� ���ڵ��� �ൿ�ϰ� 
        switch (SelectIcon)
        {
            case 1: 
                SelectPanel.gameObject.SetActive(true);
                break;
            case 2:          
                break;
            case 3:
              
                break;
            case 4:
             
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
;       if (touch)
        {
            #region SelectEffect ��� ����
            Color image1_color = select_1.color;
            Color image2_color = select_2.color;
            Color image3_color = select_3.color;
            Color image4_color = select_4.color;

            select_1.color = image1_color;
            select_2.color = image2_color;
            select_3.color = image3_color;
            select_4.color = image4_color;
            #endregion
            // r - 200 g - 125 b- 100

            if (value.x > -0.75 && value.x < 0.75 && value.y < 1 && value.y > 0)  // 1��и� d
            {
                SelectIcon = 1;

                image1_color.a = 1f;
                image2_color.a = 1f;
                image3_color.a = 0.3f;
                image4_color.a = 0.3f;

                select_1.color = image1_color;
                select_2.color = image2_color;
                select_3.color = image3_color;
                select_4.color = image4_color;
            }
            else if (value.x > 0 && value.x < 1 &&  value.y > -0.75 && value.y < 0.75) //2��
            {
                SelectIcon = 2;

                image1_color.a = 0.3f;
                image2_color.a = 1f;
                image3_color.a = 0.3f;
                image4_color.a = 1f;


                select_1.color = image1_color;
                select_2.color = image2_color;
                select_3.color = image3_color;
                select_4.color = image4_color;
            }
            else if (value.x > -0.75 && value.x < 0.75 && value.y > -1 && value.y < 0) // 3�� d
            {
                SelectIcon = 3;

                image1_color.a = 0.3f;
                image2_color.a = 0.3f;
                image3_color.a = 1f;
                image4_color.a = 1f;



                select_1.color = image1_color;
                select_2.color = image2_color;
                select_3.color = image3_color;
                select_4.color = image4_color;

            }
            else if (value.x < 0 && value.x > -1 && value.y > -0.75 && value.y < 0.75) // 4��
            {
                SelectIcon = 4;

                image1_color.a = 1f;
                image2_color.a = 0.3f;
                image3_color.a = 1f;
                image4_color.a = 0.3f;


                select_1.color = image1_color;
                select_2.color = image2_color;
                select_3.color = image3_color;
                select_4.color = image4_color;
            }
         }
    }
}
