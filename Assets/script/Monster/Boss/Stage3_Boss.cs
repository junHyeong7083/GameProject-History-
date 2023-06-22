using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using System.Security.Cryptography;
using static Stage1_Boss;
using System.Security.Principal;

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


    // -------------- Spine Animation --------------
    #region Spine
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset[] AnimClip;

    string CurrentAnimation = ""; // 현재 어떤 애니메이션이 재생되고 있는지에 대한 변수    //   TrackEntry[] tracks;

    // 현재 애니메이션 처리가 무엇인지 대한 변수
    AnimState_night _AnimState;
    #endregion


    // --------------- Pattern 1 ---------------
    GameObject pattern1_1;
    GameObject pattern1_2;
    GameObject pattern1_3;

    GameObject effect1_1;
    GameObject effect1_2;
    GameObject effect1_3;

    GameObject stone1;
    GameObject stone2;
    GameObject stone3;


    // --------------- overlab_Pattern 1 ---------------
    GameObject overlab_pattern1_1;
    GameObject overlab_pattern1_2;
    GameObject overlab_pattern1_3;

    GameObject overlab_effect1_1;
    GameObject overlab_effect1_2;
    GameObject overlab_effect1_3;

    GameObject overlab_stone1;
    GameObject overlab_stone2;
    GameObject overlab_stone3;


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
    // --------------- overlab_Pattern 2 ---------------
    GameObject overlab_pattern2_1;
    GameObject overlab_pattern2_2;
    GameObject overlab_pattern2_3;
    GameObject overlab_pattern2_4;
    GameObject overlab_pattern2_5;
    GameObject overlab_pattern2_6;
    GameObject overlab_pattern2_7;
    GameObject overlab_pattern2_8;
    GameObject overlab_pattern2_9;

    GameObject overlab_effect2_1;
    GameObject overlab_effect2_2;
    GameObject overlab_effect2_3;
    GameObject overlab_effect2_4;
    GameObject overlab_effect2_5;
    GameObject overlab_effect2_6;
    GameObject overlab_effect2_7;
    GameObject overlab_effect2_8;
    GameObject overlab_effect2_9;

    // --------------- Pattern 3 ---------------
    GameObject pattern3_1;
    GameObject pattern3Aim;

    // --------------- Overlab_Pattern 3 ---------------
    GameObject overlab_pattern3_1;
    GameObject overlab_pattern3Aim;
    // --------------- Pattern 4 ---------------
    GameObject pattern4_1;
    GameObject pattern4_2;
    GameObject pattern4_3;

    GameObject target4_1;
    GameObject target4_2;
    GameObject target4_3;
    // --------------- Overlab_Pattern 4 ---------------
    GameObject overlab_pattern4_1;
    GameObject overlab_pattern4_2;
    GameObject overlab_pattern4_3;

    GameObject overlab_target4_1;
    GameObject overlab_target4_2;
    GameObject overlab_target4_3;

    // --------------- Pattern 5 ---------------
    GameObject pattern5_1;
    // --------------- Pattern 6 ---------------
    ParticleSystem pattern6_1;
    // --------------- Pattern 7 ---------------
    GameObject pattern7_1;
    GameObject pattern7_2;
    // --------------- Pattern 8 ---------------
    GameObject pattern8_1;
    GameObject pattern8_2;

    GameObject effect8_1;
    GameObject effect8_2;
    // --------------- Pattern 9 ---------------
    GameObject pattern9_1;
    GameObject pattern9_2;



    // ----------------- bool -----------------
    #region Bool
    bool isOverlab = false;
    bool isPattern = false;
    bool isGate = false;

    int randomPattern;
    int randomOverlab;
    int randomCastle;
    bool isBossDie = false;
    #endregion
    // ----------------- HP -----------------
    #region HP && Die
    public Image fillImage;
    public float maxHp;
    public static float currentHp;
    ParticleSystem hitEffect;


    float bossDieTime = 0f;
    #endregion
    void Start()
    {
        SetCurrentAnimation(AnimState_night.idle);
        currentHp = maxHp;
        bossDieTime = 0f;
        currentHp = maxHp ;
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

    public enum AnimState_night
    {
        atk,
        atk2,
        bow,
        bow_2,
        death,
        idle,
        sword1,
        sword2,
        sword_back,
        sword_swing,
        atk3,
    }

    void _AsyncAnimation(AnimationReferenceAsset animClip, bool loop, float timeScalse)
    {
        if (animClip.name.Equals(CurrentAnimation))
            return;

        // 해당 애니메이션으로 변경한다.
        skeletonAnimation.state.SetAnimation(0, animClip, loop).TimeScale = timeScalse;

        // 애니메이션이 끝나면 원래 상태로 돌아간다.
        // skeletonAnimation.AnimationState.Complete += delegate { SetCurrentAnimation(AnimState.none); };
        // 현재 재생되고 있는 애니메이션 값을 변경
        CurrentAnimation = animClip.name;

    }



    private void SetCurrentAnimation(AnimState_night _state)
    {
        Debug.Log(_state);

        switch (_state)
        {
            case AnimState_night.atk:
                _AsyncAnimation(AnimClip[(int)AnimState_night.atk], false, 1.4f);
                break;
            case AnimState_night.atk2:
                _AsyncAnimation(AnimClip[(int)AnimState_night.atk2], false, 0.7f);
                break;
            case AnimState_night.bow:
                _AsyncAnimation(AnimClip[(int)AnimState_night.bow], false, 1f);
                break;
            case AnimState_night.bow_2:
                _AsyncAnimation(AnimClip[(int)AnimState_night.bow_2], false, 1f);
                break;
            case AnimState_night.death:
                _AsyncAnimation(AnimClip[(int)AnimState_night.death], false, 0.7f);
                break;
            case AnimState_night.idle:
                _AsyncAnimation(AnimClip[(int)AnimState_night.idle], true, 0.7f);
                break;
            case AnimState_night.sword1:
                _AsyncAnimation(AnimClip[(int)AnimState_night.sword1], false, 1.3f);
                break;
            case AnimState_night.sword2:
                _AsyncAnimation(AnimClip[(int)AnimState_night.sword2], false, 0.8f);
                break;
            case AnimState_night.sword_back:
                _AsyncAnimation(AnimClip[(int)AnimState_night.sword_back], false, 0.65f);
                break;
            case AnimState_night.sword_swing:
                _AsyncAnimation(AnimClip[(int)AnimState_night.sword_swing], false, 1.5f);
                break;
            case AnimState_night.atk3:
                _AsyncAnimation(AnimClip[(int)AnimState_night.atk], false, 0.6f);
                break;
        }
    }

    public void Scp3_1()
    {
        SetCurrentAnimation(AnimState_night.idle);
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

        pattern1_1.transform.position = new Vector3(-51.6f, 46.6f, 0);
        pattern1_1.transform.eulerAngles = new Vector3(0, 0, 225f);

        pattern1_2.transform.position = new Vector3(0, 80.5f, 0);
        pattern1_2.transform.eulerAngles = new Vector3(0, 0, 180f);

        pattern1_3.transform.position = new Vector3(51.6f, 46.6f, 0);
        pattern1_3.transform.eulerAngles = new Vector3(0, 0, 135f);

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
        SetCurrentAnimation(AnimState_night.atk);
        effect1_1 = PatternManager.Instance.StartPattern("PatternEffect");
        effect1_2 = PatternManager.Instance.StartPattern("PatternEffect");
        effect1_3 = PatternManager.Instance.StartPattern("PatternEffect");

        TrailRender tr1, tr2, tr3;
        tr1 = effect1_1.GetComponent<TrailRender>();
        tr1.trailWidthMultiplier = 4f;

        tr2 = effect1_2.GetComponent<TrailRender>();
        tr2.trailWidthMultiplier = 4f;

        tr3 = effect1_3.GetComponent<TrailRender>();
        tr3.trailWidthMultiplier = 4f;

        effect1_1.transform.position = pattern1_1.transform.position;
        effect1_2.transform.position = pattern1_2.transform.position;
        effect1_3.transform.position = pattern1_3.transform.position;

        Vector3 effect1_endPos = new Vector3(57f,-62f,0); // 이펙트 도착지점
        Vector3 effect2_endPos = new Vector3(0, -90f, 0); // 이펙트 도착지점
        Vector3 effect3_endPos = new Vector3(-57f, -62f, 0); // 이펙트 도착지점


        startTime = Time.time;
        while (Time.time - startTime < 0.1f)
        {
            TrailRender.showTrail = true;
            float t = (Time.time - startTime) / 0.1f;

            effect1_1.transform.position = Vector3.Lerp(effect1_1.transform.position, effect1_endPos, t); // 이동
            effect1_2.transform.position = Vector3.Lerp(effect1_2.transform.position, effect2_endPos, t); // 이동
            effect1_3.transform.position = Vector3.Lerp(effect1_3.transform.position, effect3_endPos, t); // 이동

            yield return null;
        }
     //   SoundManager.Instance.PlaySFXSound("Spear");
        startTime = Time.time;
        while (Time.time - startTime < 1.5f)
        {
            if (Time.time - startTime > 1.0f)
                TrailRender.showTrail = false;

            yield return null;
        }
        startTime = Time.time;
        SoundManager.Instance.PlaySFXSound("Spear");
        while (Time.time - startTime < 0.3f)
        {
            float t = (Time.time - startTime) / 0.3f;

            pattern1_1.transform.position = Vector3.Lerp(pattern1_1.transform.position, pattern1_endPos, t); // 이동
            yield return null;
        }
        stone1 = PatternManager.Instance.StartPattern("VFX_knight_stone");
        stone1.transform.position = new Vector3(27.2f, -32.2f, 0);

        // 모든 파티클의 위치를 부모 오브젝트와 동일하게 설정
        ParticleSystem[] particleSystems1 = stone1.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particleSystem in particleSystems1)
        {
            particleSystem.transform.localPosition = Vector3.zero;
        }

        startTime = Time.time;
        SoundManager.Instance.PlaySFXSound("Spear");
        while (Time.time - startTime < 0.3f)
        {
            float t = (Time.time - startTime) / 0.3f;

            pattern1_2.transform.position = Vector3.Lerp(pattern1_2.transform.position, pattern2_endPos, t); // 이동
            yield return null;
        }
        stone2 = PatternManager.Instance.StartPattern("VFX_knight_stone");
        stone2.transform.position = new Vector3(0, -48f, 0);
        // 모든 파티클의 위치를 부모 오브젝트와 동일하게 설정
        ParticleSystem[] particleSystems2 = stone2.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particleSystem in particleSystems2)
        {
            particleSystem.transform.localPosition = Vector3.zero;
        }

        SetCurrentAnimation(AnimState_night.idle);
        startTime = Time.time;
        SoundManager.Instance.PlaySFXSound("Spear");
        while (Time.time - startTime < 0.3f)
        {
            float t = (Time.time - startTime) / 0.3f;

            pattern1_3.transform.position = Vector3.Lerp(pattern1_3.transform.position, pattern3_endPos, t); // 이동
            yield return null;
        }
        stone3 = PatternManager.Instance.StartPattern("VFX_knight_stone");
        stone3.transform.position = new Vector3(-27.2f, -32.2f, 0);
        // 모든 파티클의 위치를 부모 오브젝트와 동일하게 설정
        ParticleSystem[] particleSystems3 = stone3.GetComponentsInChildren<ParticleSystem>();
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
        Destroy(stone1);
        Destroy(stone2);
        Destroy(stone3);

        Destroy(pattern1_1);
        Destroy(pattern1_2);
        Destroy(pattern1_3);

        Destroy(effect1_1);
        Destroy(effect1_2);
        Destroy(effect1_3);

        isPattern = false;
    }

    #endregion

    void Overlab_Scp3_1()
    {
        isOverlab = true;
        StartCoroutine(overlab_Scp3_1_Pattern());
    }
    #region overlab_Scp3_1 패턴로직
    IEnumerator overlab_Scp3_1_Pattern()
    {
        #region Setting
        overlab_pattern1_1 = PatternManager.Instance.StartPattern("Stage3_Spear");
        overlab_pattern1_2 = PatternManager.Instance.StartPattern("Stage3_Spear");
        overlab_pattern1_3 = PatternManager.Instance.StartPattern("Stage3_Spear");

        SpriteRenderer sprite1_1 = overlab_pattern1_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite1_2 = overlab_pattern1_2.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite1_3 = overlab_pattern1_3.GetComponent<SpriteRenderer>();

        UnityEngine.Color color1_1 = sprite1_1.color;
        UnityEngine.Color color1_2 = sprite1_2.color;
        UnityEngine.Color color1_3 = sprite1_3.color;

        color1_1.a = 0f;
        color1_2.a = 0f;
        color1_3.a = 0f;

        sprite1_1.color = color1_1;
        sprite1_2.color = color1_2;
        sprite1_3.color = color1_3;

        overlab_pattern1_1.transform.position = new Vector3(-51.6f, 46.6f, 0);
        overlab_pattern1_1.transform.eulerAngles = new Vector3(0, 0, 225f);

        overlab_pattern1_2.transform.position = new Vector3(0, 80.5f, 0);
        overlab_pattern1_2.transform.eulerAngles = new Vector3(0, 0, 180f);

        overlab_pattern1_3.transform.position = new Vector3(51.6f, 46.6f, 0);
        overlab_pattern1_3.transform.eulerAngles = new Vector3(0, 0, 135f);

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

        overlab_effect1_1 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect1_2 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect1_3 = PatternManager.Instance.StartPattern("PatternEffect");

        TrailRender tr1, tr2, tr3;
        tr1 = overlab_effect1_1.GetComponent<TrailRender>();
        tr1.trailWidthMultiplier = 4f;

        tr2 = overlab_effect1_2.GetComponent<TrailRender>();
        tr2.trailWidthMultiplier = 4f;

        tr3 = overlab_effect1_3.GetComponent<TrailRender>();
        tr3.trailWidthMultiplier = 4f;

        overlab_effect1_1.transform.position = overlab_pattern1_1.transform.position;
        overlab_effect1_2.transform.position = overlab_pattern1_2.transform.position;
        overlab_effect1_3.transform.position = overlab_pattern1_3.transform.position;

        Vector3 effect1_endPos = new Vector3(57f, -62f, 0); // 이펙트 도착지점
        Vector3 effect2_endPos = new Vector3(0, -90f, 0); // 이펙트 도착지점
        Vector3 effect3_endPos = new Vector3(-57f, -62f, 0); // 이펙트 도착지점


        startTime = Time.time;
        while (Time.time - startTime < 0.1f)
        {
            TrailRender.overlab_showTrail = true;
            float t = (Time.time - startTime) / 0.1f;

            overlab_effect1_1.transform.position = Vector3.Lerp(overlab_effect1_1.transform.position, effect1_endPos, t); // 이동
            overlab_effect1_2.transform.position = Vector3.Lerp(overlab_effect1_2.transform.position, effect2_endPos, t); // 이동
            overlab_effect1_3.transform.position = Vector3.Lerp(overlab_effect1_3.transform.position, effect3_endPos, t); // 이동

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 1.5f)
        {
            if (Time.time - startTime > 1.0f)
                TrailRender.overlab_showTrail = false;

            yield return null;
        }
        SoundManager.Instance.PlaySFXSound("Spear");
        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float t = (Time.time - startTime) / 0.3f;

            overlab_pattern1_1.transform.position = Vector3.Lerp(overlab_pattern1_1.transform.position, pattern1_endPos, t); // 이동
            yield return null;
        }
        overlab_stone1 = PatternManager.Instance.StartPattern("VFX_knight_stone");
        overlab_stone1.transform.position = new Vector3(27.2f, -32.2f, 0);

        // 모든 파티클의 위치를 부모 오브젝트와 동일하게 설정
        ParticleSystem[] particleSystems1 = overlab_stone1.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particleSystem in particleSystems1)
        {
            particleSystem.transform.localPosition = Vector3.zero;
        }
        SoundManager.Instance.PlaySFXSound("Spear");
        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float t = (Time.time - startTime) / 0.3f;

            overlab_pattern1_2.transform.position = Vector3.Lerp(overlab_pattern1_2.transform.position, pattern2_endPos, t); // 이동
            yield return null;
        }
        overlab_stone2 = PatternManager.Instance.StartPattern("VFX_knight_stone");
        overlab_stone2.transform.position = new Vector3(0, -48f, 0);
        // 모든 파티클의 위치를 부모 오브젝트와 동일하게 설정
        ParticleSystem[] particleSystems2 = overlab_stone2.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particleSystem in particleSystems2)
        {
            particleSystem.transform.localPosition = Vector3.zero;
        }
        SoundManager.Instance.PlaySFXSound("Spear");
        startTime = Time.time;
        while (Time.time - startTime < 0.3f)
        {
            float t = (Time.time - startTime) / 0.3f;

            overlab_pattern1_3.transform.position = Vector3.Lerp(overlab_pattern1_3.transform.position, pattern3_endPos, t); // 이동
            yield return null;
        }
        overlab_stone3 = PatternManager.Instance.StartPattern("VFX_knight_stone");
        overlab_stone3.transform.position = new Vector3(-27.2f, -32.2f, 0);
        // 모든 파티클의 위치를 부모 오브젝트와 동일하게 설정
        ParticleSystem[] particleSystems3 = overlab_stone3.GetComponentsInChildren<ParticleSystem>();
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
        Destroy(overlab_stone1);
        Destroy(overlab_stone2);
        Destroy(overlab_stone3);

        Destroy(overlab_pattern1_1);
        Destroy(overlab_pattern1_2);
        Destroy(overlab_pattern1_3);

        Destroy(overlab_effect1_1);
        Destroy(overlab_effect1_2);
        Destroy(overlab_effect1_3);

        isOverlab = false;
    }

    #endregion
    public void Scp3_2()
    {
        SetCurrentAnimation(AnimState_night.idle);
        isPattern = true;
        StartCoroutine(Scp3_2_Pattern());
    }
    #region Scp3_2 패턴로직
    IEnumerator Scp3_2_Pattern()
    {
        #region 초기세팅
        pattern2_1 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        pattern2_1.transform.position = new Vector3(-28, 70, 0);
        pattern2_1.SetActive(true);
        SpriteRenderer spritePattern2_1 = pattern2_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_1 = spritePattern2_1.color;
        colorPattern2_1.a = 0f;
        spritePattern2_1.color = colorPattern2_1;

        pattern2_2 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        pattern2_2.transform.position = new Vector3(-21, 70, 0);
        pattern2_2.SetActive(true);
        SpriteRenderer spritePattern2_2 = pattern2_2.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_2 = spritePattern2_2.color;
        colorPattern2_2.a = 0f;
        spritePattern2_2.color = colorPattern2_2;

        pattern2_3 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        pattern2_3.transform.position = new Vector3(-14, 70, 0);
        pattern2_3.SetActive(true);
        SpriteRenderer spritePattern2_3 = pattern2_3.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_3 = spritePattern2_3.color;
        colorPattern2_3.a = 0f;
        spritePattern2_3.color = colorPattern2_3;


        pattern2_4 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        pattern2_4.transform.position = new Vector3(-7, 70, 0);
        pattern2_4.SetActive(true);
        SpriteRenderer spritePattern2_4 = pattern2_4.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_4 = spritePattern2_4.color;
        colorPattern2_4.a = 0f;
        spritePattern2_4.color = colorPattern2_4;

        pattern2_5 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        pattern2_5.transform.position = new Vector3(0, 70, 0);
        pattern2_5.SetActive(true);
        SpriteRenderer spritePattern2_5 = pattern2_5.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_5 = spritePattern2_5.color;
        colorPattern2_5.a = 0f;
        spritePattern2_5.color = colorPattern2_5;

        pattern2_6 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        pattern2_6.transform.position = new Vector3(7, 70, 0);
        pattern2_6.SetActive(true);
        SpriteRenderer spritePattern2_6 = pattern2_6.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_6 = spritePattern2_6.color;
        colorPattern2_6.a = 0f;
        spritePattern2_6.color = colorPattern2_6;

        pattern2_7 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        pattern2_7.transform.position = new Vector3(14, 70, 0);
        pattern2_7.SetActive(true);
        SpriteRenderer spritePattern2_7 = pattern2_7.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_7 = spritePattern2_7.color;
        colorPattern2_7.a = 0f;
        spritePattern2_7.color = colorPattern2_7;

        pattern2_8 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        pattern2_8.transform.position = new Vector3(21, 70, 0);
        pattern2_8.SetActive(true);
        SpriteRenderer spritePattern2_8 = pattern2_8.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_8 = spritePattern2_8.color;
        colorPattern2_8.a = 0f;
        spritePattern2_8.color = colorPattern2_8;

        pattern2_9 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        pattern2_9.transform.position = new Vector3(28, 70, 0);
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
        SetCurrentAnimation(AnimState_night.bow);
        SoundManager.Instance.PlaySFXSound("bow");
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
        while (Time.time - startTime < 1.5f)
        {
            if (Time.time - startTime > 1.0f)
                TrailRender.showTrail = false;

            yield return null;
        }
        SetCurrentAnimation(AnimState_night.bow_2);
        SoundManager.Instance.PlaySFXSound("arrow");
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
                SetCurrentAnimation(AnimState_night.idle);
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

    void Overlab_Scp3_2()
    {
        isOverlab = true;
        StartCoroutine(overlab_Scp3_2_Pattern());
    }
    #region overlab_Scp3_2 패턴로직
    IEnumerator overlab_Scp3_2_Pattern()
    {
        #region 초기세팅
        overlab_pattern2_1 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        overlab_pattern2_1.transform.position = new Vector3(-28, 70, 0);
        overlab_pattern2_1.SetActive(true);
        SpriteRenderer spritePattern2_1 = overlab_pattern2_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_1 = spritePattern2_1.color;
        colorPattern2_1.a = 0f;
        spritePattern2_1.color = colorPattern2_1;

        overlab_pattern2_2 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        overlab_pattern2_2.transform.position = new Vector3(-21, 70, 0);
        overlab_pattern2_2.SetActive(true);
        SpriteRenderer spritePattern2_2 = overlab_pattern2_2.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_2 = spritePattern2_2.color;
        colorPattern2_2.a = 0f;
        spritePattern2_2.color = colorPattern2_2;

        overlab_pattern2_3 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        overlab_pattern2_3.transform.position = new Vector3(-14, 70, 0);
        overlab_pattern2_3.SetActive(true);
        SpriteRenderer spritePattern2_3 = overlab_pattern2_3.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_3 = spritePattern2_3.color;
        colorPattern2_3.a = 0f;
        spritePattern2_3.color = colorPattern2_3;


        overlab_pattern2_4 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        overlab_pattern2_4.transform.position = new Vector3(-7, 70, 0);
        overlab_pattern2_4.SetActive(true);
        SpriteRenderer spritePattern2_4 = overlab_pattern2_4.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_4 = spritePattern2_4.color;
        colorPattern2_4.a = 0f;
        spritePattern2_4.color = colorPattern2_4;

        overlab_pattern2_5 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        overlab_pattern2_5.transform.position = new Vector3(0, 70, 0);
        overlab_pattern2_5.SetActive(true);
        SpriteRenderer spritePattern2_5 = overlab_pattern2_5.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_5 = spritePattern2_5.color;
        colorPattern2_5.a = 0f;
        spritePattern2_5.color = colorPattern2_5;

        overlab_pattern2_6 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        overlab_pattern2_6.transform.position = new Vector3(7, 70, 0);
        overlab_pattern2_6.SetActive(true);
        SpriteRenderer spritePattern2_6 = overlab_pattern2_6.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_6 = spritePattern2_6.color;
        colorPattern2_6.a = 0f;
        spritePattern2_6.color = colorPattern2_6;

        overlab_pattern2_7 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        overlab_pattern2_7.transform.position = new Vector3(14, 70, 0);
        overlab_pattern2_7.SetActive(true);
        SpriteRenderer spritePattern2_7 = overlab_pattern2_7.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_7 = spritePattern2_7.color;
        colorPattern2_7.a = 0f;
        spritePattern2_7.color = colorPattern2_7;

        overlab_pattern2_8 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        overlab_pattern2_8.transform.position = new Vector3(21, 70, 0);
        overlab_pattern2_8.SetActive(true);
        SpriteRenderer spritePattern2_8 = overlab_pattern2_8.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_8 = spritePattern2_8.color;
        colorPattern2_8.a = 0f;
        spritePattern2_8.color = colorPattern2_8;

        overlab_pattern2_9 = PatternManager.Instance.StartPattern("Stage3_Arrow");
        overlab_pattern2_9.transform.position = new Vector3(28, 70, 0);
        overlab_pattern2_9.SetActive(true);
        SpriteRenderer spritePattern2_9 = overlab_pattern2_9.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern2_9 = spritePattern2_9.color;
        colorPattern2_9.a = 0f;
        spritePattern2_9.color = colorPattern2_9;

        overlab_effect2_1 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect2_2 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect2_3 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect2_4 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect2_5 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect2_6 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect2_7 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect2_8 = PatternManager.Instance.StartPattern("PatternEffect");
        overlab_effect2_9 = PatternManager.Instance.StartPattern("PatternEffect");

        TrailRender tr1, tr2, tr3, tr4, tr5, tr6, tr7, tr8, tr9;
        tr1 = overlab_effect2_1.GetComponent<TrailRender>(); tr3 = overlab_effect2_3.GetComponent<TrailRender>();
        tr2 = overlab_effect2_2.GetComponent<TrailRender>(); tr4 = overlab_effect2_4.GetComponent<TrailRender>();
        tr5 = overlab_effect2_5.GetComponent<TrailRender>(); tr7 = overlab_effect2_7.GetComponent<TrailRender>();
        tr6 = overlab_effect2_6.GetComponent<TrailRender>(); tr8 = overlab_effect2_8.GetComponent<TrailRender>();
        tr9 = overlab_effect2_9.GetComponent<TrailRender>();

        tr1.trailWidthMultiplier = 4f; tr3.trailWidthMultiplier = 4f; tr5.trailWidthMultiplier = 4f; tr7.trailWidthMultiplier = 4f; tr9.trailWidthMultiplier = 4f;
        tr2.trailWidthMultiplier = 4f; tr4.trailWidthMultiplier = 4f; tr6.trailWidthMultiplier = 4f; tr8.trailWidthMultiplier = 4f;

        overlab_effect2_1.transform.position = overlab_pattern2_1.transform.position;
        overlab_effect2_2.transform.position = overlab_pattern2_2.transform.position;
        overlab_effect2_3.transform.position = overlab_pattern2_3.transform.position;
        overlab_effect2_4.transform.position = overlab_pattern2_4.transform.position;
        overlab_effect2_5.transform.position = overlab_pattern2_5.transform.position;
        overlab_effect2_6.transform.position = overlab_pattern2_6.transform.position;
        overlab_effect2_7.transform.position = overlab_pattern2_7.transform.position;
        overlab_effect2_8.transform.position = overlab_pattern2_8.transform.position;
        overlab_effect2_9.transform.position = overlab_pattern2_9.transform.position;

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
            overlab_effect2_1.transform.position = Vector3.Lerp(overlab_effect2_1.transform.position, effect1_endPos, t); // 이동
            overlab_effect2_2.transform.position = Vector3.Lerp(overlab_effect2_2.transform.position, effect2_endPos, t); // 이동
            overlab_effect2_3.transform.position = Vector3.Lerp(overlab_effect2_3.transform.position, effect3_endPos, t); // 이동
            overlab_effect2_4.transform.position = Vector3.Lerp(overlab_effect2_4.transform.position, effect4_endPos, t); // 이동
            overlab_effect2_5.transform.position = Vector3.Lerp(overlab_effect2_5.transform.position, effect5_endPos, t); // 이동
            overlab_effect2_6.transform.position = Vector3.Lerp(overlab_effect2_6.transform.position, effect6_endPos, t); // 이동
            overlab_effect2_7.transform.position = Vector3.Lerp(overlab_effect2_7.transform.position, effect7_endPos, t); // 이동
            overlab_effect2_8.transform.position = Vector3.Lerp(overlab_effect2_8.transform.position, effect8_endPos, t); // 이동
            overlab_effect2_9.transform.position = Vector3.Lerp(overlab_effect2_9.transform.position, effect9_endPos, t); // 이동

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 1.5f)
        {
            if (Time.time - startTime > 1.0f)
                TrailRender.overlab_showTrail = false;

            yield return null;
        }
        SoundManager.Instance.PlaySFXSound("arrow");
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
                overlab_pattern2_1.transform.position += new Vector3(0, speed1 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.2f)
            {
                overlab_pattern2_2.transform.position += new Vector3(0, speed2 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.3f)
            {
                overlab_pattern2_3.transform.position += new Vector3(0, speed3 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.4f)
            {
                overlab_pattern2_4.transform.position += new Vector3(0, speed4 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.5f)
            {
                overlab_pattern2_5.transform.position += new Vector3(0, speed5 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.6f)
            {
                overlab_pattern2_6.transform.position += new Vector3(0, speed6 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.7f)
            {
                overlab_pattern2_7.transform.position += new Vector3(0, speed7 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.8f)
            {
                overlab_pattern2_8.transform.position += new Vector3(0, speed8 * Time.deltaTime, 0);
            }
            if (Time.time - startTime > 0.9f)
            {
                overlab_pattern2_9.transform.position += new Vector3(0, speed9 * Time.deltaTime, 0);
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
        Destroy(overlab_pattern2_1);
        Destroy(overlab_pattern2_2);
        Destroy(overlab_pattern2_3);
        Destroy(overlab_pattern2_4);
        Destroy(overlab_pattern2_5);
        Destroy(overlab_pattern2_6);
        Destroy(overlab_pattern2_7);
        Destroy(overlab_pattern2_8);
        Destroy(overlab_pattern2_9);

        Destroy(overlab_effect2_1);
        Destroy(overlab_effect2_2);
        Destroy(overlab_effect2_3);
        Destroy(overlab_effect2_4);
        Destroy(overlab_effect2_5);
        Destroy(overlab_effect2_6);
        Destroy(overlab_effect2_7);
        Destroy(overlab_effect2_8);
        Destroy(overlab_effect2_9);
        #endregion
        isOverlab = false;

        yield return null;
    }


    #endregion

    public void Scp3_3()
    {
        SetCurrentAnimation(AnimState_night.idle);
        isPattern = true;
        StartCoroutine(Scp3_3_Pattern());
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

        #endregion
        pattern3Aim = PatternManager.Instance.StartPattern("Stage1_GunAim");
        SetCurrentAnimation(AnimState_night.atk3);
        float startTime = Time.time;
        while (Time.time - startTime < 3)
        {
            pattern3Aim.transform.position = PlayerPos;
            pattern3Aim.SetActive(true);
            Vector3 direction1 = PlayerPos - pattern3_1.transform.position;
            Quaternion lookRotation1 = Quaternion.LookRotation(Vector3.forward, direction1);
            pattern3_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation1.eulerAngles.z + 0f);

            
            yield return null;
        } //3초간 조준
        color3_1.a = 1f;
        sprite3_1.color = color3_1;

     

        pattern3Aim.SetActive(false);
        SoundManager.Instance.PlaySFXSound("Spear");
        Vector3 startPos = pattern3_1.transform.position;
        Vector3 direction = (PlayerPos - startPos).normalized;
        float distance = 0f; // 초기 거리를 0으로 설정합니다.
        while (true)
        {
            pattern3_1.transform.position = startPos + direction * distance;
            float speed = 250f;
            // 벽에 부딪히는지 확인
            RaycastHit2D hit = Physics2D.Raycast(pattern3_1.transform.position, direction, 0.1f);
            if (hit.collider != null && hit.collider.CompareTag("Wall"))
            {
                break;
            }

            distance += Time.deltaTime * speed; // speed는 날아가는 속도를 나타내는 변수입니다.

            yield return null;
        }
        SetCurrentAnimation(AnimState_night.idle);
        stone1 = PatternManager.Instance.StartPattern("VFX_knight_stone");
        stone1.transform.position = pattern3_1.transform.position;

        // 모든 파티클의 위치를 부모 오브젝트와 동일하게 설정
        ParticleSystem[] particleSystems1 = stone1.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particleSystem in particleSystems1)
        {
            particleSystem.transform.localPosition = Vector3.zero;
        }


        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;

            color3_1.a = 1 - alpha;
            sprite3_1.color = color3_1;

            yield return null;
        }
        Destroy(stone1);
        Destroy(pattern3_1);
        isPattern = false;

    }
    #endregion
    void Overlab_Scp3_3()
    {
        isOverlab = true;
        StartCoroutine(overlab_Scp3_3_Pattern());
    }
    #region Overlab_Scp3_3 패턴로직
    IEnumerator overlab_Scp3_3_Pattern()
    {
        #region Setting
        overlab_pattern3_1 = PatternManager.Instance.StartPattern("Stage3_Spear");
        overlab_pattern3_1.transform.position = new Vector3(0, 20, 0);

        SpriteRenderer sprite3_1 = overlab_pattern3_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color color3_1 = sprite3_1.color;
        color3_1.a = 0f;
        sprite3_1.color = color3_1;

        #endregion
        overlab_pattern3Aim = PatternManager.Instance.StartPattern("Stage1_GunAim");
        float startTime = Time.time;
        while (Time.time - startTime < 3)
        {
            overlab_pattern3Aim.transform.position = PlayerPos;
            overlab_pattern3Aim.SetActive(true);
            Vector3 direction1 = PlayerPos - overlab_pattern3_1.transform.position;
            Quaternion lookRotation1 = Quaternion.LookRotation(Vector3.forward, direction1);
            overlab_pattern3_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation1.eulerAngles.z + 0f);


            yield return null;
        } //3초간 조준
        color3_1.a = 1f;
        sprite3_1.color = color3_1;


        SoundManager.Instance.PlaySFXSound("Spear");
        overlab_pattern3Aim.SetActive(false);
        Vector3 startPos = overlab_pattern3_1.transform.position;
        Vector3 direction = (PlayerPos - startPos).normalized;
        float distance = 0f; // 초기 거리를 0으로 설정합니다.

        while (true)
        {
            overlab_pattern3_1.transform.position = startPos + direction * distance;
            float speed = 250f;
            // 벽에 부딪히는지 확인
            RaycastHit2D hit = Physics2D.Raycast(overlab_pattern3_1.transform.position, direction, 0.1f);
            if (hit.collider != null && hit.collider.CompareTag("Wall"))
            {
                break;
            }

            distance += Time.deltaTime * speed; // speed는 날아가는 속도를 나타내는 변수입니다.

            yield return null;
        }
        overlab_stone1 = PatternManager.Instance.StartPattern("VFX_knight_stone");
        overlab_stone1.transform.position = overlab_pattern3_1.transform.position;

        // 모든 파티클의 위치를 부모 오브젝트와 동일하게 설정
        ParticleSystem[] particleSystems1 = overlab_stone1.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particleSystem in particleSystems1)
        {
            particleSystem.transform.localPosition = Vector3.zero;
        }


        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;

            color3_1.a = 1 - alpha;
            sprite3_1.color = color3_1;

            yield return null;
        }
        Destroy(overlab_stone1);
        Destroy(overlab_pattern3_1);
        isOverlab = false;

    }
    #endregion
    public void Scp3_4()
    {
        SetCurrentAnimation(AnimState_night.idle);
        isPattern = true;

        StartCoroutine(Scp3_4_Pattern());

    }
    #region Scp3_4 패턴로직
    IEnumerator Scp3_4_Pattern()
    {
        #region Settgin
        pattern4_1 = PatternManager.Instance.StartPattern("Stage3_Cannon");
        pattern4_2 = PatternManager.Instance.StartPattern("Stage3_Cannon");
        pattern4_3 = PatternManager.Instance.StartPattern("Stage3_Cannon");

        target4_1 = PatternManager.Instance.StartPattern("Stage1_GunAim");
        target4_2 = PatternManager.Instance.StartPattern("Stage1_GunAim");
        target4_3 = PatternManager.Instance.StartPattern("Stage1_GunAim");

        Transform bulletPosTransform1 = pattern4_1.transform.Find("BulletPos");
        Transform bulletPosTransform2 = pattern4_2.transform.Find("BulletPos");
        Transform bulletPosTransform3 = pattern4_3.transform.Find("BulletPos");


        pattern4_1.transform.position = new Vector3(-34, 16, 0);
        pattern4_2.transform.position = new Vector3(0, 57, 0);
        pattern4_3.transform.position = new Vector3(34, 16, 0);

        SpriteRenderer ptn_sprite1 = pattern4_1.GetComponent<SpriteRenderer>();
        SpriteRenderer ptn_sprite2 = pattern4_2.GetComponent<SpriteRenderer>();
        SpriteRenderer ptn_sprite3 = pattern4_3.GetComponent<SpriteRenderer>();

        SpriteRenderer target_sprite1 = target4_1.GetComponent<SpriteRenderer>();
        SpriteRenderer target_sprite2 = target4_2.GetComponent<SpriteRenderer>();
        SpriteRenderer target_sprite3 = target4_3.GetComponent<SpriteRenderer>();

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
        target4_1.SetActive(true);
        float startTime = Time.time;
        while(Time.time - startTime < 0.5f)
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

            target4_1.transform.position = PlayerPos;

            yield return null;
        }

        startTime = Time.time;
        SoundManager.Instance.PlaySFXSound("WaitCanon");
          while (Time.time - startTime < 1.0f)
          {
            float addeuler = 0f;

            Vector3 direction1 = PlayerPos - pattern4_1.transform.position;
            Quaternion lookRotation1 = Quaternion.LookRotation(Vector3.forward, direction1);
            pattern4_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation1.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전

            Vector3 direction2 = PlayerPos - pattern4_2.transform.position;
            Quaternion lookRotation2 = Quaternion.LookRotation(Vector3.forward, direction2);
            pattern4_2.transform.rotation = Quaternion.Euler(0, 0, lookRotation2.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전

            Vector3 direction3 = PlayerPos - pattern4_3.transform.position;
            Quaternion lookRotation3 = Quaternion.LookRotation(Vector3.forward, direction3);
            pattern4_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation3.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전



            target4_1.transform.position = PlayerPos;
            target4_1.transform.localScale += new Vector3(targetSizeup * Time.deltaTime, targetSizeup * Time.deltaTime, 0);


            yield return null;
        }
        SoundManager.Instance.PlaySFXSound("WaitCanon");
        target4_2.SetActive(true);
        startTime = Time.time;
        while (Time.time - startTime < 1.0f)
        {
            float addeuler = 0f;

            Vector3 direction2 = PlayerPos - pattern4_2.transform.position;
            Quaternion lookRotation2 = Quaternion.LookRotation(Vector3.forward, direction2);
            pattern4_2.transform.rotation = Quaternion.Euler(0, 0, lookRotation2.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전

            Vector3 direction3 = PlayerPos - pattern4_3.transform.position;
            Quaternion lookRotation3 = Quaternion.LookRotation(Vector3.forward, direction3);
            pattern4_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation3.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전



            target4_2.transform.position = PlayerPos;
            target4_2.transform.localScale += new Vector3(targetSizeup * Time.deltaTime, targetSizeup * Time.deltaTime, 0);
            yield return null;
        }


        SoundManager.Instance.PlaySFXSound("WaitCanon");
        target4_3.SetActive(true);
        startTime = Time.time;
        while (Time.time - startTime < 1.0f)
        {
            float addeuler = 0f;
            Vector3 direction3 = PlayerPos - pattern4_3.transform.position;
            Quaternion lookRotation3 = Quaternion.LookRotation(Vector3.forward, direction3);
            pattern4_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation3.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전



            target4_3.transform.position = PlayerPos;
            target4_3.transform.localScale += new Vector3(targetSizeup * Time.deltaTime, targetSizeup * Time.deltaTime, 0);
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

        bullet1.transform.rotation = pattern4_1.transform.rotation;
        bullet2.transform.rotation = pattern4_2.transform.rotation;
        bullet3.transform.rotation = pattern4_3.transform.rotation;

        ParticleSystem shoot1 = ParticleManager.Instance.StartParticle("VFX_shooting");
        shoot1.transform.position = bulletPosTransform1.transform.position;
        shoot1.transform.localScale = new Vector3(15, 15, 15);
        shoot1.transform.rotation = pattern4_1.transform.rotation;
        var main1 = shoot1.main;
        main1.startRotationZ = 0f;

    

        Vector3 dir1 = target4_1.transform.position - pattern4_1.transform.position;
        Vector3 dir2 = target4_2.transform.position - pattern4_2.transform.position;
        Vector3 dir3 = target4_3.transform.position - pattern4_3.transform.position;


        startTime = Time.time;
        SoundManager.Instance.PlaySFXSound("Canon");
        while (Time.time - startTime < 1.0f)
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
        shoot2.transform.rotation = pattern4_2.transform.rotation;
        var main2 = shoot2.main;
        main2.startRotationZ = 0f;

        startTime = Time.time;
        SoundManager.Instance.PlaySFXSound("Canon");
        while (Time.time - startTime < 1.0f)
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
        shoot3.transform.rotation = pattern4_3.transform.rotation;
        var main3 = shoot3.main;
        main3.startRotationZ = 0f;

        startTime = Time.time;
        SoundManager.Instance.PlaySFXSound("Canon");
        while (Time.time - startTime < 1f)
        {
            if (Time.time - startTime > 0.5f)
            {
                if (shoot3 != null) Destroy(shoot3.gameObject);
            }
            bullet3.GetComponent<Rigidbody2D>().velocity =   dir3.normalized * bulletSpeed;
            yield return null;
        }


        startTime = Time.time;
        while(Time.time - startTime < 0.5f)
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
        Destroy(pattern4_1);
        Destroy(pattern4_2);
        Destroy(pattern4_3);
        Destroy(target4_1);
        Destroy(target4_2);
        Destroy(target4_3);

        isPattern = false;
    }
    #endregion
    void Overlab_Scp3_4()
    {
        isOverlab = true;
        StartCoroutine(overlab_Scp3_4_Pattern());
    }
    #region overlab_Scp3_4 패턴로직
    IEnumerator overlab_Scp3_4_Pattern()
    {
        #region Settgin
        overlab_pattern4_1 = PatternManager.Instance.StartPattern("Stage3_Cannon");
        overlab_pattern4_2 = PatternManager.Instance.StartPattern("Stage3_Cannon");
        overlab_pattern4_3 = PatternManager.Instance.StartPattern("Stage3_Cannon");

        overlab_target4_1 = PatternManager.Instance.StartPattern("Stage1_GunAim");
        overlab_target4_2 = PatternManager.Instance.StartPattern("Stage1_GunAim");
        overlab_target4_3 = PatternManager.Instance.StartPattern("Stage1_GunAim");

        Transform bulletPosTransform1 = overlab_pattern4_1.transform.Find("BulletPos");
        Transform bulletPosTransform2 = overlab_pattern4_2.transform.Find("BulletPos");
        Transform bulletPosTransform3 = overlab_pattern4_3.transform.Find("BulletPos");


        overlab_pattern4_1.transform.position = new Vector3(-34, 16, 0);
        overlab_pattern4_2.transform.position = new Vector3(0, 57, 0);
        overlab_pattern4_3.transform.position = new Vector3(34, 16, 0);

        SpriteRenderer ptn_sprite1 = overlab_pattern4_1.GetComponent<SpriteRenderer>();
        SpriteRenderer ptn_sprite2 = overlab_pattern4_2.GetComponent<SpriteRenderer>();
        SpriteRenderer ptn_sprite3 = overlab_pattern4_3.GetComponent<SpriteRenderer>();

        SpriteRenderer target_sprite1 = overlab_target4_1.GetComponent<SpriteRenderer>();
        SpriteRenderer target_sprite2 = overlab_target4_2.GetComponent<SpriteRenderer>();
        SpriteRenderer target_sprite3 = overlab_target4_3.GetComponent<SpriteRenderer>();

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
        overlab_target4_1.SetActive(true);
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

            overlab_target4_1.transform.position = PlayerPos;

            yield return null;
        }
        SoundManager.Instance.PlaySFXSound("WaitCanon");
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            float addeuler = 0f;

            Vector3 direction1 = PlayerPos - overlab_pattern4_1.transform.position;
            Quaternion lookRotation1 = Quaternion.LookRotation(Vector3.forward, direction1);
            overlab_pattern4_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation1.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전

            Vector3 direction2 = PlayerPos - overlab_pattern4_2.transform.position;
            Quaternion lookRotation2 = Quaternion.LookRotation(Vector3.forward, direction2);
            overlab_pattern4_2.transform.rotation = Quaternion.Euler(0, 0, lookRotation2.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전

            Vector3 direction3 = PlayerPos - overlab_pattern4_3.transform.position;
            Quaternion lookRotation3 = Quaternion.LookRotation(Vector3.forward, direction3);
            overlab_pattern4_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation3.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전



            overlab_target4_1.transform.position = PlayerPos;
            overlab_target4_1.transform.localScale += new Vector3(targetSizeup * Time.deltaTime, targetSizeup * Time.deltaTime, 0);


            yield return null;
        }
        SoundManager.Instance.PlaySFXSound("WaitCanon");
        overlab_target4_2.SetActive(true);
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            float addeuler = 0f;

            Vector3 direction2 = PlayerPos - overlab_pattern4_2.transform.position;
            Quaternion lookRotation2 = Quaternion.LookRotation(Vector3.forward, direction2);
            overlab_pattern4_2.transform.rotation = Quaternion.Euler(0, 0, lookRotation2.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전

            Vector3 direction3 = PlayerPos - overlab_pattern4_3.transform.position;
            Quaternion lookRotation3 = Quaternion.LookRotation(Vector3.forward, direction3);
            overlab_pattern4_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation3.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전



            overlab_target4_2.transform.position = PlayerPos;
            overlab_target4_2.transform.localScale += new Vector3(targetSizeup * Time.deltaTime, targetSizeup * Time.deltaTime, 0);
            yield return null;
        }


        SoundManager.Instance.PlaySFXSound("WaitCanon");
        overlab_target4_3.SetActive(true);
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            float addeuler = 0f;
            Vector3 direction3 = PlayerPos - overlab_pattern4_3.transform.position;
            Quaternion lookRotation3 = Quaternion.LookRotation(Vector3.forward, direction3);
            overlab_pattern4_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation3.eulerAngles.z + addeuler); // 총구가 바라보는 방향으로 회전



            overlab_target4_3.transform.position = PlayerPos;
            overlab_target4_3.transform.localScale += new Vector3(targetSizeup * Time.deltaTime, targetSizeup * Time.deltaTime, 0);
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

        bullet1.transform.rotation = overlab_pattern4_1.transform.rotation;
        bullet2.transform.rotation = overlab_pattern4_2.transform.rotation;
        bullet3.transform.rotation = overlab_pattern4_3.transform.rotation;

        ParticleSystem shoot1 = ParticleManager.Instance.StartParticle("VFX_shooting");
        shoot1.transform.position = bulletPosTransform1.transform.position;
        shoot1.transform.localScale = new Vector3(15, 15, 15);
        shoot1.transform.rotation = overlab_pattern4_1.transform.rotation;
        var main1 = shoot1.main;
        main1.startRotationZ = 0f;



        Vector3 dir1 = overlab_target4_1.transform.position - overlab_pattern4_1.transform.position;
        Vector3 dir2 = overlab_target4_2.transform.position - overlab_pattern4_2.transform.position;
        Vector3 dir3 = overlab_target4_3.transform.position - overlab_pattern4_3.transform.position;

        SoundManager.Instance.PlaySFXSound("Canon");
        startTime = Time.time;
        while (Time.time - startTime <1f)
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
        shoot2.transform.rotation = overlab_pattern4_2.transform.rotation;
        var main2 = shoot2.main;
        main2.startRotationZ = 0f;

        SoundManager.Instance.PlaySFXSound("Canon");
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
        shoot3.transform.rotation = overlab_pattern4_3.transform.rotation;
        var main3 = shoot3.main;
        main3.startRotationZ = 0f;

        SoundManager.Instance.PlaySFXSound("Canon");
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
        Destroy(overlab_pattern4_1);
        Destroy(overlab_pattern4_2);
        Destroy(overlab_pattern4_3);
        Destroy(overlab_target4_1);
        Destroy(overlab_target4_2);
        Destroy(overlab_target4_3);

        isOverlab = false;
    }
    #endregion
    public void Scp3_5()
    {
        SetCurrentAnimation(AnimState_night.idle);
        isPattern = true;
        StartCoroutine(Scp3_5_Pattern());
    }
    #region Scp3_5 패턴로직
    IEnumerator Scp3_5_Pattern()
    {
        #region Setting 
        pattern5_1 = PatternManager.Instance.StartPattern("Stage3_Sword");

        pattern5_1.transform.position = new Vector3(0, 17, 0);

        SpriteRenderer sprite5_1 = pattern5_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color color5_1 = sprite5_1.color;
        color5_1.a = 0f; 
        sprite5_1.color = color5_1;
        #endregion
        float startTime = Time.time;
        while(Time.time - startTime < 1f)
        {
            float alpha = (Time.time - startTime) / 1f;

            color5_1.a = alpha;
            sprite5_1.color = color5_1;

            yield return null;
        }

        startTime = Time.time;
        SetCurrentAnimation(AnimState_night.sword_swing);
        SoundManager.Instance.PlaySFXSound("bigsword");
        while (Time.time - startTime < 0.5f)
        {
            yield return null;
        }
        SoundManager.Instance.PlaySFXSound("Sword_swing");
        startTime = Time.time;
        while(Time.time - startTime < 1f)
        {
            if(Time.time - startTime < 0.5f )
            {
                float rotateSpeed = -700f;

                pattern5_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime);
            }
            if(Time.time - startTime > 0.75f)
            {
                float rotateSpeed = -40f;
                pattern5_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime);
            }

            yield return null;
        }
        bool flipX = true;
        SetCurrentAnimation(AnimState_night.idle);
        skeletonAnimation.Skeleton.ScaleX = flipX ? -1f : 1f;
        SetCurrentAnimation(AnimState_night.sword_swing);

        SoundManager.Instance.PlaySFXSound("bigsword");
        startTime = Time.time;
        while (Time.time - startTime < 0.5f)
        {
            yield return null;
        }
        SoundManager.Instance.PlaySFXSound("Sword_swing");
        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            if (Time.time - startTime < 0.5f)
            {
                float rotateSpeed = 700f;

                pattern5_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime);
            }
            if (Time.time - startTime > 0.75f)
            {
                float rotateSpeed = 40f;
                pattern5_1.transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime);
            }

            yield return null;
        }

        flipX = false;
        skeletonAnimation.Skeleton.ScaleX = flipX ? -1f : 1f;
        SetCurrentAnimation(AnimState_night.idle);


        startTime = Time.time;
        while(Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;

            color5_1.a = 1 - alpha;
            sprite5_1.color = color5_1;

            yield return null;
        }
        Destroy(pattern5_1);
        isPattern = false;
    
    }
    #endregion

    public void Scp3_6()
    {
        SetCurrentAnimation(AnimState_night.idle);
        isPattern = true;
        StartCoroutine(Scp3_6_Pattern());
    }
    #region Scp3_6 패턴로직
    IEnumerator Scp3_6_Pattern()
    {
        Vector3 startPos = this.transform.position;
        Vector3 midPos = new Vector3(this.transform.position.x, this.transform.position.y + 20, this.transform.position.z);
        Vector3 endPos = new Vector3(0, -44.5f, 0);


        float startTime = Time.time;
        while(Time.time - startTime < 1f)
        {
            SetCurrentAnimation(AnimState_night.sword1);
            yield return null;
        }
         startTime = Time.time;
        while(Time.time - startTime < 1)
        {
            float t = (Time.time - startTime) / 1f;
            Vector3 position1 = Vector3.Lerp(startPos, endPos, t) + midPos * 4 * t * (1 - t);
            this.transform.position = position1;

            yield return null;
        }
        SoundManager.Instance.PlaySFXSound("swordjump");

        pattern6_1 = ParticleManager.Instance.StartParticle("TestEffect");
        pattern6_1.transform.position = new Vector3(this.transform.position.x-1, this.transform.position.y - 22f, this.transform.position.z);
        startTime = Time.time;
        while(Time.time - startTime < 2f)
        {
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 1.0f)
        {
            SetCurrentAnimation(AnimState_night.sword2);
            yield return null;
        }
        startTime = Time.time;
        while(Time.time - startTime < 3f)
        {
            SetCurrentAnimation(AnimState_night.idle);

            yield return null;
        }
        Destroy(pattern6_1.gameObject);
        isPattern = false;
    }
    #endregion
    public void Scp3_7()
    {
        SetCurrentAnimation(AnimState_night.idle);
        isGate = true;
        StartCoroutine(Scp3_7_Pattern());
    }
    #region Scp3_7 패턴로직
    IEnumerator Scp3_7_Pattern()
    {
        #region Setting 
        pattern7_1 = PatternManager.Instance.StartPattern("Stage3_IronGate");
        pattern7_2 = PatternManager.Instance.StartPattern("Stage3_IronGate");

        pattern7_1.transform.position = new Vector3(-25, 17.5f, 0);
        pattern7_1.transform.eulerAngles = new Vector3(0, 0, 0);

        pattern7_2.transform.position = new Vector3(25, 17.5f, 0);
        pattern7_2.transform.eulerAngles = new Vector3(0, 180, 0);

        SpriteRenderer sprite7_1 = pattern7_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite7_2 = pattern7_2.GetComponent<SpriteRenderer>();

        UnityEngine.Color color7_1 = sprite7_1.color;
        UnityEngine.Color color7_2 = sprite7_2.color;

        color7_1.a = 0f;
        color7_2.a = 0f;
        sprite7_1.color = color7_1;
        sprite7_2.color = color7_2;


        Vector3 startPos = this.transform.position;
        Vector3 endPos = new Vector3(0, 20, 0);
        #endregion
        float startTime = Time.time;
        while(Time.time - startTime < 1)
        {
            float t = (Time.time - startTime) / 1f;

            this.transform.position = Vector3.Lerp(startPos, endPos, t);

            yield return null;
        }

        startTime = Time.time;
        while(Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;

            color7_1.a = alpha;
            color7_2.a = alpha;

            sprite7_1.color = color7_1;
            sprite7_2.color = color7_2;

            yield return null;
        }

        startTime = Time.time;
        while(Time.time - startTime < 10)
        {
            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            float alpha = (Time.time - startTime) / 1f;

            color7_1.a =1- alpha;
            color7_2.a =1- alpha;

            sprite7_1.color = color7_1;
            sprite7_2.color = color7_2;

            yield return null;
        }
        Destroy(pattern7_1);
        Destroy(pattern7_2);


        isGate = false;
    }
    #endregion
    public void Scp3_8()
    {
        SetCurrentAnimation(AnimState_night.idle);
        StartCoroutine(Scp3_8_Pattern());
    }
    #region Scp3_8 패턴로직
    IEnumerator Scp3_8_Pattern()
    {
        #region Setting
        pattern8_1 = PatternManager.Instance.StartPattern("Stage3_Spear");
        pattern8_2 = PatternManager.Instance.StartPattern("Stage3_Spear");

        pattern8_1.transform.position = new Vector3(-10, 45, 0);
        pattern8_1.transform.eulerAngles = new Vector3(0, 0, 180);

        pattern8_2.transform.position = new Vector3(10, 45, 0);
        pattern8_2.transform.eulerAngles = new Vector3(0, 0, 180);

        effect8_1 = PatternManager.Instance.StartPattern("PatternEffect");
        effect8_2 = PatternManager.Instance.StartPattern("PatternEffect");

        effect8_1.transform.position = pattern8_1.transform.position;
        effect8_2.transform.position = pattern8_2.transform.position;

        Vector3 effect1startPos = new Vector3(-10, 40, 0);
        Vector3 effect2startPos = new Vector3(10, 40, 0);

        Vector3 effect1endPos = new Vector3(-10, -100, 0);
        Vector3 effect2endPos = new Vector3(10, -100, 0);


        TrailRenderer tr1, tr2;
        tr1 = effect8_1.GetComponent<TrailRenderer>();
        tr2 = effect8_2.GetComponent<TrailRenderer>();
        tr1.widthMultiplier = 2f;
        tr2.widthMultiplier = 2f;


        SpriteRenderer sprite1 = pattern8_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite2 = pattern8_2.GetComponent<SpriteRenderer>();

        UnityEngine.Color color1 = sprite1.color;
        UnityEngine.Color color2 = sprite2.color;
        color1.a = 0f;
        color2.a = 0f;

        sprite1.color = color1;
        sprite2.color = color2;

        float speed = -300f;
        #endregion
        float startTime = Time.time;
        while(Time.time - startTime < 2f)
        {
            yield return null;
        }


        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            float alpha = (Time.time - startTime) / 1f;
            color1.a = alpha;
            color2.a = alpha;

            sprite1.color = color1;
            sprite2.color = color2;

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.5f)
        {
            Debug.Log("애니메이션1");
            yield return null;
        }
        #region 이펙트표시선
        startTime = Time.time;
        while(Time.time - startTime < 0.1f)
        {
            float t = (Time.time - startTime) / 0.1f;

            TrailRender.showTrail = true;
            effect8_1.transform.position = Vector3.Lerp(effect1startPos, effect1endPos, t);

            yield return null;
        }
        startTime = Time.time;
        while(Time.time - startTime < 0.7f)
        {
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.2f)
        {
            TrailRender.showTrail = false;
            yield return null;
        }
        #endregion
        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            if(Time.time - startTime <0.6f)
            {
                pattern8_1.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 0.5f)
        {
            Debug.Log("애니메이션2");
            yield return null;
        }
        #region 이펙트표시선
        startTime = Time.time;
        while (Time.time - startTime < 0.1f)
        {
            float t = (Time.time - startTime) / 0.1f;

            TrailRender.showTrail = true;
            effect8_2.transform.position = Vector3.Lerp(effect2startPos, effect2endPos, t);

            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.7f)
        {
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 0.2f)
        {
            TrailRender.showTrail = false;
            yield return null;
        }
        #endregion
        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            if (Time.time - startTime < 0.6f)
            {
                pattern8_2.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }

            yield return null;
        }

        startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            float alpha = (Time.time - startTime) / 1f;
            color1.a = 1 - alpha;
            color2.a = 1- alpha;

            sprite1.color = color1;
            sprite2.color = color2;

            yield return null;
        }
        Destroy(pattern8_1);
        Destroy(pattern8_2);
    }

    #endregion

    public void Scp3_9()
    {
        SetCurrentAnimation(AnimState_night.idle);
        StartCoroutine(Scp3_9_Pattern());
    }
    #region Scp3_9 패턴로직
    IEnumerator Scp3_9_Pattern()
    {
        #region Setting
        pattern9_1 = PatternManager.Instance.StartPattern("Stage3_door");
        pattern9_2 = PatternManager.Instance.StartPattern("Stage3_door");

        pattern9_1.transform.position = new Vector3(0, 3, 0);
        pattern9_2.transform.position = new Vector3(0, -50, 0);
        pattern9_2.transform.eulerAngles = new Vector3(0, 0, 180f);

        Vector3 startPos1 =pattern9_1.transform.position;
        Vector3 startPos2 =pattern9_2.transform.position;

        Vector3 endPos1 = new Vector3(0, -25, 0);
        Vector3 endPos2 = new Vector3(0, -22, 0);

        SpriteRenderer sprite1 = pattern9_1.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite2 = pattern9_2.GetComponent<SpriteRenderer>();

        UnityEngine.Color color1 = sprite1.color;
        UnityEngine.Color color2 = sprite2.color;
        color1.a = 0f;
        color2.a = 0f;
        sprite1.color = color1;
        sprite2.color = color2;
        #endregion
        float startTime = Time.time;
        while(Time.time - startTime < 2f)
        {
            yield return null;
        }



        startTime = Time.time;
        while (Time.time - startTime < 0.5f)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            color1.a = alpha;
            color2.a = alpha;
            sprite1.color = color1;
            sprite2.color = color2;

            yield return null;
        }
        int randomValue = Random.Range(1, 3);
        Debug.Log("RandomValue : " + randomValue);
        switch(randomValue)
        {
            case 1:
                startTime = Time.time;
                while(Time.time - startTime < 3)
                {
                    float t = (Time.time - startTime) / 3;
                    pattern9_1.transform.position = Vector3.Lerp(startPos1, endPos1, t);
                    yield return null;
                }
                break;

            case 2:
                startTime = Time.time;
                while (Time.time - startTime < 3)
                {
                    float t = (Time.time - startTime) / 3;
                    pattern9_2.transform.position = Vector3.Lerp(startPos2, endPos2, t);
                    yield return null;
                }
                break;
        }
        startTime = Time.time;
        while (Time.time - startTime < 2f)
        {
            yield return null;
        }



        startTime = Time.time;
        while(Time.time - startTime < 0.5f)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            color1.a = 1 - alpha;
            color2.a = 1 - alpha;

            sprite1.color = color1;
            sprite2.color = color2;

            yield return null;
        }
        Destroy(pattern9_1);
        Destroy(pattern9_2);
    }

    #endregion
    float delayTime= 0f;

    public void Scp3_10()
    {
        SetCurrentAnimation(AnimState_night.idle);
        isPattern = true;
        StartCoroutine(Scp3_10_Pattern());
    }
    #region Scp3_10 패턴로직
    IEnumerator Scp3_10_Pattern()
    {
        float startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            SetCurrentAnimation(AnimState_night.sword1);
            skeletonAnimation.timeScale = 0.7f;
            yield return null;
        }
        SoundManager.Instance.PlaySFXSound("charging");
        skeletonAnimation.timeScale = 1.5f;
        SetCurrentAnimation(AnimState_night.idle);
        Vector3 targetPos = PlayerPos;
        startTime = Time.time;
        float duration = 0.7f; // 이동에 걸리는 시간
        while (Time.time - startTime < 2)
        {
            SetCurrentAnimation(AnimState_night.sword_swing);
            float t = (Time.time - startTime) / duration;
            transform.position = Vector3.Lerp(bossPos, targetPos, t); // 보스의 위치를 플레이어로 이동합니다

            //   if(Time.time - startTime < 1.5) { }  원위치로 돌아오는 애니메이션 들어갈 자리
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            SetCurrentAnimation(AnimState_night.idle);
            yield return null;
        }
        isPattern = false;
        skeletonAnimation.timeScale = 1f;
    }


    #endregion

    private void Update()
    {
        TrailRender.showTrail = false;
        TrailRender.overlab_showTrail = false;
        #region Hp Bar
        float fillAmount = currentHp / maxHp;
        fillAmount = Mathf.Clamp(fillAmount, 0f, 1f);
        fillImage.fillAmount = fillAmount;
        #endregion

        if (delayTime < 2f)
            delayTime += Time.deltaTime;
        else if (delayTime > 2f)
        {
            delayTime = 3f;
            if (!isPattern && !isOverlab && !isGate)
            {
                randomPattern = Random.Range(1, 10);
                switch (randomPattern)
                {
                    case 1:
                        Scp3_1();
                        randomOverlab = Random.Range(1, 7);
                        switch (randomOverlab)
                        {
                            case 1:
                                Overlab_Scp3_2();
                                break;
                            case 2:
                                Overlab_Scp3_3();
                                break;
                            case 3:
                                Overlab_Scp3_4();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        Scp3_2();
                        randomOverlab = Random.Range(1, 7);
                        switch (randomOverlab)
                        {
                            case 1:
                                Overlab_Scp3_1();
                                break;
                            case 2:
                                Overlab_Scp3_3();
                                break;
                            case 3:
                                Overlab_Scp3_4();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 3:
                        Scp3_3();
                        randomOverlab = Random.Range(1, 7);
                        switch (randomOverlab)
                        {
                            case 1:
                                Overlab_Scp3_2();
                                break;
                            case 2:
                                Overlab_Scp3_1();
                                break;
                            case 3:
                                Overlab_Scp3_4();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 4:
                        Scp3_4();
                        randomOverlab = Random.Range(1, 7);
                        switch (randomOverlab)
                        {
                            case 1:
                                Overlab_Scp3_2();
                                break;
                            case 2:
                                Overlab_Scp3_3();
                                break;
                            case 3:
                                Overlab_Scp3_1();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 5:
                        Scp3_5();
                        break;
                    case 6:
                        Scp3_6();
                        break;
                    case 7:
                        Scp3_7();
                        randomCastle = Random.Range(1, 3);
                        switch (randomCastle)
                        {
                            case 1:
                                Scp3_8();
                                break;

                            case 2:
                                Scp3_9();
                                break;
                        }
                        break;
                    case 8:
                        Scp3_10();
                        break;
                    case 9:
                        Scp3_10();
                        break;

                }
            }
        }

        #region Boss Hit
        if (!isBossDie)
        {
            if (PlayerController.atkState) // 공격상태이면
            {
                hitEffect.transform.position = bossPos;
                hitEffect.gameObject.SetActive(true);
                currentHp -= Time.deltaTime * 50f;
            }
            else if (!PlayerController.atkState)
            {
                hitEffect.gameObject.SetActive(false);
            }
        }
        #endregion


        PlayerPos = Player.transform.position;
        bossPos = this.transform.position;
        if (currentHp <= 0)
        {
            currentHp = 0;
            isBossDie = true;
            StopAllCoroutines();
            SetCurrentAnimation(AnimState_night.death);  //사망 애니메이션
            if (isBossDie)
            {
                bossDieTime += Time.deltaTime;
                if (bossDieTime >= 3f)
                {
                    Time.timeScale = 0f;
                    ClearPanel.SetActive(true);
                }
                TitleSelect.clearCheck = 3;
                Debug.Log("checkInt" + TitleSelect.clearCheck);
            }
        }
    }
}
 
