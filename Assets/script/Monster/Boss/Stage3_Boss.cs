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
public class Stage3_Boss : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    private PlayerController playerController;
    public GameObject Player;
    Vector3 PlayerPos;
    Vector3 bossPos;
    Camera cam;
    Vector3 cameraOriginalPos;

    public GameObject ClearPanel;

    // --------------- Pattern 1 ---------------
    GameObject pattern1_1;
    GameObject pattern1_2;
    GameObject pattern1_3;

    GameObject effect1_1;
    GameObject effect1_2;
    GameObject effect1_3;

    // --------------- Pattern 2 ---------------
    GameObject pattern2_1;
    GameObject pattern2_2;
    GameObject pattern2_3;
    GameObject pattern2_4;
    GameObject pattern2_5;
    GameObject pattern2_6;
    GameObject pattern2_7;
    GameObject pattern2_8;
    GameObject pattern2_9;

    GameObject effect2_1;
    GameObject effect2_2;
    GameObject effect2_3;
    GameObject effect2_4;
    GameObject effect2_5;
    GameObject effect2_6;
    GameObject effect2_7;
    GameObject effect2_8;
    GameObject effect2_9;
    // --------------- Pattern 3 ---------------
    GameObject pattern3_1;

    GameObject effect3_1;

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
    public void Scp3_1()
    {
        isPattern = true;
        StartCoroutine(Scp3_1_Pattern());
    }
    #region Scp3_1 패턴로직
    IEnumerator Scp3_1_Pattern()
    {
        #region Setting
        pattern1_1 = PatternManager.Instance.StartPattern("Stage3_Spear");
        pattern1_2 = PatternManager.Instance.StartPattern("Stage3_Spear");
        pattern1_3 = PatternManager.Instance.StartPattern("Stage3_Spear");

        SpriteRenderer sprite1_1 = pattern1_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite1_2 = pattern1_2.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite1_3 = pattern1_3.GetComponent<SpriteRenderer>();

        UnityEngine.Color color1_1 = sprite1_1.color;
        UnityEngine.Color color1_2 = sprite1_2.color;
        UnityEngine.Color color1_3 = sprite1_3.color;

        color1_1.a = 0f;
        color1_2.a = 0f;
        color1_3.a = 0f;

        sprite1_1.color = color1_1;
        sprite1_2.color = color1_2;
        sprite1_3.color = color1_3;

        pattern1_1.transform.position = new Vector3(-10, 20, 0);
        pattern1_1.transform.eulerAngles = new Vector3(0, 0, 45f);

        pattern1_2.transform.position = new Vector3(0, 20, 0);
        pattern1_2.transform.eulerAngles = new Vector3(0, 0, 0);

        pattern1_3.transform.position = new Vector3(10, 20, 0);
        pattern1_3.transform.eulerAngles = new Vector3(0, 0, 315);

        Vector3 pattern1_endPos = new Vector3(-26.8f, 36.8f, 0);
        Vector3 pattern2_endPos = new Vector3(0, 52f, 0);
        Vector3 pattern3_endPos = new Vector3(25.4f, 35.4f, 0);

        // 3 - 77.3   87.3  0


        #endregion
        float startTime = Time.time;
        while(Time.time - startTime < 1)
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

        effect1_1 = PatternManager.Instance.StartPattern("PatternEffect");
        effect1_2 = PatternManager.Instance.StartPattern("PatternEffect");
        effect1_3 = PatternManager.Instance.StartPattern("PatternEffect");

        TrailRender tr1,tr2,tr3;
        tr1 = effect1_1.GetComponent<TrailRender>();
        tr1.trailWidthMultiplier = 4f;

        tr2 = effect1_2.GetComponent<TrailRender>();
        tr2.trailWidthMultiplier = 4f;

        tr3= effect1_3.GetComponent<TrailRender>();
        tr3.trailWidthMultiplier = 4f;

        effect1_1.transform.position = pattern1_1.transform.position;
        effect1_2.transform.position = pattern1_2.transform.position;
        effect1_3.transform.position = pattern1_3.transform.position;

        Vector3 effect1_endPos = new Vector3(-60f, 72.6f, 0); // 이펙트 도착지점
        Vector3 effect2_endPos = new Vector3(0, 87.3f, 0); // 이펙트 도착지점
        Vector3 effect3_endPos = new Vector3(77.3f, 87.3f, 0); // 이펙트 도착지점


        startTime = Time.time;
        while(Time.time - startTime < 0.1f)
        {
            TrailRender.showTrail = true;
            float t = (Time.time - startTime) / 0.1f;

            effect1_1.transform.position = Vector3.Lerp(effect1_1.transform.position, effect1_endPos, t); // 이동
            effect1_2.transform.position = Vector3.Lerp(effect1_2.transform.position, effect2_endPos, t); // 이동
            effect1_3.transform.position = Vector3.Lerp(effect1_3.transform.position, effect3_endPos, t); // 이동

            yield return null;
        }

        startTime = Time.time;
        while(Time.time - startTime < 1.5f)
        {
            if (Time.time - startTime > 1.0f)
                TrailRender.showTrail = false;

            yield return null;
        }

        //  창 날리기
        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float t = (Time.time - startTime) / 0.3f;

            pattern1_1.transform.position = Vector3.Lerp(pattern1_1.transform.position, pattern1_endPos, t); // 이동
            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float t = (Time.time - startTime) / 0.3f;

            pattern1_2.transform.position = Vector3.Lerp(pattern1_2.transform.position, pattern2_endPos, t); // 이동
            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float t = (Time.time - startTime) / 0.3f;

            pattern1_3.transform.position = Vector3.Lerp(pattern1_3.transform.position, pattern3_endPos, t); // 이동
            yield return null;
        }

        startTime = Time.time;
        while(Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f ;

            color1_1.a = 1 - alpha;
            color1_2.a = 1 - alpha;
            color1_3.a = 1 - alpha;

            sprite1_1.color = color1_1;
            sprite1_2.color = color1_2;
            sprite1_3.color = color1_3;

            yield return null;
        }

        Destroy(pattern1_1);
        Destroy(pattern1_2);
        Destroy(pattern1_3);

        Destroy(effect1_1);
        Destroy(effect1_2);
        Destroy(effect1_3);

        isPattern = false;
    }

    #endregion

    public void Scp3_2()
    {
        isPattern = true;
        StartCoroutine(Scp3_2_Pattern());
    }
    #region Scp3_2 패턴로직
    IEnumerator Scp3_2_Pattern()
    {
        #region 초기세팅
        pattern2_1 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern2_1.transform.position = new Vector3(-28, 62, 0);
        pattern2_1.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern2_1.SetActive(true);
        SpriteRenderer spritePattern2_1 = pattern2_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_1 = spritePattern2_1.color;
        colorPattern2_1.a = 0f;
        spritePattern2_1.color = colorPattern2_1;

        pattern2_2 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern2_2.transform.position = new Vector3(-21, 62, 0);
        pattern2_2.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern2_2.SetActive(true);
        SpriteRenderer spritePattern2_2 = pattern2_2.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_2 = spritePattern2_2.color;
        colorPattern2_2.a = 0f;
        spritePattern2_2.color = colorPattern2_2;

        pattern2_3 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern2_3.transform.position = new Vector3(-14, 62, 0);
        pattern2_3.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern2_3.SetActive(true);
        SpriteRenderer spritePattern2_3 = pattern2_3.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_3 = spritePattern2_3.color;
        colorPattern2_3.a = 0f;
        spritePattern2_3.color = colorPattern2_3;


        pattern2_4 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern2_4.transform.position = new Vector3(-7, 62, 0);
        pattern2_4.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern2_4.SetActive(true);
        SpriteRenderer spritePattern2_4 = pattern2_4.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_4 = spritePattern2_4.color;
        colorPattern2_4.a = 0f;
        spritePattern2_4.color = colorPattern2_4;

        pattern2_5 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern2_5.transform.position = new Vector3(0, 62, 0);
        pattern2_5.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern2_5.SetActive(true);
        SpriteRenderer spritePattern2_5 = pattern2_5.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_5 = spritePattern2_5.color;
        colorPattern2_5.a = 0f;
        spritePattern2_5.color = colorPattern2_5;

        pattern2_6 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern2_6.transform.position = new Vector3(7, 62, 0);
        pattern2_6.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern2_6.SetActive(true);
        SpriteRenderer spritePattern2_6 = pattern2_6.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_6 = spritePattern2_6.color;
        colorPattern2_6.a = 0f;
        spritePattern2_6.color = colorPattern2_6;

        pattern2_7 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern2_7.transform.position = new Vector3(14, 62, 0);
        pattern2_7.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern2_7.SetActive(true);
        SpriteRenderer spritePattern2_7 = pattern2_7.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_7 = spritePattern2_7.color;
        colorPattern2_7.a = 0f;
        spritePattern2_7.color = colorPattern2_7;

        pattern2_8 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern2_8.transform.position = new Vector3(21, 62, 0);
        pattern2_8.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern2_8.SetActive(true);
        SpriteRenderer spritePattern2_8 = pattern2_8.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_8 = spritePattern2_8.color;
        colorPattern2_8.a = 0f;
        spritePattern2_8.color = colorPattern2_8;

        pattern2_9 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern2_9.transform.position = new Vector3(28, 62, 0);
        pattern2_9.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern2_9.SetActive(true);
        SpriteRenderer spritePattern2_9 = pattern2_9.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_9 = spritePattern2_9.color;
        colorPattern2_9.a = 0f;
        spritePattern2_9.color = colorPattern2_9;

        effect2_1 = PatternManager.Instance.StartPattern("PatternEffect");
        effect2_2 = PatternManager.Instance.StartPattern("PatternEffect");
        effect2_3 = PatternManager.Instance.StartPattern("PatternEffect");
        effect2_4 = PatternManager.Instance.StartPattern("PatternEffect");
        effect2_5 = PatternManager.Instance.StartPattern("PatternEffect");
        effect2_6 = PatternManager.Instance.StartPattern("PatternEffect");
        effect2_7 = PatternManager.Instance.StartPattern("PatternEffect");
        effect2_8 = PatternManager.Instance.StartPattern("PatternEffect");
        effect2_9 = PatternManager.Instance.StartPattern("PatternEffect");

        TrailRender tr1, tr2, tr3, tr4, tr5, tr6, tr7, tr8, tr9;
        tr1 = effect2_1.GetComponent<TrailRender>(); tr3 = effect2_3.GetComponent<TrailRender>();
        tr2 = effect2_2.GetComponent<TrailRender>(); tr4 = effect2_4.GetComponent<TrailRender>();
        tr5 = effect2_5.GetComponent<TrailRender>(); tr7 = effect2_7.GetComponent<TrailRender>();
        tr6 = effect2_6.GetComponent<TrailRender>(); tr8 = effect2_8.GetComponent<TrailRender>();
        tr9 = effect2_9.GetComponent<TrailRender>();

        tr1.trailWidthMultiplier = 4f; tr3.trailWidthMultiplier = 4f; tr5.trailWidthMultiplier = 4f; tr7.trailWidthMultiplier = 4f; tr9.trailWidthMultiplier = 4f;
        tr2.trailWidthMultiplier = 4f; tr4.trailWidthMultiplier = 4f; tr6.trailWidthMultiplier = 4f; tr8.trailWidthMultiplier = 4f;

        effect2_1.transform.position = pattern2_1.transform.position;
        effect2_2.transform.position = pattern2_2.transform.position;
        effect2_3.transform.position = pattern2_3.transform.position;
        effect2_4.transform.position = pattern2_4.transform.position;
        effect2_5.transform.position = pattern2_5.transform.position;
        effect2_6.transform.position = pattern2_6.transform.position;
        effect2_7.transform.position = pattern2_7.transform.position;
        effect2_8.transform.position = pattern2_8.transform.position;
        effect2_9.transform.position = pattern2_9.transform.position;

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
        while(Time.time - startTime  < 1)
        {
            Debug.Log("화살쏘는 애니메이션");
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
        while(Time.time - startTime < 0.1f)
        {
            TrailRender.showTrail = true;
            float t = (Time.time - startTime) / 0.1f;
            effect2_1.transform.position = Vector3.Lerp(effect2_1.transform.position, effect1_endPos, t); // 이동
            effect2_2.transform.position = Vector3.Lerp(effect2_2.transform.position, effect2_endPos, t); // 이동
            effect2_3.transform.position = Vector3.Lerp(effect2_3.transform.position, effect3_endPos, t); // 이동
            effect2_4.transform.position = Vector3.Lerp(effect2_4.transform.position, effect4_endPos, t); // 이동
            effect2_5.transform.position = Vector3.Lerp(effect2_5.transform.position, effect5_endPos, t); // 이동
            effect2_6.transform.position = Vector3.Lerp(effect2_6.transform.position, effect6_endPos, t); // 이동
            effect2_7.transform.position = Vector3.Lerp(effect2_7.transform.position, effect7_endPos, t); // 이동
            effect2_8.transform.position = Vector3.Lerp(effect2_8.transform.position, effect8_endPos, t); // 이동
            effect2_9.transform.position = Vector3.Lerp(effect2_9.transform.position, effect9_endPos, t); // 이동

            yield return null;
        }
        startTime = Time.time;
        while(Time.time - startTime  < 1.5f)
        {
            if (Time.time - startTime > 1.0f)
                TrailRender.showTrail = false;

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
                pattern2_1.transform.position += new Vector3(0, speed1 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.2f)
            {
                pattern2_2.transform.position += new Vector3(0, speed2 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.3f)
            {
                pattern2_3.transform.position += new Vector3(0, speed3 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.4f)
            {
                pattern2_4.transform.position += new Vector3(0, speed4 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.5f)
            {
                pattern2_5.transform.position += new Vector3(0, speed5 * Time.deltaTime, 0);  
            }
            if (Time.time - startTime > 0.6f)
            {
                pattern2_6.transform.position += new Vector3(0, speed6 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.7f)
            {
                pattern2_7.transform.position += new Vector3(0, speed7 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.8f)
            {
                pattern2_8.transform.position += new Vector3(0, speed8 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.9f)
            {
                pattern2_9.transform.position += new Vector3(0, speed9 * Time.deltaTime, 0);
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
        Destroy(pattern2_1);
        Destroy(pattern2_2);
        Destroy(pattern2_3);
        Destroy(pattern2_4);
        Destroy(pattern2_5);
        Destroy(pattern2_6);
        Destroy(pattern2_7);
        Destroy(pattern2_8);
        Destroy(pattern2_9);

        Destroy(effect2_1);
        Destroy(effect2_2);
        Destroy(effect2_3);
        Destroy(effect2_4);
        Destroy(effect2_5);
        Destroy(effect2_6);
        Destroy(effect2_7);
        Destroy(effect2_8);
        Destroy(effect2_9);
        #endregion
        isPattern = false;

        yield return null;
    }


    #endregion

    public void Scp3_3()
    {
        isPattern = true;

    }
    #region Scp3_3 패턴로직
    IEnumerator Scp3_3_Pattern()
    {
        #region Setting
        pattern3_1 = PatternManager.Instance.StartPattern("Stage3_Spear");
        pattern3_1.transform.position = new Vector3(0, 20, 0);

        SpriteRenderer sprite3_1 = pattern3_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color color3_1 = sprite3_1.color;
        color3_1.a = 0f;
        sprite3_1.color = color3_1;

        effect3_1 = PatternManager.Instance.StartPattern("PatternEffect");
        #endregion

        float startTime = Time.time;
        while(Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1;
            color3_1.a = alpha;

            sprite3_1.color = color3_1;

            yield return null;
        }


        startTime = Time.time;
        while(Time.time - startTime < 3)
        {
            Vector3 direction1 = PlayerPos - pattern3_1.transform.position;
            Quaternion lookRotation1 = Quaternion.LookRotation(Vector3.forward, direction1);
            pattern3_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation1.eulerAngles.z + 75f);

            Vector3 direction2 = PlayerPos -this.transform.position;
            Quaternion lookRotation2 = Quaternion.LookRotation(Vector3.forward, direction2);
            pattern3_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation2.eulerAngles.z + 75f);

            yield return null;
        } //3초간 조준

        Vector3 effectEndpos = PlayerPos;
        Vector3 effectStartpos = pattern3_1.transform.position;

        startTime = Time.time;
        while(Time.time - startTime < 0.1f)
        {
            float t = (Time.time - startTime) / 0.1f;
            effect3_1.transform.position = Vector3.Lerp(effect1_1.transform.position, PlayerPos, t);

            yield return null;
        }

        startTime = Time.time;
        while(Time.time - startTime < 1f)
        {
            if (Time.time - startTime > 0.8f)
                TrailRender.showTrail = false;


            yield return null;
        }




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
    }
 }
