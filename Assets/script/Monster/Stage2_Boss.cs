using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Stage1_Boss;

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
    // ----------------- Pattern 2 -----------------
    GameObject pattern2_1;
    GameObject pattern2_2;

    // -------------- Overlab_Pattern 2 --------------
    GameObject overlab_pattern2_1;
    GameObject overlab_pattern2_2;
    Vector3 PivotPos = new Vector3(0, -2, 0);

    // ----------------- Pattern 3 -----------------
    GameObject pattern3_1;

    // ----------------- Pattern 4 -----------------
    GameObject pattern4_1;
    GameObject pattern4_2;
    // ----------------- bool -----------------
    #region Bool
    bool isOverlab = false;
    bool isPattern = false;
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
        while(Time.time - startTime  < duration)
        {
            float t = (Time.time - startTime) / duration;
            pattern2_1.transform.eulerAngles += new Vector3(0, 0, -euler * Time.deltaTime * 50);
            pattern2_2.transform.eulerAngles += new Vector3(0, 0, euler * Time.deltaTime * 50);

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


    #region 유기
    public void Scp2_3()
    {
        isPattern = true;
    }
    IEnumerator Scp2_3_Pattern()
    {
        float startTime = Time.time;
        while(Time.time - startTime < 2f)
        {
            // 휘파람 사운드
            yield return null;
        }
        yield return null;
    }
    #endregion
    public void Scp2_4()
    {
        StartCoroutine(Scp2_4_Pattern());
        isPattern = true;   
    }
    IEnumerator Scp2_4_Pattern()
    { 
        pattern4_1 = PatternManager.Instance.StartPattern("Test"); // 왼쪽
        pattern4_2 = PatternManager.Instance.StartPattern("Test"); // 오른쪽
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


            pattern4_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime * 50);
            pattern4_2.transform.eulerAngles += new Vector3(0, 0, -rotateSpeed * Time.deltaTime * 50);

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
        isPattern = false;
    }

    private void Update()
    {
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
    }
}
