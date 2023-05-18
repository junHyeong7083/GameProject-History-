using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneTemplate;
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

    // ----------------- HitEffect  -----------------
    GameObject PatternEffect;
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
    #region Scp2_4 패턴로직
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

        effect6_1.transform.position = new Vector3(-8, 80, 0);
        Vector3 targetPosition1 = new Vector3(effect6_1.transform.position.x, effect6_1.transform.position.y - 500f, effect6_1.transform.position.z);
        effect6_2.transform.position = new Vector3(8, 80, 0);
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
      
        pattern6_1.transform.position = new Vector3(-8, -2, 0);
        pattern6_2.transform.position = new Vector3( 8, -2, 0);

        SpriteRenderer sprite6_1 = pattern6_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite6_2 = pattern6_2.GetComponent<SpriteRenderer>();

        UnityEngine.Color color6_1 = sprite6_1.color;
        UnityEngine.Color color6_2 = sprite6_2.color;

        effect6_1.transform.position = new Vector3(-16, 80, 0);
        targetPosition1 = new Vector3(effect6_1.transform.position.x, effect6_1.transform.position.y - 500f, effect6_1.transform.position.z);
        effect6_2.transform.position = new Vector3(16, 80, 0);
        targetPosition2 = new Vector3(effect6_2.transform.position.x, effect6_2.transform.position.y - 500f, effect6_2.transform.position.z);

        startTime = Time.time;
        while(Time.time - startTime < 1f)
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

        pattern6_3.transform.position = new Vector3(-16, -2, 0);
        pattern6_4.transform.position = new Vector3(16, -2, 0);

        SpriteRenderer sprite6_3 = pattern6_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite6_4 = pattern6_2.GetComponent<SpriteRenderer>();

        UnityEngine.Color color6_3 = sprite6_3.color;
        UnityEngine.Color color6_4 = sprite6_4.color;


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
