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
using Spine;

public class Stage1_Boss : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    private PlayerController playerController;
    public GameObject Player;
    Vector3 PlayerPos;
    Vector3 bossPos;
    Camera cam;
    Vector3 cameraOriginalPos;
     // -------------- Spine Animation --------------
    #region Spine
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset[] AnimClip;

    string CurrentAnimation = ""; // 현재 어떤 애니메이션이 재생되고 있는지에 대한 변수    //   TrackEntry[] tracks;

    // 현재 애니메이션 처리가 무엇인지 대한 변수
    AnimState _AnimState;
    #endregion
    // ----------------- Pattern2 -----------------
    #region Pattern2
    bool nextPtn1State = false;
    bool nextPtn2State = false;
    float ptn2_playTime = 0.35f;
    float ptn2_delayTime = 1.45f;
    GameObject pattern2_1;
    GameObject pattern2_2;
    #endregion
    // ----------------- Pattern3 -----------------
    #region Pattern3
    GameObject pattern3_1;
    GameObject pattern3_2;
    GameObject pattern3_3;
    #endregion
    // ----------------- Pattern4 -----------------
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
    // ----------------- Pattern5 -----------------
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
    // ----------------- Pattern6 -----------------
    #region Pattern6
    GameObject pattern6_1;
    GameObject pattern6_2;
    #endregion
    Vector3 dir;
    // ----------------- Pattern7 -----------------
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
    // ----------------- Pattern8 -----------------
    #region Pattern8
    GameObject pattern8_1;
    GameObject pattern8_2;
    GameObject pattern8_3;
    GameObject arrow1;
    GameObject arrow2;
    GameObject arrow3;
    #endregion
    // ----------------- Pattern8_1 ---------------
    #region Pattern8_1
    GameObject target8_1;
    GameObject arrow8_1;
    GameObject arrow8_2;
    GameObject arrow8_3;
    #endregion
    // ----------------- Pattern9 -----------------
    #region Pattern9
    GameObject pattern9_1;
    GameObject pattern9_2;
    #endregion
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
    // ----------------- HP -----------------
    public Text currentHp_Text;
    public static float currentHp;
    ParticleSystem hitEffect;

    // ----------------- bool -----------------
    bool isOverlab = false;
    bool isPattern = false;
    int randomPattern;
    int randomOverlab;
    bool isBossDie = false;
    public GameObject ClearPanel;
    private void Awake()
    {
    }

    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();

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

    public enum AnimState
    {
        samurai_anima_death_suiside, 
        samurai_anima_idle, 
        samurai_anima_katana_roll, 
        samurai_anima_katana_roll_3, 
        samurai_anima_pattern_1,
        samurai_anima_pattern_6_left,
        samurai_anima_pattern_6_right,
        samurai_anima_turn_back,
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
    IEnumerator BossShaking(float duration, float magnitude)
    {
        float timer = 0;
        while (timer <= duration)
        {
           this.transform.localPosition = Random.insideUnitSphere * magnitude + bossPos;

            timer += Time.deltaTime;
            yield return null;
        }
       this.transform.localPosition = bossPos;

    } // 오브젝트 쉐이킹

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



    private void SetCurrentAnimation(AnimState _state)
    {
        Debug.Log(_state);

        switch (_state)
        {
            case AnimState.samurai_anima_death_suiside:
                _AsyncAnimation(AnimClip[(int)AnimState.samurai_anima_death_suiside], false, 1f);
                break;
            case AnimState.samurai_anima_idle:
                _AsyncAnimation(AnimClip[(int)AnimState.samurai_anima_idle], true, 0.7f);
                break;
            case AnimState.samurai_anima_katana_roll:
                _AsyncAnimation(AnimClip[(int)AnimState.samurai_anima_katana_roll], false, 0.35f);
                break;
            case AnimState.samurai_anima_katana_roll_3:
                _AsyncAnimation(AnimClip[(int)AnimState.samurai_anima_katana_roll_3], false, 3f);
                break;
            case AnimState.samurai_anima_pattern_1:
                _AsyncAnimation(AnimClip[(int)AnimState.samurai_anima_pattern_1], false, 1.4f);
                break;
            case AnimState.samurai_anima_pattern_6_left:
                _AsyncAnimation(AnimClip[(int)AnimState.samurai_anima_pattern_6_left], false, 1.5f);
                break;
            case AnimState.samurai_anima_pattern_6_right:
                _AsyncAnimation(AnimClip[(int)AnimState.samurai_anima_pattern_6_right], false, 1.5f);
                break;
            case AnimState.samurai_anima_turn_back:
                _AsyncAnimation(AnimClip[(int)AnimState.samurai_anima_turn_back], false, 1.2f);
                break;
        }
    }

    public void Scp1_1()
    {
        SetCurrentAnimation(AnimState.samurai_anima_idle);
        isPattern = true;
        StartCoroutine(Scp1_1_Pattern());
    }
    #region Scp1_1 패턴로직
    IEnumerator Scp1_1_Pattern()
    {
        float startTime = Time.time;
        while (Time.time - startTime < 2)
        {
                // 애니메이션 실행장소
             SetCurrentAnimation(AnimState.samurai_anima_katana_roll);

            yield return null;
        }
        Vector3 targetPos = PlayerPos ;
        startTime = Time.time;
        float duration = 0.7f; // 이동에 걸리는 시간
        while (Time.time - startTime < 2)
        {
            SetCurrentAnimation(AnimState.samurai_anima_pattern_1);
            float t = (Time.time - startTime) / duration;
            rigidbody2D.MovePosition(Vector3.Lerp(bossPos, targetPos, t));

         //   if(Time.time - startTime < 1.5) { }  원위치로 돌아오는 애니메이션 들어갈 자리
            yield return null;
        }
        startTime = Time.time;
        while(Time.time - startTime < 1)
        {
            SetCurrentAnimation(AnimState.samurai_anima_turn_back);
            yield return null;
        }
        isPattern = false;
    }


    #endregion

    public void Scp1_2()
    {
        SetCurrentAnimation(AnimState.samurai_anima_idle);
        isPattern = true;

        StartCoroutine(Scp1_2_1());
    } // 투명도처리필요
    #region Scp1_2 패턴로직
    IEnumerator Scp1_2_1()
    {
        // pattern2_1 = Instantiate(Sword.gameObject);
        // pattern2_2 = Instantiate(Sword.gameObject);

        pattern2_1 = PatternManager.Instance.StartPattern("Stage1_Sword");

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
        while(Time.time - startTime < 1)
        {
            float alpha = (Time.time - startTime) / 1f;
            color2_1.a = alpha;
            sprite2_1.color = color2_1;

            yield return null;
        }
        startTime = Time.time;
        SoundManager.Instance.PlaySFXSound("sword1");
        while (Time.time - startTime < ptn2_playTime) // 2.5초간 position.y 값 변경 및 rotation.z 값 변경
        {

            float RotateZ = 90;
            pattern2_1.transform.Rotate(0, 0, -RotateZ * 1.5f*  4 * Time.deltaTime);
            yield return null;
        }
        startTime = Time.time;
        while(Time.time - startTime < ptn2_delayTime)
        {
            yield return null;
        }
        nextPtn1State = true;
        if(nextPtn1State)
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
        SoundManager.Instance.PlaySFXSound("sword1");
        while (Time.time - startTime < ptn2_playTime) // 2.5초간 position.y 값 변경 및 rotation.z 값 변경
        {
              float RotateZ = 90f;
            pattern2_2.transform.Rotate(0, 0, -RotateZ* 1.5f* 4 * Time.deltaTime);

            yield return null;
        }
        startTime = Time.time;
        while(Time.time - startTime < ptn2_delayTime)
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
        SetCurrentAnimation(AnimState.samurai_anima_idle);
        isOverlab = true;
        StartCoroutine(overlab_Scp1_2_1());
    } // 오버랩용 함수 수정필요함 
    #region Scp 1_2 Overlab
    IEnumerator overlab_Scp1_2_1()
    {
        overlab_pattern2_1 = PatternManager.Instance.StartPattern("Stage1_Sword");
        overlab_pattern2_2 = PatternManager.Instance.StartPattern("Stage1_Sword");
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
        SoundManager.Instance.PlaySFXSound("sword1");
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
        SoundManager.Instance.PlaySFXSound("sword1");
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
        SetCurrentAnimation(AnimState.samurai_anima_idle);
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
        while(Time.time - startTime < 0.5f)
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
        SoundManager.Instance.PlaySFXSound("Sword_swing");
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
        SetCurrentAnimation(AnimState.samurai_anima_idle);
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

            overlab_pattern3_1.transform.position += new Vector3(-backPos * Time.deltaTime,-backPos * Time.deltaTime, 0);
            overlab_pattern3_2.transform.position += new Vector3(0,-backPos * Time.deltaTime, 0);
            overlab_pattern3_3.transform.position += new Vector3( backPos * Time.deltaTime,-backPos * Time.deltaTime, 0);


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
        SetCurrentAnimation(AnimState.samurai_anima_idle);
        isPattern = true;
        StartCoroutine(Scp1_4_Total());
    } // 투명도 처리 필요
    #region Scp 1_4 패턴로직
    IEnumerator Scp1_4_Total()
    {
        int cnt = 8;
        while(cnt >0)
        {
            if(cnt == 8) 
            {
                pattern4_1 = PatternManager.Instance.StartPattern("Stage1_Sword");
                pattern4_1.transform.position = new Vector3(-70f, 48f, 0);
                pattern4_1.transform.eulerAngles = new Vector3(0, 0, 90);
                StartCoroutine(Scp1_4_1());
            } // 왼
            if(cnt == 7)
            {
                pattern4_2 = PatternManager.Instance.StartPattern("Stage1_Sword");
                pattern4_2.transform.position = new Vector3(70f, 35, 0);
                pattern4_2.transform.eulerAngles = new Vector3(180, 0, 270);
                StartCoroutine(Scp1_4_2());
            } // 오
            if(cnt == 6)
            {
                pattern4_3 = PatternManager.Instance.StartPattern("Stage1_Sword");
                pattern4_3.transform.position = new Vector3(-70f, 22, 0);
                pattern4_3.transform.eulerAngles = new Vector3(0, 0, 90);
                StartCoroutine(Scp1_4_3());

            } // 왼
            if(cnt == 5)
            {
                pattern4_4 = PatternManager.Instance.StartPattern("Stage1_Sword");
                pattern4_4.transform.position = new Vector3(70f, 9, 0);
                pattern4_4.transform.eulerAngles = new Vector3(180, 0, 270);
                StartCoroutine(Scp1_4_4());
            } // 오
            if(cnt == 4)
            {
                pattern4_5 = PatternManager.Instance.StartPattern("Stage1_Sword");
                pattern4_5.transform.position = new Vector3(-70f, -4, 0);
                pattern4_5.transform.eulerAngles = new Vector3(0, 0, 90);
                StartCoroutine(Scp1_4_5());
            } // 왼
            if(cnt == 3)
            {
                pattern4_6 = PatternManager.Instance.StartPattern("Stage1_Sword");
                pattern4_6.transform.position = new Vector3(70f, -17, 0);
                pattern4_6.transform.eulerAngles = new Vector3(180, 0, 270);
                StartCoroutine(Scp1_4_6());
            } // 오
            if(cnt == 2)
            {
                pattern4_7 = PatternManager.Instance.StartPattern("Stage1_Sword");
                pattern4_7.transform.position = new Vector3(-70f, -30, 0);
                pattern4_7.transform.eulerAngles = new Vector3(0, 0, 90);
                StartCoroutine(Scp1_4_7());
            } // 왼
            if(cnt == 1)
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
        while(Time.time - startTime < 0.5f)
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
        SoundManager.Instance.PlaySFXSound("sword1");
        startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3) 
        {
            if(pattern4_1.transform.position.x < -40)
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
            color4_1.a = 1- alpha;
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
        SoundManager.Instance.PlaySFXSound("sword1");
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
        SoundManager.Instance.PlaySFXSound("sword1");
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
        SoundManager.Instance.PlaySFXSound("sword1");
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
        SoundManager.Instance.PlaySFXSound("sword1");
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
            color4_5.a =1 - alpha;
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
        SoundManager.Instance.PlaySFXSound("sword1");
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
        SoundManager.Instance.PlaySFXSound("sword1");
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
            color4_7.a =1 -  alpha;
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
        SoundManager.Instance.PlaySFXSound("sword1");
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
        SetCurrentAnimation(AnimState.samurai_anima_idle);
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
        SoundManager.Instance.PlaySFXSound("gun");


        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if(Time.time - startTime < 1)
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
        while(Time.time - startTime < 1f)
        {
            yield return null;
        }


        StartCoroutine(CameraShaking(0.1f, 0.5f));
        SoundManager.Instance.PlaySFXSound("gun");
        startTime = Time.time;
        while (Time.time - startTime < 2)
        {
            if(Time.time - startTime > 1.0)
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
            ptn_color.a =1 - alpha;

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
        SoundManager.Instance.PlaySFXSound("gun");
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
            ptn_color.a =1- alpha;

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
        SoundManager.Instance.PlaySFXSound("gun");

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

            before_Sprite.color = before_Color ;
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
        SoundManager.Instance.PlaySFXSound("gun");

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

        SoundManager.Instance.PlaySFXSound("gun");
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
        SoundManager.Instance.PlaySFXSound("gun");

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
            ptn_color.a = 1- alpha;
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
        SetCurrentAnimation(AnimState.samurai_anima_idle);
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
    public void Scp1_6()
    {
        SetCurrentAnimation(AnimState.samurai_anima_idle);
        this.transform.position = new Vector3(0, 7, 0);
        isPattern = true;
        StartCoroutine(Scp1_6_1());
    }
    #region Scp 1_6 패턴로직
    IEnumerator Scp1_6_1()
    {
        #region Pattern6_1 오브젝트 생성및 기본설정
        pattern6_1 = PatternManager.Instance.StartPattern("Stage1_Sword1");
        pattern6_1.transform.position = new Vector3(-15, 20, 0);
        pattern6_1.transform.eulerAngles = new Vector3(0, 180, 180);
        SpriteRenderer spritePattern6_1 = pattern6_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern6_1 = spritePattern6_1.color;
        colorPattern6_1.a = 0f;
        spritePattern6_1.color = colorPattern6_1;
        #endregion
        pattern6_1.SetActive(true);

        #region Pattern6_2 오브젝트 생성및 기본설정
        pattern6_2 = PatternManager.Instance.StartPattern("Stage1_Sword1");
        pattern6_2.transform.position = new Vector3(15, 20, 0);
        pattern6_2.transform.eulerAngles = new Vector3(0, 0, 180);
        SpriteRenderer spritePattern6_2 = pattern6_2.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern6_2 = spritePattern6_2.color;
        colorPattern6_2.a = 0f;
        spritePattern6_2.color = colorPattern6_2;
        #endregion
        pattern6_2.SetActive(true);

        float startTime = Time.time;
        while(Time.time - startTime < 1f) 
        {
            SetCurrentAnimation(AnimState.samurai_anima_katana_roll);
            float alpha = (Time.time - startTime) / 1f;
            colorPattern6_1.a = alpha;
            spritePattern6_1.color = colorPattern6_1;

            colorPattern6_2.a = alpha;
            spritePattern6_2.color = colorPattern6_2;
            yield return null;
        }
        startTime = Time.time;
        Vector3 dir = Vector3.zero;
        float RotateSpeed = 50;
        float MoveSpeed = 90f;
        while (Time.time - startTime<2) // 첫번째 애니메이션
        {
            SetCurrentAnimation(AnimState.samurai_anima_pattern_6_right);
            if (Time.time - startTime < 1)
            {
                 dir = (PlayerPos - pattern6_1.transform.position).normalized;
            }
            pattern6_1.transform.eulerAngles += new Vector3(0, 0, -RotateSpeed* 70 * Time.deltaTime);

            if (Time.time - startTime > 1)
            {
                pattern6_1.transform.position += dir * MoveSpeed*Time.deltaTime;
            }
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 3.0f) // 두번째 애니메이션
        {
            SetCurrentAnimation(AnimState.samurai_anima_pattern_6_left);
            if (Time.time - startTime < 1)
            {
                dir = (PlayerPos - pattern6_2.transform.position).normalized;
            }
            pattern6_2.transform.eulerAngles += new Vector3(0, 0, +RotateSpeed * 70 * Time.deltaTime);
            pattern6_1.transform.eulerAngles += new Vector3(0, 0, -RotateSpeed * 70 * Time.deltaTime);
            if(Time.time - startTime > 1.1f)
            {
                SetCurrentAnimation(AnimState.samurai_anima_idle);
            }

            if (1<Time.time - startTime  && Time.time - startTime < 2)
            {
                pattern6_2.transform.position += dir * MoveSpeed * Time.deltaTime;
            }
            yield return null;
        }
   
        startTime = Time.time;
        while(Time.time - startTime < 0.5f)
        {
            float alpha = (Time.time - startTime) / 0.5f;
            colorPattern6_1.a = 1f -alpha;
            spritePattern6_1.color = colorPattern6_1;

            colorPattern6_2.a =1f -alpha;
            spritePattern6_2.color = colorPattern6_2;
            yield return null;
        }
        Destroy(pattern6_1);
        Destroy(pattern6_2);
        isPattern = false;
    }
    #endregion
    // -20 ., 20
    public void Scp1_7()
    {
        SetCurrentAnimation(AnimState.samurai_anima_idle);
        isPattern = true;
        StartCoroutine(Scp1_7_1());
    }
    #region Scp 1_7 패턴로직
    IEnumerator Scp1_7_1()
    {
        #region 초기세팅
        pattern7_1 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern7_1.transform.position = new Vector3(-28, -62, 0);
        pattern7_1.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_1.SetActive(true);
        SpriteRenderer spritePattern7_1 = pattern7_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_1 = spritePattern7_1.color;
        colorPattern7_1.a = 0f;
        spritePattern7_1.color = colorPattern7_1;

        pattern7_2 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern7_2.transform.position = new Vector3(-21, -62, 0);
        pattern7_2.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_2.SetActive(true);
        SpriteRenderer spritePattern7_2 = pattern7_2.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_2 = spritePattern7_2.color;
        colorPattern7_2.a = 0f;
        spritePattern7_2.color = colorPattern7_2;

        pattern7_3 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern7_3.transform.position = new Vector3(-14, -62, 0);
        pattern7_3.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_3.SetActive(true);
        SpriteRenderer spritePattern7_3 = pattern7_3.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_3 = spritePattern7_3.color;
        colorPattern7_3.a = 0f;
        spritePattern7_3.color = colorPattern7_3;


        pattern7_4 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern7_4.transform.position = new Vector3(-7, -62, 0);
        pattern7_4.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_4.SetActive(true);
        SpriteRenderer spritePattern7_4 = pattern7_4.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_4 = spritePattern7_4.color;
        colorPattern7_4.a = 0f;
        spritePattern7_4.color = colorPattern7_4;

        pattern7_5 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern7_5.transform.position = new Vector3(0, -62, 0);
        pattern7_5.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_5.SetActive(true);
        SpriteRenderer spritePattern7_5 = pattern7_5.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_5 = spritePattern7_5.color;
        colorPattern7_5.a = 0f;
        spritePattern7_5.color = colorPattern7_5;

        pattern7_6 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern7_6.transform.position = new Vector3(7, -62, 0);
        pattern7_6.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_6.SetActive(true);
        SpriteRenderer spritePattern7_6 = pattern7_6.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_6 = spritePattern7_6.color;
        colorPattern7_6.a = 0f;
        spritePattern7_6.color = colorPattern7_6;

        pattern7_7 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern7_7.transform.position = new Vector3(14, -62, 0);
        pattern7_7.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_7.SetActive(true);
        SpriteRenderer spritePattern7_7 = pattern7_7.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_7 = spritePattern7_7.color;
        colorPattern7_7.a = 0f;
        spritePattern7_7.color = colorPattern7_7;

        pattern7_8 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern7_8.transform.position = new Vector3(21, -62, 0);
        pattern7_8.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_8.SetActive(true);
        SpriteRenderer spritePattern7_8 = pattern7_8.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_8 = spritePattern7_8.color;
        colorPattern7_8.a = 0f;
        spritePattern7_8.color = colorPattern7_8;

        pattern7_9 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        pattern7_9.transform.position = new Vector3(28, -62, 0);
        pattern7_9.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_9.SetActive(true);
        SpriteRenderer spritePattern7_9 = pattern7_9.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_9 = spritePattern7_9.color;
        colorPattern7_9.a = 0f;
        spritePattern7_9.color = colorPattern7_9;
        #endregion
        float startTime = Time.time;
        while(Time.time - startTime < 1)
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
        SoundManager.Instance.PlaySFXSound("arrow");

        while (Time.time - startTime <2)
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
                if (pattern7_1.transform.position.y >= 57)
                {
                    pattern7_1.transform.position = new Vector3(-28, 57, 0);
                }
            }
            if (Time.time - startTime > 0.2f)
            {
                pattern7_2.transform.position += new Vector3(0, speed2 * Time.deltaTime, 0);
                if (pattern7_2.transform.position.y >= 57)
                {
                    pattern7_2.transform.position = new Vector3(-21, 57, 0);
                }
            }
            if (Time.time - startTime > 0.3f)
            {
                pattern7_3.transform.position += new Vector3(0, speed3 * Time.deltaTime, 0);
                if (pattern7_3.transform.position.y >= 57)
                {
                    pattern7_3.transform.position = new Vector3(-14, 57, 0);
                }
            }
            if (Time.time - startTime > 0.4f)
            {
                pattern7_4.transform.position += new Vector3(0, speed4 * Time.deltaTime, 0);
                if (pattern7_4.transform.position.y >= 57)
                {
                    pattern7_4.transform.position = new Vector3(-7, 57, 0);
                }
            }
            if (Time.time - startTime > 0.5f)
            {
                pattern7_5.transform.position += new Vector3(0, speed5 * Time.deltaTime, 0);
                if (pattern7_5.transform.position.y >= 57)
                {

                    pattern7_5.transform.position = new Vector3(0, 57, 0);
                }
            }
            if (Time.time - startTime > 0.6f)
            {
                pattern7_6.transform.position += new Vector3(0, speed6 * Time.deltaTime, 0);
                if (pattern7_6.transform.position.y >= 57)
                {
                    pattern7_6.transform.position = new Vector3(7, 57, 0);
                }
            }
            if (Time.time - startTime > 0.7f)
            {
                pattern7_7.transform.position += new Vector3(0, speed7 * Time.deltaTime, 0);
                if (pattern7_7.transform.position.y >= 57)
                {
                    pattern7_7.transform.position = new Vector3(14, 57, 0);
                }
            }
            if (Time.time - startTime > 0.8f)
            {
                pattern7_8.transform.position += new Vector3(0, speed8 * Time.deltaTime, 0);
                if (pattern7_8.transform.position.y >= 57)
                {
                    pattern7_8.transform.position = new Vector3(21, 57, 0);
                }
            }
            if (Time.time - startTime > 0.9f)
            {
                pattern7_9.transform.position += new Vector3(0, speed9 * Time.deltaTime, 0);
                if (pattern7_9.transform.position.y >= 57)
                {
                    pattern7_9.transform.position = new Vector3(28, 57, 0);
                }
            }



            yield return null;

        }
        startTime = Time.time;
        while(Time.time - startTime < 1)
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
        SetCurrentAnimation(AnimState.samurai_anima_idle);
        isOverlab = true;
        StartCoroutine(overlab_Scp1_7_1());
    }
    #region overlab_Scp 1_7 패턴로직
    IEnumerator overlab_Scp1_7_1()
    {
        #region 초기세팅
        overlab_pattern7_1 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern7_1.transform.position = new Vector3(-28, -62, 0);
        overlab_pattern7_1.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_1.SetActive(true);
        SpriteRenderer spritePattern7_1 = overlab_pattern7_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_1 = spritePattern7_1.color;
        colorPattern7_1.a = 0f;
        spritePattern7_1.color = colorPattern7_1;

        overlab_pattern7_2 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern7_2.transform.position = new Vector3(-21, -62, 0);
        overlab_pattern7_2.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_2.SetActive(true);
        SpriteRenderer spritePattern7_2 = overlab_pattern7_2.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_2 = spritePattern7_2.color;
        colorPattern7_2.a = 0f;
        spritePattern7_2.color = colorPattern7_2;

        overlab_pattern7_3 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern7_3.transform.position = new Vector3(-14, -62, 0);
        overlab_pattern7_3.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_3.SetActive(true);
        SpriteRenderer spritePattern7_3 = overlab_pattern7_3.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_3 = spritePattern7_3.color;
        colorPattern7_3.a = 0f;
        spritePattern7_3.color = colorPattern7_3;


        overlab_pattern7_4 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern7_4.transform.position = new Vector3(-7, -62, 0);
        overlab_pattern7_4.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_4.SetActive(true);
        SpriteRenderer spritePattern7_4 = overlab_pattern7_4.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_4 = spritePattern7_4.color;
        colorPattern7_4.a = 0f;
        spritePattern7_4.color = colorPattern7_4;

        overlab_pattern7_5 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern7_5.transform.position = new Vector3(0, -62, 0);
        overlab_pattern7_5.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_5.SetActive(true);
        SpriteRenderer spritePattern7_5 = overlab_pattern7_5.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_5 = spritePattern7_5.color;
        colorPattern7_5.a = 0f;
        spritePattern7_5.color = colorPattern7_5;

        overlab_pattern7_6 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern7_6.transform.position = new Vector3(7, -62, 0);
        overlab_pattern7_6.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_6.SetActive(true);
        SpriteRenderer spritePattern7_6 = overlab_pattern7_6.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_6 = spritePattern7_6.color;
        colorPattern7_6.a = 0f;
        spritePattern7_6.color = colorPattern7_6;

        overlab_pattern7_7 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern7_7.transform.position = new Vector3(14, -62, 0);
        overlab_pattern7_7.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_7.SetActive(true);
        SpriteRenderer spritePattern7_7 = overlab_pattern7_7.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_7 = spritePattern7_7.color;
        colorPattern7_7.a = 0f;
        spritePattern7_7.color = colorPattern7_7;

        overlab_pattern7_8 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern7_8.transform.position = new Vector3(21, -62, 0);
        overlab_pattern7_8.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_8.SetActive(true);
        SpriteRenderer spritePattern7_8 = overlab_pattern7_8.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_8 = spritePattern7_8.color;
        colorPattern7_8.a = 0f;
        spritePattern7_8.color = colorPattern7_8;

        overlab_pattern7_9 = PatternManager.Instance.StartPattern("Stage1_Kunai");
        overlab_pattern7_9.transform.position = new Vector3(28, -62, 0);
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
                if (overlab_pattern7_1.transform.position.y >= 57)
                {
                    speed1 = 0;
                    overlab_pattern7_1.transform.position = new Vector3(-28, 57, 0);
                }
            }
            if (Time.time - startTime > 0.2f)
            {
                overlab_pattern7_2.transform.position += new Vector3(0, speed2 * Time.deltaTime, 0);
                if (overlab_pattern7_2.transform.position.y >= 57)
                {
                    speed2 = 0;
                    overlab_pattern7_2.transform.position = new Vector3(-21, 57, 0);
                }
            }
            if (Time.time - startTime > 0.3f)
            {
                overlab_pattern7_3.transform.position += new Vector3(0, speed3 * Time.deltaTime, 0);
                if (overlab_pattern7_3.transform.position.y >= 57)
                {
                    speed3 = 0;
                    overlab_pattern7_3.transform.position = new Vector3(-14, 57, 0);
                }
            }
            if (Time.time - startTime > 0.4f)
            {
                overlab_pattern7_4.transform.position += new Vector3(0, speed4 * Time.deltaTime, 0);
                if (overlab_pattern7_4.transform.position.y >= 57)
                {
                    speed4 = 0;
                    overlab_pattern7_4.transform.position = new Vector3(-7, 57, 0);
                }
            }
            if (Time.time - startTime > 0.5f)
            {
                overlab_pattern7_5.transform.position += new Vector3(0, speed5 * Time.deltaTime, 0);
                if (overlab_pattern7_5.transform.position.y >= 57)
                {
                    speed5 = 0;
                    overlab_pattern7_5.transform.position = new Vector3(0, 57, 0);
                }
            }
            if (Time.time - startTime > 0.6f)
            {
                overlab_pattern7_6.transform.position += new Vector3(0, speed6 * Time.deltaTime, 0);
                if (overlab_pattern7_6.transform.position.y >= 57)
                {
                    speed6 = 0;
                    overlab_pattern7_6.transform.position = new Vector3(7, 57, 0);
                }
            }
            if (Time.time - startTime > 0.7f)
            {
                overlab_pattern7_7.transform.position += new Vector3(0, speed7 * Time.deltaTime, 0);
                if (overlab_pattern7_7.transform.position.y >= 57)
                {
                    speed7 = 0;
                    overlab_pattern7_7.transform.position = new Vector3(14, 57, 0);
                }
            }
            if (Time.time - startTime > 0.8f)
            {
                overlab_pattern7_8.transform.position += new Vector3(0, speed8 * Time.deltaTime, 0);
                if (overlab_pattern7_8.transform.position.y >= 57)
                {
                    speed8 = 0;
                    overlab_pattern7_8.transform.position = new Vector3(21, 57, 0);
                }
            }
            if (Time.time - startTime > 0.9f)
            {
                overlab_pattern7_9.transform.position += new Vector3(0, speed9 * Time.deltaTime, 0);
                if (overlab_pattern7_9.transform.position.y >= 57)
                {
                    speed9 = 0;
                    overlab_pattern7_9.transform.position = new Vector3(28, 57, 0);
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
        SetCurrentAnimation(AnimState.samurai_anima_idle);
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
        SoundManager.Instance.PlaySFXSound("bow");
        while (Time.time - startTime < 3)
        {
            
            if(Time.time - startTime > 0.75f && bowCnt == 1)
            {
                arrow1.transform.position += new Vector3(0, -2f, 0); // 활 위치 변경
                arrow2.transform.position += new Vector3(-1.75f, -1.75f, 0);
                arrow3.transform.position += new Vector3(1.75f, -1.75f, 0);
                bowCnt++;
            }
            if (Time.time - startTime > 1.5f   && bowCnt == 2)
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
        SoundManager.Instance.PlaySFXSound("arrow");
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
            if(Time.time - startTime  < 1)
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

            arrow8_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation1.eulerAngles.z + 180 );
            arrow8_2.transform.rotation = Quaternion.Euler(0, 0, lookRotation2.eulerAngles.z + 180);
            arrow8_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation3.eulerAngles.z + 180);
            yield return null;
        }
        startTime = Time.time;
        Vector3 direction = (PlayerPos - arrow8_1.transform.position).normalized;
        SoundManager.Instance.PlaySFXSound("arrow");
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

        while (Time.time - startTime< 1)
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
        isPattern= false;
    }
    #endregion
    void overlab_Scp1_8_1()
    {
        SetCurrentAnimation(AnimState.samurai_anima_idle);
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
    // Update is called once per frame
    public void Scp1_9()
    {
        SetCurrentAnimation(AnimState.samurai_anima_idle);
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
        int randomValue = Random.Range(1,4); ;
        while (Time.time - startTime < 4)
        {
            if(Time.time -startTime < 1)
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
        SoundManager.Instance.PlaySFXSound("Sword_swing");
        while (Time.time - startTime < ptn9_playTime)
        {
            float Speed = 350f;
            if(randomValue == 1)
            {
                float X1 = 100f;
                float Y1 = 4f;
                pattern9_1.transform.position += new Vector3(-X1 * Time.deltaTime, -Y1 * Time.deltaTime, 0);
                pattern9_1.transform.eulerAngles += new Vector3(0,0,-Speed*1.7f*Time.deltaTime);
             } // 위쪽검
           else if (randomValue == 2)
            {
                float X2 = 100f;
                float Y2 = 4f;
               
                pattern9_2.transform.position += new Vector3(X2 * Time.deltaTime, 0, 0);
                pattern9_2.transform.eulerAngles += new Vector3(0, Y2*Time.deltaTime, -Speed*1.7f*Time.deltaTime);
            }
           else if(randomValue == 3)
            {
                // 패턴 x
                //continue;
            }
            yield return null;
        }
        startTime = Time.time;
        while(Time.time - startTime < ptn9_delayTime)
        {
            yield return null;
        }
        startTime = Time.time;
        while(Time.time - startTime < 1)
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

    float bossDieTime = 0f;
    float delayTime;
    void Update()
    {
        PlayerPos = Player.transform.position;
        bossPos = this.transform.position;

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

        if (delayTime < 2f)
            delayTime += Time.deltaTime;
        else if (delayTime > 2f)
        {
            delayTime = 3f;
            if (!isPattern && !isOverlab)
            {
                randomPattern = Random.Range(1, 18);
                switch (randomPattern)
                {
                    case 1: // pattern1
                        Scp1_1();
                        break;
                    case 2:
                        Scp1_2();
                        randomOverlab = Random.Range(1, 9);
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
                            default:

                                break;
                        }
                        break;
                    case 3:
                        Scp1_3();
                        randomOverlab = Random.Range(1, 9);
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
                            default:
                                break;
                        }

                        break;
                    case 4:
                        Scp1_4();
                        break;
                    case 5:
                        Scp1_5();
                        randomOverlab = Random.Range(1, 9);
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
                            default:
                                break;
                        }

                        break;
                    case 6:
                        Scp1_6();
                        break;
                    case 7:
                        Scp1_7();
                        randomOverlab = Random.Range(1, 9);
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
                            default:
                                break;
                        }

                        break;
                    case 8:
                        Scp1_8();
                        break;
                    case 9:
                        Scp1_8_1();
                        randomOverlab = Random.Range(1, 9);
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
                                overlab_Scp1_2();
                                break;
                            default:
                                break;
                        }

                        break;
                    case 10:
                        Scp1_9();
                        break;
                    case 11:
                        Scp1_6();
                        break;
                    case 12:
                        Scp1_6();
                        break;
                    default:
                        Scp1_1();
                        break;
                }
            }
        }

        if (currentHp <= 0)
        {
            currentHp = 0;
            isBossDie = true;
            StopAllCoroutines();
           // skeletonAnimation.AnimationState.ClearTracks(); // 이전에 재생한 모든 애니메이션 중지
            SetCurrentAnimation(AnimState.samurai_anima_death_suiside);
            // 사망 애니메이션 넣을자리
            if (isBossDie)
            {
                bossDieTime += Time.deltaTime;
                if (bossDieTime >= 3f)
                {
                    Time.timeScale = 0f;
                    ClearPanel.SetActive(true);
                }
                TitleSelect.clearCheck = 1;
                Debug.Log("checkInt" + TitleSelect.clearCheck);
            }
        }
   
    }
}
