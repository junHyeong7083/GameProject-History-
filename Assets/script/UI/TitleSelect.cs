using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSelect : MonoBehaviour
{
    public RectTransform rectBackground;
    public RectTransform rectJoystick;
    public Image JoystickImage;

    [Header("-------Stage-------")]
    public Image SelectPanel;
    public Image Stage1_image;
    public Image Stage2_image;
    public Image Stage3_image;

    public Image Stage1_clear;
    public Image Stage2_clear;
    public Image Stage3_clear;

    public Image select_1;
    public Image select_2;
    public Image select_3;
    public Image select_4;

    [Header("BestScore")]
    public Text infinityMode;
    public Text totalStage;  // 내가 몇스테이지까지 깼는가?

    private float radius;
    private Vector2 value;
    private bool istouch = false;

    private int SelectIcon;
    [SerializeField]
    bool checkActive;
    public static int clearCheck = 0;
    void Start()
    {
        checkActive = true;
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
    public void stage1_change()
    {
        SceneManager.LoadScene(1);
    }
    public void stage2_change()
    {
        SceneManager.LoadScene(3);
    }
    public void stage3_change()
    {
        SceneManager.LoadScene(4);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if ( touch.phase == TouchPhase.Moved)
            {
                istouch = true;
                checkActive = true;

                value = touch.position - (Vector2)rectBackground.position;
                value = Vector2.ClampMagnitude(value, radius);
                rectJoystick.localPosition = value;
                value = value.normalized;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                istouch = false;

                rectJoystick.localPosition = Vector3.zero;

                if (checkActive)
                {
                    switch (SelectIcon)
                    {
                        case 1: // 스테이지 선택
                            checkActive = false;
                            istouch = false;
                            SelectPanel.gameObject.SetActive(true);
                            break;
                        case 2: // 웨이브모드
                            SceneManager.LoadScene(2);
                            checkActive = false;
                            break;
                        case 3: // 게임종료
#if UNITY_EDITOR
                            // 에디터에서는 플레이 모드를 중지합니다.
                            UnityEditor.EditorApplication.isPlaying = false;
#else
        // 빌드된 게임에서는 어플리케이션을 종료합니다.
        Application.Quit();
#endif
                            checkActive = false;
                            break;
                        case 4: // 튜토리얼
                            SceneManager.LoadScene(5);
                            checkActive = false;
                            break;
                    }
                }
            }
            #region SelectEffect 요소 세팅
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
            if(istouch)
            {
                if (value.x > -0.75 && value.x < 0.75 && value.y < 1 && value.y > 0)  // 1사분면 d
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
                else if (value.x > 0 && value.x < 1 && value.y > -0.75 && value.y < 0.75) //2사
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
                else if (value.x > -0.75 && value.x < 0.75 && value.y > -1 && value.y < 0) // 3사 d
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
                else if (value.x < 0 && value.x > -1 && value.y > -0.75 && value.y < 0.75) // 4사
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
     
        #region 클리어 이미지표시
        switch(clearCheck)
        {
            case 0:
                totalStage.text = "Stage " + clearCheck.ToString();
                break;
            case 1:
                Stage1_image.gameObject.SetActive(false);
                Stage1_clear.gameObject.SetActive(true);
                totalStage.text = "Stage " + clearCheck.ToString();
                break;
            case 2:
                Stage2_image.gameObject.SetActive(false);
                Stage2_clear.gameObject.SetActive(true);
                totalStage.text = "Stage " + clearCheck.ToString();
                break;
            case 3:
                Stage3_image.gameObject.SetActive(false);
                Stage3_clear.gameObject.SetActive(true);
                totalStage.text = "Stage " + clearCheck.ToString();
                break;

        }
        #endregion

        infinityMode.text = Stage_infinity.maxTime.ToString();

    
    }
}
