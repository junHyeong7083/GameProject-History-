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

    Vector3 PivotPos = new Vector3(0, -2, 0);
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

        // ��� �ִϸ��̼� ������Ʈ ��������
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
    #region Scp2_1 ���Ϸ���
    IEnumerator Scp2_1_Pattern()
    {
        float startTime = Time.time;
        while (Time.time - startTime < 2)
        {
            // �ִϸ��̼� �������
          //  SetCurrentAnimation(AnimState.samurai_anima_katana_roll);

            yield return null;
        }
        Vector3 targetPos = PlayerPos;
        startTime = Time.time;
        float duration = 0.7f; // �̵��� �ɸ��� �ð�
        while (Time.time - startTime < 2)
        {
          //  SetCurrentAnimation(AnimState.samurai_anima_pattern_1);
            float t = (Time.time - startTime) / duration;
            rigidbody2D.MovePosition(Vector3.Lerp(bossPos, targetPos, t));

            //   if(Time.time - startTime < 1.5) { }  ����ġ�� ���ƿ��� �ִϸ��̼� �� �ڸ�
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
    #region Scp2_2 ���Ϸ���
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
        float duration = 2.0f; // �̵� �ð�
        float euler = 35f; // ȸ������
        #endregion
        float startTime = Time.time;
        while(Time.time - startTime  < 1) // ���ð�
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

            Vector3 position1 = Vector3.Lerp(startpattern2_1, endpattern2_1, t) + midpattern2_1 * 4 * t * (1 - t); // ������ �̵� ��� ���
            pattern2_1.transform.position = position1; // �̵�

            Vector3 position2 = Vector3.Lerp(startpattern2_2, endpattern2_2, t) + midpattern2_2 * 4 * t * (1 - t); // ������ �̵� ��� ���
            pattern2_2.transform.position = position2; // �̵�

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

    public void Scp2_3()
    {
        isPattern = true;
    }
    IEnumerator Scp2_3_Pattern()
    {
        yield return null;
    }

    private void Update()
    {
        if (currentHp <= 0)
        {
            currentHp = 0;
            isBossDie = true;
            StopAllCoroutines();
        //    SetCurrentAnimation(AnimState.samurai_anima_death_suiside);  ��� �ִϸ��̼�
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
