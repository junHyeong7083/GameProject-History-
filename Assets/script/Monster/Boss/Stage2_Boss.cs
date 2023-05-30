using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneTemplate;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;
public class Stage2_Boss : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    private PlayerController playerController;
    public GameObject Player;
    Vector3 PlayerPos;
    Vector3 bossPos;
    Camera cam;
    Vector3 cameraOriginalPos;

    public GameObject ClearPanel;
    Stage2_wolf stage2_Wolf;
    // ----------------- HitEffect  -----------------
    GameObject PatternEffect;
    // ----------------- Pattern 2 -----------------
    GameObject pattern2_1;
    GameObject pattern2_2;

    GameObject effect2_1;
    GameObject effect2_2;

    // -------------- Overlab_Pattern 2 --------------
    GameObject overlab_pattern2_1;
    GameObject overlab_pattern2_2;
    Vector3 PivotPos = new Vector3(0, -2, 0);

    // ----------------- Pattern 3 -----------------
    GameObject pattern3_1;
    GameObject target3;
    // ----------------- Pattern 4 -----------------
    GameObject pattern4_1;
    GameObject pattern4_2;

    GameObject effect4_1;
    GameObject effect4_2;

    // ----------------- Pattern 5 -----------------
    GameObject pattern5_1;
    GameObject pattern5_2;
    GameObject pattern5_3;

    // ----------------- Pattern 6 -----------------
    GameObject pattern6_Hammer; // 바닥에 던질 망치

    GameObject pattern6_1;
    GameObject pattern6_2;
    GameObject pattern6_3;
    GameObject pattern6_4;
    GameObject pattern6_5;
    GameObject pattern6_6;

    GameObject effect6_1;
    GameObject effect6_2;


    // ----------------- Pattern 7 -----------------
    GameObject pattern7;

    // ----------------- Pattern 8 -----------------
    GameObject pattern8_1;
    GameObject pattern8_2;
    GameObject pattern8_3;
    GameObject pattern8_4;

    float toggleTimer = 0;
    float maxtoggleTimer = 20f;
    // ----------------- Pattern 9 -----------------
    GameObject pattern9;


    // ----------------- bool -----------------
    #region Bool
    bool isOverlab = false;
    bool isPattern = false;
    bool isToggle = false;

    int randomPattern;
    int randomOverlab;
    bool isBossDie = false;
    #endregion
    // ----------------- HP -----------------
    #region HP && Die
    public Text currentHp_Text;
    public static float currentHp;
    ParticleSystem hitEffect;

    float bossDieTime = 0f;
    float delayTime;
    #endregion
    void Start()
    {
       // skeletonAnimation = GetComponent<SkeletonAnimation>();

        // 모든 애니메이션 컴포넌트 가져오기
        //tracks = skeletonAnimation.AnimationState.Tracks.Items;
        bossDieTime = 0f;
        currentHp = 2000f;
        isBossDie = false;

        ClearPanel.SetActive(false);

        rigidbody2D = GetComponent<Rigidbody2D>();
        playerController = Player.GetComponent<PlayerController>();

        cam = Camera.main;
        cameraOriginalPos = cam.transform.position;


        PatternEffect = PatternManager.Instance.StartPattern("PatternEffect");
        #region HitEffect Setting
        hitEffect = ParticleManager.Instance.StartParticle("VFX_hit");
        hitEffect.gameObject.SetActive(false);
        #endregion
    }
  
    public void Scp2_1()
    {
        isPattern = true;
        StartCoroutine(Scp2_1_Pattern());
    }
    #region Scp2_1 패턴로직
    IEnumerator Scp2_1_Pattern()
    {
        float startTime = Time.time;
        while (Time.time - startTime < 2)
        {
            // 애니메이션 실행장소
          //  SetCurrentAnimation(AnimState.samurai_anima_katana_roll);

            yield return null;
        }
        Vector3 targetPos = PlayerPos;
        startTime = Time.time;
        float duration = 0.7f; // 이동에 걸리는 시간
        while (Time.time - startTime < 2)
        {
          //  SetCurrentAnimation(AnimState.samurai_anima_pattern_1);
            float t = (Time.time - startTime) / duration;
            rigidbody2D.MovePosition(Vector3.Lerp(bossPos, targetPos, t));

            //   if(Time.time - startTime < 1.5) { }  원위치로 돌아오는 애니메이션 들어갈 자리
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
         //   SetCurrentAnimation(AnimState.samurai_anima_turn_back);
            yield return null;
        }
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
        pattern2_1 = PatternManager.Instance.StartPattern("Test");
        pattern2_2 = PatternManager.Instance.StartPattern("Test");

        effect2_1 = PatternManager.Instance.StartPattern("PatternEffect");
        effect2_2 = PatternManager.Instance.StartPattern("PatternEffect");
     
        TrailRender tr1;
        TrailRender tr2;
        tr1 = effect2_1.GetComponent<TrailRender>();
        tr2 = effect2_2.GetComponent<TrailRender>();
        tr1.trailWidthMultiplier = 4f;
        tr2.trailWidthMultiplier = 4f;

        SpriteRenderer sprite2_2 = pattern2_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite2_3 = pattern2_2.GetComponent<SpriteRenderer>();

        UnityEngine.Color color2_2 = sprite2_2.color;
        UnityEngine.Color color2_3 = sprite2_3.color;

        color2_2.a = 0;
        color2_3.a = 0;

        sprite2_2.color = color2_2;
        sprite2_3.color = color2_3;

        pattern2_1.transform.position = new Vector3(25, 20, 0);
        pattern2_2.transform.position = new Vector3(-25, 13, 0);

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
        while(Time.time - startTime  < 1) // 대기시간
        {
            float alpha = (Time.time - startTime) / 1f;
      
            color2_2.a = alpha;
            color2_3.a = alpha;

            sprite2_2.color = color2_2;
            sprite2_3.color = color2_3;

            yield return null;
        }
        startTime = Time.time;
        while(Time.time - startTime < 1f)
        {
            pattern2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);
            pattern2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);

            yield return null;
        }
        startTime = Time.time;
        while(Time.time - startTime < 0.04f)
        {
            float t = (Time.time - startTime) / 0.04f;
            TrailRender.showTrail = true;

            pattern2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);
            pattern2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);

            Vector3 position1 = Vector3.Lerp(effect_startpattern2_1, effect_endpattern2_1, t) + effect_midpattern2_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            effect2_1.transform.position = position1; // 이동

            Vector3 position2 = Vector3.Lerp(effect_startpattern2_2, effect_endpattern2_2, t) + effect_midpattern2_2 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            effect2_2.transform.position = position2; // 이동

            yield return null;
        }
        startTime = Time.time;
        while(Time.time - startTime < 1f)
        {
            pattern2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);
            pattern2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);

            yield return null;
        }

        startTime = Time.time;
        while(Time.time - startTime < 0.3f)
        {
            TrailRender.showTrail = false;

            yield return null;

        }


        startTime = Time.time;
        while(Time.time - startTime  < duration)
        {
            float t = (Time.time - startTime) / duration;
            pattern2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);  // 뱅글뱅글
            pattern2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);   // 뱅글뱅글

            Vector3 position1 = Vector3.Lerp(startpattern2_1, endpattern2_1, t) + midpattern2_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            pattern2_1.transform.position = position1; // 이동

            Vector3 position2 = Vector3.Lerp(startpattern2_2, endpattern2_2, t) + midpattern2_2 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            pattern2_2.transform.position = position2; // 이동

            yield return null;
        }

        startTime = Time.time;
        while(Time.time - startTime < 3-duration)
        {
            pattern2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);
            pattern2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);

            yield return null;
        }
        Destroy(pattern2_1);
        Destroy(pattern2_2);
        Destroy(effect2_1);
        Destroy(effect2_2);
        isPattern = false;  
    }
    #endregion

    public void Overlab_Scp2_2()
    {
        isOverlab = true;
        StartCoroutine(Overlab_Scp2_2_Pattern());
    }
    #region Overlab_Scp2_2 패턴로직
    IEnumerator Overlab_Scp2_2_Pattern()
    {
        #region Setting
        overlab_pattern2_1 = PatternManager.Instance.StartPattern("Test");
        overlab_pattern2_2 = PatternManager.Instance.StartPattern("Test");

        SpriteRenderer sprite2_2 = overlab_pattern2_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite2_3 = overlab_pattern2_2.GetComponent<SpriteRenderer>();

        UnityEngine.Color color2_2 = sprite2_2.color;
        UnityEngine.Color color2_3 = sprite2_3.color;

        color2_2.a = 0;
        color2_3.a = 0;

        sprite2_2.color = color2_2;
        sprite2_3.color = color2_3;

        overlab_pattern2_1.transform.position = new Vector3(25, 20, 0);
        overlab_pattern2_2.transform.position = new Vector3(-25, 13, 0);

        Vector3 startpattern2_1 = new Vector3(25, 20, 0);
        Vector3 midpattern2_1 = new Vector3(-10, -90, 0);
        Vector3 endpattern2_1 = new Vector3(-35, 75, 0);

        Vector3 startpattern2_2 = new Vector3(-25, 13, 0);
        Vector3 midpattern2_2 = new Vector3(8, -77, 0);
        Vector3 endpattern2_2 = new Vector3(30, 75, 0);
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
            overlab_pattern2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);
            overlab_pattern2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);

            yield return null;
        }


        startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            overlab_pattern2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);
            overlab_pattern2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);

            Vector3 position1 = Vector3.Lerp(startpattern2_1, endpattern2_1, t) + midpattern2_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            overlab_pattern2_1.transform.position = position1; // 이동

            Vector3 position2 = Vector3.Lerp(startpattern2_2, endpattern2_2, t) + midpattern2_2 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            overlab_pattern2_2.transform.position = position2; // 이동

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 3 - duration)
        {
            overlab_pattern2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);
            overlab_pattern2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);

            yield return null;
        }
        Destroy(overlab_pattern2_1);
        Destroy(overlab_pattern2_2);

        isOverlab = false;
    }
    #endregion

    public void Scp2_3()
    {
        isPattern = true;
        StartCoroutine(Scp2_3_Pattern());
    }
    #region Scp2_3 패턴로직
    IEnumerator Scp2_3_Pattern()
    {
        float startTime = Time.time;
        while (Time.time - startTime < 2f)
        {
            // 휘파람 사운드

            yield return null;
        }

        startTime = Time.time;
        #region Setting
        target3 = PatternManager.Instance.StartPattern("test_eyes");
        SpriteRenderer spritetarget = target3.GetComponent<SpriteRenderer>();
       UnityEngine.Color colortarget = spritetarget.color;
        colortarget.a = 0f;

        spritetarget.color = colortarget;

        pattern3_1 = PatternManager.Instance.StartPattern("Stage2_Wolf");
        pattern3_1.transform.position = new Vector3(0, -20, 0);

        stage2_Wolf = pattern3_1.GetComponent<Stage2_wolf>();
        #endregion
        startTime = Time.time;
        while(Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1;
            stage2_Wolf.SetTransparencyForAllSlots(alpha);

            colortarget.a = alpha;
            spritetarget.color = colortarget;

            yield return null;
        }// 투명도 조절

        startTime = Time.time;
        while (Time.time - startTime < 2f)
        {
            Vector3 direction = PlayerPos - pattern3_1.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            pattern3_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 75f);


            target3.transform.position = PlayerPos;
            colortarget.a = 1f;
            spritetarget.color = colortarget;
            yield return null;
        }

        Vector3 targetPosition = PlayerPos;
        Vector3 startPosition = pattern3_1.transform.position;
        startTime = Time.time;
        while(Time.time - startTime < 4)
        {
            stage2_Wolf.SetCurrentAnimation(Stage2_wolf.AnimState_wolf.run);

            float t = (Time.time - startTime) / 4;
            // 시작 위치와 목표 위치 사이의 보간값을 사용하여 새로운 위치 계산
            Vector3 newPosition = Vector3.Lerp(startPosition, targetPosition, t);
            // 오브젝트의 위치를 새로운 위치로 업데이트
            pattern3_1.transform.position = newPosition;

            if(Time.time - startTime > 3.9f)
            {
                stage2_Wolf.SetCurrentAnimation(Stage2_wolf.AnimState_wolf.animation);
            } // 다시 idle


            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 2f)
        {

            Vector3 direction = PlayerPos - pattern3_1.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            pattern3_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 75f);

            target3.transform.position = PlayerPos;
            colortarget.a = 1f;
            spritetarget.color = colortarget;

            yield return null;
        }

        targetPosition = PlayerPos;
        startPosition = pattern3_1.transform.position;
        startTime = Time.time;
        while (Time.time - startTime < 4)
        {
            stage2_Wolf.SetCurrentAnimation(Stage2_wolf.AnimState_wolf.run);

            float t = (Time.time - startTime) / 4;
            // 시작 위치와 목표 위치 사이의 보간값을 사용하여 새로운 위치 계산
            Vector3 newPosition = Vector3.Lerp(startPosition, targetPosition, t);
            // 오브젝트의 위치를 새로운 위치로 업데이트
            pattern3_1.transform.position = newPosition;

            if (Time.time - startTime > 3.9f)
            {
                stage2_Wolf.SetCurrentAnimation(Stage2_wolf.AnimState_wolf.animation);
            } // 다시 idle


            yield return null;
        }


        startTime = Time.time;
        while (Time.time - startTime < 2f)
        {
            Vector3 direction = PlayerPos - pattern3_1.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            pattern3_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 75f);


            target3.transform.position = PlayerPos;
            colortarget.a = 1f;
            spritetarget.color = colortarget;
            yield return null;
        }

        targetPosition = PlayerPos;
        startPosition = pattern3_1.transform.position;
        startTime = Time.time;
        while (Time.time - startTime < 4)
        {
            stage2_Wolf.SetCurrentAnimation(Stage2_wolf.AnimState_wolf.run);

            float t = (Time.time - startTime) / 4;
            // 시작 위치와 목표 위치 사이의 보간값을 사용하여 새로운 위치 계산
            Vector3 newPosition = Vector3.Lerp(startPosition, targetPosition, t);
            // 오브젝트의 위치를 새로운 위치로 업데이트
            pattern3_1.transform.position = newPosition;

            if (Time.time - startTime > 3.9f)
            {
                stage2_Wolf.SetCurrentAnimation(Stage2_wolf.AnimState_wolf.animation);
            } // 다시 idle


            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1;
            float decreaseAlpha = 1 - alpha;
            stage2_Wolf.SetTransparencyForAllSlots(decreaseAlpha);

            yield return null;
        }// 투명도 조절



        isPattern = false;
    }


    #endregion


    public void Scp2_4()
    {
        StartCoroutine(Scp2_4_Pattern());
        isPattern = true;   
    }
    #region Scp2_4 패턴로직
    IEnumerator Scp2_4_Pattern()
    { 
        pattern4_1 = PatternManager.Instance.StartPattern("Test"); // 왼쪽
        pattern4_2 = PatternManager.Instance.StartPattern("Test"); // 오른쪽

        effect4_1 = PatternManager.Instance.StartPattern("PatternEffect");
        effect4_2 = PatternManager.Instance.StartPattern("PatternEffect");

        TrailRender tr1;
        TrailRender tr2;
        tr1 = effect4_1.GetComponent<TrailRender>();
        tr2 = effect4_2.GetComponent<TrailRender>();

        tr1.trailWidthMultiplier = 2f;
        tr2.trailWidthMultiplier = 2f;
        #region Setting
        SpriteRenderer sprite4_1 = pattern4_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite4_2 = pattern4_2.GetComponent<SpriteRenderer>();

        UnityEngine.Color color4_1 = sprite4_1.color;
        UnityEngine.Color color4_2 = sprite4_2.color;

        color4_1.a = 0f;
        color4_2.a = 0f;

        sprite4_1.color= color4_1;
        sprite4_2.color= color4_2;

        pattern4_1.transform.position = new Vector3(-25, 0, 0);
        pattern4_2.transform.position = new Vector3(25, 0, 0); // 시작좌표

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

        Vector3 startboss = bossPos;
        Vector3 endboss = new Vector3(0, 5, 0);
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
        while(Time.time - startTime<0.7f)
        {
            float t = (Time.time - startTime) / 0.7f;
            Vector3 bossposition = Vector3.Lerp(startboss, endboss, t); // 포물선 이동 경로 계산
            this.transform.position = bossposition; // 이동


            pattern4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50);    //뱅글뱅글
            pattern4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50);  //뱅글뱅글

            yield return null;
        }
        startTime = Time.time;
        while(Time.time - startTime < 0.04f)
        {
            float t = (Time.time - startTime) / 0.04f;
            pattern4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50f);
            pattern4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);

            TrailRender.showTrail = true;

            Vector3 position1 = Vector3.Lerp(startpattern4_1, endpattern4_1, t) + midpattern4_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            effect4_1.transform.position = position1; // 이동

            Vector3 position2 = Vector3.Lerp(startpattern4_2, endpattern4_2, t) + midpattern4_2 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            effect4_2.transform.position = position2; // 이동

            yield return null;
        }


        startTime = Time.time;
        while(Time.time - startTime < 1f)
        {
            pattern4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50f);
            pattern4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);

            yield return null;
        }

        startTime = Time.time;
        while(Time.time - startTime < 0.3f)
        {
            TrailRender.showTrail = false;
            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            pattern4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50f);
            pattern4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);

            Vector3 position1 = Vector3.Lerp(startpattern4_1, endpattern4_1, t) + midpattern4_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            pattern4_1.transform.position = position1; // 이동

            Vector3 position2 = Vector3.Lerp(startpattern4_2, endpattern4_2, t) + midpattern4_2 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            pattern4_2.transform.position = position2; // 이동

            yield return null;
        } // 날라감
        startTime = Time.time;
        while (Time.time - startTime < 1f) 
        {
            rotateSpeed -= Time.deltaTime * 20f;
            pattern4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50f);
            pattern4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);
            yield return null;
        }// 잠깐 대기하면서 회전속도감소

        startTime = Time.time;
        while(Time.time - startTime < 0.04f) 
        {
            float t = (Time.time - startTime) / 0.04f;
            TrailRender.showTrail = true;

            pattern4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50f);
            pattern4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);

            Vector3 position1 = Vector3.Lerp(startpattern4_1_1, endpattern4_1_1, t) + midpattern4_1_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            effect4_1.transform.position = position1; // 이동


            Vector3 position2 = Vector3.Lerp(startpattern4_2_1, endpattern4_2_1, t) + midpattern4_2_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            effect4_2.transform.position = position2; // 이동


            yield return null;
        }
        startTime = Time.time;
        while(Time.time - startTime < 1f)
        {
            pattern4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50f);
            pattern4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);

            yield return null;
        }
        startTime = Time.time;
        while(Time.time - startTime < 0.3f)
        {
            TrailRender.showTrail = false;
            yield return null;
        }

        rotateSpeed = 35f;

        startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            pattern4_1.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);
            pattern4_2.transform.eulerAngles += new Vector3(0, 0, +rotateSpeed * Time.deltaTime * 50f);

            Vector3 position1 = Vector3.Lerp(startpattern4_1_1, endpattern4_1_1, t) + midpattern4_1_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            pattern4_1.transform.position = position1; // 이동


            Vector3 position2 = Vector3.Lerp(startpattern4_2_1, endpattern4_2_1, t) + midpattern4_2_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            pattern4_2.transform.position = position2; // 이동


            yield return null;
        } // 돌아옴

        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            pattern4_1.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);
            pattern4_2.transform.eulerAngles += new Vector3(0, 0, +rotateSpeed * Time.deltaTime * 50f);
            yield return null;
        }// 잠깐 대기

        startTime = Time.time;
        while(Time.time - startTime < 1f)
        {
            pattern4_1.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50f);
            pattern4_2.transform.eulerAngles += new Vector3(0, 0, +rotateSpeed * Time.deltaTime * 50f);
            // 투명도 점점0
            float alpha = (Time.time - startTime) / 1f;
            color4_1.a = 1- alpha;
            color4_2.a = 1 - alpha;

            sprite4_1.color = color4_1;
            sprite4_2.color = color4_2;

            yield return null;
        } // 투명도감소

        Destroy(pattern4_1.gameObject);
        Destroy(pattern4_2.gameObject);
        Destroy(effect4_1.gameObject);
        Destroy(effect4_2.gameObject);
        isPattern = false;
    }
    #endregion

    public void Scp2_5()
    {
        isPattern = true;
        StartCoroutine(Scp2_5_Pattern());
    }
    #region Scp2_5 패턴로직
    IEnumerator Scp2_5_Pattern()
    {
        PatternEffect.transform.position = new Vector3(-21, 80, 0);
        Vector3 targetPosition = new Vector3(PatternEffect.transform.position.x, PatternEffect.transform.position.y-500f, PatternEffect.transform.position.z);
        float startTime = Time.time;
        while(Time.time - startTime < 0.2f) 
        {
            TrailRender.showTrail = true;
            float t = (Time.time - startTime) / 0.2f;
            PatternEffect.transform.position = Vector3.Lerp(PatternEffect.transform.position, targetPosition, t);

            yield return null;
        } // 트레일 이동1
       
        startTime = Time.time;
        while(Time.time - startTime < 1f)
        {
            yield return null;
        } // 1경고시간

        startTime = Time.time;
        while(Time.time - startTime < 0.3f)
        {
            TrailRender.showTrail = false;
            yield return null;
        }

        pattern5_1 = PatternManager.Instance.StartPattern("Stage2_LightningEffect");
        pattern5_1.transform.position = new Vector3(-21, -2, 0);
        SpriteRenderer sprite5_1 = pattern5_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color color5_1 = sprite5_1.color;

        PatternEffect.transform.position = new Vector3(0, 80, 0);
        targetPosition = new Vector3(PatternEffect.transform.position.x, PatternEffect.transform.position.y - 500f, PatternEffect.transform.position.z);
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            if(Time.time - startTime < 0.2f)
            {
                TrailRender.showTrail = true;
                float t = (Time.time - startTime) / 0.2f;
                PatternEffect.transform.position = Vector3.Lerp(PatternEffect.transform.position, targetPosition, t); // 두번째 경고선
            }

            color5_1.a = 1f;
            sprite5_1.color = color5_1;

            yield return null;
        }
        Destroy(pattern5_1);

        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            yield return null;
        } // 2경고시간
        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            TrailRender.showTrail = false;
            yield return null;
        }


        pattern5_2 = PatternManager.Instance.StartPattern("Stage2_LightningEffect");
        pattern5_2.transform.position = new Vector3(0, -2, 0);
        SpriteRenderer sprite5_2 = pattern5_2.GetComponent<SpriteRenderer>();
        UnityEngine.Color color5_2 = sprite5_2.color;

        PatternEffect.transform.position = new Vector3(21, 80, 0);
        targetPosition = new Vector3(PatternEffect.transform.position.x, PatternEffect.transform.position.y - 500f, PatternEffect.transform.position.z);

        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            color5_2.a = 1f;
            sprite5_2.color = color5_2;

            if(Time.time - startTime < 0.2f)
            {
                TrailRender.showTrail = true;
                float t = (Time.time - startTime) / 0.2f;
                PatternEffect.transform.position = Vector3.Lerp(PatternEffect.transform.position, targetPosition, t); // 3번째 선
            }

            yield return null;
        }
        Destroy(pattern5_2);

        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            yield return null;
        } // 3경고시간

        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            TrailRender.showTrail = false;
            yield return null;
        }

        pattern5_3 = PatternManager.Instance.StartPattern("Stage2_LightningEffect");
        pattern5_3.transform.position = new Vector3(21, -2, 0);
        SpriteRenderer sprite5_3 = pattern5_3.GetComponent<SpriteRenderer>();
        UnityEngine.Color color5_3 = sprite5_3.color;
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            color5_3.a = 1f;
            sprite5_3.color = color5_3;

            yield return null;
        }
        Destroy(pattern5_3);

        isPattern = false;

    }


    #endregion

    public void Scp2_6()
    {
        isPattern = true;
        StartCoroutine(Scp2_6_Pattern());
    }
    #region Scp2_6 패턴로직
    IEnumerator Scp2_6_Pattern()
    {
        #region Hammer Setting
        pattern6_Hammer = PatternManager.Instance.StartPattern("Stage2_Hammer"); // 인스턴스
        pattern6_Hammer.transform.position = new Vector3(bossPos.x - 4f, bossPos.y + 4f, bossPos.z); // 이 좌표는 보스  애니메이션 재생하면서 수정해야함
        pattern6_Hammer.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);

        effect6_1 = PatternManager.Instance.StartPattern("PatternEffect");
        effect6_2 = PatternManager.Instance.StartPattern("PatternEffect");

        SpriteRenderer sprite_hammer = pattern6_Hammer.GetComponent<SpriteRenderer>();
        UnityEngine.Color color_hammer = sprite_hammer.color;
        color_hammer.a = 0f;
        sprite_hammer.color = color_hammer;

        Vector3 startHammerPos = pattern6_Hammer.transform.position;
        #endregion

        Vector3 target_HammerPosition = new Vector3(0, -50, 0); // 망치가 이동할 포지션
        float startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            // 애니메이션 재생  
            Debug.Log("애니메이션 재생");

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 0.5f)
        {
            // 돌아오는 애니메이션 (a -> idle)
            color_hammer.a = 1f;
            sprite_hammer.color = color_hammer;

            float t = (Time.time - startTime) / 0.5f;
            float rotate_Speed = 240;

            pattern6_Hammer.transform.eulerAngles += new Vector3(0, 0, rotate_Speed * Time.deltaTime);
            pattern6_Hammer.transform.position = Vector3.Lerp(startHammerPos, target_HammerPosition, t);

            yield return null;
        }

        effect6_1.transform.position = new Vector3(-7, 80, 0);
        Vector3 targetPosition1 = new Vector3(effect6_1.transform.position.x, effect6_1.transform.position.y - 500f, effect6_1.transform.position.z);
        effect6_2.transform.position = new Vector3(7, 80, 0);
        Vector3 targetPosition2 = new Vector3(effect6_2.transform.position.x, effect6_2.transform.position.y - 500f, effect6_2.transform.position.z);


        startTime = Time.time;
        while (Time.time - startTime < 0.2f)
        {
            TrailRender.showTrail = true;
            float t = (Time.time - startTime) / 0.2f;
            effect6_1.transform.position = Vector3.Lerp(effect6_1.transform.position, targetPosition1, t);
            effect6_2.transform.position = Vector3.Lerp(effect6_2.transform.position, targetPosition2, t);

            yield return null;
        } // 1 경고선
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            yield return null;
        } // 1경고시간
        startTime = Time.time;
        while(Time.time - startTime < 0.3f)
        {
            TrailRender.showTrail = false;

            yield return null;
        } // 경고선 지우기

        pattern6_1 = PatternManager.Instance.StartPattern("Stage2_LightningEffect");
        pattern6_2 = PatternManager.Instance.StartPattern("Stage2_LightningEffect");
      
        pattern6_1.transform.position = new Vector3(-7, -2, 0);
        pattern6_2.transform.position = new Vector3( 7, -2, 0);

        SpriteRenderer sprite6_1 = pattern6_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite6_2 = pattern6_2.GetComponent<SpriteRenderer>();

        UnityEngine.Color color6_1 = sprite6_1.color;
        UnityEngine.Color color6_2 = sprite6_2.color;

        effect6_1.transform.position = new Vector3(-15, 80, 0);
        targetPosition1 = new Vector3(effect6_1.transform.position.x, effect6_1.transform.position.y - 500f, effect6_1.transform.position.z);
        effect6_2.transform.position = new Vector3(15, 80, 0);
        targetPosition2 = new Vector3(effect6_2.transform.position.x, effect6_2.transform.position.y - 500f, effect6_2.transform.position.z);

        startTime = Time.time;
       // StartCoroutine(CameraShaking(0.1f, 0.5f));
        while(Time.time - startTime < 1.2f)
        {
            color6_1.a = 1f;
            color6_2.a = 1f;

            sprite6_1.color = color6_1;
            sprite6_2.color = color6_2;


            if(Time.time - startTime < 0.2f)
            {
                float t = (Time.time - startTime) / 0.2f;
                TrailRender.showTrail = true;
                effect6_1.transform.position = Vector3.Lerp(effect6_1.transform.position, targetPosition1, t);
                effect6_2.transform.position = Vector3.Lerp(effect6_2.transform.position, targetPosition2, t);
            }
            yield return null;
        }
        startTime= Time.time;
        while(Time.time - startTime < 0.3f)
        {
            TrailRender.showTrail = false;

            yield return null;
        }

        pattern6_3 = PatternManager.Instance.StartPattern("Stage2_LightningEffect");
        pattern6_4 = PatternManager.Instance.StartPattern("Stage2_LightningEffect");

        pattern6_3.transform.position = new Vector3(-15, -2, 0);
        pattern6_4.transform.position = new Vector3(15, -2, 0);

        SpriteRenderer sprite6_3 = pattern6_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite6_4 = pattern6_2.GetComponent<SpriteRenderer>();

        UnityEngine.Color color6_3 = sprite6_3.color;
        UnityEngine.Color color6_4 = sprite6_4.color;

        effect6_1.transform.position = new Vector3(-24, 80, 0);
        targetPosition1 = new Vector3(effect6_1.transform.position.x, effect6_1.transform.position.y - 500f, effect6_1.transform.position.z);
        effect6_2.transform.position = new Vector3(24, 80, 0);
        targetPosition2 = new Vector3(effect6_2.transform.position.x, effect6_2.transform.position.y - 500f, effect6_2.transform.position.z);

        startTime = Time.time;
       // StartCoroutine(CameraShaking(0.1f, 0.5f));
        while (Time.time - startTime < 1.2f)
        {
            color6_3.a = 1f;
            color6_4.a = 1f;

            sprite6_3.color = color6_3;
            sprite6_4.color = color6_4;

            if (Time.time - startTime < 0.2f)
            {
                float t = (Time.time - startTime) / 0.2f;
                TrailRender.showTrail = true;
                effect6_1.transform.position = Vector3.Lerp(effect6_1.transform.position, targetPosition1, t);
                effect6_2.transform.position = Vector3.Lerp(effect6_2.transform.position, targetPosition2, t);
            }

            yield return null;
        }

        startTime = Time.time;
        while(Time.time - startTime  < 0.3f)
        {
            TrailRender.showTrail = false;

            yield return null;
        }
        pattern6_5 = PatternManager.Instance.StartPattern("Stage2_LightningEffect");
        pattern6_6 = PatternManager.Instance.StartPattern("Stage2_LightningEffect");

        pattern6_5.transform.position = new Vector3(-24, -2, 0);
        pattern6_6.transform.position = new Vector3(24, -2, 0);

        SpriteRenderer sprite6_5 = pattern6_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite6_6 = pattern6_2.GetComponent<SpriteRenderer>();

        UnityEngine.Color color6_5 = sprite6_5.color;
        UnityEngine.Color color6_6 = sprite6_6.color;

        startTime = Time.time;
      //  StartCoroutine(CameraShaking(0.1f, 0.5f));
        while (Time.time - startTime < 0.8f) // 일부로 다음패턴 넘어가기 빠르게 시간을 줄일까 고민중
        {
            color6_5.a = 1f;
            color6_6.a = 1f;

            sprite6_5.color = color6_5;
            sprite6_6.color = color6_6;

            yield return null;
        }


        isPattern = false; // 패턴끝
    }
    #endregion

    public void Scp2_7()
    {
        isPattern = true;
        StartCoroutine(Scp2_7_Pattern());
    }
    #region Scp2_7 패턴로직
    IEnumerator Scp2_7_Pattern()
    {
        pattern7 = PatternManager.Instance.StartPattern("Stage2_Hammer");
        #region Setting
        pattern7.transform.position = new Vector3(bossPos.x - 5f, bossPos.y, bossPos.z);
       
        SpriteRenderer sprite7 = pattern7.GetComponent<SpriteRenderer>();
        UnityEngine.Color color7 = sprite7.color;
        color7.a = 0;
        sprite7.color = color7;


        Vector3 startpattern7_1 = pattern7.transform.position;
        Vector3 midpattern7_1 = new Vector3(-11, 60, 0);
        Vector3 endpattern7_1 = new Vector3(-50, 40, 0);
        #endregion
        float rotateSpeed = 35;
        float startTime = Time.time;
        while(Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;

            color7.a = alpha;
            sprite7.color = color7;

            yield return null;
        } // 투명도 조절 오브젝트 등장
        startTime = Time.time;
        while(Time.time - startTime < 2)
        {
            // 애니메이션 재생
            Debug.Log("애니메이션");
            if(Time.time - startTime > 0.7f)
            {
                float offset = 1f;
                pattern7.transform.localScale += new Vector3(offset, offset, offset) * Time.deltaTime;
                if(Time.time - startTime > 1.2f)
                {
                    pattern7.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * 50f * Time.deltaTime);
                }
            }

            yield return null;
        } // 애니메이션, 헤머 사이즈업
        startTime = Time.time;
        float duration = 1.5f;
        while(Time.time - startTime < duration)
        {
            pattern7.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * 50f * Time.deltaTime);
            float t = (Time.time - startTime) / duration;
            Vector3 position1 = Vector3.Lerp(startpattern7_1, endpattern7_1, t) + midpattern7_1 * 4 * t * (1 - t); // 포물선 이동 경로 계산
            pattern7.transform.position = position1;

            yield return null;
        } // 헤머 포물선

        PatternEffect.transform.position = new Vector3(pattern7.transform.position.x - 50f, pattern7.transform.position.y, pattern7.transform.position.z);
        Vector3 targetPosition = new Vector3(PatternEffect.transform.position.x + 500, PatternEffect.transform.position.y, PatternEffect.transform.position.z);
        startTime = Time.time;
        while (Time.time - startTime < 0.2f)
        {
            TrailRender.showTrail = true;
            float t = (Time.time - startTime) / 0.2f;
            PatternEffect.transform.position = Vector3.Lerp(PatternEffect.transform.position, targetPosition, t);
            yield return null;
        } // 트레일 이동

        float effectTime = 1f;
        startTime = Time.time;
        while (Time.time - startTime < effectTime)
        {
            yield return null;
        } // 이펙트 보여주는시간


        pattern7.transform.eulerAngles = new Vector3(0, 0, 45);
        rotateSpeed = 720f;
        startTime = Time.time;
        while(Time.time - startTime < 3 )
        {
            TrailRender.showTrail = false;
            float offset = 60f * Time.deltaTime;
            pattern7.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime);
            pattern7.transform.position += new Vector3(offset * 2, 0, 0);
       

            yield return null;
        } // 왼-> 오
       
        pattern7.transform.position = new Vector3(50, 0, 0);
        PatternEffect.transform.position = pattern7.transform.position;
        targetPosition = new Vector3(PatternEffect.transform.position.x - 500, PatternEffect.transform.position.y, PatternEffect.transform.position.z);
        startTime = Time.time;
        while (Time.time - startTime < 0.2f)
        {
            TrailRender.showTrail = true;
            float t = (Time.time - startTime) / 0.2f;
            PatternEffect.transform.position = Vector3.Lerp(PatternEffect.transform.position, targetPosition, t);
            yield return null;
        } // 트레일 이동

        startTime = Time.time;
        while(Time.time - startTime < effectTime)
        {
            yield return null;
        } // 이펙트 보여줌

        pattern7.transform.eulerAngles = new Vector3(0, 0, -45);

        startTime = Time.time;
        while(Time.time - startTime <3)
        {
            TrailRender.showTrail = false;
            float offset = -60f * Time.deltaTime;
            pattern7.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime);
            pattern7.transform.position += new Vector3(offset * 2, 0, 0);
            yield return null;
        } // 오 -> 왼

        pattern7.transform.position = new Vector3(-55,-40, 0);
        PatternEffect.transform.position = new Vector3(pattern7.transform.position.x - 50f, pattern7.transform.position.y, pattern7.transform.position.z);
        targetPosition = new Vector3(PatternEffect.transform.position.x + 500, PatternEffect.transform.position.y, PatternEffect.transform.position.z);
        startTime = Time.time;
        while (Time.time - startTime < 0.2f)
        {
            TrailRender.showTrail = true;
            float t = (Time.time - startTime) / 0.2f;
            PatternEffect.transform.position = Vector3.Lerp(PatternEffect.transform.position, targetPosition, t);
            yield return null;
        } // 트레일

        startTime = Time.time;
        while (Time.time - startTime < effectTime)
        {
            yield return null;
        }

        pattern7.transform.eulerAngles = new Vector3(0, 0, 45);

        while (Time.time - startTime < 3)
        {
            TrailRender.showTrail = false;
            float offset = 60f * Time.deltaTime;
            pattern7.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime);

            pattern7.transform.position += new Vector3(offset * 2, 0, 0);
             

            yield return null;
        } // 왼-> 오
        Destroy(pattern7.gameObject);
        isPattern = false;
    }
    #endregion

    public void Scp2_8()
    {
        isToggle = true;
        StartCoroutine(Scp2_8_Pattern());
    }
    #region Scp2_8 패턴로직
    IEnumerator Scp2_8_Pattern()
    {
        #region Setting
        pattern8_1 = PatternManager.Instance.StartPattern("Stage2_Tide");
        pattern8_2 = PatternManager.Instance.StartPattern("Stage2_Tide");
        pattern8_3 = PatternManager.Instance.StartPattern("Stage2_Tide");
        pattern8_4 = PatternManager.Instance.StartPattern("Stage2_Tide");

        pattern8_1.transform.position = new Vector3(1.5f, 0, 0); // 왼
        pattern8_1.transform.eulerAngles = new Vector3(0, 0, 180f);

        pattern8_2.transform.position = new Vector3(0, -28f, 0);// 아래
        pattern8_2.transform.eulerAngles = new Vector3(0, 0, 90f);

        pattern8_3.transform.position = new Vector3(-1.5f, 0, 0); // 오른

        pattern8_4.transform.position = new Vector3(0, 28f, 0); // 위
        pattern8_4.transform.eulerAngles = new Vector3(0, 0, 270f);

        SpriteRenderer sprite8_1 = pattern8_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite8_2 = pattern8_2.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite8_3 = pattern8_3.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite8_4 = pattern8_4.GetComponent<SpriteRenderer>();

        UnityEngine.Color color8_1 = sprite8_1.color;
        UnityEngine.Color color8_2 = sprite8_2.color;
        UnityEngine.Color color8_3 = sprite8_3.color;
        UnityEngine.Color color8_4 = sprite8_4.color;
        #endregion
        float startTime = Time.time;
        while(Time.time-  startTime < 1f)
        {
            float alpha = (Time.time - startTime) / 1f;
            color8_1.a = alpha;
            color8_2.a = alpha;
            color8_3.a = alpha;
            color8_4.a = alpha;

            sprite8_1.color = color8_1;
            sprite8_2.color = color8_2;
            sprite8_3.color = color8_3;
            sprite8_4.color = color8_4;

            yield return null;
        }
        startTime = Time.time;
        while(Time.time- startTime < 1)
        {
            yield return null;
        }
        int randValue;
        randValue = Random.Range(1, 3);
        switch(randValue)
        {
            case 1:
                Scp2_9();
                break;
            case 2:
                startTime = Time.time;
                while (Time.time - startTime < 9)
                {
                    yield return null;
                }

                startTime = Time.time;
                while (Time.time - startTime < 0.5)
                {
                    float alpha = (Time.time - startTime) / 0.5f;

                    color8_1.a = 1 - alpha;
                    color8_2.a = 1 - alpha;
                    color8_3.a = 1 - alpha;
                    color8_4.a = 1 - alpha;

                    sprite8_1.color = color8_1;
                    sprite8_2.color = color8_2;
                    sprite8_3.color = color8_3;
                    sprite8_4.color = color8_4;

                    yield return null;
                } // 투명도 다시 0되게
                Destroy(pattern8_1.gameObject);
                Destroy(pattern8_2.gameObject);
                Destroy(pattern8_3.gameObject);
                Destroy(pattern8_4.gameObject);

                isToggle = false;
                break;

        }
    }
    #endregion
    public void Scp2_9()
    {
        isToggle = true;
        StartCoroutine(Scp2_9_Pattern());
    }
    #region
    IEnumerator Scp2_9_Pattern()
    {
        int randValue;
        randValue = Random.Range(1, 5);

        pattern9 = PatternManager.Instance.StartPattern("Stage2_Ship");
        SpriteRenderer sprite9 = pattern9.GetComponent<SpriteRenderer>();

        SpriteRenderer sprite8_1 = pattern8_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite8_2 = pattern8_2.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite8_3 = pattern8_3.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite8_4 = pattern8_4.GetComponent<SpriteRenderer>();

        UnityEngine.Color color8_1 = sprite8_1.color;
        UnityEngine.Color color8_2 = sprite8_2.color;
        UnityEngine.Color color8_3 = sprite8_3.color;
        UnityEngine.Color color8_4 = sprite8_4.color;

        UnityEngine.Color color9 = sprite9.color;
        float startTime = Time.time;
        switch(randValue)
        {
            case 1: // 왼쪽
                pattern9.transform.position = new Vector3(-16, 52, 0);
                pattern9.transform.eulerAngles = new Vector3(0, 0, 270);
                while (Time.time - startTime < 1)
                {
                    float alpha = (Time.time - startTime) / 1;
                    color9.a = alpha;
                    sprite9.color = color9;

                    yield return null;
                }

                Vector3 startPos1 = pattern9.transform.position; // 출발지점
                Vector3 targetPos1 = new Vector3(-16, -46, 0); // 도착지점
                startTime = Time.time;
                while(Time.time - startTime < 8)
                {
                    if(Time.time - startTime < 4)
                    {
                        float t = (Time.time - startTime) / 4f;
                        pattern9.transform.position = Vector3.Lerp(startPos1, targetPos1, t);

                        // X 좌표에 3씩 더하고 빼기
                        float offset = Mathf.PingPong(Time.time - startTime, 1f) * 3f - 2f;
                        pattern9.transform.position += new Vector3(offset, 0f, 0f);
                    }

  
                    yield return null;
                }

                startTime = Time.time;
                while (Time.time - startTime < 1)
                {
                    float alpha = (Time.time - startTime) / 1f;

                    color9.a = 1 - alpha;
                    sprite9.color = color9;


                    color8_1.a = 1 - alpha;
                    color8_2.a = 1 - alpha;
                    color8_3.a = 1 - alpha;
                    color8_4.a = 1 - alpha;

                    sprite8_1.color = color8_1;
                    sprite8_2.color = color8_2;
                    sprite8_3.color = color8_3;
                    sprite8_4.color = color8_4;


                    yield return null;
                }

                break;

            case 2: // 아래
                pattern9.transform.position = new Vector3(-27, -42, 0);
                pattern9.transform.eulerAngles = new Vector3(0, 0, 0);
                while (Time.time - startTime < 1)
                {
                    float alpha = (Time.time - startTime) / 1;
                    color9.a = alpha;
                    sprite9.color = color9;

                    yield return null;
                }

                Vector3 startPos2 = pattern9.transform.position; // 출발지점
                Vector3 targetPos2 = new Vector3(22, -42, 0); // 도착지점
                startTime = Time.time;
                while (Time.time - startTime < 8)
                {
                    if (Time.time - startTime < 4)
                    {
                        float t = (Time.time - startTime) / 4f;
                        pattern9.transform.position = Vector3.Lerp(startPos2, targetPos2, t);

                        // X 좌표에 3씩 더하고 빼기
                        float offset = Mathf.PingPong(Time.time - startTime, 1f) * 3f - 2f;
                        pattern9.transform.position += new Vector3(0f, offset, 0f);
                    }

                    yield return null;
                }

                startTime = Time.time;
                while (Time.time - startTime < 1)
                {
                    float alpha = (Time.time - startTime) / 1f;

                    color9.a = 1 - alpha;
                    sprite9.color = color9;


                    color8_1.a = 1 - alpha;
                    color8_2.a = 1 - alpha;
                    color8_3.a = 1 - alpha;
                    color8_4.a = 1 - alpha;

                    sprite8_1.color = color8_1;
                    sprite8_2.color = color8_2;
                    sprite8_3.color = color8_3;
                    sprite8_4.color = color8_4;


                    yield return null;
                }

                break;

            case 3: // 오른쪽
                pattern9.transform.position = new Vector3(16, -52, 0);
                pattern9.transform.eulerAngles = new Vector3(0, 0, 90);
                while (Time.time - startTime < 1)
                {
                    float alpha = (Time.time - startTime) / 1;
                    color9.a = alpha;
                    sprite9.color = color9;

                    yield return null;
                }

                Vector3 startPos3 = pattern9.transform.position; // 출발지점
                Vector3 targetPos3 = new Vector3(16, 46, 0); // 도착지점
                startTime = Time.time;
                while (Time.time - startTime < 8)
                {
                    if (Time.time - startTime < 4)
                    {
                        float t = (Time.time - startTime) / 4f;
                        pattern9.transform.position = Vector3.Lerp(startPos3, targetPos3, t);

                        // X 좌표에 3씩 더하고 빼기
                        float offset = Mathf.PingPong(Time.time - startTime, 1f) * 3f - 2f;
                        pattern9.transform.position += new Vector3(offset, 0f, 0f);
                    }


                    yield return null;
                }

                startTime = Time.time;
                while (Time.time - startTime < 1)
                {
                    float alpha = (Time.time - startTime) / 1f;

                    color9.a = 1 - alpha;
                    sprite9.color = color9;


                    color8_1.a = 1 - alpha;
                    color8_2.a = 1 - alpha;
                    color8_3.a = 1 - alpha;
                    color8_4.a = 1 - alpha;

                    sprite8_1.color = color8_1;
                    sprite8_2.color = color8_2;
                    sprite8_3.color = color8_3;
                    sprite8_4.color = color8_4;


                    yield return null;
                }

                break;

            case 4: // 우ㅢ;쪽
                pattern9.transform.position = new Vector3(27, 42, 0);
                pattern9.transform.eulerAngles = new Vector3(0, 0, 180);
                while (Time.time - startTime < 1)
                {
                    float alpha = (Time.time - startTime) / 1;
                    color9.a = alpha;
                    sprite9.color = color9;

                    yield return null;
                }

                Vector3 startPos4 = pattern9.transform.position; // 출발지점
                Vector3 targetPos4 = new Vector3(-22, 42, 0); // 도착지점
                startTime = Time.time;
                while (Time.time - startTime < 8)
                {
                    if (Time.time - startTime < 4)
                    {
                        float t = (Time.time - startTime) / 4f;
                        pattern9.transform.position = Vector3.Lerp(startPos4, targetPos4, t);

                        // X 좌표에 3씩 더하고 빼기
                        float offset = Mathf.PingPong(Time.time - startTime, 1f) * 3f - 2f;
                        pattern9.transform.position += new Vector3(0, offset, 0f);
                    }

                    yield return null;
                }

                startTime = Time.time;
                while (Time.time - startTime < 1)
                {
                    float alpha = (Time.time - startTime) / 1f;

                    color9.a = 1 - alpha;
                    sprite9.color = color9;


                    color8_1.a = 1 - alpha;
                    color8_2.a = 1 - alpha;
                    color8_3.a = 1 - alpha;
                    color8_4.a = 1 - alpha;

                    sprite8_1.color = color8_1;
                    sprite8_2.color = color8_2;
                    sprite8_3.color = color8_3;
                    sprite8_4.color = color8_4;


                    yield return null;
                }

                break;

        }
        Destroy(pattern8_1.gameObject);
        Destroy(pattern8_2.gameObject);
        Destroy(pattern8_3.gameObject);
        Destroy(pattern8_4.gameObject);

        Destroy(pattern9.gameObject);

        isToggle = false;
    }
    #endregion


    private void Update()
    {
        PlayerPos = Player.transform.position;
        bossPos = this.transform.position;
        if (currentHp <= 0)
        {
            currentHp = 0;
            isBossDie = true;
            StopAllCoroutines();
        //    SetCurrentAnimation(AnimState.samurai_anima_death_suiside);  사망 애니메이션
            if (isBossDie)
            {
                bossDieTime += Time.deltaTime;
                if (bossDieTime >= 3f)
                {
                    Time.timeScale = 0f;
                    ClearPanel.SetActive(true);
                }
                TitleSelect.clearCheck = 2;
                Debug.Log("checkInt" + TitleSelect.clearCheck);
            }
        }


        #region Scp2_8, Scp2_9
        if (toggleTimer > maxtoggleTimer) // checkToggle = 30f; 
        {
            if(isToggle)
            {
                Scp2_8();
                toggleTimer = 0; // 다시 토글타이머 초기화
            }
            Scp2_8();
            toggleTimer = 0; // 다시 토글타이머 초기화
        }
        if(!isToggle)
           toggleTimer += Time.deltaTime; // 시작과 동시에 토글타이머가 돌아감
        #endregion
    }
}
