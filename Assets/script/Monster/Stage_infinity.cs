using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using Spine.Unity;
using Unity.VisualScripting;
using static Stage2_Boss;
using static Stage3_Boss;

public class Stage_infinity : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    private PlayerController playerController;
    public GameObject Player;
    Vector3 PlayerPos;
    Camera cam;
    Vector3 cameraOriginalPos;

    // ----------------- Pattern1_2 -----------------
    #region Pattern2
    bool nextPtn1State = false;
    bool nextPtn2State = false;
    float ptn2_playTime = 0.35f;
    float ptn2_delayTime = 1.45f;
    GameObject pattern2_1;
    GameObject pattern2_2;
    #endregion
    // ----------------- Pattern1_3 -----------------
    #region Pattern3
    GameObject pattern3_1;
    GameObject pattern3_2;
    GameObject pattern3_3;
    #endregion
    // ----------------- Pattern1_4 -----------------
    #region Pattern4
    GameObject pattern4_1;
    GameObject pattern4_2;
    GameObject pattern4_3;
    GameObject pattern4_4;
    GameObject pattern4_5;
    GameObject pattern4_6;
    GameObject pattern4_7;
    GameObject pattern4_8;
    #endregion
    // ----------------- Pattern1_5 -----------------
    #region Pattern5
    GameObject pattern5_1;
    GameObject target_1;
    GameObject pattern5_2;
    GameObject target_2;
    GameObject pattern5_3;
    GameObject target_3;
    GameObject pattern5_4;
    GameObject target_4;
    GameObject pattern5_5;
    GameObject target_5;

    ParticleSystem shoot1;
    ParticleSystem shoot2;
    ParticleSystem shoot3;
    ParticleSystem shoot4;
    ParticleSystem shoot5;
    #endregion
    float bulletSpeed = 400f;
    // ----------------- Pattern1_7 -----------------
    #region Pattern7
    GameObject pattern7_1;
    GameObject pattern7_2;
    GameObject pattern7_3;
    GameObject pattern7_4;
    GameObject pattern7_5;
    GameObject pattern7_6;
    GameObject pattern7_7;
    GameObject pattern7_8;
    GameObject pattern7_9;
    #endregion
    // ----------------- Pattern1_8 -----------------
    #region Pattern8
    GameObject pattern8_1;
    GameObject pattern8_2;
    GameObject pattern8_3;
    GameObject arrow1;
    GameObject arrow2;
    GameObject arrow3;
    #endregion
    // ----------------- Pattern1_8_1 ---------------
    #region Pattern8_1
    GameObject target8_1;
    GameObject arrow8_1;
    GameObject arrow8_2;
    GameObject arrow8_3;
    #endregion
    // ----------------- Pattern1_9 -----------------
    #region Pattern9
    GameObject pattern9_1;
    GameObject pattern9_2;
    #endregion

    // ----------------- Pattern 2_2 -----------------
    GameObject pattern2_2_1;
    GameObject pattern2_2_2;

    GameObject effect2_1;
    GameObject effect2_2;
    // ----------------- overlab_Pattern 2_2 -----------------
    GameObject overlab_pattern2_2_1;
    GameObject overlab_pattern2_2_2;

    GameObject overlab_effect2_1;
    GameObject overlab_effect2_2;



    // ----------------- Pattern 2_4 -----------------
    GameObject pattern2_4_1;
    GameObject pattern2_4_2;

    GameObject effect4_1;
    GameObject effect4_2;

    // ----------------- overlab_Pattern 2_4 -----------------
    GameObject overlab_pattern2_4_1;
    GameObject overlab_pattern2_4_2;

    GameObject overlab_effect4_1;
    GameObject overlab_effect4_2;

    // --------------- Pattern 3_1 ---------------
    GameObject pattern3_1_1;
    GameObject pattern3_1_2;
    GameObject pattern3_1_3;

    GameObject effect3_1_1;
    GameObject effect3_1_2;
    GameObject effect3_1_3;

    GameObject stone3_1;
    GameObject stone3_2;
    GameObject stone3_3;


    // --------------- overlab_Pattern 3_1 ---------------
    GameObject overlab_pattern3_1_1;
    GameObject overlab_pattern3_1_2;
    GameObject overlab_pattern3_1_3;

    GameObject overlab_effect3_1_1;
    GameObject overlab_effect3_1_2;
    GameObject overlab_effect3_1_3;

    GameObject overlab_stone3_1;
    GameObject overlab_stone3_2;
    GameObject overlab_stone3_3;
    // --------------- Pattern 3_2 ---------------
    GameObject pattern3_2_1;
    GameObject pattern3_2_2;
    GameObject pattern3_2_3;
    GameObject pattern3_2_4;
    GameObject pattern3_2_5;
    GameObject pattern3_2_6;
    GameObject pattern3_2_7;
    GameObject pattern3_2_8;
    GameObject pattern3_2_9;

    GameObject effect3_2_1;
    GameObject effect3_2_2;
    GameObject effect3_2_3;
    GameObject effect3_2_4;
    GameObject effect3_2_5;
    GameObject effect3_2_6;
    GameObject effect3_2_7;
    GameObject effect3_2_8;
    GameObject effect3_2_9;
    // --------------- Pattern 3_2 ---------------
    GameObject overlab_pattern3_2_1;
    GameObject overlab_pattern3_2_2;
    GameObject overlab_pattern3_2_3;
    GameObject overlab_pattern3_2_4;
    GameObject overlab_pattern3_2_5;
    GameObject overlab_pattern3_2_6;
    GameObject overlab_pattern3_2_7;
    GameObject overlab_pattern3_2_8;
    GameObject overlab_pattern3_2_9;

    GameObject overlab_effect3_2_1;
    GameObject overlab_effect3_2_2;
    GameObject overlab_effect3_2_3;
    GameObject overlab_effect3_2_4;
    GameObject overlab_effect3_2_5;
    GameObject overlab_effect3_2_6;
    GameObject overlab_effect3_2_7;
    GameObject overlab_effect3_2_8;
    GameObject overlab_effect3_2_9;

    // --------------- Pattern 3 ---------------
    GameObject pattern3_3_1;
    GameObject pattern3_3Aim;

    // --------------- Overlab_Pattern 3 ---------------
    GameObject overlab_pattern3_3_1;
    GameObject overlab_pattern3_3Aim;
    // --------------- Pattern 4 ---------------
    GameObject pattern3_4_1;
    GameObject pattern3_4_2;
    GameObject pattern3_4_3;

    GameObject target3_4_1;
    GameObject target3_4_2;
    GameObject target3_4_3;
    // --------------- Overlab_Pattern 4 ---------------
    GameObject overlab_pattern3_4_1;
    GameObject overlab_pattern3_4_2;
    GameObject overlab_pattern3_4_3;

    GameObject overlab_target3_4_1;
    GameObject overlab_target3_4_2;
    GameObject overlab_target3_4_3;
    // ----------------- Overlab -----------------
    #region Overlab
    // ----------------- PatternOverlab_2 -----------------
    GameObject overlab_pattern2_1;
    GameObject overlab_pattern2_2;
    // ----------------- PatternOverlab_3 -----------------
    GameObject overlab_pattern3_1;
    GameObject overlab_pattern3_2;
    GameObject overlab_pattern3_3;
    // ----------------- PatternOverlab_5 -----------------
    GameObject overlab_pattern5_1;
    GameObject overlab_target1;
    GameObject overlab_pattern5_2;
    GameObject overlab_target2;
    GameObject overlab_pattern5_3;
    GameObject overlab_target3;
    GameObject overlab_pattern5_4;
    GameObject overlab_target4;
    GameObject overlab_pattern5_5;
    GameObject overlab_target5;

    ParticleSystem overlab_shoot1;
    ParticleSystem overlab_shoot2;
    ParticleSystem overlab_shoot3;
    ParticleSystem overlab_shoot4;
    ParticleSystem overlab_shoot5;
    // ----------------- PatternOverlab_7 -----------------
    GameObject overlab_pattern7_1;
    GameObject overlab_pattern7_2;
    GameObject overlab_pattern7_3;
    GameObject overlab_pattern7_4;
    GameObject overlab_pattern7_5;
    GameObject overlab_pattern7_6;
    GameObject overlab_pattern7_7;
    GameObject overlab_pattern7_8;
    GameObject overlab_pattern7_9;
    // ----------------- PatternOverlab_8.1 -----------------
    GameObject overlab_target8_1;
    GameObject overlab_arrow8_1;
    GameObject overlab_arrow8_2;
    GameObject overlab_arrow8_3;
    #endregion
    float ptn9_playTime = 0.3f;
    float ptn9_delayTime = 1.7f;

    // ----------------- bool -----------------
    bool isOverlab = false;
    bool isPattern = false;
    int randomPattern;
    int randomOverlab;

    //----------------- Text -----------------
    public Text currentText;
    public Text maxText;

    public void Scp1_2()
    {
        isPattern = true;

        StartCoroutine(Scp1_2_1());
    } // 투명도처리필요
    #region Scp1_2 패턴로직
    IEnumerator Scp1_2_1()
    {
        // pattern2_1 = Instantiate(Sword.gameObject);
        // pattern2_2 = Instantiate(Sword.gameObject);

        pattern2_1 = PatternManager.Instance.StartPattern("Stage1_Sword");
       // pattern2_2 = PatternManager.Instance.StartPattern("Stage1_Sword");

        #region Pattern2_1 Pos Setting
        pattern2_1.transform.localScale = new Vector3(2, 2, 2);
        pattern2_1.transform.position = new Vector3(-25, 0, 0);
        pattern2_1.transform.rotation = Quaternion.Euler(0, 0, 180);
        #endregion

        #region Pattern2_1
        SpriteRenderer sprite2_1 = pattern2_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color color2_1 = sprite2_1.color;
        color2_1.a = 0;
        sprite2_1.color = color2_1;
        #endregion


        pattern2_1.SetActive(true);
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;
            color2_1.a = alpha;
            sprite2_1.color = color2_1;

            yield return null;
        }
        startTime = Time.time;

        while (Time.time - startTime < ptn2_playTime) // 2.5초간 position.y 값 변경 및 rotation.z 값 변경
        {

            float RotateZ = 90;
            pattern2_1.transform.Rotate(0, 0, -RotateZ * 1.5f * 4 * Time.deltaTime);
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < ptn2_delayTime)
        {
            yield return null;
        }
        nextPtn1State = true;
        if (nextPtn1State)
            StartCoroutine(Scp1_2_2());

    }
    IEnumerator Scp1_2_2()
    {
        #region Pattern2_2 Pos Setting
        pattern2_2 = PatternManager.Instance.StartPattern("Stage1_Sword");
        pattern2_2.transform.localScale = new Vector3(2, 2, 2);
        pattern2_2.transform.position = new Vector3(25, 0, 0);
        pattern2_2.transform.rotation = Quaternion.Euler(0, 0, 360f);
        #endregion
        #region Pattern2_1
        SpriteRenderer sprite2_2 = pattern2_2.GetComponent<SpriteRenderer>();
        UnityEngine.Color color2_2 = sprite2_2.color;
        color2_2.a = 0;
        sprite2_2.color = color2_2;

        SpriteRenderer sprite2_1 = pattern2_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color color2_1 = sprite2_1.color;
        color2_1.a = 0;
        sprite2_1.color = color2_1;
        #endregion
        pattern2_2.SetActive(true);
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;
            color2_1.a = 1 - alpha;
            sprite2_1.color = color2_1;

            color2_2.a = alpha;
            sprite2_2.color = color2_2;

            yield return null;
        }
        Destroy(pattern2_1);
        startTime = Time.time;

        while (Time.time - startTime < ptn2_playTime) // 2.5초간 position.y 값 변경 및 rotation.z 값 변경
        {
            float RotateZ = 90f;
            pattern2_2.transform.Rotate(0, 0, -RotateZ * 1.5f * 4 * Time.deltaTime);

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < ptn2_delayTime)
        {
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;
            color2_2.a = 1 - alpha;
            sprite2_2.color = color2_2;

            yield return null;
        }
        Destroy(pattern2_2);
        nextPtn1State = false;
        isPattern = false;
    }
    #endregion
    void overlab_Scp1_2()
    {
        isOverlab = true;
        StartCoroutine(overlab_Scp1_2_1());
    } // 오버랩용 함수 수정필요함 
    #region Scp 1_2 Overlab
    IEnumerator overlab_Scp1_2_1()
    {
        overlab_pattern2_1 = PatternManager.Instance.StartPattern("Stage1_Sword");
        overlab_pattern2_1.SetActive(true);

        overlab_pattern2_1.transform.localScale = new Vector3(2, 2, 2);
        overlab_pattern2_1.transform.position = new Vector3(-25, 0, 0);
        overlab_pattern2_1.transform.rotation = Quaternion.Euler(0, 0, 180);

        SpriteRenderer sprite2_1 = overlab_pattern2_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color color2_1 = sprite2_1.color;
        color2_1.a = 0;
        sprite2_1.color = color2_1;


        overlab_pattern2_1.SetActive(true);
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;
            color2_1.a = alpha;
            sprite2_1.color = color2_1;

            yield return null;
        }
        startTime = Time.time;

        while (Time.time - startTime < ptn2_playTime) // 2.5초간 position.y 값 변경 및 rotation.z 값 변경
        {

            float RotateZ = 90;
            overlab_pattern2_1.transform.Rotate(0, 0, -RotateZ * 1.5f * 4 * Time.deltaTime);
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < ptn2_delayTime)
        {
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;
            color2_1.a = 1 - alpha;
            sprite2_1.color = color2_1;

            yield return null;
        }
        nextPtn2State = true;
        if (nextPtn2State)
            StartCoroutine(overlab_Scp1_2_2());
    }
    IEnumerator overlab_Scp1_2_2()
    {
        #region overlab_pattern2_2 Pos Setting
        overlab_pattern2_2 = PatternManager.Instance.StartPattern("Stage1_Sword");
        overlab_pattern2_2.transform.localScale = new Vector3(2, 2, 2);
        overlab_pattern2_2.transform.position = new Vector3(25, 0, 0);
        overlab_pattern2_2.transform.rotation = Quaternion.Euler(0, 0, 360f);
        #endregion
        #region overlab_pattern2_2
        SpriteRenderer sprite2_2 = overlab_pattern2_2.GetComponent<SpriteRenderer>();
        UnityEngine.Color color2_2 = sprite2_2.color;
        color2_2.a = 0;
        sprite2_2.color = color2_2;

        SpriteRenderer sprite2_1 = overlab_pattern2_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color color2_1 = sprite2_1.color;
        color2_1.a = 0;
        sprite2_1.color = color2_1;
        #endregion
        overlab_pattern2_2.SetActive(true);
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;
            color2_1.a = 1 - alpha;
            sprite2_1.color = color2_1;

            color2_2.a = alpha;
            sprite2_2.color = color2_2;

            yield return null;
        }
        Destroy(overlab_pattern2_1);

        startTime = Time.time;

        while (Time.time - startTime < ptn2_playTime) // 2.5초간 position.y 값 변경 및 rotation.z 값 변경
        {
            float RotateZ = 90f;
            overlab_pattern2_2.transform.Rotate(0, 0, -RotateZ * 1.5f * 4 * Time.deltaTime);

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < ptn2_delayTime)
        {
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;
            color2_2.a = 1 - alpha;
            sprite2_2.color = color2_2;

            yield return null;
        }

        Destroy(overlab_pattern2_2);
        nextPtn2State = false;
        isOverlab = false;
    }
    #endregion
    public void Scp1_3()
    {
        isPattern = true;
        StartCoroutine(Scp1_3_1());
    } // 투명도 처리 필요
    #region Scp 1_3 패턴로직
    IEnumerator Scp1_3_1()
    {
        #region 복제
        pattern3_1 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern3_2 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern3_3 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        #endregion

        #region SpriteRenderer
        SpriteRenderer sprite3_1 = pattern3_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite3_2 = pattern3_2.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite3_3 = pattern3_3.GetComponent<SpriteRenderer>();

        UnityEngine.Color color3_1 = sprite3_1.color;
        UnityEngine.Color color3_2 = sprite3_2.color;
        UnityEngine.Color color3_3 = sprite3_3.color;

        color3_1.a = 0;
        color3_2.a = 0;
        color3_3.a = 0;

        sprite3_1.color = color3_1;
        sprite3_2.color = color3_2;
        sprite3_3.color = color3_3;
        #endregion
        #region Pattern3 Setting Pos
        float posX = 8f;
        float posY = 10f;

        pattern3_1.transform.position = new Vector3(PlayerPos.x - posX, PlayerPos.y - posY, 0);
        pattern3_1.transform.eulerAngles = new Vector3(0, 0, 220);

        pattern3_2.transform.position = new Vector3(PlayerPos.x, PlayerPos.y - posY - 3f, 0);
        pattern3_2.transform.eulerAngles = new Vector3(0, 0, 270);

        pattern3_3.transform.position = new Vector3(PlayerPos.x + posX, PlayerPos.y - posY, 0);
        pattern3_3.transform.eulerAngles = new Vector3(0, 0, 320);
        #endregion
        pattern3_1.SetActive(true);
        pattern3_2.SetActive(true);
        pattern3_3.SetActive(true);

        Vector3 dir1 = (PlayerPos - pattern3_1.transform.position).normalized;
        Vector3 dir2 = (PlayerPos - pattern3_2.transform.position).normalized;
        Vector3 dir3 = (PlayerPos - pattern3_3.transform.position).normalized;

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 0.5f)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            color3_1.a = alpha;
            color3_2.a = alpha;
            color3_3.a = alpha;

            sprite3_1.color = color3_1;
            sprite3_2.color = color3_2;
            sprite3_3.color = color3_3;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 2) // 1초간 rotation.z 값 변경
        {
            float backPos = 1.2f;
            pattern3_1.transform.position += new Vector3(-backPos * Time.deltaTime, -backPos * Time.deltaTime, 0);
            pattern3_2.transform.position += new Vector3(0, -backPos * Time.deltaTime, 0);
            pattern3_3.transform.position += new Vector3(backPos * Time.deltaTime, -backPos * Time.deltaTime, 0);

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 2) // 1초간 rotation.z 값 변경
        {
            float speed = 150f;
            pattern3_1.transform.position += new Vector3(speed * dir1.x * Time.deltaTime, speed * dir1.y * Time.deltaTime, 0);
            pattern3_2.transform.position += new Vector3(speed * dir2.x * Time.deltaTime, speed * dir2.y * Time.deltaTime, 0);
            pattern3_3.transform.position += new Vector3(speed * dir3.x * Time.deltaTime, speed * dir3.y * Time.deltaTime, 0);

            yield return null;
        }

        // 알파값 지울필요없음

        Destroy(pattern3_1);
        Destroy(pattern3_2);
        Destroy(pattern3_3);

        isPattern = false;
    }
    #endregion
    void overlab_Scp1_3()
    {
        isOverlab = true;

        StartCoroutine(overlab_Scp1_3_1());
    }
    #region overlab_Scp 1_3 패턴로직
    IEnumerator overlab_Scp1_3_1()
    {
        overlab_pattern3_1 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern3_2 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern3_3 = PatternManager.Instance.StartPattern("Stage1_Kunai");

        #region Pattern3 Setting Pos
        float posX = 8f;
        float posY = 10f;

        overlab_pattern3_1.transform.position = new Vector3(PlayerPos.x - posX, PlayerPos.y - posY, 0);
        overlab_pattern3_1.transform.eulerAngles = new Vector3(0, 0, 220);

        overlab_pattern3_2.transform.position = new Vector3(PlayerPos.x, PlayerPos.y - posY - 3f, 0);
        overlab_pattern3_2.transform.eulerAngles = new Vector3(0, 0, 270);

        overlab_pattern3_3.transform.position = new Vector3(PlayerPos.x + posX, PlayerPos.y - posY, 0);
        overlab_pattern3_3.transform.eulerAngles = new Vector3(0, 0, 320);

        overlab_pattern3_1.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        overlab_pattern3_2.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        overlab_pattern3_3.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        #endregion

        overlab_pattern3_1.SetActive(true);
        overlab_pattern3_2.SetActive(true);
        overlab_pattern3_3.SetActive(true);
        #region SpriteRenderer
        SpriteRenderer sprite3_1 = overlab_pattern3_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite3_2 = overlab_pattern3_2.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite3_3 = overlab_pattern3_3.GetComponent<SpriteRenderer>();

        UnityEngine.Color color3_1 = sprite3_1.color;
        UnityEngine.Color color3_2 = sprite3_2.color;
        UnityEngine.Color color3_3 = sprite3_3.color;

        color3_1.a = 0;
        color3_2.a = 0;
        color3_3.a = 0;

        sprite3_1.color = color3_1;
        sprite3_2.color = color3_2;
        sprite3_3.color = color3_3;
        #endregion
        Vector3 dir1 = (PlayerPos - overlab_pattern3_1.transform.position).normalized;
        Vector3 dir2 = (PlayerPos - overlab_pattern3_2.transform.position).normalized;
        Vector3 dir3 = (PlayerPos - overlab_pattern3_3.transform.position).normalized;

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 0.5f)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            color3_1.a = alpha;
            color3_2.a = alpha;
            color3_3.a = alpha;

            sprite3_1.color = color3_1;
            sprite3_2.color = color3_2;
            sprite3_3.color = color3_3;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 2) // 1초간 rotation.z 값 변경
        {
            float backPos = 1.2f;

            overlab_pattern3_1.transform.position += new Vector3(-backPos * Time.deltaTime, -backPos * Time.deltaTime, 0);
            overlab_pattern3_2.transform.position += new Vector3(0, -backPos * Time.deltaTime, 0);
            overlab_pattern3_3.transform.position += new Vector3(backPos * Time.deltaTime, -backPos * Time.deltaTime, 0);


            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 2) // 1초간 rotation.z 값 변경
        {
            float speed = 150f;
            overlab_pattern3_1.transform.position += new Vector3(speed * dir1.x * Time.deltaTime, speed * dir1.y * Time.deltaTime, 0);
            overlab_pattern3_2.transform.position += new Vector3(speed * dir2.x * Time.deltaTime, speed * dir2.y * Time.deltaTime, 0);
            overlab_pattern3_3.transform.position += new Vector3(speed * dir3.x * Time.deltaTime, speed * dir3.y * Time.deltaTime, 0);

            yield return null;
        }

        Destroy(overlab_pattern3_1);
        Destroy(overlab_pattern3_2);
        Destroy(overlab_pattern3_3);
        isOverlab = false;
    }
    #endregion 
    public void Scp1_4()
    {
        isPattern = true;
        StartCoroutine(Scp1_4_Total());
    } // 투명도 처리 필요
    #region Scp 1_4 패턴로직
    IEnumerator Scp1_4_Total()
    {
        int cnt = 8;
        while (cnt > 0)
        {
            if (cnt == 8)
            {
                pattern4_1 = PatternManager.Instance.StartPattern("Stage1_Sword");
                pattern4_1.transform.position = new Vector3(-70f, 48f, 0);
                pattern4_1.transform.eulerAngles = new Vector3(0, 0, 90);
                StartCoroutine(Scp1_4_1());
            } // 왼
            if (cnt == 7)
            {
                pattern4_2 = PatternManager.Instance.StartPattern("Stage1_Sword");
                pattern4_2.transform.position = new Vector3(70f, 35, 0);
                pattern4_2.transform.eulerAngles = new Vector3(180, 0, 270);
                StartCoroutine(Scp1_4_2());
            } // 오
            if (cnt == 6)
            {
                pattern4_3 = PatternManager.Instance.StartPattern("Stage1_Sword");
                pattern4_3.transform.position = new Vector3(-70f, 22, 0);
                pattern4_3.transform.eulerAngles = new Vector3(0, 0, 90);
                StartCoroutine(Scp1_4_3());

            } // 왼
            if (cnt == 5)
            {
                pattern4_4 = PatternManager.Instance.StartPattern("Stage1_Sword");
                pattern4_4.transform.position = new Vector3(70f, 9, 0);
                pattern4_4.transform.eulerAngles = new Vector3(180, 0, 270);
                StartCoroutine(Scp1_4_4());
            } // 오
            if (cnt == 4)
            {
                pattern4_5 = PatternManager.Instance.StartPattern("Stage1_Sword");
                pattern4_5.transform.position = new Vector3(-70f, -4, 0);
                pattern4_5.transform.eulerAngles = new Vector3(0, 0, 90);
                StartCoroutine(Scp1_4_5());
            } // 왼
            if (cnt == 3)
            {
                pattern4_6 = PatternManager.Instance.StartPattern("Stage1_Sword");
                pattern4_6.transform.position = new Vector3(70f, -17, 0);
                pattern4_6.transform.eulerAngles = new Vector3(180, 0, 270);
                StartCoroutine(Scp1_4_6());
            } // 오
            if (cnt == 2)
            {
                pattern4_7 = PatternManager.Instance.StartPattern("Stage1_Sword");
                pattern4_7.transform.position = new Vector3(-70f, -30, 0);
                pattern4_7.transform.eulerAngles = new Vector3(0, 0, 90);
                StartCoroutine(Scp1_4_7());
            } // 왼
            if (cnt == 1)
            {
                pattern4_8 = PatternManager.Instance.StartPattern("Stage1_Sword");
                pattern4_8.transform.position = new Vector3(70f, -43, 0);
                pattern4_8.transform.eulerAngles = new Vector3(180, 0, 270);
                StartCoroutine(Scp1_4_8());
            } // 오

            yield return new WaitForSeconds(0.5f);
            cnt--;
        }
    } // 패턴 묶음

    IEnumerator Scp1_4_1()
    {
        pattern4_1.SetActive(true);

        SpriteRenderer sprite4_1 = pattern4_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color color4_1 = sprite4_1.color;
        color4_1.a = 0;
        sprite4_1.color = color4_1;

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 0.5f)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            color4_1.a = alpha;
            sprite4_1.color = color4_1;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 4)
        {
            float speed = 2f;
            pattern4_1.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

            yield return null;
        }

        startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (pattern4_1.transform.position.x < -40)
            {
                float speed = 200f;
                pattern4_1.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float alpha = (Time.time - startTime) / 0.3f;
            color4_1.a = 1 - alpha;
            sprite4_1.color = color4_1;

            yield return null;
        }
        Destroy(pattern4_1);
        StopCoroutine(Scp1_4_1());
    }
    IEnumerator Scp1_4_2()
    {
        pattern4_2.SetActive(true);

        SpriteRenderer sprite4_2 = pattern4_2.GetComponent<SpriteRenderer>();
        UnityEngine.Color color4_2 = sprite4_2.color;
        color4_2.a = 0;
        sprite4_2.color = color4_2;

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 0.5f)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            color4_2.a = alpha;
            sprite4_2.color = color4_2;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 4)
        {
            float speed = 2f;
            pattern4_2.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

            yield return null;
        }
        startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (pattern4_2.transform.position.x > 40)
            {
                float speed = 200f;
                pattern4_2.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }

            yield return null;
        }
        startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 0.3f)
        {
            float alpha = (Time.time - startTime) / 0.3f;
            color4_2.a = 1 - alpha;
            sprite4_2.color = color4_2;

            yield return null;
        }
        Destroy(pattern4_2);
        StopCoroutine(Scp1_4_2());

    }
    IEnumerator Scp1_4_3()
    {
        pattern4_3.SetActive(true);

        SpriteRenderer sprite4_3 = pattern4_3.GetComponent<SpriteRenderer>();
        UnityEngine.Color color4_3 = sprite4_3.color;
        color4_3.a = 0;
        sprite4_3.color = color4_3;

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 0.5f)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            color4_3.a = alpha;
            sprite4_3.color = color4_3;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 4)
        {
            float speed = 2f;
            pattern4_3.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

            yield return null;
        }

        startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (pattern4_3.transform.position.x < -40)
            {
                float speed = 200f;
                pattern4_3.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float alpha = (Time.time - startTime) / 0.3f;
            color4_3.a = 1 - alpha;
            sprite4_3.color = color4_3;

            yield return null;
        }
        Destroy(pattern4_3);
        StopCoroutine(Scp1_4_3());
    }
    IEnumerator Scp1_4_4()
    {
        pattern4_4.SetActive(true);
        SpriteRenderer sprite4_4 = pattern4_4.GetComponent<SpriteRenderer>();
        UnityEngine.Color color4_4 = sprite4_4.color;
        color4_4.a = 0;
        sprite4_4.color = color4_4;

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 0.5f)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            color4_4.a = alpha;
            sprite4_4.color = color4_4;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 4)
        {
            float speed = 2f;
            pattern4_4.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

            yield return null;
        }
        startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (pattern4_4.transform.position.x > 40)
            {
                float speed = 200f;
                pattern4_4.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float alpha = (Time.time - startTime) / 0.3f;
            color4_4.a = 1 - alpha;
            sprite4_4.color = color4_4;

            yield return null;
        }
        Destroy(pattern4_4);
        StopCoroutine(Scp1_4_4());
    }
    IEnumerator Scp1_4_5()
    {
        pattern4_5.SetActive(true);
        SpriteRenderer sprite4_5 = pattern4_5.GetComponent<SpriteRenderer>();
        UnityEngine.Color color4_5 = sprite4_5.color;
        color4_5.a = 0;
        sprite4_5.color = color4_5;

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 0.5f)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            color4_5.a = alpha;
            sprite4_5.color = color4_5;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 4)
        {
            float speed = 2f;
            pattern4_5.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

            yield return null;
        }

        startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (pattern4_5.transform.position.x < -40)
            {
                float speed = 200f;
                pattern4_5.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float alpha = (Time.time - startTime) / 0.3f;
            color4_5.a = 1 - alpha;
            sprite4_5.color = color4_5;

            yield return null;
        }
        Destroy(pattern4_5);
        StopCoroutine(Scp1_4_5());
    }
    IEnumerator Scp1_4_6()
    {
        pattern4_6.SetActive(true);
        SpriteRenderer sprite4_6 = pattern4_6.GetComponent<SpriteRenderer>();
        UnityEngine.Color color4_6 = sprite4_6.color;
        color4_6.a = 0;
        sprite4_6.color = color4_6;

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 0.5f)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            color4_6.a = alpha;
            sprite4_6.color = color4_6;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 4)
        {
            float speed = 2f;
            pattern4_6.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

            yield return null;
        }
        startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (pattern4_6.transform.position.x > 40)
            {
                float speed = 200f;
                pattern4_6.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float alpha = (Time.time - startTime) / 0.3f;
            color4_6.a = 1 - alpha;
            sprite4_6.color = color4_6;

            yield return null;
        }
        Destroy(pattern4_6);
        StopCoroutine(Scp1_4_6());

    }
    IEnumerator Scp1_4_7()
    {
        pattern4_7.SetActive(true);
        SpriteRenderer sprite4_7 = pattern4_7.GetComponent<SpriteRenderer>();
        UnityEngine.Color color4_7 = sprite4_7.color;
        color4_7.a = 0;
        sprite4_7.color = color4_7;

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 0.5f)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            color4_7.a = alpha;
            sprite4_7.color = color4_7;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 4)
        {
            float speed = 2f;
            pattern4_7.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

            yield return null;
        }

        startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (pattern4_7.transform.position.x < -40)
            {
                float speed = 200f;
                pattern4_7.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float alpha = (Time.time - startTime) / 0.3f;
            color4_7.a = 1 - alpha;
            sprite4_7.color = color4_7;

            yield return null;
        }

        Destroy(pattern4_7);
        StopCoroutine(Scp1_4_7());
    }
    IEnumerator Scp1_4_8()
    {
        pattern4_8.SetActive(true);
        SpriteRenderer sprite4_8 = pattern4_8.GetComponent<SpriteRenderer>();
        UnityEngine.Color color4_8 = sprite4_8.color;
        color4_8.a = 0;
        sprite4_8.color = color4_8;

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 0.5f)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            color4_8.a = alpha;
            sprite4_8.color = color4_8;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 4)
        {
            float speed = 2f;
            pattern4_8.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

            yield return null;
        }
        startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (pattern4_8.transform.position.x > 40)
            {
                float speed = 200f;
                pattern4_8.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float alpha = (Time.time - startTime) / 0.3f;
            color4_8.a = 1 - alpha;
            sprite4_8.color = color4_8;

            yield return null;
        }
        Destroy(pattern4_8);
        isPattern = false;
    }
    #endregion
    public void Scp1_5()
    {
        isPattern = true;
        StartCoroutine(Scp1_5_total());
    } // 투명도 처리 필요
    #region Scp 1_5 패턴로직
    IEnumerator Scp1_5_total()
    {
        int cnt = 5;
        while (cnt > 0)
        {
            if (cnt == 5)
            {
                pattern5_1 = PatternManager.Instance.StartPattern("Stage1_Gun");
                pattern5_1.transform.position = new Vector3(-37f, 44f, 0);
                pattern5_1.transform.eulerAngles = new Vector3(0, 0, 0);

                target_1 = PatternManager.Instance.StartPattern("Stage1_GunAim");
                StartCoroutine(Scp1_5_1());
            }
            if (cnt == 4)
            {
                pattern5_2 = PatternManager.Instance.StartPattern("Stage1_Gun");
                pattern5_2.transform.position = new Vector3(37f, 24f, 0);
                pattern5_2.transform.eulerAngles = new Vector3(0, 0, 0);
                target_2 = PatternManager.Instance.StartPattern("Stage1_GunAim");
                StartCoroutine(Scp1_5_2());
            }
            if (cnt == 3)
            {
                pattern5_3 = PatternManager.Instance.StartPattern("Stage1_Gun");
                pattern5_3.transform.position = new Vector3(-37f, 4f, 0);
                pattern5_3.transform.eulerAngles = new Vector3(0, 0 - 0);
                target_3 = PatternManager.Instance.StartPattern("Stage1_GunAim");
                StartCoroutine(Scp1_5_3());
            }
            if (cnt == 2)
            {
                pattern5_4 = PatternManager.Instance.StartPattern("Stage1_Gun");
                pattern5_4.transform.position = new Vector3(37f, -24f, 0);
                pattern5_4.transform.eulerAngles = new Vector3(0, 0, 0);
                target_4 = PatternManager.Instance.StartPattern("Stage1_GunAim");
                StartCoroutine(Scp1_5_4());
            }
            if (cnt == 1)
            {
                pattern5_5 = PatternManager.Instance.StartPattern("Stage1_Gun");
                pattern5_5.transform.position = new Vector3(-37f, -44f, 0);
                pattern5_5.transform.eulerAngles = new Vector3(0, 0 - 40f);
                target_5 = PatternManager.Instance.StartPattern("Stage1_GunAim");
                StartCoroutine(Scp1_5_5());
            }
            yield return new WaitForSeconds(0.5f);
            cnt--;
        }
    }
    IEnumerator Scp1_5_1()
    {
        pattern5_1.SetActive(true);
        target_1.SetActive(true);

        SpriteRenderer ptn_sprite_1 = pattern5_1.GetComponent<SpriteRenderer>();
        SpriteRenderer tgt_sprite_1 = target_1.GetComponent<SpriteRenderer>();

        UnityEngine.Color ptn_color = ptn_sprite_1.color;
        UnityEngine.Color tgt_color = tgt_sprite_1.color;

        ptn_color.a = 0f;
        tgt_color.a = 0f;

        ptn_sprite_1.color = ptn_color;
        tgt_sprite_1.color = tgt_color;



        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (Time.time - startTime < 1)
            {
                float alpha = (Time.time - startTime) / 1;
                ptn_color.a = alpha;
                tgt_color.a = alpha;

                ptn_sprite_1.color = ptn_color;
                tgt_sprite_1.color = tgt_color;
            }

            Vector3 direction = PlayerPos - pattern5_1.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            pattern5_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            target_1.transform.position = PlayerPos;
            target_1.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);
            yield return null;
        }

        Transform bulletPosTransform = pattern5_1.transform.Find("BulletPos");
        GameObject bullet = PatternManager.Instance.StartPattern("Stage1_Bullet");
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = pattern5_1.transform.rotation;
        Vector3 dir = PlayerPos - pattern5_1.transform.position;

        shoot1 = ParticleManager.Instance.StartParticle("VFX_shooting");
        shoot1.transform.position = bulletPosTransform.transform.position;
        shoot1.transform.localScale = new Vector3(15, 15, 15);
        shoot1.transform.rotation = pattern5_1.transform.rotation;
        var main = shoot1.main;
        main.startRotationZ = 0f;
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            yield return null;
        }


        StartCoroutine(CameraShaking(0.1f, 0.5f));
        startTime = Time.time;
        while (Time.time - startTime < 2)
        {
            if (Time.time - startTime > 1.0)
            {
                if (shoot1 != null) Destroy(shoot1.gameObject);
            }
            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.5)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            ptn_color.a = 1 - alpha;

            ptn_sprite_1.color = ptn_color;
            yield return null;
        }

        Destroy(pattern5_1);
        Destroy(bullet);
        StopCoroutine(Scp1_5_1());
    }
    IEnumerator Scp1_5_2()
    {
        pattern5_2.SetActive(true);
        target_2.SetActive(true);

        SpriteRenderer ptn_sprite_2 = pattern5_2.GetComponent<SpriteRenderer>();
        SpriteRenderer tgt_sprite_2 = target_2.GetComponent<SpriteRenderer>();

        UnityEngine.Color ptn_color = ptn_sprite_2.color;
        UnityEngine.Color tgt_color = tgt_sprite_2.color;

        ptn_color.a = 0f;
        tgt_color.a = 0f;

        ptn_sprite_2.color = ptn_color;
        tgt_sprite_2.color = tgt_color;


        SpriteRenderer before_Sprite = target_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color before_Color = before_Sprite.color;
        before_Color.a = 0;
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (Time.time - startTime < 1)
            {
                float alpha = (Time.time - startTime) / 1;
                ptn_color.a = alpha;
                tgt_color.a = alpha;

                ptn_sprite_2.color = ptn_color;
                tgt_sprite_2.color = tgt_color;
            }
            Vector3 direction = PlayerPos - pattern5_2.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            pattern5_2.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            before_Sprite.color = before_Color;
            target_2.transform.position = PlayerPos;
            target_2.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);

            yield return null;
        }

        Transform bulletPosTransform = pattern5_2.transform.Find("BulletPos");
        GameObject bullet = PatternManager.Instance.StartPattern("Stage1_Bullet");
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = pattern5_2.transform.rotation;
        Vector3 dir = PlayerPos - pattern5_2.transform.position;

        shoot2 = ParticleManager.Instance.StartParticle("VFX_shooting");
        shoot2.transform.position = bulletPosTransform.transform.position;
        shoot2.transform.localScale = new Vector3(15, 15, 15);
        shoot2.transform.rotation = pattern5_2.transform.rotation;
        var main = shoot2.main;
        main.startRotationZ = 0f;
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            yield return null;
        }


        StartCoroutine(CameraShaking(0.1f, 0.5f));
        startTime = Time.time;
        while (Time.time - startTime < 2)
        {
            if (Time.time - startTime > 1.0)
            {
                if (shoot2 != null) Destroy(shoot2.gameObject);
            }
            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.5)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            ptn_color.a = 1 - alpha;

            ptn_sprite_2.color = ptn_color;

            yield return null;
        }
        Destroy(pattern5_2);
        Destroy(bullet);
        StopCoroutine(Scp1_5_2());
    }
    IEnumerator Scp1_5_3()
    {
        pattern5_3.SetActive(true);
        target_3.SetActive(true);

        SpriteRenderer ptn_sprite_3 = pattern5_3.GetComponent<SpriteRenderer>();
        SpriteRenderer tgt_sprite_3 = target_3.GetComponent<SpriteRenderer>();

        UnityEngine.Color ptn_color = ptn_sprite_3.color;
        UnityEngine.Color tgt_color = tgt_sprite_3.color;

        ptn_color.a = 0f;
        tgt_color.a = 0f;

        ptn_sprite_3.color = ptn_color;
        tgt_sprite_3.color = tgt_color;

        SpriteRenderer before_Sprite = target_2.GetComponent<SpriteRenderer>();
        UnityEngine.Color before_Color = before_Sprite.color;
        before_Color.a = 0;

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (Time.time - startTime < 1)
            {
                float alpha = (Time.time - startTime) / 1;
                ptn_color.a = alpha;
                tgt_color.a = alpha;

                ptn_sprite_3.color = ptn_color;
                tgt_sprite_3.color = tgt_color;
            }
            Vector3 direction = PlayerPos - pattern5_3.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            pattern5_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            before_Sprite.color = before_Color;
            target_3.transform.position = PlayerPos;
            target_3.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);
            yield return null;
        }

        Transform bulletPosTransform = pattern5_3.transform.Find("BulletPos");
        GameObject bullet = PatternManager.Instance.StartPattern("Stage1_Bullet");
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = pattern5_3.transform.rotation;
        Vector3 dir = PlayerPos - pattern5_3.transform.position;

        shoot3 = ParticleManager.Instance.StartParticle("VFX_shooting");
        shoot3.transform.position = bulletPosTransform.transform.position;
        shoot3.transform.localScale = new Vector3(15, 15, 15);
        shoot3.transform.rotation = pattern5_3.transform.rotation;
        var main = shoot3.main;
        main.startRotationZ = 0f;

        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            yield return null;
        }

        StartCoroutine(CameraShaking(0.1f, 0.5f));
        startTime = Time.time;
        while (Time.time - startTime < 2)
        {
            if (Time.time - startTime > 1.0)
            {
                if (shoot3 != null) Destroy(shoot3.gameObject);
            }
            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.5)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            ptn_color.a = 1 - alpha;

            ptn_sprite_3.color = ptn_color;

            yield return null;
        }
        Destroy(pattern5_3);
        Destroy(bullet);
        StopCoroutine(Scp1_5_3());
    }
    IEnumerator Scp1_5_4()
    {
        pattern5_4.SetActive(true);
        target_4.SetActive(true);

        SpriteRenderer ptn_sprite_4 = pattern5_4.GetComponent<SpriteRenderer>();
        SpriteRenderer tgt_sprite_4 = target_4.GetComponent<SpriteRenderer>();

        UnityEngine.Color ptn_color = ptn_sprite_4.color;
        UnityEngine.Color tgt_color = tgt_sprite_4.color;

        ptn_color.a = 0f;
        tgt_color.a = 0f;

        ptn_sprite_4.color = ptn_color;
        tgt_sprite_4.color = tgt_color;


        SpriteRenderer before_Sprite = target_3.GetComponent<SpriteRenderer>();
        UnityEngine.Color before_Color = before_Sprite.color;
        before_Color.a = 0;

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (Time.time - startTime < 1)
            {
                float alpha = (Time.time - startTime) / 1;
                ptn_color.a = alpha;
                tgt_color.a = alpha;

                ptn_sprite_4.color = ptn_color;
                tgt_sprite_4.color = tgt_color;
            }
            Vector3 direction = PlayerPos - pattern5_4.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            pattern5_4.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            before_Sprite.color = before_Color;
            target_4.transform.position = PlayerPos;
            target_4.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);

            yield return null;
        }
        Transform bulletPosTransform = pattern5_4.transform.Find("BulletPos");
        GameObject bullet = PatternManager.Instance.StartPattern("Stage1_Bullet");
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = pattern5_4.transform.rotation;
        Vector3 dir = PlayerPos - pattern5_4.transform.position;

        shoot4 = ParticleManager.Instance.StartParticle("VFX_shooting");
        shoot4.transform.position = bulletPosTransform.transform.position;
        shoot4.transform.localScale = new Vector3(15, 15, 15);
        shoot4.transform.rotation = pattern5_4.transform.rotation;
        var main = shoot4.main;
        main.startRotationZ = 0f;
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            yield return null;
        }


        StartCoroutine(CameraShaking(0.1f, 0.5f));
        startTime = Time.time;
        while (Time.time - startTime < 2)
        {
            if (Time.time - startTime > 1.0)
            {
                if (shoot4 != null) Destroy(shoot4.gameObject);
            }
            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.5)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            ptn_color.a = 1 - alpha;

            ptn_sprite_4.color = ptn_color;

            yield return null;
        }
        Destroy(pattern5_4);
        Destroy(bullet);
        StopCoroutine(Scp1_5_4());
    }
    IEnumerator Scp1_5_5()
    {
        pattern5_5.SetActive(true);
        target_5.SetActive(true);

        SpriteRenderer ptn_sprite_5 = pattern5_5.GetComponent<SpriteRenderer>();
        SpriteRenderer tgt_sprite_5 = target_5.GetComponent<SpriteRenderer>();

        UnityEngine.Color ptn_color = ptn_sprite_5.color;
        UnityEngine.Color tgt_color = tgt_sprite_5.color;

        ptn_color.a = 0f;
        tgt_color.a = 0f;

        ptn_sprite_5.color = ptn_color;
        tgt_sprite_5.color = tgt_color;

        SpriteRenderer before_Sprite = target_4.GetComponent<SpriteRenderer>();
        UnityEngine.Color before_Color = before_Sprite.color;
        before_Color.a = 0;


        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (Time.time - startTime < 1)
            {
                float alpha = (Time.time - startTime) / 1f;
                ptn_color.a = alpha;
                tgt_color.a = alpha;

                ptn_sprite_5.color = ptn_color;
                tgt_sprite_5.color = tgt_color;
            }
            Vector3 direction = PlayerPos - pattern5_5.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            pattern5_5.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            before_Sprite.color = before_Color;
            if (Time.time - startTime < 0.7) // 조준점이 커지는 시간
            {
                target_5.transform.position = PlayerPos;
                target_5.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);

            }
            yield return null;
        }
        Transform bulletPosTransform = pattern5_5.transform.Find("BulletPos");
        GameObject bullet = PatternManager.Instance.StartPattern("Stage1_Bullet");
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = pattern5_5.transform.rotation;
        Vector3 dir = PlayerPos - pattern5_5.transform.position;

        shoot5 = ParticleManager.Instance.StartParticle("VFX_shooting");
        shoot5.transform.position = bulletPosTransform.transform.position;
        shoot5.transform.localScale = new Vector3(15, 15, 15);
        shoot5.transform.rotation = pattern5_5.transform.rotation;
        var main = shoot5.main;
        main.startRotationZ = 0f;
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            yield return null;
        }


        StartCoroutine(CameraShaking(0.1f, 0.5f));
        startTime = Time.time;
        while (Time.time - startTime < 2)
        {
            if (Time.time - startTime > 1.0)
            {
                if (shoot5 != null) Destroy(shoot5.gameObject);
            }
            if (Time.time - startTime < 0.5f)
            {
                Destroy(target_1);
                Destroy(target_2);
                Destroy(target_3);
                Destroy(target_4);
            } // 조준점 삭제

            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.5)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            ptn_color.a = 1 - alpha;
            tgt_color.a = 1 - alpha;

            ptn_sprite_5.color = ptn_color;
            tgt_sprite_5.color = tgt_color;

            yield return null;
        }
        Destroy(target_5);
        Destroy(pattern5_5);
        Destroy(bullet);
        isPattern = false;
    }
    #endregion
    public void overlab_Scp1_5()
    {
        isOverlab = true;
        StartCoroutine(overlab_Scp1_5_total());
    }
    #region overlab_Scp 1_5 패턴로직
    IEnumerator overlab_Scp1_5_total()
    {
        int cnt = 5;
        while (cnt > 0)
        {
            if (cnt == 5)
            {
                overlab_pattern5_1 = PatternManager.Instance.StartPattern("Stage1_Gun");
                overlab_pattern5_1.transform.position = new Vector3(-37f, 44f, 0);
                overlab_pattern5_1.transform.eulerAngles = new Vector3(0, 0, 0);

                overlab_target1 = PatternManager.Instance.StartPattern("Stage1_GunAim");
                StartCoroutine(overlab_Scp1_5_1());
            }
            if (cnt == 4)
            {
                overlab_pattern5_2 = PatternManager.Instance.StartPattern("Stage1_Gun");
                overlab_pattern5_2.transform.position = new Vector3(37f, 24f, 0);
                overlab_pattern5_2.transform.eulerAngles = new Vector3(0, 0, 0);
                overlab_target2 = PatternManager.Instance.StartPattern("Stage1_GunAim");
                StartCoroutine(overlab_Scp1_5_2());
            }
            if (cnt == 3)
            {
                overlab_pattern5_3 = PatternManager.Instance.StartPattern("Stage1_Gun");
                overlab_pattern5_3.transform.position = new Vector3(-37f, 4f, 0);
                overlab_pattern5_3.transform.eulerAngles = new Vector3(0, 0 - 0);
                overlab_target3 = PatternManager.Instance.StartPattern("Stage1_GunAim");
                StartCoroutine(overlab_Scp1_5_3());
            }
            if (cnt == 2)
            {
                overlab_pattern5_4 = PatternManager.Instance.StartPattern("Stage1_Gun");
                overlab_pattern5_4.transform.position = new Vector3(37f, -24f, 0);
                overlab_pattern5_4.transform.eulerAngles = new Vector3(0, 0, 0);
                overlab_target4 = PatternManager.Instance.StartPattern("Stage1_GunAim");
                StartCoroutine(overlab_Scp1_5_4());
            }
            if (cnt == 1)
            {
                overlab_pattern5_5 = PatternManager.Instance.StartPattern("Stage1_Gun");
                overlab_pattern5_5.transform.position = new Vector3(-37f, -44f, 0);
                overlab_pattern5_5.transform.eulerAngles = new Vector3(0, 0 - 40f);
                overlab_target5 = PatternManager.Instance.StartPattern("Stage1_GunAim");
                StartCoroutine(overlab_Scp1_5_5());
            }
            yield return new WaitForSeconds(0.5f);
            cnt--;
        }
    }
    IEnumerator overlab_Scp1_5_1()
    {
        overlab_pattern5_1.SetActive(true);
        overlab_target1.SetActive(true);
        SpriteRenderer ptn_sprite_1 = overlab_pattern5_1.GetComponent<SpriteRenderer>();
        SpriteRenderer tgt_sprite_1 = overlab_target1.GetComponent<SpriteRenderer>();

        UnityEngine.Color ptn_color = ptn_sprite_1.color;
        UnityEngine.Color tgt_color = tgt_sprite_1.color;

        ptn_color.a = 0f;
        tgt_color.a = 0f;

        ptn_sprite_1.color = ptn_color;
        tgt_sprite_1.color = tgt_color;


        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (Time.time - startTime < 1)
            {
                float alpha = (Time.time - startTime) / 1;
                ptn_color.a = alpha;
                tgt_color.a = alpha;

                ptn_sprite_1.color = ptn_color;
                tgt_sprite_1.color = tgt_color;
            }
            Vector3 direction = PlayerPos - overlab_pattern5_1.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            overlab_pattern5_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            overlab_target1.transform.position = PlayerPos;
            overlab_target1.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);
            yield return null;
        }
        Transform bulletPosTransform = overlab_pattern5_1.transform.Find("BulletPos");
        GameObject bullet = PatternManager.Instance.StartPattern("Stage1_Bullet");
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = overlab_pattern5_1.transform.rotation;
        Vector3 dir = PlayerPos - overlab_pattern5_1.transform.position;

        overlab_shoot1 = ParticleManager.Instance.StartParticle("VFX_shooting");
        overlab_shoot1.transform.position = bulletPosTransform.transform.position;
        overlab_shoot1.transform.localScale = new Vector3(15, 15, 15);
        overlab_shoot1.transform.rotation = overlab_pattern5_1.transform.rotation;
        var main = overlab_shoot1.main;
        main.startRotationZ = 0f;
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            yield return null;
        }
        StartCoroutine(CameraShaking(0.1f, 0.5f));

        startTime = Time.time;
        while (Time.time - startTime < 2)
        {
            if (Time.time - startTime > 1.0)
            {
                if (overlab_shoot1 != null) Destroy(overlab_shoot1.gameObject);
            }
            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.5)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            ptn_color.a = 1 - alpha;

            ptn_sprite_1.color = ptn_color;
            yield return null;
        }

        Destroy(overlab_pattern5_1);
        Destroy(bullet);
        StopCoroutine(overlab_Scp1_5_1());
    }
    IEnumerator overlab_Scp1_5_2()
    {
        overlab_pattern5_2.SetActive(true);
        overlab_target2.SetActive(true);
        SpriteRenderer ptn_sprite_2 = overlab_pattern5_2.GetComponent<SpriteRenderer>();
        SpriteRenderer tgt_sprite_2 = overlab_target2.GetComponent<SpriteRenderer>();

        UnityEngine.Color ptn_color = ptn_sprite_2.color;
        UnityEngine.Color tgt_color = tgt_sprite_2.color;

        ptn_color.a = 0f;
        tgt_color.a = 0f;

        ptn_sprite_2.color = ptn_color;
        tgt_sprite_2.color = tgt_color;



        SpriteRenderer before_Sprite = overlab_target1.GetComponent<SpriteRenderer>();
        UnityEngine.Color before_Color = before_Sprite.color;
        before_Color.a = 0;

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (Time.time - startTime < 1)
            {
                float alpha = (Time.time - startTime) / 1;
                ptn_color.a = alpha;
                tgt_color.a = alpha;

                ptn_sprite_2.color = ptn_color;
                tgt_sprite_2.color = tgt_color;
            }
            Vector3 direction = PlayerPos - overlab_pattern5_2.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            overlab_pattern5_2.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            before_Sprite.color = before_Color;
            overlab_target2.transform.position = PlayerPos;
            overlab_target2.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);

            yield return null;
        }
        Transform bulletPosTransform = overlab_pattern5_2.transform.Find("BulletPos");
        GameObject bullet = PatternManager.Instance.StartPattern("Stage1_Bullet");
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = overlab_pattern5_2.transform.rotation;
        Vector3 dir = PlayerPos - overlab_pattern5_2.transform.position;


        overlab_shoot2 = ParticleManager.Instance.StartParticle("VFX_shooting");
        overlab_shoot2.transform.position = bulletPosTransform.transform.position;
        overlab_shoot2.transform.localScale = new Vector3(15, 15, 15);
        overlab_shoot2.transform.rotation = overlab_pattern5_2.transform.rotation;
        var main = overlab_shoot2.main;
        main.startRotationZ = 0f;
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            yield return null;
        }

        StartCoroutine(CameraShaking(0.1f, 0.5f));
        startTime = Time.time;
        while (Time.time - startTime < 2)
        {
            if (Time.time - startTime > 1.0)
            {
                if (overlab_shoot2 != null) Destroy(overlab_shoot2.gameObject);
            }
            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 0.5)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            ptn_color.a = 1 - alpha;

            ptn_sprite_2.color = ptn_color;
            yield return null;
        }
        Destroy(overlab_pattern5_2);
        Destroy(bullet);
        StopCoroutine(overlab_Scp1_5_2());
    }
    IEnumerator overlab_Scp1_5_3()
    {
        overlab_pattern5_3.SetActive(true);
        overlab_target3.SetActive(true);

        SpriteRenderer ptn_sprite_3 = overlab_pattern5_3.GetComponent<SpriteRenderer>();
        SpriteRenderer tgt_sprite_3 = overlab_target3.GetComponent<SpriteRenderer>();

        UnityEngine.Color ptn_color = ptn_sprite_3.color;
        UnityEngine.Color tgt_color = tgt_sprite_3.color;

        ptn_color.a = 0f;
        tgt_color.a = 0f;

        ptn_sprite_3.color = ptn_color;
        tgt_sprite_3.color = tgt_color;

        SpriteRenderer before_Sprite = overlab_target2.GetComponent<SpriteRenderer>();
        UnityEngine.Color before_Color = before_Sprite.color;
        before_Color.a = 0;

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (Time.time - startTime < 1)
            {
                float alpha = (Time.time - startTime) / 1;
                ptn_color.a = alpha;
                tgt_color.a = alpha;

                ptn_sprite_3.color = ptn_color;
                tgt_sprite_3.color = tgt_color;
            }
            Vector3 direction = PlayerPos - overlab_pattern5_3.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            overlab_pattern5_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            before_Sprite.color = before_Color;
            overlab_target3.transform.position = PlayerPos;
            overlab_target3.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);
            yield return null;
        }

        Transform bulletPosTransform = overlab_pattern5_3.transform.Find("BulletPos");
        GameObject bullet = PatternManager.Instance.StartPattern("Stage1_Bullet");
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = overlab_pattern5_3.transform.rotation;
        Vector3 dir = PlayerPos - overlab_pattern5_3.transform.position;

        overlab_shoot3 = ParticleManager.Instance.StartParticle("VFX_shooting");
        overlab_shoot3.transform.position = bulletPosTransform.transform.position;
        overlab_shoot3.transform.localScale = new Vector3(15, 15, 15);
        overlab_shoot3.transform.rotation = overlab_pattern5_3.transform.rotation;
        var main = overlab_shoot3.main;
        main.startRotationZ = 0f;
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            yield return null;
        }
        StartCoroutine(CameraShaking(0.1f, 0.5f));
        startTime = Time.time;
        while (Time.time - startTime < 2)
        {
            if (Time.time - startTime > 1.0)
            {
                if (overlab_shoot3 != null) Destroy(overlab_shoot3.gameObject);
            }
            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.5)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            ptn_color.a = 1 - alpha;

            ptn_sprite_3.color = ptn_color;
            yield return null;
        }
        Destroy(overlab_pattern5_3);
        Destroy(bullet);
        StopCoroutine(overlab_Scp1_5_3());
    }
    IEnumerator overlab_Scp1_5_4()
    {
        overlab_pattern5_4.SetActive(true);
        overlab_target4.SetActive(true);

        SpriteRenderer ptn_sprite_4 = overlab_pattern5_4.GetComponent<SpriteRenderer>();
        SpriteRenderer tgt_sprite_4 = overlab_target4.GetComponent<SpriteRenderer>();

        UnityEngine.Color ptn_color = ptn_sprite_4.color;
        UnityEngine.Color tgt_color = tgt_sprite_4.color;

        ptn_color.a = 0f;
        tgt_color.a = 0f;

        ptn_sprite_4.color = ptn_color;
        tgt_sprite_4.color = tgt_color;

        SpriteRenderer before_Sprite = overlab_target3.GetComponent<SpriteRenderer>();
        UnityEngine.Color before_Color = before_Sprite.color;
        before_Color.a = 0;

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (Time.time - startTime < 1)
            {
                float alpha = (Time.time - startTime) / 1;
                ptn_color.a = alpha;
                tgt_color.a = alpha;

                ptn_sprite_4.color = ptn_color;
                tgt_sprite_4.color = tgt_color;
            }
            Vector3 direction = PlayerPos - overlab_pattern5_4.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            overlab_pattern5_4.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            before_Sprite.color = before_Color;
            overlab_target4.transform.position = PlayerPos;
            overlab_target4.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);

            yield return null;
        }
        Transform bulletPosTransform = overlab_pattern5_4.transform.Find("BulletPos");
        GameObject bullet = PatternManager.Instance.StartPattern("Stage1_Bullet");
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = overlab_pattern5_4.transform.rotation;
        Vector3 dir = PlayerPos - overlab_pattern5_4.transform.position;

        overlab_shoot4 = ParticleManager.Instance.StartParticle("VFX_shooting");
        overlab_shoot4.transform.position = bulletPosTransform.transform.position;
        overlab_shoot4.transform.localScale = new Vector3(15, 15, 15);
        overlab_shoot4.transform.rotation = overlab_pattern5_4.transform.rotation;
        var main = overlab_shoot4.main;
        main.startRotationZ = 0f;
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            yield return null;
        }


        StartCoroutine(CameraShaking(0.1f, 0.5f));
        startTime = Time.time;
        while (Time.time - startTime < 2)
        {
            if (Time.time - startTime > 1.0)
            {
                if (overlab_shoot4 != null) Destroy(overlab_shoot4.gameObject);
            }
            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.5)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            ptn_color.a = 1 - alpha;

            ptn_sprite_4.color = ptn_color;
            yield return null;
        }
        Destroy(overlab_pattern5_4);
        Destroy(bullet);
        StopCoroutine(overlab_Scp1_5_4());
    }
    IEnumerator overlab_Scp1_5_5()
    {
        overlab_pattern5_5.SetActive(true);
        overlab_target5.SetActive(true);

        SpriteRenderer ptn_sprite_5 = overlab_pattern5_5.GetComponent<SpriteRenderer>();
        SpriteRenderer tgt_sprite_5 = overlab_target5.GetComponent<SpriteRenderer>();

        UnityEngine.Color ptn_color = ptn_sprite_5.color;
        UnityEngine.Color tgt_color = tgt_sprite_5.color;

        ptn_color.a = 0f;
        tgt_color.a = 0f;

        ptn_sprite_5.color = ptn_color;
        tgt_sprite_5.color = tgt_color;

        SpriteRenderer before_Sprite = overlab_target4.GetComponent<SpriteRenderer>();
        UnityEngine.Color before_Color = before_Sprite.color;
        before_Color.a = 0;

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (Time.time - startTime < 1)
            {
                float alpha = (Time.time - startTime) / 1;
                ptn_color.a = alpha;
                tgt_color.a = alpha;

                ptn_sprite_5.color = ptn_color;
                tgt_sprite_5.color = tgt_color;
            }
            Vector3 direction = PlayerPos - overlab_pattern5_5.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            overlab_pattern5_5.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            before_Sprite.color = before_Color;
            if (Time.time - startTime < 0.7) // 조준점이 커지는 시간
            {
                overlab_target5.transform.position = PlayerPos;
                overlab_target5.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);

            }
            yield return null;
        }
        Transform bulletPosTransform = overlab_pattern5_5.transform.Find("BulletPos");
        GameObject bullet = PatternManager.Instance.StartPattern("Stage1_Bullet");
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = overlab_pattern5_5.transform.rotation;
        Vector3 dir = PlayerPos - overlab_pattern5_5.transform.position;

        overlab_shoot5 = ParticleManager.Instance.StartParticle("VFX_shooting");
        overlab_shoot5.transform.position = bulletPosTransform.transform.position;
        overlab_shoot5.transform.localScale = new Vector3(15, 15, 15);
        overlab_shoot5.transform.rotation = overlab_pattern5_5.transform.rotation;
        var main = overlab_shoot5.main;
        main.startRotationZ = 0f;
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            yield return null;
        }
        StartCoroutine(CameraShaking(0.1f, 0.5f));
        startTime = Time.time;
        while (Time.time - startTime < 2)
        {
            if (Time.time - startTime > 1.0)
            {
                if (overlab_shoot5 != null) Destroy(overlab_shoot5.gameObject);
            }
            if (Time.time - startTime < 1.5f)
            {
                Destroy(overlab_target1);
                Destroy(overlab_target2);
                Destroy(overlab_target3);
                Destroy(overlab_target4);
            } // 조준점 삭제

            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
            yield return null;
        }
        while (Time.time - startTime < 0.5)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            ptn_color.a = 1 - alpha;
            tgt_color.a = 1 - alpha;

            ptn_sprite_5.color = ptn_color;
            tgt_sprite_5.color = tgt_color;

            yield return null;
        }
        Destroy(overlab_target5);
        Destroy(overlab_pattern5_5);
        Destroy(bullet);
        isOverlab = false;
    }
    #endregion
    public void Scp1_7()
    {
        isPattern = true;
        StartCoroutine(Scp1_7_1());
    }
    #region Scp 1_7 패턴로직
    IEnumerator Scp1_7_1()
    {
        #region 초기세팅
        pattern7_1 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern7_1.transform.position = new Vector3(-28, -40, 0);
        pattern7_1.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_1.SetActive(true);
        SpriteRenderer spritePattern7_1 = pattern7_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_1 = spritePattern7_1.color;
        colorPattern7_1.a = 0f;
        spritePattern7_1.color = colorPattern7_1;

        pattern7_2 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern7_2.transform.position = new Vector3(-21, -40, 0);
        pattern7_2.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_2.SetActive(true);
        SpriteRenderer spritePattern7_2 = pattern7_2.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_2 = spritePattern7_2.color;
        colorPattern7_2.a = 0f;
        spritePattern7_2.color = colorPattern7_2;

        pattern7_3 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern7_3.transform.position = new Vector3(-14, -40, 0);
        pattern7_3.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_3.SetActive(true);
        SpriteRenderer spritePattern7_3 = pattern7_3.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_3 = spritePattern7_3.color;
        colorPattern7_3.a = 0f;
        spritePattern7_3.color = colorPattern7_3;


        pattern7_4 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern7_4.transform.position = new Vector3(-7, -40, 0);
        pattern7_4.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_4.SetActive(true);
        SpriteRenderer spritePattern7_4 = pattern7_4.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_4 = spritePattern7_4.color;
        colorPattern7_4.a = 0f;
        spritePattern7_4.color = colorPattern7_4;

        pattern7_5 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern7_5.transform.position = new Vector3(0, -40, 0);
        pattern7_5.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_5.SetActive(true);
        SpriteRenderer spritePattern7_5 = pattern7_5.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_5 = spritePattern7_5.color;
        colorPattern7_5.a = 0f;
        spritePattern7_5.color = colorPattern7_5;

        pattern7_6 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern7_6.transform.position = new Vector3(7, -40, 0);
        pattern7_6.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_6.SetActive(true);
        SpriteRenderer spritePattern7_6 = pattern7_6.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_6 = spritePattern7_6.color;
        colorPattern7_6.a = 0f;
        spritePattern7_6.color = colorPattern7_6;

        pattern7_7 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern7_7.transform.position = new Vector3(14, -40, 0);
        pattern7_7.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_7.SetActive(true);
        SpriteRenderer spritePattern7_7 = pattern7_7.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_7 = spritePattern7_7.color;
        colorPattern7_7.a = 0f;
        spritePattern7_7.color = colorPattern7_7;

        pattern7_8 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern7_8.transform.position = new Vector3(21, -40, 0);
        pattern7_8.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_8.SetActive(true);
        SpriteRenderer spritePattern7_8 = pattern7_8.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_8 = spritePattern7_8.color;
        colorPattern7_8.a = 0f;
        spritePattern7_8.color = colorPattern7_8;

        pattern7_9 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern7_9.transform.position = new Vector3(28, -40, 0);
        pattern7_9.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_9.SetActive(true);
        SpriteRenderer spritePattern7_9 = pattern7_9.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_9 = spritePattern7_9.color;
        colorPattern7_9.a = 0f;
        spritePattern7_9.color = colorPattern7_9;
        #endregion
        float startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;
            colorPattern7_1.a = alpha;
            spritePattern7_1.color = colorPattern7_1;

            colorPattern7_2.a = alpha;
            spritePattern7_2.color = colorPattern7_2;

            colorPattern7_3.a = alpha;
            spritePattern7_3.color = colorPattern7_3;

            colorPattern7_4.a = alpha;
            spritePattern7_4.color = colorPattern7_4;

            colorPattern7_5.a = alpha;
            spritePattern7_5.color = colorPattern7_5;

            colorPattern7_6.a = alpha;
            spritePattern7_6.color = colorPattern7_6;

            colorPattern7_7.a = alpha;
            spritePattern7_7.color = colorPattern7_7;

            colorPattern7_8.a = alpha;
            spritePattern7_8.color = colorPattern7_8;

            colorPattern7_9.a = alpha;
            spritePattern7_9.color = colorPattern7_9;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 2)
        {
            float totalSpeed = 300f;
            float speed1 = totalSpeed;
            float speed2 = totalSpeed;
            float speed3 = totalSpeed;
            float speed4 = totalSpeed;
            float speed5 = totalSpeed;
            float speed6 = totalSpeed;
            float speed7 = totalSpeed;
            float speed8 = totalSpeed;
            float speed9 = totalSpeed;
            if (Time.time - startTime > 0.1f)
            {
                pattern7_1.transform.position += new Vector3(0, speed1 * Time.deltaTime, 0);
                if (pattern7_1.transform.position.y >= 50)
                {
                    pattern7_1.transform.position = new Vector3(-28, 50, 0);
                }
            }
            if (Time.time - startTime > 0.2f)
            {
                pattern7_2.transform.position += new Vector3(0, speed2 * Time.deltaTime, 0);
                if (pattern7_2.transform.position.y >= 50)
                {
                    pattern7_2.transform.position = new Vector3(-21, 50, 0);
                }
            }
            if (Time.time - startTime > 0.3f)
            {
                pattern7_3.transform.position += new Vector3(0, speed3 * Time.deltaTime, 0);
                if (pattern7_3.transform.position.y >= 50)
                {
                    pattern7_3.transform.position = new Vector3(-14, 50, 0);
                }
            }
            if (Time.time - startTime > 0.4f)
            {
                pattern7_4.transform.position += new Vector3(0, speed4 * Time.deltaTime, 0);
                if (pattern7_4.transform.position.y >= 50)
                {
                    pattern7_4.transform.position = new Vector3(-7, 50, 0);
                }
            }
            if (Time.time - startTime > 0.5f)
            {
                pattern7_5.transform.position += new Vector3(0, speed5 * Time.deltaTime, 0);
                if (pattern7_5.transform.position.y >= 50)
                {

                    pattern7_5.transform.position = new Vector3(0, 50, 0);
                }
            }
            if (Time.time - startTime > 0.6f)
            {
                pattern7_6.transform.position += new Vector3(0, speed6 * Time.deltaTime, 0);
                if (pattern7_6.transform.position.y >= 50)
                {
                    pattern7_6.transform.position = new Vector3(7, 50, 0);
                }
            }
            if (Time.time - startTime > 0.7f)
            {
                pattern7_7.transform.position += new Vector3(0, speed7 * Time.deltaTime, 0);
                if (pattern7_7.transform.position.y >= 50)
                {
                    pattern7_7.transform.position = new Vector3(14, 50, 0);
                }
            }
            if (Time.time - startTime > 0.8f)
            {
                pattern7_8.transform.position += new Vector3(0, speed8 * Time.deltaTime, 0);
                if (pattern7_8.transform.position.y >= 50)
                {
                    pattern7_8.transform.position = new Vector3(21, 50, 0);
                }
            }
            if (Time.time - startTime > 0.9f)
            {
                pattern7_9.transform.position += new Vector3(0, speed9 * Time.deltaTime, 0);
                if (pattern7_9.transform.position.y >= 50)
                {
                    pattern7_9.transform.position = new Vector3(28, 50, 0);
                }
            }



            yield return null;

        }
        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;
            colorPattern7_1.a = 1f - alpha;
            spritePattern7_1.color = colorPattern7_1;

            colorPattern7_2.a = 1f - alpha;
            spritePattern7_2.color = colorPattern7_2;

            colorPattern7_3.a = 1f - alpha;
            spritePattern7_3.color = colorPattern7_3;

            colorPattern7_4.a = 1f - alpha;
            spritePattern7_4.color = colorPattern7_4;

            colorPattern7_5.a = 1f - alpha;
            spritePattern7_5.color = colorPattern7_5;

            colorPattern7_6.a = 1f - alpha;
            spritePattern7_6.color = colorPattern7_6;

            colorPattern7_7.a = 1f - alpha;
            spritePattern7_7.color = colorPattern7_7;

            colorPattern7_8.a = 1f - alpha;
            spritePattern7_8.color = colorPattern7_8;

            colorPattern7_9.a = 1f - alpha;
            spritePattern7_9.color = colorPattern7_9;

            yield return null;
        }

        #region 삭제
        Destroy(pattern7_1);
        Destroy(pattern7_2);
        Destroy(pattern7_3);
        Destroy(pattern7_4);
        Destroy(pattern7_5);
        Destroy(pattern7_6);
        Destroy(pattern7_7);
        Destroy(pattern7_8);
        Destroy(pattern7_9);
        #endregion
        isPattern = false;
    }
    #endregion
    void overlab_Scp1_7()
    {
        isOverlab = true;
        StartCoroutine(overlab_Scp1_7_1());
    }
    #region overlab_Scp 1_7 패턴로직
    IEnumerator overlab_Scp1_7_1()
    {
        #region 초기세팅
        overlab_pattern7_1 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern7_1.transform.position = new Vector3(-28, -40, 0);
        overlab_pattern7_1.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_1.SetActive(true);
        SpriteRenderer spritePattern7_1 = overlab_pattern7_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_1 = spritePattern7_1.color;
        colorPattern7_1.a = 0f;
        spritePattern7_1.color = colorPattern7_1;

        overlab_pattern7_2 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern7_2.transform.position = new Vector3(-21, -40, 0);
        overlab_pattern7_2.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_2.SetActive(true);
        SpriteRenderer spritePattern7_2 = overlab_pattern7_2.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_2 = spritePattern7_2.color;
        colorPattern7_2.a = 0f;
        spritePattern7_2.color = colorPattern7_2;

        overlab_pattern7_3 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern7_3.transform.position = new Vector3(-14, -40, 0);
        overlab_pattern7_3.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_3.SetActive(true);
        SpriteRenderer spritePattern7_3 = overlab_pattern7_3.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_3 = spritePattern7_3.color;
        colorPattern7_3.a = 0f;
        spritePattern7_3.color = colorPattern7_3;


        overlab_pattern7_4 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern7_4.transform.position = new Vector3(-7, -40, 0);
        overlab_pattern7_4.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_4.SetActive(true);
        SpriteRenderer spritePattern7_4 = overlab_pattern7_4.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_4 = spritePattern7_4.color;
        colorPattern7_4.a = 0f;
        spritePattern7_4.color = colorPattern7_4;

        overlab_pattern7_5 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern7_5.transform.position = new Vector3(0, -40, 0);
        overlab_pattern7_5.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_5.SetActive(true);
        SpriteRenderer spritePattern7_5 = overlab_pattern7_5.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_5 = spritePattern7_5.color;
        colorPattern7_5.a = 0f;
        spritePattern7_5.color = colorPattern7_5;

        overlab_pattern7_6 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern7_6.transform.position = new Vector3(7, -40, 0);
        overlab_pattern7_6.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_6.SetActive(true);
        SpriteRenderer spritePattern7_6 = overlab_pattern7_6.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_6 = spritePattern7_6.color;
        colorPattern7_6.a = 0f;
        spritePattern7_6.color = colorPattern7_6;

        overlab_pattern7_7 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern7_7.transform.position = new Vector3(14, -40, 0);
        overlab_pattern7_7.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_7.SetActive(true);
        SpriteRenderer spritePattern7_7 = overlab_pattern7_7.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_7 = spritePattern7_7.color;
        colorPattern7_7.a = 0f;
        spritePattern7_7.color = colorPattern7_7;

        overlab_pattern7_8 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern7_8.transform.position = new Vector3(21, -40, 0);
        overlab_pattern7_8.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_8.SetActive(true);
        SpriteRenderer spritePattern7_8 = overlab_pattern7_8.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_8 = spritePattern7_8.color;
        colorPattern7_8.a = 0f;
        spritePattern7_8.color = colorPattern7_8;

        overlab_pattern7_9 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern7_9.transform.position = new Vector3(28, -40, 0);
        overlab_pattern7_9.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_9.SetActive(true);
        SpriteRenderer spritePattern7_9 = overlab_pattern7_9.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_9 = spritePattern7_9.color;
        colorPattern7_9.a = 0f;
        spritePattern7_9.color = colorPattern7_9;


        overlab_pattern7_1.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        overlab_pattern7_2.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        overlab_pattern7_3.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        overlab_pattern7_4.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        overlab_pattern7_5.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        overlab_pattern7_6.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        overlab_pattern7_7.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        overlab_pattern7_8.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        overlab_pattern7_9.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);


        #endregion
        float startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;
            colorPattern7_1.a = alpha;
            spritePattern7_1.color = colorPattern7_1;

            colorPattern7_2.a = alpha;
            spritePattern7_2.color = colorPattern7_2;

            colorPattern7_3.a = alpha;
            spritePattern7_3.color = colorPattern7_3;

            colorPattern7_4.a = alpha;
            spritePattern7_4.color = colorPattern7_4;

            colorPattern7_5.a = alpha;
            spritePattern7_5.color = colorPattern7_5;

            colorPattern7_6.a = alpha;
            spritePattern7_6.color = colorPattern7_6;

            colorPattern7_7.a = alpha;
            spritePattern7_7.color = colorPattern7_7;

            colorPattern7_8.a = alpha;
            spritePattern7_8.color = colorPattern7_8;

            colorPattern7_9.a = alpha;
            spritePattern7_9.color = colorPattern7_9;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 2)
        {
            float totalSpeed = 200f;
            float speed1 = totalSpeed;
            float speed2 = totalSpeed;
            float speed3 = totalSpeed;
            float speed4 = totalSpeed;
            float speed5 = totalSpeed;
            float speed6 = totalSpeed;
            float speed7 = totalSpeed;
            float speed8 = totalSpeed;
            float speed9 = totalSpeed;
            if (Time.time - startTime > 0.1f)
            {
                overlab_pattern7_1.transform.position += new Vector3(0, speed1 * Time.deltaTime, 0);
                if (overlab_pattern7_1.transform.position.y >= 50)
                {
                    speed1 = 0;
                    overlab_pattern7_1.transform.position = new Vector3(-28, 50, 0);
                }
            }
            if (Time.time - startTime > 0.2f)
            {
                overlab_pattern7_2.transform.position += new Vector3(0, speed2 * Time.deltaTime, 0);
                if (overlab_pattern7_2.transform.position.y >= 50)
                {
                    speed2 = 0;
                    overlab_pattern7_2.transform.position = new Vector3(-21, 50, 0);
                }
            }
            if (Time.time - startTime > 0.3f)
            {
                overlab_pattern7_3.transform.position += new Vector3(0, speed3 * Time.deltaTime, 0);
                if (overlab_pattern7_3.transform.position.y >= 50)
                {
                    speed3 = 0;
                    overlab_pattern7_3.transform.position = new Vector3(-14, 50, 0);
                }
            }
            if (Time.time - startTime > 0.4f)
            {
                overlab_pattern7_4.transform.position += new Vector3(0, speed4 * Time.deltaTime, 0);
                if (overlab_pattern7_4.transform.position.y >= 50)
                {
                    speed4 = 0;
                    overlab_pattern7_4.transform.position = new Vector3(-7, 50, 0);
                }
            }
            if (Time.time - startTime > 0.5f)
            {
                overlab_pattern7_5.transform.position += new Vector3(0, speed5 * Time.deltaTime, 0);
                if (overlab_pattern7_5.transform.position.y >= 50)
                {
                    speed5 = 0;
                    overlab_pattern7_5.transform.position = new Vector3(0, 50, 0);
                }
            }
            if (Time.time - startTime > 0.6f)
            {
                overlab_pattern7_6.transform.position += new Vector3(0, speed6 * Time.deltaTime, 0);
                if (overlab_pattern7_6.transform.position.y >= 50)
                {
                    speed6 = 0;
                    overlab_pattern7_6.transform.position = new Vector3(7, 50, 0);
                }
            }
            if (Time.time - startTime > 0.7f)
            {
                overlab_pattern7_7.transform.position += new Vector3(0, speed7 * Time.deltaTime, 0);
                if (overlab_pattern7_7.transform.position.y >= 50)
                {
                    speed7 = 0;
                    overlab_pattern7_7.transform.position = new Vector3(14, 50, 0);
                }
            }
            if (Time.time - startTime > 0.8f)
            {
                overlab_pattern7_8.transform.position += new Vector3(0, speed8 * Time.deltaTime, 0);
                if (overlab_pattern7_8.transform.position.y >= 50)
                {
                    speed8 = 0;
                    overlab_pattern7_8.transform.position = new Vector3(21, 50, 0);
                }
            }
            if (Time.time - startTime > 0.9f)
            {
                overlab_pattern7_9.transform.position += new Vector3(0, speed9 * Time.deltaTime, 0);
                if (overlab_pattern7_9.transform.position.y >= 50)
                {
                    speed9 = 0;
                    overlab_pattern7_9.transform.position = new Vector3(28, 50, 0);
                }
            }



            yield return null;

        }
        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;
            colorPattern7_1.a = 1f - alpha;
            spritePattern7_1.color = colorPattern7_1;

            colorPattern7_2.a = 1f - alpha;
            spritePattern7_2.color = colorPattern7_2;

            colorPattern7_3.a = 1f - alpha;
            spritePattern7_3.color = colorPattern7_3;

            colorPattern7_4.a = 1f - alpha;
            spritePattern7_4.color = colorPattern7_4;

            colorPattern7_5.a = 1f - alpha;
            spritePattern7_5.color = colorPattern7_5;

            colorPattern7_6.a = 1f - alpha;
            spritePattern7_6.color = colorPattern7_6;

            colorPattern7_7.a = 1f - alpha;
            spritePattern7_7.color = colorPattern7_7;

            colorPattern7_8.a = 1f - alpha;
            spritePattern7_8.color = colorPattern7_8;

            colorPattern7_9.a = 1f - alpha;
            spritePattern7_9.color = colorPattern7_9;

            yield return null;
        }

        #region 삭제
        Destroy(overlab_pattern7_1);
        Destroy(overlab_pattern7_2);
        Destroy(overlab_pattern7_3);
        Destroy(overlab_pattern7_4);
        Destroy(overlab_pattern7_5);
        Destroy(overlab_pattern7_6);
        Destroy(overlab_pattern7_7);
        Destroy(overlab_pattern7_8);
        Destroy(overlab_pattern7_9);
        #endregion
        isOverlab = false;
    }
    #endregion
    public void Scp1_8()
    {
        isPattern = true;
        StartCoroutine(Scp1_8_Pattern());
    }
    #region Scp 1_8 패턴로직
    IEnumerator Scp1_8_Pattern()
    {
        #region 초기세팅 위치, 각도, 투명도0
        pattern8_1 = PatternManager.Instance.StartPattern("Stage1_Bow");
        pattern8_2 = PatternManager.Instance.StartPattern("Stage1_Bow");
        pattern8_3 = PatternManager.Instance.StartPattern("Stage1_Bow");

        pattern8_1.SetActive(true);
        pattern8_2.SetActive(true);
        pattern8_3.SetActive(true);

        pattern8_1.transform.position = new Vector3(-25, -40, 0);
        pattern8_1.transform.eulerAngles = new Vector3(0, 0, 45);

        pattern8_2.transform.position = new Vector3(0, -50, 0);
        pattern8_2.transform.eulerAngles = new Vector3(0, 0, 90);

        pattern8_3.transform.position = new Vector3(25, -41, 0);
        pattern8_3.transform.eulerAngles = new Vector3(0, 0, 135);

        SpriteRenderer pattern1_sprite = pattern8_1.GetComponent<SpriteRenderer>();
        SpriteRenderer pattern2_sprite = pattern8_2.GetComponent<SpriteRenderer>();
        SpriteRenderer pattern3_sprite = pattern8_3.GetComponent<SpriteRenderer>();

        UnityEngine.Color pattern1_color = pattern1_sprite.color;
        UnityEngine.Color pattern2_color = pattern2_sprite.color;
        UnityEngine.Color pattern3_color = pattern3_sprite.color;

        pattern1_color.a = 0f;
        pattern2_color.a = 0f;
        pattern3_color.a = 0f;

        pattern1_sprite.color = pattern1_color;
        pattern2_sprite.color = pattern2_color;
        pattern3_sprite.color = pattern3_color;

        arrow1 = PatternManager.Instance.StartPattern("Stage1_Arrow");
        arrow2 = PatternManager.Instance.StartPattern("Stage1_Arrow");
        arrow3 = PatternManager.Instance.StartPattern("Stage1_Arrow");

        arrow1.SetActive(true);
        arrow2.SetActive(true);
        arrow3.SetActive(true);

        arrow1.transform.position = new Vector3(0, -44, 0);
        arrow1.transform.eulerAngles = new Vector3(0, 0, 180);

        arrow2.transform.position = new Vector3(-20, -35, 0);
        arrow2.transform.eulerAngles = new Vector3(0, 0, 135);

        arrow3.transform.position = new Vector3(20, -35, 0);
        arrow3.transform.eulerAngles = new Vector3(0, 0, 225);

        SpriteRenderer arrow1_sprite = arrow1.GetComponent<SpriteRenderer>();
        SpriteRenderer arrow2_sprite = arrow2.GetComponent<SpriteRenderer>();
        SpriteRenderer arrow3_sprite = arrow3.GetComponent<SpriteRenderer>();

        UnityEngine.Color arrow1_color = arrow1_sprite.color;
        UnityEngine.Color arrow2_color = arrow2_sprite.color;
        UnityEngine.Color arrow3_color = arrow3_sprite.color;

        arrow1_color.a = 0f;
        arrow2_color.a = 0f;
        arrow3_color.a = 0f;

        arrow1_sprite.color = arrow1_color;
        arrow2_sprite.color = arrow2_color;
        arrow3_sprite.color = arrow3_color;

        int bowCnt = 1;
        #endregion
        float startTime = Time.time;
        while (Time.time - startTime < 3)
        {

            if (Time.time - startTime > 0.75f && bowCnt == 1)
            {
                arrow1.transform.position += new Vector3(0, -2f, 0); // 활 위치 변경
                arrow2.transform.position += new Vector3(-1.75f, -1.75f, 0);
                arrow3.transform.position += new Vector3(1.75f, -1.75f, 0);
                bowCnt++;
            }
            if (Time.time - startTime > 1.5f && bowCnt == 2)
            {
                arrow1.transform.position += new Vector3(0, -2f, 0); // 활 위치 변경
                arrow2.transform.position += new Vector3(-1.75f, -1.75f, 0);
                arrow3.transform.position += new Vector3(1.75f, -1.75f, 0);
                bowCnt++;
            }
            if (Time.time - startTime > 2.25f && bowCnt == 3)
            {
                arrow1.transform.position += new Vector3(0, -2f, 0); // 활 위치 변경
                arrow2.transform.position += new Vector3(-1.75f, -1.75f, 0);
                arrow3.transform.position += new Vector3(1.75f, -1.75f, 0);
                bowCnt++;
            }
            if (Time.time - startTime < 1)
            {
                float alpha = (Time.time - startTime) / 1f;
                pattern1_color.a = alpha;
                pattern2_color.a = alpha;
                pattern3_color.a = alpha;

                arrow1_color.a = alpha;
                arrow2_color.a = alpha;
                arrow3_color.a = alpha;

                pattern1_sprite.color = pattern1_color;
                pattern2_sprite.color = pattern2_color;
                pattern3_sprite.color = pattern3_color;

                arrow1_sprite.color = arrow1_color;
                arrow2_sprite.color = arrow2_color;
                arrow3_sprite.color = arrow3_color;
            }
            yield return null;
        }

        startTime = Time.time;

        Vector3 arrow1Dir = (Vector3.zero - arrow1.transform.position).normalized;
        Vector3 arrow2Dir = (Vector3.zero - arrow2.transform.position).normalized;
        Vector3 arrow3Dir = (Vector3.zero - arrow3.transform.position).normalized;
        float bowSpeed = 250f;
        while (Time.time - startTime < 2)
        {
            arrow1.GetComponent<Rigidbody2D>().velocity = arrow1Dir * bowSpeed;
            arrow2.GetComponent<Rigidbody2D>().velocity = arrow2Dir * bowSpeed;
            arrow3.GetComponent<Rigidbody2D>().velocity = arrow3Dir * bowSpeed;
            if (Time.time - startTime < 1)
            {
                float alpha = (Time.time - startTime) / 1f;
                pattern1_color.a = 1f - alpha;
                pattern2_color.a = 1f - alpha;
                pattern3_color.a = 1f - alpha;

                pattern1_sprite.color = pattern1_color;
                pattern2_sprite.color = pattern2_color;
                pattern3_sprite.color = pattern3_color;
            }

            yield return null;
        }
        Destroy(pattern8_1);
        Destroy(pattern8_2);
        Destroy(pattern8_3);
        Destroy(arrow1);
        Destroy(arrow2);
        Destroy(arrow3);
        Scp1_8_1();
    }
    #endregion
    public void Scp1_8_1()
    {
        isPattern = true;
        StartCoroutine(Scp1_8_1_Pattern());
    }
    #region Scp1_8_1 패턴로직
    IEnumerator Scp1_8_1_Pattern()
    {
        target8_1 = PatternManager.Instance.StartPattern("Stage1_GunAim");
        target8_1.SetActive(true);
        SpriteRenderer target_sprite = target8_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color target_color = target_sprite.color;
        target_color.a = 0;
        target_sprite.color = target_color;
        float startTime = Time.time;

        arrow8_1 = PatternManager.Instance.StartPattern("Stage1_Arrow");
        arrow8_2 = PatternManager.Instance.StartPattern("Stage1_Arrow");
        arrow8_3 = PatternManager.Instance.StartPattern("Stage1_Arrow");

        arrow8_1.transform.position = new Vector3(-6, 75, 0);
        arrow8_2.transform.position = new Vector3(0, 75, 0);
        arrow8_3.transform.position = new Vector3(6, 75, 0);

        arrow8_1.SetActive(true);
        arrow8_2.SetActive(true);
        arrow8_3.SetActive(true);

        while (Time.time - startTime < 2) // 2초의 대기시간
        {
            #region  타겟 투명도
            if (Time.time - startTime < 1)
            {
                float alpha = (Time.time - startTime) / 1f;
                target_color.a = alpha;
                target_sprite.color = target_color;
            }
            #endregion
            target8_1.transform.position = PlayerPos;

            Vector3 direction1 = PlayerPos - arrow8_1.transform.position;
            Quaternion lookRotation1 = Quaternion.LookRotation(Vector3.forward, direction1);

            Vector3 direction2 = PlayerPos - arrow8_1.transform.position;
            Quaternion lookRotation2 = Quaternion.LookRotation(Vector3.forward, direction2);

            Vector3 direction3 = PlayerPos - arrow8_1.transform.position;
            Quaternion lookRotation3 = Quaternion.LookRotation(Vector3.forward, direction3);

            arrow8_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation1.eulerAngles.z + 180);
            arrow8_2.transform.rotation = Quaternion.Euler(0, 0, lookRotation2.eulerAngles.z + 180);
            arrow8_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation3.eulerAngles.z + 180);
            yield return null;
        }
        startTime = Time.time;
        Vector3 direction = (PlayerPos - arrow8_1.transform.position).normalized;

        while (Time.time - startTime < 3)
        {
            float speed = 250f; // 화살표의 이동 속도

            arrow8_1.transform.position += direction * speed * Time.deltaTime;
            arrow8_2.transform.position += direction * speed * Time.deltaTime;
            arrow8_3.transform.position += direction * speed * Time.deltaTime;


            yield return null;
        }

        startTime = Time.time;

        SpriteRenderer arrow1_sprite = arrow8_1.GetComponent<SpriteRenderer>();
        SpriteRenderer arrow2_sprite = arrow8_2.GetComponent<SpriteRenderer>();
        SpriteRenderer arrow3_sprite = arrow8_3.GetComponent<SpriteRenderer>();

        UnityEngine.Color arrow1_color = arrow1_sprite.color;
        UnityEngine.Color arrow2_color = arrow2_sprite.color;
        UnityEngine.Color arrow3_color = arrow3_sprite.color;

        while (Time.time - startTime < 1)
        {
            arrow8_1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            arrow8_2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            arrow8_3.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            float alpha = (Time.time - startTime) / 1f;
            target_color.a = 1 - alpha;
            target_sprite.color = target_color;

            arrow1_color.a = 1 - alpha;
            arrow1_sprite.color = arrow1_color;

            arrow2_color.a = 1 - alpha;
            arrow2_sprite.color = arrow2_color;

            arrow3_color.a = 1 - alpha;
            arrow3_sprite.color = arrow3_color;


            yield return null;
        }
        Destroy(arrow8_1);
        Destroy(arrow8_2);
        Destroy(arrow8_3);
        Destroy(target8_1);
        isPattern = false;
    }
    #endregion
    void overlab_Scp1_8_1()
    {
        isOverlab = true;
        StartCoroutine(overlab_Scp1_8_1_Pattern());
    }
    #region overlab_Scp1_8_1 패턴로직
    IEnumerator overlab_Scp1_8_1_Pattern()
    {
        overlab_target8_1 = PatternManager.Instance.StartPattern("Stage1_GunAim");
        overlab_target8_1.SetActive(true);
        SpriteRenderer target_sprite = overlab_target8_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color target_color = target_sprite.color;
        target_color.a = 0;
        target_sprite.color = target_color;
        float startTime = Time.time;

        overlab_arrow8_1 = PatternManager.Instance.StartPattern("Stage1_Arrow");
        overlab_arrow8_2 = PatternManager.Instance.StartPattern("Stage1_Arrow");
        overlab_arrow8_3 = PatternManager.Instance.StartPattern("Stage1_Arrow");

        overlab_arrow8_1.transform.position = new Vector3(-10, 75, 0);
        overlab_arrow8_2.transform.position = new Vector3(0, 75, 0);
        overlab_arrow8_3.transform.position = new Vector3(10, 75, 0);

        overlab_arrow8_1.SetActive(true);
        overlab_arrow8_2.SetActive(true);
        overlab_arrow8_3.SetActive(true);

        while (Time.time - startTime < 2) // 2초의 대기시간
        {
            #region  타겟 투명도
            if (Time.time - startTime < 1)
            {
                float alpha = (Time.time - startTime) / 1f;
                target_color.a = alpha;
                target_sprite.color = target_color;
            }
            #endregion
            overlab_target8_1.transform.position = PlayerPos;

            Vector3 direction1 = PlayerPos - overlab_arrow8_1.transform.position;
            Quaternion lookRotation1 = Quaternion.LookRotation(Vector3.forward, direction1);

            Vector3 direction2 = PlayerPos - overlab_arrow8_1.transform.position;
            Quaternion lookRotation2 = Quaternion.LookRotation(Vector3.forward, direction2);

            Vector3 direction3 = PlayerPos - overlab_arrow8_1.transform.position;
            Quaternion lookRotation3 = Quaternion.LookRotation(Vector3.forward, direction3);

            overlab_arrow8_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation1.eulerAngles.z + 180);
            overlab_arrow8_2.transform.rotation = Quaternion.Euler(0, 0, lookRotation2.eulerAngles.z + 180);
            overlab_arrow8_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation3.eulerAngles.z + 180);
            yield return null;
        }
        startTime = Time.time;
        Vector3 direction = (PlayerPos - overlab_arrow8_1.transform.position).normalized;

        while (Time.time - startTime < 3)
        {
            float speed = 250f; // 화살표의 이동 속도

            overlab_arrow8_1.transform.position += direction * speed * Time.deltaTime;
            overlab_arrow8_2.transform.position += direction * speed * Time.deltaTime;
            overlab_arrow8_3.transform.position += direction * speed * Time.deltaTime;


            yield return null;
        }

        startTime = Time.time;

        SpriteRenderer arrow1_sprite = overlab_arrow8_1.GetComponent<SpriteRenderer>();
        SpriteRenderer arrow2_sprite = overlab_arrow8_2.GetComponent<SpriteRenderer>();
        SpriteRenderer arrow3_sprite = overlab_arrow8_3.GetComponent<SpriteRenderer>();

        UnityEngine.Color arrow1_color = arrow1_sprite.color;
        UnityEngine.Color arrow2_color = arrow2_sprite.color;
        UnityEngine.Color arrow3_color = arrow3_sprite.color;

        while (Time.time - startTime < 1)
        {
            overlab_arrow8_1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            overlab_arrow8_2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            overlab_arrow8_3.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            float alpha = (Time.time - startTime) / 1f;
            target_color.a = 1 - alpha;
            target_sprite.color = target_color;

            arrow1_color.a = 1 - alpha;
            arrow1_sprite.color = arrow1_color;

            arrow2_color.a = 1 - alpha;
            arrow2_sprite.color = arrow2_color;

            arrow3_color.a = 1 - alpha;
            arrow3_sprite.color = arrow3_color;


            yield return null;
        }
        Destroy(overlab_arrow8_1);
        Destroy(overlab_arrow8_2);
        Destroy(overlab_arrow8_3);
        Destroy(overlab_target8_1);
        isOverlab = false;
    }
    #endregion
    public void Scp1_9()
    {
        isPattern = true;
        StartCoroutine(Scp1_9_Pattern());
    }
    #region Scp1_9 패턴 로직
    IEnumerator Scp1_9_Pattern()
    {
        #region 초기 세팅
        pattern9_1 = PatternManager.Instance.StartPattern("Stage1_Sword1");
        pattern9_2 = PatternManager.Instance.StartPattern("Stage1_Sword1");

        pattern9_1.transform.position = new Vector3(20, 10, 0);
        pattern9_1.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern9_2.transform.position = new Vector3(-20, -10, 0);
        pattern9_2.transform.eulerAngles = new Vector3(0, 0, 90);
        pattern9_1.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        pattern9_2.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        SpriteRenderer pattern9_1sprite = pattern9_1.GetComponent<SpriteRenderer>();
        SpriteRenderer pattern9_2sprite = pattern9_2.GetComponent<SpriteRenderer>();

        UnityEngine.Color pattern9_1color = pattern9_1sprite.color;
        UnityEngine.Color pattern9_2color = pattern9_2sprite.color;

        pattern9_1color.a = 0f;
        pattern9_2color.a = 0f;

        pattern9_1sprite.color = pattern9_1color;
        pattern9_2sprite.color = pattern9_2color;

        pattern9_1.SetActive(true);
        pattern9_2.SetActive(true);
        #endregion
        float startTime = Time.time;
        int randomValue = Random.Range(1, 4); ;
        while (Time.time - startTime < 4)
        {
            if (Time.time - startTime < 1)
            {
                float alpha = (Time.time - startTime) / 1f;
                pattern9_1color.a = alpha;
                pattern9_2color.a = alpha;

                pattern9_1sprite.color = pattern9_1color;
                pattern9_2sprite.color = pattern9_2color;
            }
            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < ptn9_playTime)
        {
            float Speed = 350f;
            if (randomValue == 1)
            {
                float X1 = 100f;
                float Y1 = 4f;
                pattern9_1.transform.position += new Vector3(-X1 * Time.deltaTime, -Y1 * Time.deltaTime, 0);
                pattern9_1.transform.eulerAngles += new Vector3(0, 0, -Speed * 1.7f * Time.deltaTime);
            } // 위쪽검
            else if (randomValue == 2)
            {
                float X2 = 100f;
                float Y2 = 4f;

                pattern9_2.transform.position += new Vector3(X2 * Time.deltaTime, 0, 0);
                pattern9_2.transform.eulerAngles += new Vector3(0, Y2 * Time.deltaTime, -Speed * 1.7f * Time.deltaTime);
            }
            else if (randomValue == 3)
            {
                // 패턴 x
                //continue;
            }
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < ptn9_delayTime)
        {
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;
            pattern9_1color.a = 1 - alpha;
            pattern9_2color.a = 1 - alpha;

            pattern9_1sprite.color = pattern9_1color;
            pattern9_2sprite.color = pattern9_2color;

            yield return null;
        }

        Destroy(pattern9_1);
        Destroy(pattern9_2);
        isPattern = false;
    }
    #endregion
    public void Scp2_2()
    {
        isPattern = true;
        StartCoroutine(Scp2_2_Pattern());
    }
    #region Scp2_2 패턴로직
    IEnumerator Scp2_2_Pattern()
    {
        #region Setting
        pattern2_2_1 = PatternManager.Instance.StartPattern("Test");
        pattern2_2_2 = PatternManager.Instance.StartPattern("Test");

        effect2_1 = PatternManager.Instance.StartPattern("PatternEffect");
        effect2_2 = PatternManager.Instance.StartPattern("PatternEffect");

        TrailRender tr1;
        TrailRender tr2;
        tr1 = effect2_1.GetComponent<TrailRender>();
        tr2 = effect2_2.GetComponent<TrailRender>();
        tr1.trailWidthMultiplier = 4f;
        tr2.trailWidthMultiplier = 4f;

        SpriteRenderer sprite2_2 = pattern2_2_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite2_3 = pattern2_2_2.GetComponent<SpriteRenderer>();

        UnityEngine.Color color2_2 = sprite2_2.color;
        UnityEngine.Color color2_3 = sprite2_3.color;

        color2_2.a = 0;
        color2_3.a = 0;

        sprite2_2.color = color2_2;
        sprite2_3.color = color2_3;

        pattern2_2_1.transform.position = new Vector3(25, 20, 0);
        pattern2_2_2.transform.position = new Vector3(-25, 13, 0);

        Vector3 startpattern2_1 = new Vector3(25, 20, 0);
        Vector3 midpattern2_1 = new Vector3(-10, -90, 0);
        Vector3 endpattern2_1 = new Vector3(-35, 75, 0);

        Vector3 startpattern2_2 = new Vector3(-25, 13, 0);
        Vector3 midpattern2_2 = new Vector3(8, -77, 0);
        Vector3 endpattern2_2 = new Vector3(30, 75, 0);

        Vector3 effect_startpattern2_1 = new Vector3(25, 20, 0);
        Vector3 effect_midpattern2_1 = new Vector3(-10, -90, 0);
        Vector3 effect_endpattern2_1 = new Vector3(-30, 75, 0);

        Vector3 effect_startpattern2_2 = new Vector3(-25, 13, 0);
        Vector3 effect_midpattern2_2 = new Vector3(8, -77, 0);
        Vector3 effect_endpattern2_2 = new Vector3(30, 75, 0);

        float duration = 2.0f; // 이동 시간
        float euler = 35f; // 회전각도
        #endregion
        float startTime = Time.time;
        while (Time.time - startTime < 1) // 대기시간
        {
            float alpha = (Time.time - startTime) / 1f;

            color2_2.a = alpha;
            color2_3.a = alpha;

            sprite2_2.color = color2_2;
            sprite2_3.color = color2_3;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            pattern2_2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);
            pattern2_2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.04f)
        {
            float t = (Time.time - startTime) / 0.04f;
            TrailRender.showTrail = true;

            pattern2_2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);
            pattern2_2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);

            Vector3 position1 = Vector3.Lerp(effect_startpattern2_1, effect_endpattern2_1, t) + effect_midpattern2_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            effect2_1.transform.position = position1; // 이동

            Vector3 position2 = Vector3.Lerp(effect_startpattern2_2, effect_endpattern2_2, t) + effect_midpattern2_2 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            effect2_2.transform.position = position2; // 이동

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            pattern2_2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);
            pattern2_2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            TrailRender.showTrail = false;

            yield return null;

        }


        startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            pattern2_2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);  // 뱅글뱅글
            pattern2_2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);   // 뱅글뱅글

            Vector3 position1 = Vector3.Lerp(startpattern2_1, endpattern2_1, t) + midpattern2_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            pattern2_2_1.transform.position = position1; // 이동

            Vector3 position2 = Vector3.Lerp(startpattern2_2, endpattern2_2, t) + midpattern2_2 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            pattern2_2_2.transform.position = position2; // 이동

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 3 - duration)
        {
            pattern2_2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);
            pattern2_2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);

            yield return null;
        }
        Destroy(pattern2_2_1);
        Destroy(pattern2_2_2);
        Destroy(effect2_1);
        Destroy(effect2_2);
        isPattern = false;
    }
    #endregion
    public void overlab_Scp2_2()
    {
        isOverlab = true;
        StartCoroutine(overalb_Scp2_2_Pattern());
    }
    #region overlab_Scp2_2 패턴로직
    IEnumerator overalb_Scp2_2_Pattern()
    {
        #region Setting
        overlab_pattern2_2_1 = PatternManager.Instance.StartPattern("Test");
        overlab_pattern2_2_2 = PatternManager.Instance.StartPattern("Test");

        overlab_effect2_1 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect2_2 = PatternManager.Instance.StartPattern("PatternEffect");

        TrailRender tr1;
        TrailRender tr2;
        tr1 = overlab_effect2_1.GetComponent<TrailRender>();
        tr2 = overlab_effect2_2.GetComponent<TrailRender>();
        tr1.trailWidthMultiplier = 4f;
        tr2.trailWidthMultiplier = 4f;

        SpriteRenderer sprite2_2 = overlab_pattern2_2_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite2_3 = overlab_pattern2_2_2.GetComponent<SpriteRenderer>();

        UnityEngine.Color color2_2 = sprite2_2.color;
        UnityEngine.Color color2_3 = sprite2_3.color;

        color2_2.a = 0;
        color2_3.a = 0;

        sprite2_2.color = color2_2;
        sprite2_3.color = color2_3;

        overlab_pattern2_2_1.transform.position = new Vector3(25, 20, 0);
        overlab_pattern2_2_2.transform.position = new Vector3(-25, 13, 0);

        Vector3 startpattern2_1 = new Vector3(25, 20, 0);
        Vector3 midpattern2_1 = new Vector3(-10, -90, 0);
        Vector3 endpattern2_1 = new Vector3(-35, 75, 0);

        Vector3 startpattern2_2 = new Vector3(-25, 13, 0);
        Vector3 midpattern2_2 = new Vector3(8, -77, 0);
        Vector3 endpattern2_2 = new Vector3(30, 75, 0);

        Vector3 effect_startpattern2_1 = new Vector3(25, 20, 0);
        Vector3 effect_midpattern2_1 = new Vector3(-10, -90, 0);
        Vector3 effect_endpattern2_1 = new Vector3(-30, 75, 0);

        Vector3 effect_startpattern2_2 = new Vector3(-25, 13, 0);
        Vector3 effect_midpattern2_2 = new Vector3(8, -77, 0);
        Vector3 effect_endpattern2_2 = new Vector3(30, 75, 0);

        float duration = 2.0f; // 이동 시간
        float euler = 35f; // 회전각도
        #endregion
        float startTime = Time.time;
        while (Time.time - startTime < 1) // 대기시간
        {
            float alpha = (Time.time - startTime) / 1f;

            color2_2.a = alpha;
            color2_3.a = alpha;

            sprite2_2.color = color2_2;
            sprite2_3.color = color2_3;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            overlab_pattern2_2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);
            overlab_pattern2_2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.04f)
        {
            float t = (Time.time - startTime) / 0.04f;
            TrailRender.showTrail = true;

            overlab_pattern2_2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);
            overlab_pattern2_2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);

            Vector3 position1 = Vector3.Lerp(effect_startpattern2_1, effect_endpattern2_1, t) + effect_midpattern2_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            overlab_effect2_1.transform.position = position1; // 이동

            Vector3 position2 = Vector3.Lerp(effect_startpattern2_2, effect_endpattern2_2, t) + effect_midpattern2_2 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            overlab_effect2_2.transform.position = position2; // 이동

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            overlab_pattern2_2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);
            overlab_pattern2_2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            TrailRender.showTrail = false;

            yield return null;

        }


        startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            overlab_pattern2_2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);  // 뱅글뱅글
            overlab_pattern2_2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);   // 뱅글뱅글

            Vector3 position1 = Vector3.Lerp(startpattern2_1, endpattern2_1, t) + midpattern2_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            overlab_pattern2_2_1.transform.position = position1; // 이동

            Vector3 position2 = Vector3.Lerp(startpattern2_2, endpattern2_2, t) + midpattern2_2 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            overlab_pattern2_2_2.transform.position = position2; // 이동

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 3 - duration)
        {
            overlab_pattern2_2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);
            overlab_pattern2_2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);

            yield return null;
        }
        Destroy(overlab_pattern2_2_1);
        Destroy(overlab_pattern2_2_2);
        Destroy(overlab_effect2_1);
        Destroy(overlab_effect2_2);
        isOverlab = false;
    }
    #endregion
    public void Scp2_4()
    {
        isPattern = true;
        StartCoroutine(Scp2_4_Pattern());    
    }
    #region Scp2_4 패턴로직
    IEnumerator Scp2_4_Pattern()
    {
        pattern2_4_1 = PatternManager.Instance.StartPattern("Test"); // 왼쪽
        pattern2_4_2 = PatternManager.Instance.StartPattern("Test"); // 오른쪽

        effect4_1 = PatternManager.Instance.StartPattern("PatternEffect");
        effect4_2 = PatternManager.Instance.StartPattern("PatternEffect");

        TrailRender tr1;
        TrailRender tr2;
        tr1 = effect4_1.GetComponent<TrailRender>();
        tr2 = effect4_2.GetComponent<TrailRender>();

        tr1.trailWidthMultiplier = 2f;
        tr2.trailWidthMultiplier = 2f;
        #region Setting
        SpriteRenderer sprite4_1 = pattern2_4_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite4_2 = pattern2_4_2.GetComponent<SpriteRenderer>();

        UnityEngine.Color color4_1 = sprite4_1.color;
        UnityEngine.Color color4_2 = sprite4_2.color;

        color4_1.a = 0f;
        color4_2.a = 0f;

        sprite4_1.color = color4_1;
        sprite4_2.color = color4_2;

        pattern2_4_1.transform.position = new Vector3(-25, 0, 0);
        pattern2_4_2.transform.position = new Vector3(25, 0, 0); // 시작좌표

        #region 포물선 좌표값
        Vector3 startpattern4_1 = new Vector3(-25, 0, 0);
        Vector3 midpattern4_1 = new Vector3(0, 25, 0);
        Vector3 endpattern4_1 = new Vector3(25, 0, 0);

        Vector3 startpattern4_2 = new Vector3(25, 0, 0);
        Vector3 midpattern4_2 = new Vector3(0, -25, 0);
        Vector3 endpattern4_2 = new Vector3(-25, 0, 0);
        // =============돌아옴=============
        Vector3 startpattern4_1_1 = new Vector3(25, 0, 0);
        Vector3 midpattern4_1_1 = new Vector3(0, 25, 0);
        Vector3 endpattern4_1_1 = new Vector3(-25, 0, 0);

        Vector3 startpattern4_2_1 = new Vector3(-25, 0, 0);
        Vector3 midpattern4_2_1 = new Vector3(0, -25, 0);
        Vector3 endpattern4_2_1 = new Vector3(25, 0, 0);
   
        #endregion

        #endregion
        float startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            // 투명도 점점 올리기
            float alpha = (Time.time - startTime) / 1f;
            color4_1.a = alpha;
            color4_2.a = alpha;

            sprite4_1.color = color4_1;
            sprite4_2.color = color4_2;

            yield return null;
        } // 투명도
        float duration = 1.5f; // 이동 시간
        float rotateSpeed = 35f;

        startTime = Time.time;
        while (Time.time - startTime < 0.7f)
        {
            float t = (Time.time - startTime) / 0.7f;

            pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50);    //뱅글뱅글
            pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50);  //뱅글뱅글

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.1f)
        {
            float t = (Time.time - startTime) / 0.1f;
            pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50f);
            pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);

            TrailRender.showTrail = true;

            Vector3 position1 = Vector3.Lerp(startpattern4_1, endpattern4_1, t) + midpattern4_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            effect4_1.transform.position = position1; // 이동

            Vector3 position2 = Vector3.Lerp(startpattern4_2, endpattern4_2, t) + midpattern4_2 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            effect4_2.transform.position = position2; // 이동

            yield return null;
        }


        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50f);
            pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            TrailRender.showTrail = false;
            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50f);
            pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);

            Vector3 position1 = Vector3.Lerp(startpattern4_1, endpattern4_1, t) + midpattern4_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            pattern2_4_1.transform.position = position1; // 이동

            Vector3 position2 = Vector3.Lerp(startpattern4_2, endpattern4_2, t) + midpattern4_2 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            pattern2_4_2.transform.position = position2; // 이동

            yield return null;
        } // 날라감
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            rotateSpeed -= Time.deltaTime * 20f;
            pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50f);
            pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);
            yield return null;
        }// 잠깐 대기하면서 회전속도감소

        startTime = Time.time;
        while (Time.time - startTime < 0.1f)
        {
            float t = (Time.time - startTime) / 0.1f;
            TrailRender.showTrail = true;

            pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50f);
            pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);

            Vector3 position1 = Vector3.Lerp(startpattern4_1_1, endpattern4_1_1, t) + midpattern4_1_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            effect4_1.transform.position = position1; // 이동


            Vector3 position2 = Vector3.Lerp(startpattern4_2_1, endpattern4_2_1, t) + midpattern4_2_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            effect4_2.transform.position = position2; // 이동


            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50f);
            pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            TrailRender.showTrail = false;
            yield return null;
        }

        rotateSpeed = 35f;

        startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);
            pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, +rotateSpeed * Time.deltaTime * 50f);

            Vector3 position1 = Vector3.Lerp(startpattern4_1_1, endpattern4_1_1, t) + midpattern4_1_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            pattern2_4_1.transform.position = position1; // 이동


            Vector3 position2 = Vector3.Lerp(startpattern4_2_1, endpattern4_2_1, t) + midpattern4_2_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            pattern2_4_2.transform.position = position2; // 이동


            yield return null;
        } // 돌아옴

        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);
            pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, +rotateSpeed * Time.deltaTime * 50f);
            yield return null;
        }// 잠깐 대기

        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);
            pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, +rotateSpeed * Time.deltaTime * 50f);
            // 투명도 점점0
            float alpha = (Time.time - startTime) / 1f;
            color4_1.a = 1 - alpha;
            color4_2.a = 1 - alpha;

            sprite4_1.color = color4_1;
            sprite4_2.color = color4_2;

            yield return null;
        } // 투명도감소

        Destroy(pattern2_4_1.gameObject);
        Destroy(pattern2_4_2.gameObject);
        Destroy(effect4_1.gameObject);
        Destroy(effect4_2.gameObject);
        isPattern = false;
    }
    #endregion
    public void overlab_Scp2_4()
    {
        isOverlab = true;
        StartCoroutine(overlab_Scp2_4_Pattern());
    }
    #region Scp2_4 패턴로직
    IEnumerator overlab_Scp2_4_Pattern()
    {
        overlab_pattern2_4_1 = PatternManager.Instance.StartPattern("Test"); // 왼쪽
        overlab_pattern2_4_2 = PatternManager.Instance.StartPattern("Test"); // 오른쪽

        overlab_effect4_1 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect4_2 = PatternManager.Instance.StartPattern("PatternEffect");

        TrailRender tr1;
        TrailRender tr2;
        tr1 = overlab_effect4_1.GetComponent<TrailRender>();
        tr2 = overlab_effect4_2.GetComponent<TrailRender>();

        tr1.trailWidthMultiplier = 2f;
        tr2.trailWidthMultiplier = 2f;
        #region Setting
        SpriteRenderer sprite4_1 = overlab_pattern2_4_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite4_2 = overlab_pattern2_4_2.GetComponent<SpriteRenderer>();

        UnityEngine.Color color4_1 = sprite4_1.color;
        UnityEngine.Color color4_2 = sprite4_2.color;

        color4_1.a = 0f;
        color4_2.a = 0f;

        sprite4_1.color = color4_1;
        sprite4_2.color = color4_2;

        overlab_pattern2_4_1.transform.position = new Vector3(-25, 0, 0);
        overlab_pattern2_4_2.transform.position = new Vector3(25, 0, 0); // 시작좌표

        #region 포물선 좌표값
        Vector3 startpattern4_1 = new Vector3(-25, 0, 0);
        Vector3 midpattern4_1 = new Vector3(0, 25, 0);
        Vector3 endpattern4_1 = new Vector3(25, 0, 0);

        Vector3 startpattern4_2 = new Vector3(25, 0, 0);
        Vector3 midpattern4_2 = new Vector3(0, -25, 0);
        Vector3 endpattern4_2 = new Vector3(-25, 0, 0);
        // =============돌아옴=============
        Vector3 startpattern4_1_1 = new Vector3(25, 0, 0);
        Vector3 midpattern4_1_1 = new Vector3(0, 25, 0);
        Vector3 endpattern4_1_1 = new Vector3(-25, 0, 0);

        Vector3 startpattern4_2_1 = new Vector3(-25, 0, 0);
        Vector3 midpattern4_2_1 = new Vector3(0, -25, 0);
        Vector3 endpattern4_2_1 = new Vector3(25, 0, 0);

        #endregion

        #endregion
        float startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            // 투명도 점점 올리기
            float alpha = (Time.time - startTime) / 1f;
            color4_1.a = alpha;
            color4_2.a = alpha;

            sprite4_1.color = color4_1;
            sprite4_2.color = color4_2;

            yield return null;
        } // 투명도
        float duration = 1.5f; // 이동 시간
        float rotateSpeed = 35f;

        startTime = Time.time;
        while (Time.time - startTime < 0.7f)
        {
            float t = (Time.time - startTime) / 0.7f;

            overlab_pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50);    //뱅글뱅글
            overlab_pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50);  //뱅글뱅글

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.1f)
        {
            float t = (Time.time - startTime) / 0.1f;
            overlab_pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50f);
            overlab_pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);

            TrailRender.showTrail = true;

            Vector3 position1 = Vector3.Lerp(startpattern4_1, endpattern4_1, t) + midpattern4_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
           overlab_effect4_1.transform.position = position1; // 이동

            Vector3 position2 = Vector3.Lerp(startpattern4_2, endpattern4_2, t) + midpattern4_2 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            overlab_effect4_2.transform.position = position2; // 이동

            yield return null;
        }


        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            overlab_pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50f);
            overlab_pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            TrailRender.showTrail = false;
            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            overlab_pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50f);
            overlab_pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);

            Vector3 position1 = Vector3.Lerp(startpattern4_1, endpattern4_1, t) + midpattern4_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            overlab_pattern2_4_1.transform.position = position1; // 이동

            Vector3 position2 = Vector3.Lerp(startpattern4_2, endpattern4_2, t) + midpattern4_2 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            overlab_pattern2_4_2.transform.position = position2; // 이동

            yield return null;
        } // 날라감
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            rotateSpeed -= Time.deltaTime * 20f;
            overlab_pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50f);
            overlab_pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);
            yield return null;
        }// 잠깐 대기하면서 회전속도감소

        startTime = Time.time;
        while (Time.time - startTime < 0.1f)
        {
            float t = (Time.time - startTime) / 0.1f;
            TrailRender.showTrail = true;

            overlab_pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50f);
            overlab_pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);

            Vector3 position1 = Vector3.Lerp(startpattern4_1_1, endpattern4_1_1, t) + midpattern4_1_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            overlab_effect4_1.transform.position = position1; // 이동


            Vector3 position2 = Vector3.Lerp(startpattern4_2_1, endpattern4_2_1, t) + midpattern4_2_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            overlab_effect4_2.transform.position = position2; // 이동


            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            overlab_pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50f);
            overlab_pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            TrailRender.showTrail = false;
            yield return null;
        }

        rotateSpeed = 35f;

        startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            overlab_pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);
            overlab_pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, +rotateSpeed * Time.deltaTime * 50f);

            Vector3 position1 = Vector3.Lerp(startpattern4_1_1, endpattern4_1_1, t) + midpattern4_1_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            overlab_pattern2_4_1.transform.position = position1; // 이동


            Vector3 position2 = Vector3.Lerp(startpattern4_2_1, endpattern4_2_1, t) + midpattern4_2_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            overlab_pattern2_4_2.transform.position = position2; // 이동


            yield return null;
        } // 돌아옴

        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            overlab_pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);
            overlab_pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, +rotateSpeed * Time.deltaTime * 50f);
            yield return null;
        }// 잠깐 대기

        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            overlab_pattern2_4_1.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);
            overlab_pattern2_4_2.transform.eulerAngles += new Vector3(0, 0, +rotateSpeed * Time.deltaTime * 50f);
            // 투명도 점점0
            float alpha = (Time.time - startTime) / 1f;
            color4_1.a = 1 - alpha;
            color4_2.a = 1 - alpha;

            sprite4_1.color = color4_1;
            sprite4_2.color = color4_2;

            yield return null;
        } // 투명도감소

        Destroy(overlab_pattern2_4_1.gameObject);
        Destroy(overlab_pattern2_4_2.gameObject);
        Destroy(overlab_effect4_1.gameObject);
        Destroy(overlab_effect4_2.gameObject);
        isOverlab = false;
    }
    #endregion
    void Scp3_1()
    {
        isPattern = true;
        StartCoroutine(Scp3_1_Pattern());
    }
    #region Scp3_1 패턴로직
    IEnumerator Scp3_1_Pattern()
    {
        #region Setting
        pattern3_1_1 = PatternManager.Instance.StartPattern("Stage3_Spear");
        pattern3_1_2 = PatternManager.Instance.StartPattern("Stage3_Spear");
        pattern3_1_3 = PatternManager.Instance.StartPattern("Stage3_Spear");

        SpriteRenderer sprite1_1 = pattern3_1_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite1_2 = pattern3_1_2.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite1_3 = pattern3_1_3.GetComponent<SpriteRenderer>();

        UnityEngine.Color color1_1 = sprite1_1.color;
        UnityEngine.Color color1_2 = sprite1_2.color;
        UnityEngine.Color color1_3 = sprite1_3.color;

        color1_1.a = 0f;
        color1_2.a = 0f;
        color1_3.a = 0f;

        sprite1_1.color = color1_1;
        sprite1_2.color = color1_2;
        sprite1_3.color = color1_3;

        pattern3_1_1.transform.position = new Vector3(-51.6f, 46.6f, 0);
        pattern3_1_1.transform.eulerAngles = new Vector3(0, 0, 225f);

        pattern3_1_2.transform.position = new Vector3(0, 80.5f, 0);
        pattern3_1_2.transform.eulerAngles = new Vector3(0, 0, 180f);

        pattern3_1_3.transform.position = new Vector3(51.6f, 46.6f, 0);
        pattern3_1_3.transform.eulerAngles = new Vector3(0, 0, 135f);

        Vector3 pattern1_endPos = new Vector3(27.2f, -32.2f, 0);
        Vector3 pattern2_endPos = new Vector3(0, -48f, 0);
        Vector3 pattern3_endPos = new Vector3(-27.2f, -32.2f, 0);

        // 3 - 77.3   87.3  0


        #endregion
        float startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1;

            color1_1.a = alpha;
            color1_2.a = alpha;
            color1_3.a = alpha;

            sprite1_1.color = color1_1;
            sprite1_2.color = color1_2;
            sprite1_3.color = color1_3;

            yield return null;
        }

        effect3_1_1 = PatternManager.Instance.StartPattern("PatternEffect");
        effect3_1_2 = PatternManager.Instance.StartPattern("PatternEffect");
        effect3_1_3 = PatternManager.Instance.StartPattern("PatternEffect");

        TrailRender tr1, tr2, tr3;
        tr1 = effect3_1_1.GetComponent<TrailRender>();
        tr1.trailWidthMultiplier = 4f;

        tr2 = effect3_1_2.GetComponent<TrailRender>();
        tr2.trailWidthMultiplier = 4f;

        tr3 = effect3_1_3.GetComponent<TrailRender>();
        tr3.trailWidthMultiplier = 4f;

        effect3_1_1.transform.position = pattern3_1_1.transform.position;
        effect3_1_2.transform.position = pattern3_1_2.transform.position;
        effect3_1_3.transform.position = pattern3_1_3.transform.position;

        Vector3 effect1_endPos = new Vector3(57f, -62f, 0); // 이펙트 도착지점
        Vector3 effect2_endPos = new Vector3(0, -90f, 0); // 이펙트 도착지점
        Vector3 effect3_endPos = new Vector3(-57f, -62f, 0); // 이펙트 도착지점


        startTime = Time.time;
        while (Time.time - startTime < 0.1f)
        {
            TrailRender.overlab_showTrail = true;
            float t = (Time.time - startTime) / 0.1f;

            effect3_1_1.transform.position = Vector3.Lerp(effect3_1_1.transform.position, effect1_endPos, t); // 이동
            effect3_1_2.transform.position = Vector3.Lerp(effect3_1_2.transform.position, effect2_endPos, t); // 이동
            effect3_1_3.transform.position = Vector3.Lerp(effect3_1_3.transform.position, effect3_endPos, t); // 이동

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 1.5f)
        {
            if (Time.time - startTime > 1.0f)
                TrailRender.overlab_showTrail = false;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float t = (Time.time - startTime) / 0.3f;

            pattern3_1_1.transform.position = Vector3.Lerp(pattern3_1_1.transform.position, pattern1_endPos, t); // 이동
            yield return null;
        }
        stone3_1 = PatternManager.Instance.StartPattern("VFX_knight_stone");
        stone3_1.transform.position = new Vector3(27.2f, -32.2f, 0);

        // 모든 파티클의 위치를 부모 오브젝트와 동일하게 설정
        ParticleSystem[] particleSystems1 = stone3_1.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particleSystem in particleSystems1)
        {
            particleSystem.transform.localPosition = Vector3.zero;
        }

        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float t = (Time.time - startTime) / 0.3f;

            pattern3_1_2.transform.position = Vector3.Lerp(pattern3_1_2.transform.position, pattern2_endPos, t); // 이동
            yield return null;
        }
        stone3_2 = PatternManager.Instance.StartPattern("VFX_knight_stone");
        stone3_2.transform.position = new Vector3(0, -48f, 0);
        // 모든 파티클의 위치를 부모 오브젝트와 동일하게 설정
        ParticleSystem[] particleSystems2 = stone3_2.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particleSystem in particleSystems2)
        {
            particleSystem.transform.localPosition = Vector3.zero;
        }

        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float t = (Time.time - startTime) / 0.3f;

            pattern3_1_3.transform.position = Vector3.Lerp(pattern3_1_3.transform.position, pattern3_endPos, t); // 이동
            yield return null;
        }
        stone3_3 = PatternManager.Instance.StartPattern("VFX_knight_stone");
        stone3_3.transform.position = new Vector3(-27.2f, -32.2f, 0);
        // 모든 파티클의 위치를 부모 오브젝트와 동일하게 설정
        ParticleSystem[] particleSystems3 = stone3_3.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particleSystem in particleSystems3)
        {
            particleSystem.transform.localPosition = Vector3.zero;
        }

        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;

            color1_1.a = 1 - alpha;
            color1_2.a = 1 - alpha;
            color1_3.a = 1 - alpha;

            sprite1_1.color = color1_1;
            sprite1_2.color = color1_2;
            sprite1_3.color = color1_3;

            yield return null;
        }
        Destroy(stone3_1);
        Destroy(stone3_2);
        Destroy(stone3_3);

        Destroy(pattern3_1_1);
        Destroy(pattern3_1_2);
        Destroy(pattern3_1_3);

        Destroy(effect3_1_1);
        Destroy(effect3_1_2);
        Destroy(effect3_1_3);

        isPattern = false;
    }

    #endregion
    void overlab_Scp3_1()
    {
        isOverlab = true;
        StartCoroutine(overlab_Scp3_1_Pattern());
    }
    #region overlab_Scp3_1 패턴로직
    IEnumerator overlab_Scp3_1_Pattern()
    {
        #region Setting
        overlab_pattern3_1_1 = PatternManager.Instance.StartPattern("Stage3_Spear");
        overlab_pattern3_1_2 = PatternManager.Instance.StartPattern("Stage3_Spear");
        overlab_pattern3_1_3 = PatternManager.Instance.StartPattern("Stage3_Spear");

        SpriteRenderer sprite1_1 = overlab_pattern3_1_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite1_2 = overlab_pattern3_1_2.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite1_3 = overlab_pattern3_1_3.GetComponent<SpriteRenderer>();

        UnityEngine.Color color1_1 = sprite1_1.color;
        UnityEngine.Color color1_2 = sprite1_2.color;
        UnityEngine.Color color1_3 = sprite1_3.color;

        color1_1.a = 0f;
        color1_2.a = 0f;
        color1_3.a = 0f;

        sprite1_1.color = color1_1;
        sprite1_2.color = color1_2;
        sprite1_3.color = color1_3;

        overlab_pattern3_1_1.transform.position = new Vector3(-51.6f, 46.6f, 0);
        overlab_pattern3_1_1.transform.eulerAngles = new Vector3(0, 0, 225f);

        overlab_pattern3_1_2.transform.position = new Vector3(0, 80.5f, 0);
        overlab_pattern3_1_2.transform.eulerAngles = new Vector3(0, 0, 180f);

        overlab_pattern3_1_3.transform.position = new Vector3(51.6f, 46.6f, 0);
        overlab_pattern3_1_3.transform.eulerAngles = new Vector3(0, 0, 135f);

        Vector3 pattern1_endPos = new Vector3(27.2f, -32.2f, 0);
        Vector3 pattern2_endPos = new Vector3(0, -48f, 0);
        Vector3 pattern3_endPos = new Vector3(-27.2f, -32.2f, 0);

        // 3 - 77.3   87.3  0


        #endregion
        float startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1;

            color1_1.a = alpha;
            color1_2.a = alpha;
            color1_3.a = alpha;

            sprite1_1.color = color1_1;
            sprite1_2.color = color1_2;
            sprite1_3.color = color1_3;

            yield return null;
        }

        overlab_effect3_1_1 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect3_1_2 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect3_1_3 = PatternManager.Instance.StartPattern("PatternEffect");

        TrailRender tr1, tr2, tr3;
        tr1 = overlab_effect3_1_1.GetComponent<TrailRender>();
        tr1.trailWidthMultiplier = 4f;

        tr2 = overlab_effect3_1_2.GetComponent<TrailRender>();
        tr2.trailWidthMultiplier = 4f;

        tr3 = overlab_effect3_1_3.GetComponent<TrailRender>();
        tr3.trailWidthMultiplier = 4f;

        overlab_effect3_1_1.transform.position = overlab_pattern3_1_1.transform.position;
        overlab_effect3_1_2.transform.position = overlab_pattern3_1_2.transform.position;
        overlab_effect3_1_3.transform.position = overlab_pattern3_1_3.transform.position;

        Vector3 effect1_endPos = new Vector3(57f, -62f, 0); // 이펙트 도착지점
        Vector3 effect2_endPos = new Vector3(0, -90f, 0); // 이펙트 도착지점
        Vector3 effect3_endPos = new Vector3(-57f, -62f, 0); // 이펙트 도착지점


        startTime = Time.time;
        while (Time.time - startTime < 0.1f)
        {
            TrailRender.overlab_showTrail = true;
            float t = (Time.time - startTime) / 0.1f;

            overlab_effect3_1_1.transform.position = Vector3.Lerp(overlab_effect3_1_1.transform.position, effect1_endPos, t); // 이동
            overlab_effect3_1_2.transform.position = Vector3.Lerp(overlab_effect3_1_2.transform.position, effect2_endPos, t); // 이동
            overlab_effect3_1_3.transform.position = Vector3.Lerp(overlab_effect3_1_3.transform.position, effect3_endPos, t); // 이동

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 1.5f)
        {
            if (Time.time - startTime > 1.0f)
                TrailRender.overlab_showTrail = false;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float t = (Time.time - startTime) / 0.3f;

            overlab_pattern3_1_1.transform.position = Vector3.Lerp(overlab_pattern3_1_1.transform.position, pattern1_endPos, t); // 이동
            yield return null;
        }
        overlab_stone3_1 = PatternManager.Instance.StartPattern("VFX_knight_stone");
        overlab_stone3_1.transform.position = new Vector3(27.2f, -32.2f, 0);

        // 모든 파티클의 위치를 부모 오브젝트와 동일하게 설정
        ParticleSystem[] particleSystems1 = overlab_stone3_1.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particleSystem in particleSystems1)
        {
            particleSystem.transform.localPosition = Vector3.zero;
        }

        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float t = (Time.time - startTime) / 0.3f;

            overlab_pattern3_1_2.transform.position = Vector3.Lerp(overlab_pattern3_1_2.transform.position, pattern2_endPos, t); // 이동
            yield return null;
        }
        overlab_stone3_2 = PatternManager.Instance.StartPattern("VFX_knight_stone");
        overlab_stone3_2.transform.position = new Vector3(0, -48f, 0);
        // 모든 파티클의 위치를 부모 오브젝트와 동일하게 설정
        ParticleSystem[] particleSystems2 = overlab_stone3_2.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particleSystem in particleSystems2)
        {
            particleSystem.transform.localPosition = Vector3.zero;
        }

        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float t = (Time.time - startTime) / 0.3f;

            overlab_pattern3_1_3.transform.position = Vector3.Lerp(overlab_pattern3_1_3.transform.position, pattern3_endPos, t); // 이동
            yield return null;
        }
        overlab_stone3_3 = PatternManager.Instance.StartPattern("VFX_knight_stone");
        overlab_stone3_3.transform.position = new Vector3(-27.2f, -32.2f, 0);
        // 모든 파티클의 위치를 부모 오브젝트와 동일하게 설정
        ParticleSystem[] particleSystems3 = overlab_stone3_3.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particleSystem in particleSystems3)
        {
            particleSystem.transform.localPosition = Vector3.zero;
        }

        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;

            color1_1.a = 1 - alpha;
            color1_2.a = 1 - alpha;
            color1_3.a = 1 - alpha;

            sprite1_1.color = color1_1;
            sprite1_2.color = color1_2;
            sprite1_3.color = color1_3;

            yield return null;
        }
        Destroy(overlab_stone3_1);
        Destroy(overlab_stone3_2);
        Destroy(overlab_stone3_3);

        Destroy(overlab_pattern3_1_1);
        Destroy(overlab_pattern3_1_2);
        Destroy(overlab_pattern3_1_3);

        Destroy(overlab_effect3_1_1);
        Destroy(overlab_effect3_1_2);
        Destroy(overlab_effect3_1_3);

        isOverlab = false;
    }

    #endregion
    void Scp3_2()
    {
        isPattern = true;
        StartCoroutine(Scp3_2_Pattern());
    }
    #region Scp3_2 패턴로직
    IEnumerator Scp3_2_Pattern()
    {
        #region 초기세팅
        pattern3_2_1 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        pattern3_2_1.transform.position = new Vector3(-28, 70, 0);
        pattern3_2_1.SetActive(true);
        SpriteRenderer spritePattern2_1 = pattern3_2_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_1 = spritePattern2_1.color;
        colorPattern2_1.a = 0f;
        spritePattern2_1.color = colorPattern2_1;

        pattern3_2_2 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        pattern3_2_2.transform.position = new Vector3(-21, 70, 0);
        pattern3_2_2.SetActive(true);
        SpriteRenderer spritePattern2_2 = pattern3_2_2.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_2 = spritePattern2_2.color;
        colorPattern2_2.a = 0f;
        spritePattern2_2.color = colorPattern2_2;

        pattern3_2_3 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        pattern3_2_3.transform.position = new Vector3(-14, 70, 0);
        pattern3_2_3.SetActive(true);
        SpriteRenderer spritePattern2_3 = pattern3_2_3.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_3 = spritePattern2_3.color;
        colorPattern2_3.a = 0f;
        spritePattern2_3.color = colorPattern2_3;


        pattern3_2_4 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        pattern3_2_4.transform.position = new Vector3(-7, 70, 0);
        pattern3_2_4.SetActive(true);
        SpriteRenderer spritePattern2_4 = pattern3_2_4.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_4 = spritePattern2_4.color;
        colorPattern2_4.a = 0f;
        spritePattern2_4.color = colorPattern2_4;

        pattern3_2_5 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        pattern3_2_5.transform.position = new Vector3(0, 70, 0);
        pattern3_2_5.SetActive(true);
        SpriteRenderer spritePattern2_5 = pattern3_2_5.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_5 = spritePattern2_5.color;
        colorPattern2_5.a = 0f;
        spritePattern2_5.color = colorPattern2_5;

        pattern3_2_6 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        pattern3_2_6.transform.position = new Vector3(7, 70, 0);
        pattern3_2_6.SetActive(true);
        SpriteRenderer spritePattern2_6 = pattern3_2_6.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_6 = spritePattern2_6.color;
        colorPattern2_6.a = 0f;
        spritePattern2_6.color = colorPattern2_6;

        pattern3_2_7 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        pattern3_2_7.transform.position = new Vector3(14, 70, 0);
        pattern3_2_7.SetActive(true);
        SpriteRenderer spritePattern2_7 = pattern3_2_7.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_7 = spritePattern2_7.color;
        colorPattern2_7.a = 0f;
        spritePattern2_7.color = colorPattern2_7;

        pattern3_2_8 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        pattern3_2_8.transform.position = new Vector3(21, 70, 0);
        pattern3_2_8.SetActive(true);
        SpriteRenderer spritePattern2_8 = pattern3_2_8.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_8 = spritePattern2_8.color;
        colorPattern2_8.a = 0f;
        spritePattern2_8.color = colorPattern2_8;

        pattern3_2_9 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        pattern3_2_9.transform.position = new Vector3(28, 70, 0);
        pattern3_2_9.SetActive(true);
        SpriteRenderer spritePattern2_9 = pattern3_2_9.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_9 = spritePattern2_9.color;
        colorPattern2_9.a = 0f;
        spritePattern2_9.color = colorPattern2_9;

        effect3_2_1 = PatternManager.Instance.StartPattern("PatternEffect");
        effect3_2_2 = PatternManager.Instance.StartPattern("PatternEffect");
        effect3_2_3 = PatternManager.Instance.StartPattern("PatternEffect");
        effect3_2_4 = PatternManager.Instance.StartPattern("PatternEffect");
        effect3_2_5 = PatternManager.Instance.StartPattern("PatternEffect");
        effect3_2_6 = PatternManager.Instance.StartPattern("PatternEffect");
        effect3_2_7 = PatternManager.Instance.StartPattern("PatternEffect");
        effect3_2_8 = PatternManager.Instance.StartPattern("PatternEffect");
        effect3_2_9 = PatternManager.Instance.StartPattern("PatternEffect");

        TrailRender tr1, tr2, tr3, tr4, tr5, tr6, tr7, tr8, tr9;
        tr1 = effect3_2_1.GetComponent<TrailRender>(); tr3 = effect3_2_3.GetComponent<TrailRender>();
        tr2 = effect3_2_2.GetComponent<TrailRender>(); tr4 = effect3_2_4.GetComponent<TrailRender>();
        tr5 = effect3_2_5.GetComponent<TrailRender>(); tr7 = effect3_2_7.GetComponent<TrailRender>();
        tr6 = effect3_2_6.GetComponent<TrailRender>(); tr8 = effect3_2_8.GetComponent<TrailRender>();
        tr9 = effect3_2_9.GetComponent<TrailRender>();

        tr1.trailWidthMultiplier = 4f; tr3.trailWidthMultiplier = 4f; tr5.trailWidthMultiplier = 4f; tr7.trailWidthMultiplier = 4f; tr9.trailWidthMultiplier = 4f;
        tr2.trailWidthMultiplier = 4f; tr4.trailWidthMultiplier = 4f; tr6.trailWidthMultiplier = 4f; tr8.trailWidthMultiplier = 4f;

        effect3_2_1.transform.position = pattern3_2_1.transform.position;
        effect3_2_2.transform.position = pattern3_2_2.transform.position;
        effect3_2_3.transform.position = pattern3_2_3.transform.position;
        effect3_2_4.transform.position = pattern3_2_4.transform.position;
        effect3_2_5.transform.position = pattern3_2_5.transform.position;
        effect3_2_6.transform.position = pattern3_2_6.transform.position;
        effect3_2_7.transform.position = pattern3_2_7.transform.position;
        effect3_2_8.transform.position = pattern3_2_8.transform.position;
        effect3_2_9.transform.position = pattern3_2_9.transform.position;

        Vector3 effect1_endPos = new Vector3(-28, -62, 0);
        Vector3 effect2_endPos = new Vector3(-21, -62, 0);
        Vector3 effect3_endPos = new Vector3(-14, -62, 0);
        Vector3 effect4_endPos = new Vector3(-7, -62, 0);
        Vector3 effect5_endPos = new Vector3(0, -62, 0);
        Vector3 effect6_endPos = new Vector3(7, -62, 0);
        Vector3 effect7_endPos = new Vector3(14, -62, 0);
        Vector3 effect8_endPos = new Vector3(21, -62, 0);
        Vector3 effect9_endPos = new Vector3(28, -62, 0);

        #endregion
        float startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            yield return null;
        }


        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;
            colorPattern2_1.a = alpha;
            spritePattern2_1.color = colorPattern2_1;

            colorPattern2_2.a = alpha;
            spritePattern2_2.color = colorPattern2_2;

            colorPattern2_3.a = alpha;
            spritePattern2_3.color = colorPattern2_3;

            colorPattern2_4.a = alpha;
            spritePattern2_4.color = colorPattern2_4;

            colorPattern2_5.a = alpha;
            spritePattern2_5.color = colorPattern2_5;

            colorPattern2_6.a = alpha;
            spritePattern2_6.color = colorPattern2_6;

            colorPattern2_7.a = alpha;
            spritePattern2_7.color = colorPattern2_7;

            colorPattern2_8.a = alpha;
            spritePattern2_8.color = colorPattern2_8;

            colorPattern2_9.a = alpha;
            spritePattern2_9.color = colorPattern2_9;

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 0.1f)
        {
            TrailRender.overlab_showTrail = true;
            float t = (Time.time - startTime) / 0.1f;
            effect3_2_1.transform.position = Vector3.Lerp(effect3_2_1.transform.position, effect1_endPos, t); // 이동
            effect3_2_2.transform.position = Vector3.Lerp(effect3_2_2.transform.position, effect2_endPos, t); // 이동
            effect3_2_3.transform.position = Vector3.Lerp(effect3_2_3.transform.position, effect3_endPos, t); // 이동
            effect3_2_4.transform.position = Vector3.Lerp(effect3_2_4.transform.position, effect4_endPos, t); // 이동
            effect3_2_5.transform.position = Vector3.Lerp(effect3_2_5.transform.position, effect5_endPos, t); // 이동
            effect3_2_6.transform.position = Vector3.Lerp(effect3_2_6.transform.position, effect6_endPos, t); // 이동
            effect3_2_7.transform.position = Vector3.Lerp(effect3_2_7.transform.position, effect7_endPos, t); // 이동
            effect3_2_8.transform.position = Vector3.Lerp(effect3_2_8.transform.position, effect8_endPos, t); // 이동
            effect3_2_9.transform.position = Vector3.Lerp(effect3_2_9.transform.position, effect9_endPos, t); // 이동

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 1.5f)
        {
            if (Time.time - startTime > 1.0f)
                TrailRender.overlab_showTrail = false;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 2)
        {
            float totalSpeed = -300f;
            float speed1 = totalSpeed;
            float speed2 = totalSpeed;
            float speed3 = totalSpeed;
            float speed4 = totalSpeed;
            float speed5 = totalSpeed;
            float speed6 = totalSpeed;
            float speed7 = totalSpeed;
            float speed8 = totalSpeed;
            float speed9 = totalSpeed;
            if (Time.time - startTime > 0.1f)
            {
                pattern3_2_1.transform.position += new Vector3(0, speed1 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.2f)
            {
               pattern3_2_2.transform.position += new Vector3(0, speed2 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.3f)
            {
                pattern3_2_3.transform.position += new Vector3(0, speed3 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.4f)
            {
                pattern3_2_4.transform.position += new Vector3(0, speed4 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.5f)
            {
               pattern3_2_5.transform.position += new Vector3(0, speed5 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.6f)
            {
                pattern3_2_6.transform.position += new Vector3(0, speed6 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.7f)
            {
                pattern3_2_7.transform.position += new Vector3(0, speed7 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.8f)
            {
                pattern3_2_8.transform.position += new Vector3(0, speed8 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.9f)
            {
                pattern3_2_9.transform.position += new Vector3(0, speed9 * Time.deltaTime, 0);
            }



            yield return null;

        }
        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;
            colorPattern2_1.a = 1f - alpha;
            spritePattern2_1.color = colorPattern2_1;

            colorPattern2_2.a = 1f - alpha;
            spritePattern2_2.color = colorPattern2_2;

            colorPattern2_3.a = 1f - alpha;
            spritePattern2_3.color = colorPattern2_3;

            colorPattern2_4.a = 1f - alpha;
            spritePattern2_4.color = colorPattern2_4;

            colorPattern2_5.a = 1f - alpha;
            spritePattern2_5.color = colorPattern2_5;

            colorPattern2_6.a = 1f - alpha;
            spritePattern2_6.color = colorPattern2_6;

            colorPattern2_7.a = 1f - alpha;
            spritePattern2_7.color = colorPattern2_7;

            colorPattern2_8.a = 1f - alpha;
            spritePattern2_8.color = colorPattern2_8;

            colorPattern2_9.a = 1f - alpha;
            spritePattern2_9.color = colorPattern2_9;

            yield return null;
        }

        #region 삭제
        Destroy(pattern3_2_1);
        Destroy(pattern3_2_2);
        Destroy(pattern3_2_3);
        Destroy(pattern3_2_4);
        Destroy(pattern3_2_5);
        Destroy(pattern3_2_6);
        Destroy(pattern3_2_7);
        Destroy(pattern3_2_8);
        Destroy(pattern3_2_9);

        Destroy(effect3_2_1);
        Destroy(effect3_2_2);
        Destroy(effect3_2_3);
        Destroy(effect3_2_4);
        Destroy(effect3_2_5);
        Destroy(effect3_2_6);
        Destroy(effect3_2_7);
        Destroy(effect3_2_8);
        Destroy(effect3_2_9);
        #endregion
        isPattern = false;

        yield return null;
    }


    #endregion
    void overlab_Scp3_2()
    {
        isOverlab = true;
        StartCoroutine(overlab_Scp3_2_Pattern());
    }
    #region Scp3_2 패턴로직
    IEnumerator overlab_Scp3_2_Pattern()
    {
        #region 초기세팅
        overlab_pattern3_2_1 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        overlab_pattern3_2_1.transform.position = new Vector3(-28, 70, 0);
        overlab_pattern3_2_1.SetActive(true);
        SpriteRenderer spritePattern2_1 = overlab_pattern3_2_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_1 = spritePattern2_1.color;
        colorPattern2_1.a = 0f;
        spritePattern2_1.color = colorPattern2_1;

        overlab_pattern3_2_2 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        overlab_pattern3_2_2.transform.position = new Vector3(-21, 70, 0);
        overlab_pattern3_2_2.SetActive(true);
        SpriteRenderer spritePattern2_2 = overlab_pattern3_2_2.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_2 = spritePattern2_2.color;
        colorPattern2_2.a = 0f;
        spritePattern2_2.color = colorPattern2_2;

        overlab_pattern3_2_3 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        overlab_pattern3_2_3.transform.position = new Vector3(-14, 70, 0);
        overlab_pattern3_2_3.SetActive(true);
        SpriteRenderer spritePattern2_3 = overlab_pattern3_2_3.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_3 = spritePattern2_3.color;
        colorPattern2_3.a = 0f;
        spritePattern2_3.color = colorPattern2_3;


        overlab_pattern3_2_4 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        overlab_pattern3_2_4.transform.position = new Vector3(-7, 70, 0);
        overlab_pattern3_2_4.SetActive(true);
        SpriteRenderer spritePattern2_4 = overlab_pattern3_2_4.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_4 = spritePattern2_4.color;
        colorPattern2_4.a = 0f;
        spritePattern2_4.color = colorPattern2_4;

       overlab_pattern3_2_5 = PatternManager.Instance.StartPattern("Stage3_Arrow");
       overlab_pattern3_2_5.transform.position = new Vector3(0, 70, 0);
       overlab_pattern3_2_5.SetActive(true);
        SpriteRenderer spritePattern2_5 = overlab_pattern3_2_5.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_5 = spritePattern2_5.color;
        colorPattern2_5.a = 0f;
        spritePattern2_5.color = colorPattern2_5;

        overlab_pattern3_2_6 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        overlab_pattern3_2_6.transform.position = new Vector3(7, 70, 0);
        overlab_pattern3_2_6.SetActive(true);
        SpriteRenderer spritePattern2_6 = overlab_pattern3_2_6.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_6 = spritePattern2_6.color;
        colorPattern2_6.a = 0f;
        spritePattern2_6.color = colorPattern2_6;

        overlab_pattern3_2_7 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        overlab_pattern3_2_7.transform.position = new Vector3(14, 70, 0);
        overlab_pattern3_2_7.SetActive(true);
        SpriteRenderer spritePattern2_7 = overlab_pattern3_2_7.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_7 = spritePattern2_7.color;
        colorPattern2_7.a = 0f;
        spritePattern2_7.color = colorPattern2_7;

        overlab_pattern3_2_8 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        overlab_pattern3_2_8.transform.position = new Vector3(21, 70, 0);
        overlab_pattern3_2_8.SetActive(true);
        SpriteRenderer spritePattern2_8 = overlab_pattern3_2_8.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_8 = spritePattern2_8.color;
        colorPattern2_8.a = 0f;
        spritePattern2_8.color = colorPattern2_8;

        overlab_pattern3_2_9 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        overlab_pattern3_2_9.transform.position = new Vector3(28, 70, 0);
        overlab_pattern3_2_9.SetActive(true);
        SpriteRenderer spritePattern2_9 = overlab_pattern3_2_9.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_9 = spritePattern2_9.color;
        colorPattern2_9.a = 0f;
        spritePattern2_9.color = colorPattern2_9;

        overlab_effect3_2_1 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect3_2_2 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect3_2_3 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect3_2_4 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect3_2_5 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect3_2_6 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect3_2_7 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect3_2_8 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect3_2_9 = PatternManager.Instance.StartPattern("PatternEffect");

        TrailRender tr1, tr2, tr3, tr4, tr5, tr6, tr7, tr8, tr9;
        tr1 = overlab_effect3_2_1.GetComponent<TrailRender>(); tr3 = overlab_effect3_2_3.GetComponent<TrailRender>();
        tr2 = overlab_effect3_2_2.GetComponent<TrailRender>(); tr4 = overlab_effect3_2_4.GetComponent<TrailRender>();
        tr5 = overlab_effect3_2_5.GetComponent<TrailRender>(); tr7 = overlab_effect3_2_7.GetComponent<TrailRender>();
        tr6 = overlab_effect3_2_6.GetComponent<TrailRender>(); tr8 = overlab_effect3_2_8.GetComponent<TrailRender>();
        tr9 = overlab_effect3_2_9.GetComponent<TrailRender>();

        tr1.trailWidthMultiplier = 4f; tr3.trailWidthMultiplier = 4f; tr5.trailWidthMultiplier = 4f; tr7.trailWidthMultiplier = 4f; tr9.trailWidthMultiplier = 4f;
        tr2.trailWidthMultiplier = 4f; tr4.trailWidthMultiplier = 4f; tr6.trailWidthMultiplier = 4f; tr8.trailWidthMultiplier = 4f;

        overlab_effect3_2_1.transform.position = overlab_pattern3_2_1.transform.position;
        overlab_effect3_2_2.transform.position = overlab_pattern3_2_2.transform.position;
        overlab_effect3_2_3.transform.position = overlab_pattern3_2_3.transform.position;
        overlab_effect3_2_4.transform.position = overlab_pattern3_2_4.transform.position;
        overlab_effect3_2_5.transform.position = overlab_pattern3_2_5.transform.position;
        overlab_effect3_2_6.transform.position = overlab_pattern3_2_6.transform.position;
        overlab_effect3_2_7.transform.position = overlab_pattern3_2_7.transform.position;
        overlab_effect3_2_8.transform.position = overlab_pattern3_2_8.transform.position;
        overlab_effect3_2_9.transform.position = overlab_pattern3_2_9.transform.position;

        Vector3 effect1_endPos = new Vector3(-28, -62, 0);
        Vector3 effect2_endPos = new Vector3(-21, -62, 0);
        Vector3 effect3_endPos = new Vector3(-14, -62, 0);
        Vector3 effect4_endPos = new Vector3(-7, -62, 0);
        Vector3 effect5_endPos = new Vector3(0, -62, 0);
        Vector3 effect6_endPos = new Vector3(7, -62, 0);
        Vector3 effect7_endPos = new Vector3(14, -62, 0);
        Vector3 effect8_endPos = new Vector3(21, -62, 0);
        Vector3 effect9_endPos = new Vector3(28, -62, 0);

        #endregion
        float startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            yield return null;
        }


        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;
            colorPattern2_1.a = alpha;
            spritePattern2_1.color = colorPattern2_1;

            colorPattern2_2.a = alpha;
            spritePattern2_2.color = colorPattern2_2;

            colorPattern2_3.a = alpha;
            spritePattern2_3.color = colorPattern2_3;

            colorPattern2_4.a = alpha;
            spritePattern2_4.color = colorPattern2_4;

            colorPattern2_5.a = alpha;
            spritePattern2_5.color = colorPattern2_5;

            colorPattern2_6.a = alpha;
            spritePattern2_6.color = colorPattern2_6;

            colorPattern2_7.a = alpha;
            spritePattern2_7.color = colorPattern2_7;

            colorPattern2_8.a = alpha;
            spritePattern2_8.color = colorPattern2_8;

            colorPattern2_9.a = alpha;
            spritePattern2_9.color = colorPattern2_9;

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 0.1f)
        {
            TrailRender.overlab_showTrail = true;
            float t = (Time.time - startTime) / 0.1f;
            overlab_effect3_2_1.transform.position = Vector3.Lerp(overlab_effect3_2_1.transform.position, effect1_endPos, t); // 이동
            overlab_effect3_2_2.transform.position = Vector3.Lerp(overlab_effect3_2_2.transform.position, effect2_endPos, t); // 이동
            overlab_effect3_2_3.transform.position = Vector3.Lerp(overlab_effect3_2_3.transform.position, effect3_endPos, t); // 이동
            overlab_effect3_2_4.transform.position = Vector3.Lerp(overlab_effect3_2_4.transform.position, effect4_endPos, t); // 이동
            overlab_effect3_2_5.transform.position = Vector3.Lerp(overlab_effect3_2_5.transform.position, effect5_endPos, t); // 이동
            overlab_effect3_2_6.transform.position = Vector3.Lerp(overlab_effect3_2_6.transform.position, effect6_endPos, t); // 이동
            overlab_effect3_2_7.transform.position = Vector3.Lerp(overlab_effect3_2_7.transform.position, effect7_endPos, t); // 이동
            overlab_effect3_2_8.transform.position = Vector3.Lerp(overlab_effect3_2_8.transform.position, effect8_endPos, t); // 이동
            overlab_effect3_2_9.transform.position = Vector3.Lerp(overlab_effect3_2_9.transform.position, effect9_endPos, t); // 이동

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 1.5f)
        {
            if (Time.time - startTime > 1.0f)
                TrailRender.overlab_showTrail = false;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 2)
        {
            float totalSpeed = -300f;
            float speed1 = totalSpeed;
            float speed2 = totalSpeed;
            float speed3 = totalSpeed;
            float speed4 = totalSpeed;
            float speed5 = totalSpeed;
            float speed6 = totalSpeed;
            float speed7 = totalSpeed;
            float speed8 = totalSpeed;
            float speed9 = totalSpeed;
            if (Time.time - startTime > 0.1f)
            {
                overlab_pattern3_2_1.transform.position += new Vector3(0, speed1 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.2f)
            {
                overlab_pattern3_2_2.transform.position += new Vector3(0, speed2 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.3f)
            {
                overlab_pattern3_2_3.transform.position += new Vector3(0, speed3 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.4f)
            {
                overlab_pattern3_2_4.transform.position += new Vector3(0, speed4 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.5f)
            {
                overlab_pattern3_2_5.transform.position += new Vector3(0, speed5 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.6f)
            {
                overlab_pattern3_2_6.transform.position += new Vector3(0, speed6 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.7f)
            {
                overlab_pattern3_2_7.transform.position += new Vector3(0, speed7 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.8f)
            {
                overlab_pattern3_2_8.transform.position += new Vector3(0, speed8 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.9f)
            {
                overlab_pattern3_2_9.transform.position += new Vector3(0, speed9 * Time.deltaTime, 0);
            }



            yield return null;

        }
        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;
            colorPattern2_1.a = 1f - alpha;
            spritePattern2_1.color = colorPattern2_1;

            colorPattern2_2.a = 1f - alpha;
            spritePattern2_2.color = colorPattern2_2;

            colorPattern2_3.a = 1f - alpha;
            spritePattern2_3.color = colorPattern2_3;

            colorPattern2_4.a = 1f - alpha;
            spritePattern2_4.color = colorPattern2_4;

            colorPattern2_5.a = 1f - alpha;
            spritePattern2_5.color = colorPattern2_5;

            colorPattern2_6.a = 1f - alpha;
            spritePattern2_6.color = colorPattern2_6;

            colorPattern2_7.a = 1f - alpha;
            spritePattern2_7.color = colorPattern2_7;

            colorPattern2_8.a = 1f - alpha;
            spritePattern2_8.color = colorPattern2_8;

            colorPattern2_9.a = 1f - alpha;
            spritePattern2_9.color = colorPattern2_9;

            yield return null;
        }

        #region 삭제
        Destroy(overlab_pattern3_2_1);
        Destroy(overlab_pattern3_2_2);
        Destroy(overlab_pattern3_2_3);
        Destroy(overlab_pattern3_2_4);
        Destroy(overlab_pattern3_2_5);
        Destroy(overlab_pattern3_2_6);
        Destroy(overlab_pattern3_2_7);
        Destroy(overlab_pattern3_2_8);
        Destroy(overlab_pattern3_2_9);

        Destroy(overlab_effect3_2_1);
        Destroy(overlab_effect3_2_2);
        Destroy(overlab_effect3_2_3);
        Destroy(overlab_effect3_2_4);
        Destroy(overlab_effect3_2_5);
        Destroy(overlab_effect3_2_6);
        Destroy(overlab_effect3_2_7);
        Destroy(overlab_effect3_2_8);
        Destroy(overlab_effect3_2_9);
        #endregion
        isOverlab = false;

        yield return null;
    }


    #endregion
    void Scp3_4()
    {
        isPattern = true;
        StartCoroutine(Scp3_4_Pattern());
    }
    #region Scp3_4 패턴로직
    IEnumerator Scp3_4_Pattern()
    {
        #region Settgin
        pattern3_4_1 = PatternManager.Instance.StartPattern("Stage3_Cannon");
        pattern3_4_2 = PatternManager.Instance.StartPattern("Stage3_Cannon");
        pattern3_4_3 = PatternManager.Instance.StartPattern("Stage3_Cannon");

        target3_4_1 = PatternManager.Instance.StartPattern("Stage1_GunAim");
        target3_4_2 = PatternManager.Instance.StartPattern("Stage1_GunAim");
        target3_4_3 = PatternManager.Instance.StartPattern("Stage1_GunAim");

        Transform bulletPosTransform1 = pattern3_4_1.transform.Find("BulletPos");
        Transform bulletPosTransform2 = pattern3_4_2.transform.Find("BulletPos");
        Transform bulletPosTransform3 = pattern3_4_3.transform.Find("BulletPos");


        pattern3_4_1.transform.position = new Vector3(-34, 16, 0);
        pattern3_4_2.transform.position = new Vector3(0, 57, 0);
        pattern3_4_3.transform.position = new Vector3(34, 16, 0);

        SpriteRenderer ptn_sprite1 = pattern3_4_1.GetComponent<SpriteRenderer>();
        SpriteRenderer ptn_sprite2 = pattern3_4_2.GetComponent<SpriteRenderer>();
        SpriteRenderer ptn_sprite3 = pattern3_4_3.GetComponent<SpriteRenderer>();

        SpriteRenderer target_sprite1 = target3_4_1.GetComponent<SpriteRenderer>();
        SpriteRenderer target_sprite2 = target3_4_2.GetComponent<SpriteRenderer>();
        SpriteRenderer target_sprite3 = target3_4_3.GetComponent<SpriteRenderer>();

        UnityEngine.Color ptn_color1 = ptn_sprite1.color;
        UnityEngine.Color ptn_color2 = ptn_sprite2.color;
        UnityEngine.Color ptn_color3 = ptn_sprite3.color;

        UnityEngine.Color target_color1 = target_sprite1.color;
        UnityEngine.Color target_color2 = target_sprite2.color;
        UnityEngine.Color target_color3 = target_sprite3.color;

        ptn_color1.a = 0f;
        ptn_color2.a = 0f;
        ptn_color3.a = 0f;
        target_color1.a = 0f;
        target_color2.a = 1f;
        target_color3.a = 1f;

        ptn_sprite1.color = ptn_color1;
        ptn_sprite2.color = ptn_color2;
        ptn_sprite3.color = ptn_color3;
        target_sprite1.color = target_color1;
        target_sprite2.color = target_color2;
        target_sprite3.color = target_color3;

        float targetSizeup = 0.3f;

        #endregion
        target3_4_1.SetActive(true);
        float startTime = Time.time;
        while (Time.time - startTime < 0.5f)
        {
            float alpha = (Time.time - startTime) / 0.5f;

            ptn_color1.a = alpha;
            ptn_color2.a = alpha;
            ptn_color3.a = alpha;

            target_color1.a = alpha;
            target_sprite1.color = target_color1;

            ptn_sprite1.color = ptn_color1;
            ptn_sprite2.color = ptn_color2;
            ptn_sprite3.color = ptn_color3;

            target3_4_1.transform.position = PlayerPos;

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            float addeuler = 0f;

            Vector3 direction1 = PlayerPos - pattern3_4_1.transform.position;
            Quaternion lookRotation1 = Quaternion.LookRotation(Vector3.forward, direction1);
            pattern3_4_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation1.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전

            Vector3 direction2 = PlayerPos - pattern3_4_2.transform.position;
            Quaternion lookRotation2 = Quaternion.LookRotation(Vector3.forward, direction2);
            pattern3_4_2.transform.rotation = Quaternion.Euler(0, 0, lookRotation2.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전

            Vector3 direction3 = PlayerPos - pattern3_4_3.transform.position;
            Quaternion lookRotation3 = Quaternion.LookRotation(Vector3.forward, direction3);
            pattern3_4_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation3.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전



            target3_4_1.transform.position = PlayerPos;
            target3_4_1.transform.localScale += new Vector3(targetSizeup * Time.deltaTime, targetSizeup * Time.deltaTime, 0);


            yield return null;
        }

        target3_4_2.SetActive(true);
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            float addeuler = 0f;

            Vector3 direction2 = PlayerPos - pattern3_4_2.transform.position;
            Quaternion lookRotation2 = Quaternion.LookRotation(Vector3.forward, direction2);
            pattern3_4_2.transform.rotation = Quaternion.Euler(0, 0, lookRotation2.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전

            Vector3 direction3 = PlayerPos - pattern3_4_3.transform.position;
            Quaternion lookRotation3 = Quaternion.LookRotation(Vector3.forward, direction3);
            pattern3_4_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation3.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전



            target3_4_2.transform.position = PlayerPos;
            target3_4_2.transform.localScale += new Vector3(targetSizeup * Time.deltaTime, targetSizeup * Time.deltaTime, 0);
            yield return null;
        }



        target3_4_3.SetActive(true);
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            float addeuler = 0f;
            Vector3 direction3 = PlayerPos - pattern3_4_3.transform.position;
            Quaternion lookRotation3 = Quaternion.LookRotation(Vector3.forward, direction3);
            pattern3_4_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation3.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전



            target3_4_3.transform.position = PlayerPos;
            target3_4_3.transform.localScale += new Vector3(targetSizeup * Time.deltaTime, targetSizeup * Time.deltaTime, 0);
            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 0.5f)
        {
            float alpha = Mathf.PingPong((Time.time - startTime) * 5f, 1f); // 알파값을 PingPong 함수를 사용하여 반짝거리는 효과를 생성

            target_color1.a = alpha;
            target_color2.a = alpha;
            target_color3.a = alpha;

            target_sprite1.color = target_color1;
            target_sprite2.color = target_color2;
            target_sprite3.color = target_color3;


            yield return null;
        }


        float bulletSpeed = 400f;

        GameObject bullet1 = PatternManager.Instance.StartPattern("Stage3_Cannonball");
        GameObject bullet2 = PatternManager.Instance.StartPattern("Stage3_Cannonball");
        GameObject bullet3 = PatternManager.Instance.StartPattern("Stage3_Cannonball");

        bullet1.transform.position = bulletPosTransform1.transform.position;
        bullet2.transform.position = bulletPosTransform2.transform.position;
        bullet3.transform.position = bulletPosTransform3.transform.position;

        bullet1.transform.rotation = pattern3_4_1.transform.rotation;
        bullet2.transform.rotation = pattern3_4_2.transform.rotation;
        bullet3.transform.rotation = pattern3_4_3.transform.rotation;

        ParticleSystem shoot1 = ParticleManager.Instance.StartParticle("VFX_shooting");
        shoot1.transform.position = bulletPosTransform1.transform.position;
        shoot1.transform.localScale = new Vector3(15, 15, 15);
        shoot1.transform.rotation = pattern3_4_1.transform.rotation;
        var main1 = shoot1.main;
        main1.startRotationZ = 0f;



        Vector3 dir1 = target3_4_1.transform.position - pattern3_4_1.transform.position;
        Vector3 dir2 = target3_4_2.transform.position - pattern3_4_2.transform.position;
        Vector3 dir3 = target3_4_3.transform.position - pattern3_4_3.transform.position;


        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            if (Time.time - startTime > 0.5f)
            {
                if (shoot1 != null) Destroy(shoot1.gameObject);
            }
            bullet1.GetComponent<Rigidbody2D>().velocity = dir1.normalized * bulletSpeed;
            yield return null;
        }
        ParticleSystem shoot2 = ParticleManager.Instance.StartParticle("VFX_shooting");
        shoot2.transform.position = bulletPosTransform2.transform.position;
        shoot2.transform.localScale = new Vector3(15, 15, 15);
        shoot2.transform.rotation = pattern3_4_2.transform.rotation;
        var main2 = shoot2.main;
        main2.startRotationZ = 0f;

        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            if (Time.time - startTime > 0.5f)
            {
                if (shoot2 != null) Destroy(shoot2.gameObject);
            }
            bullet2.GetComponent<Rigidbody2D>().velocity = dir2.normalized * bulletSpeed;
            yield return null;
        }
        ParticleSystem shoot3 = ParticleManager.Instance.StartParticle("VFX_shooting");
        shoot3.transform.position = bulletPosTransform3.transform.position;
        shoot3.transform.localScale = new Vector3(15, 15, 15);
        shoot3.transform.rotation = pattern3_4_3.transform.rotation;
        var main3 = shoot3.main;
        main3.startRotationZ = 0f;

        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            if (Time.time - startTime > 0.5f)
            {
                if (shoot3 != null) Destroy(shoot3.gameObject);
            }
            bullet3.GetComponent<Rigidbody2D>().velocity = dir3.normalized * bulletSpeed;
            yield return null;
        }


        startTime = Time.time;
        while (Time.time - startTime < 0.5f)
        {
            float alpha = (Time.time - startTime) / 0.5f;

            ptn_color1.a = 1 - alpha;
            ptn_color2.a = 1 - alpha;
            ptn_color3.a = 1 - alpha;

            target_color1.a = 1 - alpha;
            target_color2.a = 1 - alpha;
            target_color3.a = 1 - alpha;

            ptn_sprite1.color = ptn_color1;
            ptn_sprite2.color = ptn_color2;
            ptn_sprite3.color = ptn_color3;

            target_sprite1.color = target_color1;
            target_sprite2.color = target_color2;
            target_sprite3.color = target_color3;

            yield return null;
        }
        Destroy(bullet1);
        Destroy(bullet2);
        Destroy(bullet3);
        Destroy(pattern3_4_1);
        Destroy(pattern3_4_2);
        Destroy(pattern3_4_3);
        Destroy(target3_4_1);
        Destroy(target3_4_2);
        Destroy(target3_4_3);

        isPattern = false;
    }
    #endregion
    void overlab_Scp3_4()
    {
        isOverlab = true;
        StartCoroutine(overlab_Scp3_4_Pattern());
    }
    #region overlab_Scp3_4 패턴로직
    IEnumerator overlab_Scp3_4_Pattern()
    {
        #region Settgin
        overlab_pattern3_4_1 = PatternManager.Instance.StartPattern("Stage3_Cannon");
        overlab_pattern3_4_2 = PatternManager.Instance.StartPattern("Stage3_Cannon");
        overlab_pattern3_4_3 = PatternManager.Instance.StartPattern("Stage3_Cannon");

        overlab_target3_4_1 = PatternManager.Instance.StartPattern("Stage1_GunAim");
        overlab_target3_4_2 = PatternManager.Instance.StartPattern("Stage1_GunAim");
        overlab_target3_4_3 = PatternManager.Instance.StartPattern("Stage1_GunAim");

        Transform bulletPosTransform1 = overlab_pattern3_4_1.transform.Find("BulletPos");
        Transform bulletPosTransform2 = overlab_pattern3_4_2.transform.Find("BulletPos");
        Transform bulletPosTransform3 = overlab_pattern3_4_3.transform.Find("BulletPos");


        overlab_pattern3_4_1.transform.position = new Vector3(-34, 16, 0);
        overlab_pattern3_4_2.transform.position = new Vector3(0, 57, 0);
        overlab_pattern3_4_3.transform.position = new Vector3(34, 16, 0);

        SpriteRenderer ptn_sprite1 = overlab_pattern3_4_1.GetComponent<SpriteRenderer>();
        SpriteRenderer ptn_sprite2 = overlab_pattern3_4_2.GetComponent<SpriteRenderer>();
        SpriteRenderer ptn_sprite3 = overlab_pattern3_4_3.GetComponent<SpriteRenderer>();

        SpriteRenderer target_sprite1 = overlab_target3_4_1.GetComponent<SpriteRenderer>();
        SpriteRenderer target_sprite2 = overlab_target3_4_2.GetComponent<SpriteRenderer>();
        SpriteRenderer target_sprite3 = overlab_target3_4_3.GetComponent<SpriteRenderer>();

        UnityEngine.Color ptn_color1 = ptn_sprite1.color;
        UnityEngine.Color ptn_color2 = ptn_sprite2.color;
        UnityEngine.Color ptn_color3 = ptn_sprite3.color;

        UnityEngine.Color target_color1 = target_sprite1.color;
        UnityEngine.Color target_color2 = target_sprite2.color;
        UnityEngine.Color target_color3 = target_sprite3.color;

        ptn_color1.a = 0f;
        ptn_color2.a = 0f;
        ptn_color3.a = 0f;
        target_color1.a = 0f;
        target_color2.a = 1f;
        target_color3.a = 1f;

        ptn_sprite1.color = ptn_color1;
        ptn_sprite2.color = ptn_color2;
        ptn_sprite3.color = ptn_color3;
        target_sprite1.color = target_color1;
        target_sprite2.color = target_color2;
        target_sprite3.color = target_color3;

        float targetSizeup = 0.3f;

        #endregion
        overlab_target3_4_1.SetActive(true);
        float startTime = Time.time;
        while (Time.time - startTime < 0.5f)
        {
            float alpha = (Time.time - startTime) / 0.5f;

            ptn_color1.a = alpha;
            ptn_color2.a = alpha;
            ptn_color3.a = alpha;

            target_color1.a = alpha;
            target_sprite1.color = target_color1;

            ptn_sprite1.color = ptn_color1;
            ptn_sprite2.color = ptn_color2;
            ptn_sprite3.color = ptn_color3;

            overlab_target3_4_1.transform.position = PlayerPos;

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            float addeuler = 0f;

            Vector3 direction1 = PlayerPos - overlab_pattern3_4_1.transform.position;
            Quaternion lookRotation1 = Quaternion.LookRotation(Vector3.forward, direction1);
            overlab_pattern3_4_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation1.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전

            Vector3 direction2 = PlayerPos - overlab_pattern3_4_2.transform.position;
            Quaternion lookRotation2 = Quaternion.LookRotation(Vector3.forward, direction2);
            overlab_pattern3_4_2.transform.rotation = Quaternion.Euler(0, 0, lookRotation2.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전

            Vector3 direction3 = PlayerPos - overlab_pattern3_4_3.transform.position;
            Quaternion lookRotation3 = Quaternion.LookRotation(Vector3.forward, direction3);
            overlab_pattern3_4_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation3.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전



            overlab_target3_4_1.transform.position = PlayerPos;
            overlab_target3_4_1.transform.localScale += new Vector3(targetSizeup * Time.deltaTime, targetSizeup * Time.deltaTime, 0);


            yield return null;
        }

        overlab_target3_4_2.SetActive(true);
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            float addeuler = 0f;

            Vector3 direction2 = PlayerPos - overlab_pattern3_4_2.transform.position;
            Quaternion lookRotation2 = Quaternion.LookRotation(Vector3.forward, direction2);
            overlab_pattern3_4_2.transform.rotation = Quaternion.Euler(0, 0, lookRotation2.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전

            Vector3 direction3 = PlayerPos - overlab_pattern3_4_3.transform.position;
            Quaternion lookRotation3 = Quaternion.LookRotation(Vector3.forward, direction3);
            overlab_pattern3_4_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation3.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전



            overlab_target3_4_2.transform.position = PlayerPos;
            overlab_target3_4_2.transform.localScale += new Vector3(targetSizeup * Time.deltaTime, targetSizeup * Time.deltaTime, 0);
            yield return null;
        }



        overlab_target3_4_3.SetActive(true);
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            float addeuler = 0f;
            Vector3 direction3 = PlayerPos - overlab_pattern3_4_3.transform.position;
            Quaternion lookRotation3 = Quaternion.LookRotation(Vector3.forward, direction3);
            overlab_pattern3_4_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation3.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전



            overlab_target3_4_3.transform.position = PlayerPos;
            overlab_target3_4_3.transform.localScale += new Vector3(targetSizeup * Time.deltaTime, targetSizeup * Time.deltaTime, 0);
            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 0.5f)
        {
            float alpha = Mathf.PingPong((Time.time - startTime) * 5f, 1f); // 알파값을 PingPong 함수를 사용하여 반짝거리는 효과를 생성

            target_color1.a = alpha;
            target_color2.a = alpha;
            target_color3.a = alpha;

            target_sprite1.color = target_color1;
            target_sprite2.color = target_color2;
            target_sprite3.color = target_color3;


            yield return null;
        }


        float bulletSpeed = 400f;

        GameObject bullet1 = PatternManager.Instance.StartPattern("Stage3_Cannonball");
        GameObject bullet2 = PatternManager.Instance.StartPattern("Stage3_Cannonball");
        GameObject bullet3 = PatternManager.Instance.StartPattern("Stage3_Cannonball");

        bullet1.transform.position = bulletPosTransform1.transform.position;
        bullet2.transform.position = bulletPosTransform2.transform.position;
        bullet3.transform.position = bulletPosTransform3.transform.position;

        bullet1.transform.rotation = overlab_pattern3_4_1.transform.rotation;
        bullet2.transform.rotation = overlab_pattern3_4_2.transform.rotation;
        bullet3.transform.rotation = overlab_pattern3_4_3.transform.rotation;

        ParticleSystem shoot1 = ParticleManager.Instance.StartParticle("VFX_shooting");
        shoot1.transform.position = bulletPosTransform1.transform.position;
        shoot1.transform.localScale = new Vector3(15, 15, 15);
        shoot1.transform.rotation = overlab_pattern3_4_1.transform.rotation;
        var main1 = shoot1.main;
        main1.startRotationZ = 0f;



        Vector3 dir1 = overlab_target3_4_1.transform.position - overlab_pattern3_4_1.transform.position;
        Vector3 dir2 = overlab_target3_4_2.transform.position - overlab_pattern3_4_2.transform.position;
        Vector3 dir3 = overlab_target3_4_3.transform.position - overlab_pattern3_4_3.transform.position;


        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            if (Time.time - startTime > 0.5f)
            {
                if (shoot1 != null) Destroy(shoot1.gameObject);
            }
            bullet1.GetComponent<Rigidbody2D>().velocity = dir1.normalized * bulletSpeed;
            yield return null;
        }
        ParticleSystem shoot2 = ParticleManager.Instance.StartParticle("VFX_shooting");
        shoot2.transform.position = bulletPosTransform2.transform.position;
        shoot2.transform.localScale = new Vector3(15, 15, 15);
        shoot2.transform.rotation = overlab_pattern3_4_2.transform.rotation;
        var main2 = shoot2.main;
        main2.startRotationZ = 0f;

        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            if (Time.time - startTime > 0.5f)
            {
                if (shoot2 != null) Destroy(shoot2.gameObject);
            }
            bullet2.GetComponent<Rigidbody2D>().velocity = dir2.normalized * bulletSpeed;
            yield return null;
        }
        ParticleSystem shoot3 = ParticleManager.Instance.StartParticle("VFX_shooting");
        shoot3.transform.position = bulletPosTransform3.transform.position;
        shoot3.transform.localScale = new Vector3(15, 15, 15);
        shoot3.transform.rotation = overlab_pattern3_4_3.transform.rotation;
        var main3 = shoot3.main;
        main3.startRotationZ = 0f;

        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            if (Time.time - startTime > 0.5f)
            {
                if (shoot3 != null) Destroy(shoot3.gameObject);
            }
            bullet3.GetComponent<Rigidbody2D>().velocity = dir3.normalized * bulletSpeed;
            yield return null;
        }


        startTime = Time.time;
        while (Time.time - startTime < 0.5f)
        {
            float alpha = (Time.time - startTime) / 0.5f;

            ptn_color1.a = 1 - alpha;
            ptn_color2.a = 1 - alpha;
            ptn_color3.a = 1 - alpha;

            target_color1.a = 1 - alpha;
            target_color2.a = 1 - alpha;
            target_color3.a = 1 - alpha;

            ptn_sprite1.color = ptn_color1;
            ptn_sprite2.color = ptn_color2;
            ptn_sprite3.color = ptn_color3;

            target_sprite1.color = target_color1;
            target_sprite2.color = target_color2;
            target_sprite3.color = target_color3;

            yield return null;
        }
        Destroy(bullet1);
        Destroy(bullet2);
        Destroy(bullet3);
        Destroy(overlab_pattern3_4_1);
        Destroy(overlab_pattern3_4_2);
        Destroy(overlab_pattern3_4_3);
        Destroy(overlab_target3_4_1);
        Destroy(overlab_target3_4_2);
        Destroy(overlab_target3_4_3);

        isOverlab = false;
    }
    #endregion


    void Start()
    {


        Time.timeScale = 1f;
        playerController = Player.GetComponent<PlayerController>();

        cam = Camera.main;
        cameraOriginalPos = cam.transform.position;

        currentTime = 0f;
    }
    IEnumerator CameraShaking(float duration, float magnitude)
    {
        float timer = 0;
        while (timer <= duration)
        {
            cam.transform.localPosition = Random.insideUnitSphere * magnitude + cameraOriginalPos;

            timer += Time.deltaTime;
            yield return null;
        }
        cam.transform.localPosition = cameraOriginalPos;

    } // 카메라 쉐이킹
    float delayTime;
    public static float currentTime = 0f;
    public static float maxTime = 0f; 
    void Update()
    {
        if(! PlayerController.isDie)
          currentTime += Time.deltaTime;
        PlayerPos = Player.transform.position;


        if (delayTime < 2f)
            delayTime += Time.deltaTime;
        else if (delayTime > 2f)
        {
            delayTime = 3f;

            if (!isPattern && !isOverlab)
            {
                randomPattern = Random.Range(1, 13);
                switch (randomPattern)
                {
                    case 1:
                        Scp1_2();
                        randomOverlab = Random.Range(1, 10);
                        switch (randomOverlab)
                        {
                            case 1:
                                overlab_Scp1_3();
                                break;
                            case 2:
                                overlab_Scp1_5();
                                break;
                            case 3:
                                overlab_Scp1_7();
                                break;
                            case 4:
                                overlab_Scp1_8_1();
                                break;
                            case 5:
                                overlab_Scp2_2();
                                break;
                            case 6:
                                overlab_Scp2_4();
                                break;
                            case 7:
                                overlab_Scp3_1();
                                break;
                            case 8:
                                overlab_Scp3_2();
                                break;
                            case 9:
                                overlab_Scp3_4();
                                break;
                        }
                        break;
                    case 2:
                        Scp1_3();
                        randomOverlab = Random.Range(1, 10);
                        switch (randomOverlab)
                        {
                            case 1:
                                overlab_Scp1_2();
                                break;
                            case 2:
                                overlab_Scp1_5();
                                break;
                            case 3:
                                overlab_Scp1_7();
                                break;
                            case 4:
                                overlab_Scp1_8_1();
                                break;
                            case 5:
                                overlab_Scp2_2();
                                break;
                            case 6:
                                overlab_Scp2_4();
                                break;
                            case 7:
                                overlab_Scp3_1();
                                break;
                            case 8:
                                overlab_Scp3_2();
                                break;
                            case 9:
                                overlab_Scp3_4();
                                break;
                        }
                        break;
                    case 3:
                        Scp1_4();
                        break;
                    case 4:
                        Scp1_5();
                        randomOverlab = Random.Range(1, 10);
                        switch (randomOverlab)
                        {
                            case 1:
                                overlab_Scp1_3();
                                break;
                            case 2:
                                overlab_Scp1_2();
                                break;
                            case 3:
                                overlab_Scp1_7();
                                break;
                            case 4:
                                overlab_Scp1_8_1();
                                break;
                            case 5:
                                overlab_Scp2_2();
                                break;
                            case 6:
                                overlab_Scp2_4();
                                break;
                            case 7:
                                overlab_Scp3_1();
                                break;
                            case 8:
                                overlab_Scp3_2();
                                break;    
                            case 9:
                                overlab_Scp3_4();
                                break;
                        }

                        break;
                    case 5:
                        Scp1_7();
                        randomOverlab = Random.Range(1, 10);
                        switch (randomOverlab)
                        {
                            case 1:
                                overlab_Scp1_3();
                                break;
                            case 2:
                                overlab_Scp1_5();
                                break;
                            case 3:
                                overlab_Scp1_2();
                                break;
                            case 4:
                                overlab_Scp1_8_1();
                                break;
                            case 5:
                                overlab_Scp2_2();
                                break;
                            case 6:
                                overlab_Scp2_4();
                                break;
                            case 7:
                                overlab_Scp3_1();
                                break;
                            case 8:
                                overlab_Scp3_2();
                                break;
                            case 9:
                                overlab_Scp3_4();
                                break;
                        }
                        break;
                    case 6:
                        Scp1_8();
                        break;
                    case 8:
                        Scp1_9();
                        break;
                    case 9:
                        Scp2_2();
                        randomOverlab = Random.Range(1, 10);
                        switch (randomOverlab)
                        {
                            case 1:
                                overlab_Scp1_3();
                                break;
                            case 2:
                                overlab_Scp1_5();
                                break;
                            case 3:
                                overlab_Scp1_7();
                                break;
                            case 4:
                                overlab_Scp1_8_1();
                                break;
                            case 5:
                                overlab_Scp1_2();
                                break;
                            case 6:
                                overlab_Scp2_4();
                                break;
                            case 7:
                                overlab_Scp3_1();
                                break;
                            case 8:
                                overlab_Scp3_2();
                                break;
                            case 9:
                                overlab_Scp3_4();
                                break;
                        }
                        break;
                    case 10:
                        Scp2_4();
                        randomOverlab = Random.Range(1, 10);
                        switch (randomOverlab)
                        {
                            case 1:
                                overlab_Scp1_3();
                                break;
                            case 2:
                                overlab_Scp1_5();
                                break;
                            case 3:
                                overlab_Scp1_7();
                                break;
                            case 4:
                                overlab_Scp1_8_1();
                                break;
                            case 5:
                                overlab_Scp2_2();
                                break;
                            case 6:
                                overlab_Scp1_2();
                                break;
                            case 7:
                                overlab_Scp3_1();
                                break;
                            case 8:
                                overlab_Scp3_2();
                                break;
                            case 9:
                                overlab_Scp3_4();
                                break;
                        }
                        break;
                    case 11:
                        Scp3_1();
                        randomOverlab = Random.Range(1, 10);
                        switch (randomOverlab)
                        {
                            case 1:
                                overlab_Scp1_3();
                                break;
                            case 2:
                                overlab_Scp1_5();
                                break;
                            case 3:
                                overlab_Scp1_7();
                                break;
                            case 4:
                                overlab_Scp1_8_1();
                                break;
                            case 5:
                                overlab_Scp2_2();
                                break;
                            case 6:
                                overlab_Scp2_4();
                                break;
                            case 7:
                                overlab_Scp3_1();
                                break;
                            case 8:
                                overlab_Scp1_2();
                                break;
                            case 9:
                                overlab_Scp3_4();
                                break;
                        }
                        break;
                    case 12:
                        Scp3_2();
                        randomOverlab = Random.Range(1, 10);
                        switch (randomOverlab)
                        {
                            case 1:
                                overlab_Scp1_3();
                                break;
                            case 2:
                                overlab_Scp1_5();
                                break;
                            case 3:
                                overlab_Scp1_7();
                                break;
                            case 4:
                                overlab_Scp1_8_1();
                                break;
                            case 5:
                                overlab_Scp2_2();
                                break;
                            case 6:
                                overlab_Scp2_4();
                                break;
                            case 7:
                                overlab_Scp3_1();
                                break;
                            case 8:
                                overlab_Scp1_2();
                                break;
                            case 9:
                                overlab_Scp3_4();
                                break;
                        }
                        break;
                    case 13:
                        Scp3_4();
                        randomOverlab = Random.Range(1, 11);
                        switch (randomOverlab)
                        {
                            case 1:
                                overlab_Scp1_3();
                                break;
                            case 2:
                                overlab_Scp1_5();
                                break;
                            case 3:
                                overlab_Scp1_7();
                                break;
                            case 4:
                                overlab_Scp1_8_1();
                                break;
                            case 5:
                                overlab_Scp2_2();
                                break;
                            case 6:
                                overlab_Scp2_4();
                                break;
                            case 7:
                                overlab_Scp3_1();
                                break;
                            case 8:
                                overlab_Scp3_2();
                                break;
                            case 9:
                                overlab_Scp1_2();
                                break;
                        }
                        break;


                }
            }
        }

        #region Score
        if(PlayerController.isDie)
        {
            if (currentTime > maxTime)
                maxTime = currentTime;
        }
        #endregion
        currentText.text = currentTime.ToString("F2");
        maxText.text = maxTime.ToString("F2");
    }
}