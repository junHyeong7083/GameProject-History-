using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;


public class Stage1_Boss : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    private PlayerController playerController;
    public GameObject Player;
    Vector3 PlayerPos;
    Camera cam;
    Vector3 cameraOriginalPos;
    Vector3 bossOriginalPos;

    // ----------------- Pattern2 -----------------
    bool nextPtn1State = false;
    public GameObject Sword;
    // ----------------- Pattern3 -----------------
    public GameObject Kunai;
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
    public GameObject Gun;
    public GameObject Target;
    public GameObject Bullet;
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
    #endregion
    // ----------------- Pattern6 -----------------
    public GameObject Sword2;
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
    public GameObject Bow;
    public GameObject arrow;
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
    // ----------------- bool -----------------
    bool isOverlab = false;
    bool isPattern = false;
    int randomPattern;
    int randomOverlab;
    void Start()
    {
        // 보스 현재 포지션 0, 2
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerController = Player.GetComponent<PlayerController>();

        cam = Camera.main;
        cameraOriginalPos = cam.transform.position;
        bossOriginalPos = this.transform.position;
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
            this.transform.localPosition = Random.insideUnitSphere * magnitude + bossOriginalPos;

            timer += Time.deltaTime;
            yield return null;
        }
        this.transform.localPosition = bossOriginalPos;

    } // 오브젝트 쉐이킹

    public void Scp1_1()
    {
        isPattern = true;
        StartCoroutine(Scp1_1_Pattern());
    }
    #region Scp1_1 패턴로직
    IEnumerator Scp1_1_Pattern()
    {
        float startTime = Time.time;
        while(Time.time - startTime < 2)
        {
            if(Time.time - startTime < 1)
            {
                StartCoroutine(BossShaking(0.3f, 0.15f));
            }
            if(Time.time - startTime > 1)
            {
                // 애니메이션 실행
                Debug.Log("anim");
            }
            yield return null;
        }
        Vector3 targetPos = PlayerPos ;
        Vector3 startPos = this.transform.position;
        startTime = Time.time;
        float duration = 0.7f; // 이동에 걸리는 시간
        while (Time.time - startTime < 2)
        {
            float t = (Time.time - startTime) / duration;
            rigidbody2D.MovePosition(Vector3.Lerp(startPos, targetPos, t));
            yield return null;
        }

        isPattern = false;
    }

    #endregion

    public void Scp1_2()
    {
        isPattern = true;

        Sword.transform.position = new Vector3(-10f, 20f, 0);
        Sword.transform.rotation = Quaternion.Euler(0, 0, 140f);
        StartCoroutine(Scp1_2_1());
    }
    #region Scp1_2 패턴로직
    IEnumerator Scp1_2_1()
    {
        Sword.SetActive(true);
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 1) // 1초간 rotation.z 값 변경
        {
            float backX = 2.5f;
            float upY = 2f;
            float RotateZ = 4.5f;
            Sword.transform.position += new Vector3(-backX * Time.deltaTime, upY * Time.deltaTime, 0);
            Sword.transform.Rotate(0, 0, RotateZ * Time.deltaTime);
            yield return null;
        }

        startTime = Time.time; // 시작 시간 재설정
        while (Time.time - startTime < 2.0f) // 2.5초간 position.y 값 변경 및 rotation.z 값 변경
        {
            if(Sword.transform.position.y  > -12)
            {
                float frontX = 30f;
                float downY = 130f;
                float RotateZ = 90f;
                Sword.transform.position += new Vector3(frontX * Time.deltaTime, -downY * Time.deltaTime, 0);
                Sword.transform.Rotate(0, 0, -RotateZ *  4 * Time.deltaTime);
            }
  

            yield return null;
        }
        Sword.SetActive(false);
        nextPtn1State = true;
        if(nextPtn1State)
        {
            Sword.transform.position = new Vector3(4, -25f, 0);
            Sword.transform.rotation = Quaternion.Euler(0, 0, 320f);
            StartCoroutine(Scp1_2_2());
        }
    }
    IEnumerator Scp1_2_2()
    {
        Sword.SetActive(true);
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 1) // 1초간 rotation.z 값 변경
        {
            float backX = 2.5f;
            float upY = 2f;
            float RotateZ = 4.5f;
            Sword.transform.position += new Vector3(+backX * Time.deltaTime, -upY * Time.deltaTime, 0);
            Sword.transform.Rotate(0, 0, RotateZ * Time.deltaTime);
            yield return null;
        }

        startTime = Time.time; // 시작 시간 재설정
        while (Time.time - startTime < 2.0f) // 2.5초간 position.y 값 변경 및 rotation.z 값 변경
        {
            if (Sword.transform.position.y < 25f)
            {
                float frontX = 30f;
                float upY = 150f;
                float RotateZ = 80;
                Sword.transform.position += new Vector3(-frontX * Time.deltaTime, upY * Time.deltaTime, 0);
                Sword.transform.Rotate(0, 0, -RotateZ * 4 * Time.deltaTime);
            }


            yield return null;
        }
        Sword.SetActive(false);
        nextPtn1State = false;
        isPattern = false;
    }
    #endregion
    void overlab_Scp1_2() 
    {
        isOverlab = true;
        Sword.transform.position = new Vector3(-10f, 20f, 0);
        Sword.transform.rotation = Quaternion.Euler(0, 0, 140f);
    } // 오버랩용 함수
    #region Scp 1_2 Overlab
    IEnumerator overlab_Scp1_2_1()
    {
        overlab_pattern2_1 = Instantiate(Sword.gameObject);
        overlab_pattern2_2 = Instantiate(Sword.gameObject);
        overlab_pattern2_1.SetActive(true);

        overlab_pattern2_1.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        overlab_pattern2_2.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 1) // 1초간 rotation.z 값 변경
        {
            float backX = 2.5f;
            float upY = 2f;
            float RotateZ = 4.5f;
            overlab_pattern2_1.transform.position += new Vector3(-backX * Time.deltaTime, upY * Time.deltaTime, 0);
            overlab_pattern2_1.transform.Rotate(0, 0, RotateZ * Time.deltaTime);
            yield return null;
        }

        startTime = Time.time; // 시작 시간 재설정
        while (Time.time - startTime < 2.0f) // 2.5초간 position.y 값 변경 및 rotation.z 값 변경
        {
            if (overlab_pattern2_1.transform.position.y > -12)
            {
                float frontX = 30f;
                float downY = 130f;
                float RotateZ = 90f;
                overlab_pattern2_1.transform.position += new Vector3(frontX * Time.deltaTime, -downY * Time.deltaTime, 0);
                overlab_pattern2_1.transform.Rotate(0, 0, -RotateZ * 4 * Time.deltaTime);
            }


            yield return null;
        }
        overlab_pattern2_1.SetActive(false);
        nextPtn1State = true;
        if (nextPtn1State)
        {
            overlab_pattern2_2.transform.position = new Vector3(4, -25f, 0);
            overlab_pattern2_2.transform.rotation = Quaternion.Euler(0, 0, 320f);
            StartCoroutine(overlab_Scp1_2_2());
        }
    }
    IEnumerator overlab_Scp1_2_2()
    {
        overlab_pattern2_2.SetActive(true);
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 1) // 1초간 rotation.z 값 변경
        {
            float backX = 2.5f;
            float upY = 2f;
            float RotateZ = 4.5f;
            overlab_pattern2_2.transform.position += new Vector3(+backX * Time.deltaTime, -upY * Time.deltaTime, 0);
            overlab_pattern2_2.transform.Rotate(0, 0, RotateZ * Time.deltaTime);
            yield return null;
        }

        startTime = Time.time; // 시작 시간 재설정
        while (Time.time - startTime < 2.0f) // 2.5초간 position.y 값 변경 및 rotation.z 값 변경
        {
            if (overlab_pattern2_2.transform.position.y < 25f)
            {
                float frontX = 30f;
                float upY = 150f;
                float RotateZ = 80;
                overlab_pattern2_2.transform.position += new Vector3(-frontX * Time.deltaTime, upY * Time.deltaTime, 0);
                overlab_pattern2_2.transform.Rotate(0, 0, -RotateZ * 4 * Time.deltaTime);
            }


            yield return null;
        }
        overlab_pattern2_2.SetActive(false);
        nextPtn1State = false;
        isOverlab = false;
    }
    #endregion
    public void Scp1_3()
    {
        #region 복제
        pattern3_1 = Instantiate(Kunai.gameObject);
        pattern3_2 = Instantiate(Kunai.gameObject);
        pattern3_3 = Instantiate(Kunai.gameObject);
        #endregion

        #region Pattern3 Setting Pos
        float posX = 8f;
        float posY = 10f;

        pattern3_1.transform.position = new Vector3(PlayerPos.x  - posX, PlayerPos.y - posY, 0);
        pattern3_1.transform.eulerAngles = new Vector3(0, 0, 220);

        pattern3_2.transform.position = new Vector3(PlayerPos.x, PlayerPos.y - posY - 3f, 0);
        pattern3_2.transform.eulerAngles = new Vector3(0, 0, 270);

        pattern3_3.transform.position = new Vector3(PlayerPos.x + posX, PlayerPos.y - posY, 0);
        pattern3_3.transform.eulerAngles = new Vector3(0, 0, 320);
        #endregion
        isPattern = true;
        StartCoroutine(Scp1_3_1());
    }
    #region Scp 1_3 패턴로직
    IEnumerator Scp1_3_1()
    {
        pattern3_1.SetActive(true);
        pattern3_2.SetActive(true);
        pattern3_3.SetActive(true);

        Vector3 dir1 = (PlayerPos - pattern3_1.transform.position).normalized;
        Vector3 dir2 = (PlayerPos - pattern3_2.transform.position).normalized;
        Vector3 dir3 = (PlayerPos - pattern3_3.transform.position).normalized;

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 2) // 1초간 rotation.z 값 변경
        {
            float backPos = 1f;

            pattern3_1.transform.position += new Vector3(-backPos * Time.deltaTime, -backPos * Time.deltaTime, 0);
            pattern3_2.transform.position += new Vector3(0, -backPos * Time.deltaTime, 0);
            pattern3_3.transform.position += new Vector3(backPos * Time.deltaTime, -backPos * Time.deltaTime, 0);


            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < 2) // 1초간 rotation.z 값 변경
        {
            float speed = 100f;
            pattern3_1.transform.position += new Vector3(speed * dir1.x * Time.deltaTime, speed * dir1.y * Time.deltaTime, 0);
            pattern3_2.transform.position += new Vector3(speed * dir2.x * Time.deltaTime, speed * dir2.y * Time.deltaTime, 0);
            pattern3_3.transform.position += new Vector3(speed * dir3.x * Time.deltaTime, speed * dir3.y * Time.deltaTime, 0);

            yield return null;
        }

        Destroy(pattern3_1);
        Destroy(pattern3_2);
        Destroy(pattern3_3);

        isPattern = false;
    }
    #endregion
    void overlab_Scp1_3()
    {
        isOverlab = true;
        overlab_pattern3_1 = Instantiate(Kunai.gameObject);
        overlab_pattern3_2 = Instantiate(Kunai.gameObject);
        overlab_pattern3_3 = Instantiate(Kunai.gameObject);

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
        isPattern = true;
        StartCoroutine(overlab_Scp1_3_1());
    }
    #region overlab_Scp 1_3 패턴로직
    IEnumerator overlab_Scp1_3_1()
    {
        overlab_pattern3_1.SetActive(true);
        overlab_pattern3_2.SetActive(true);
        overlab_pattern3_3.SetActive(true);

        Vector3 dir1 = (PlayerPos - overlab_pattern3_1.transform.position).normalized;
        Vector3 dir2 = (PlayerPos - overlab_pattern3_2.transform.position).normalized;
        Vector3 dir3 = (PlayerPos - overlab_pattern3_3.transform.position).normalized;

        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 2) // 1초간 rotation.z 값 변경
        {
            float backPos = 1f;

            overlab_pattern3_1.transform.position += new Vector3(-backPos * Time.deltaTime,-backPos * Time.deltaTime, 0);
            overlab_pattern3_2.transform.position += new Vector3(0,-backPos * Time.deltaTime, 0);
            overlab_pattern3_3.transform.position += new Vector3( backPos * Time.deltaTime,-backPos * Time.deltaTime, 0);


            yield return null;          
        }
        startTime = Time.time;
        while (Time.time - startTime < 2) // 1초간 rotation.z 값 변경
        {
            float speed = 100f;
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
    }
    #region Scp 1_4 패턴로직
    IEnumerator Scp1_4_Total()
    {
        int cnt = 8;
        while(cnt >0)
        {
            if(cnt == 8) 
            {
                pattern4_1 = Instantiate(Sword.gameObject);
                pattern4_1.transform.position = new Vector3(-35f, 48f, 0);
                pattern4_1.transform.eulerAngles = new Vector3(0, 0, 90);
                StartCoroutine(Scp1_4_1());
            } // 왼
            if(cnt == 7)
            {
                pattern4_2 = Instantiate(Sword.gameObject);
                pattern4_2.transform.position = new Vector3(40, 35, 0);
                pattern4_2.transform.eulerAngles = new Vector3(180, 0, 270);
                StartCoroutine(Scp1_4_2());
            } // 오
            if(cnt == 6)
            {
                pattern4_3 = Instantiate(Sword.gameObject);
                pattern4_3.transform.position = new Vector3(-35f, 22, 0);
                pattern4_3.transform.eulerAngles = new Vector3(0, 0, 90);
                StartCoroutine(Scp1_4_3());

            } // 왼
            if(cnt == 5)
            {
                pattern4_4 = Instantiate(Sword.gameObject);
                pattern4_4.transform.position = new Vector3(40, 9, 0);
                pattern4_4.transform.eulerAngles = new Vector3(180, 0, 270);
                StartCoroutine(Scp1_4_4());
            } // 오
            if(cnt == 4)
            {
                pattern4_5 = Instantiate(Sword.gameObject);
                pattern4_5.transform.position = new Vector3(-35f, -4, 0);
                pattern4_5.transform.eulerAngles = new Vector3(0, 0, 90);
                StartCoroutine(Scp1_4_5());
            } // 왼
            if(cnt == 3)
            {
                pattern4_6 = Instantiate(Sword.gameObject);
                pattern4_6.transform.position = new Vector3(40, -17, 0);
                pattern4_6.transform.eulerAngles = new Vector3(180, 0, 270);
                StartCoroutine(Scp1_4_6());
            } // 오
            if(cnt == 2)
            {
                pattern4_7 = Instantiate(Sword.gameObject);
                pattern4_7.transform.position = new Vector3(-35f, -30, 0);
                pattern4_7.transform.eulerAngles = new Vector3(0, 0, 90);
                StartCoroutine(Scp1_4_7());
            } // 왼
            if(cnt == 1)
            {
                pattern4_8 = Instantiate(Sword.gameObject);
                pattern4_8.transform.position = new Vector3(40, -43, 0);
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
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 4) 
        {
            float speed = 2f;
            pattern4_1.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

            yield return null;
        }

        startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3) 
        {
            if(pattern4_1.transform.position.x < -30)
            {
                float speed = 200f;
                pattern4_1.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }

            yield return null;
        }
       Destroy(pattern4_1);
       StopCoroutine(Scp1_4_1());
    }
    IEnumerator Scp1_4_2()
    {
        pattern4_2.SetActive(true);
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 4)
        {
            float speed = 2f;
            pattern4_2.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

            yield return null;
        }
        startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (pattern4_2.transform.position.x > 30)
            {
                float speed = 200f;
                pattern4_2.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }

            yield return null;
        }
        Destroy(pattern4_2);
        StopCoroutine(Scp1_4_2());

    }
    IEnumerator Scp1_4_3()
    {
        pattern4_3.SetActive(true);
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 4)
        {
            float speed = 2f;
            pattern4_3.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

            yield return null;
        }

        startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (pattern4_3.transform.position.x < -30)
            {
                float speed = 200f;
                pattern4_3.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }

            yield return null;
        }
        Destroy(pattern4_3);
        StopCoroutine(Scp1_4_3());
    }
    IEnumerator Scp1_4_4()
    {
        pattern4_4.SetActive(true);
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 4)
        {
            float speed = 2f;
            pattern4_4.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

            yield return null;
        }
        startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (pattern4_4.transform.position.x > 30)
            {
                float speed = 200f;
                pattern4_4.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }

            yield return null;
        }
        Destroy(pattern4_4);
        StopCoroutine(Scp1_4_4());
    }
    IEnumerator Scp1_4_5()
    {
        pattern4_5.SetActive(true);
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 4)
        {
            float speed = 2f;
            pattern4_5.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

            yield return null;
        }

        startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (pattern4_5.transform.position.x < -30)
            {
                float speed = 200f;
                pattern4_5.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }

            yield return null;
        }
        Destroy(pattern4_5);
        StopCoroutine(Scp1_4_5());
    }
    IEnumerator Scp1_4_6()
    {
        pattern4_6.SetActive(true);
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 4)
        {
            float speed = 2f;
            pattern4_6.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

            yield return null;
        }
        startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (pattern4_6.transform.position.x > 30)
            {
                float speed = 200f;
                pattern4_6.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }

            yield return null;
        }
        Destroy(pattern4_6);
        StopCoroutine(Scp1_4_6());

    }
    IEnumerator Scp1_4_7()
    {
        pattern4_7.SetActive(true);
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 4)
        {
            float speed = 2f;
            pattern4_7.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

            yield return null;
        }

        startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (pattern4_7.transform.position.x < -30)
            {
                float speed = 200f;
                pattern4_7.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }

            yield return null;
        }
        Destroy(pattern4_7);
        StopCoroutine(Scp1_4_7());
    }
    IEnumerator Scp1_4_8()
    {
        pattern4_8.SetActive(true);
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 4)
        {
            float speed = 2f;
            pattern4_8.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

            yield return null;
        }
        startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            if (pattern4_8.transform.position.x > 30)
            {
                float speed = 200f;
                pattern4_8.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }

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
    }
    #region Scp 1_5 패턴로직
    IEnumerator Scp1_5_total()
    {
        int cnt = 5;
        while (cnt > 0)
        {
            if (cnt == 5)
            {
                pattern5_1 = Instantiate(Gun.gameObject);
                pattern5_1.transform.position = new Vector3(-35, 44f, 0);
                pattern5_1.transform.eulerAngles = new Vector3(0, 0, 0);

                target_1 = Instantiate(Target.gameObject);
                StartCoroutine(Scp1_5_1());
            }
            if (cnt == 4)
            {
                pattern5_2 = Instantiate(Gun.gameObject);
                pattern5_2.transform.position = new Vector3(35f, 24f, 0);
                pattern5_2.transform.eulerAngles = new Vector3(0, 0, 0);
                target_2 = Instantiate(Target.gameObject);
                StartCoroutine(Scp1_5_2());
            }
            if (cnt == 3)
            {
                pattern5_3 = Instantiate(Gun.gameObject);
                pattern5_3.transform.position = new Vector3(-35f, 4f, 0);
                pattern5_3.transform.eulerAngles = new Vector3(0, 0 - 0);
                target_3 = Instantiate(Target.gameObject);
                StartCoroutine(Scp1_5_3());
            }
            if (cnt == 2)
            {
                pattern5_4 = Instantiate(Gun.gameObject);
                pattern5_4.transform.position = new Vector3(35f, -24f, 0);
                pattern5_4.transform.eulerAngles = new Vector3(0, 0, 0);
                target_4 = Instantiate(Target.gameObject);
                StartCoroutine(Scp1_5_4());
            }
            if (cnt == 1)
            {
                pattern5_5 = Instantiate(Gun.gameObject);
                pattern5_5.transform.position = new Vector3(-35f, -44f, 0);
                pattern5_5.transform.eulerAngles = new Vector3(0, 0 - 40f);
                target_5 = Instantiate(Target.gameObject);
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
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            Vector3 direction = PlayerPos - pattern5_1.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            pattern5_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            target_1.transform.position = PlayerPos;
            target_1.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);
            yield return null;
        }

        startTime = Time.time;

        Transform bulletPosTransform = pattern5_1.transform.Find("BulletPos");
        GameObject bullet = Instantiate(Bullet.gameObject);
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = pattern5_1.transform.rotation;
        float bulletSpeed = 300f;
        Vector3 dir = PlayerPos - pattern5_1.transform.position;
        StartCoroutine(CameraShaking(0.1f, 0.5f));

        while (Time.time - startTime < 2)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
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
        float startTime = Time.time; // 시작 시간 저장

        SpriteRenderer before_Sprite = target_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color before_Color = before_Sprite.color;
        before_Color.a = 0;
        while (Time.time - startTime < 3)
        {
            Vector3 direction = PlayerPos - pattern5_2.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            pattern5_2.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            before_Sprite.color = before_Color;
            target_2.transform.position = PlayerPos;
            target_2.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);

            yield return null;
        }
        startTime = Time.time;
        Transform bulletPosTransform = pattern5_2.transform.Find("BulletPos");
        GameObject bullet = Instantiate(Bullet.gameObject);
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = pattern5_2.transform.rotation;
        float bulletSpeed = 300f;
        Vector3 dir = PlayerPos - pattern5_2.transform.position;
        StartCoroutine(CameraShaking(0.1f, 0.5f));
        while (Time.time - startTime < 2)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
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
        float startTime = Time.time; // 시작 시간 저장

        SpriteRenderer before_Sprite = target_2.GetComponent<SpriteRenderer>();
        UnityEngine.Color before_Color = before_Sprite.color;
        before_Color.a = 0;

        while (Time.time - startTime < 3)
        {
            Vector3 direction = PlayerPos - pattern5_3.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            pattern5_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            before_Sprite.color = before_Color;
            target_3.transform.position = PlayerPos;
            target_3.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);
            yield return null;
        }

        Transform bulletPosTransform = pattern5_3.transform.Find("BulletPos");
        startTime = Time.time;

        GameObject bullet = Instantiate(Bullet.gameObject);
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = pattern5_3.transform.rotation;
        float bulletSpeed = 300f;
        Vector3 dir = PlayerPos - pattern5_3.transform.position;
        StartCoroutine(CameraShaking(0.1f, 0.5f));
        while (Time.time - startTime < 2)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
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
        float startTime = Time.time; // 시작 시간 저장

        SpriteRenderer before_Sprite = target_3.GetComponent<SpriteRenderer>();
        UnityEngine.Color before_Color = before_Sprite.color;
        before_Color.a = 0;

        while (Time.time - startTime < 3)
        {
            Vector3 direction = PlayerPos - pattern5_4.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            pattern5_4.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            before_Sprite.color = before_Color ;
            target_4.transform.position = PlayerPos;
            target_4.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);

            yield return null;
        }
        Transform bulletPosTransform = pattern5_4.transform.Find("BulletPos");
        startTime = Time.time;
        GameObject bullet = Instantiate(Bullet.gameObject);
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = pattern5_4.transform.rotation;
        float bulletSpeed = 300f;
        Vector3 dir = PlayerPos - pattern5_4.transform.position;
        StartCoroutine(CameraShaking(0.1f, 0.5f));
        while (Time.time - startTime < 2)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;

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
        float startTime = Time.time; // 시작 시간 저장

        SpriteRenderer before_Sprite = target_4.GetComponent<SpriteRenderer>();
        UnityEngine.Color before_Color = before_Sprite.color;
        before_Color.a = 0;

        while (Time.time - startTime < 3)
        {
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
        startTime = Time.time;
        Transform bulletPosTransform = pattern5_5.transform.Find("BulletPos");
        GameObject bullet = Instantiate(Bullet.gameObject);
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = pattern5_5.transform.rotation;
        float bulletSpeed = 300f;
        Vector3 dir = PlayerPos - pattern5_5.transform.position;
        StartCoroutine(CameraShaking(0.1f, 0.5f));
        while (Time.time - startTime < 2)
        {
            if (Time.time - startTime < 1.5f)
            {
                Destroy(target_1);
                Destroy(target_2);
                Destroy(target_3);
                Destroy(target_4);
            } // 조준점 삭제

            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
            Destroy(target_5);
            yield return null;
        }
        Destroy(pattern5_5);
        Destroy(bullet);
        isPattern = false;
    }
    #endregion
    void overlab_Scp1_5()
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
                overlab_pattern5_1 = Instantiate(Gun.gameObject);
                overlab_pattern5_1.transform.position = new Vector3(-35, 44f, 0);
                overlab_pattern5_1.transform.eulerAngles = new Vector3(0, 0, 0);

                overlab_target1 = Instantiate(Target.gameObject);
                StartCoroutine(overlab_Scp1_5_1());
            }
            if (cnt == 4)
            {
                overlab_pattern5_2 = Instantiate(Gun.gameObject);
                overlab_pattern5_2.transform.position = new Vector3(35f, 24f, 0);
                overlab_pattern5_2.transform.eulerAngles = new Vector3(0, 0, 0);
                overlab_target2 = Instantiate(Target.gameObject);
                StartCoroutine(overlab_Scp1_5_2());
            }
            if (cnt == 3)
            {
                overlab_pattern5_3 = Instantiate(Gun.gameObject);
                overlab_pattern5_3.transform.position = new Vector3(-35f, 4f, 0);
                overlab_pattern5_3.transform.eulerAngles = new Vector3(0, 0 - 0);
                overlab_target3 = Instantiate(Target.gameObject);
                StartCoroutine(overlab_Scp1_5_3());
            }
            if (cnt == 2)
            {
                overlab_pattern5_4 = Instantiate(Gun.gameObject);
                overlab_pattern5_4.transform.position = new Vector3(35f, -24f, 0);
                overlab_pattern5_4.transform.eulerAngles = new Vector3(0, 0, 0);
                overlab_target4 = Instantiate(Target.gameObject);
                StartCoroutine(overlab_Scp1_5_4());
            }
            if (cnt == 1)
            {
                overlab_pattern5_5 = Instantiate(Gun.gameObject);
                overlab_pattern5_5.transform.position = new Vector3(-35f, -44f, 0);
                overlab_pattern5_5.transform.eulerAngles = new Vector3(0, 0 - 40f);
                overlab_target5 = Instantiate(Target.gameObject);
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
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 3)
        {
            Vector3 direction = PlayerPos - overlab_pattern5_1.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            overlab_pattern5_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            overlab_target1.transform.position = PlayerPos;
            overlab_target1.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);
            yield return null;
        }

        startTime = Time.time;

        Transform bulletPosTransform = overlab_pattern5_1.transform.Find("BulletPos");
        GameObject bullet = Instantiate(Bullet.gameObject);
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = overlab_pattern5_1.transform.rotation;
        float bulletSpeed = 300f;
        Vector3 dir = PlayerPos - overlab_pattern5_1.transform.position;
        StartCoroutine(CameraShaking(0.1f, 0.5f));

        while (Time.time - startTime < 2)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
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
        float startTime = Time.time; // 시작 시간 저장

        SpriteRenderer before_Sprite = overlab_target1.GetComponent<SpriteRenderer>();
        UnityEngine.Color before_Color = before_Sprite.color;
        before_Color.a = 0;
        while (Time.time - startTime < 3)
        {
            Vector3 direction = PlayerPos - overlab_pattern5_2.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            overlab_pattern5_2.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            before_Sprite.color = before_Color;
            overlab_target2.transform.position = PlayerPos;
            overlab_target2.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);

            yield return null;
        }
        startTime = Time.time;
        Transform bulletPosTransform = overlab_pattern5_2.transform.Find("BulletPos");
        GameObject bullet = Instantiate(Bullet.gameObject);
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = overlab_pattern5_2.transform.rotation;
        float bulletSpeed = 300f;
        Vector3 dir = PlayerPos - overlab_pattern5_2.transform.position;
        StartCoroutine(CameraShaking(0.1f, 0.5f));
        while (Time.time - startTime < 2)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
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
        float startTime = Time.time; // 시작 시간 저장

        SpriteRenderer before_Sprite = overlab_target2.GetComponent<SpriteRenderer>();
        UnityEngine.Color before_Color = before_Sprite.color;
        before_Color.a = 0;

        while (Time.time - startTime < 3)
        {
            Vector3 direction = PlayerPos - overlab_pattern5_3.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            overlab_pattern5_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            before_Sprite.color = before_Color;
            overlab_target3.transform.position = PlayerPos;
            overlab_target3.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);
            yield return null;
        }

        Transform bulletPosTransform = overlab_pattern5_3.transform.Find("BulletPos");
        startTime = Time.time;

        GameObject bullet = Instantiate(Bullet.gameObject);
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = overlab_pattern5_3.transform.rotation;
        float bulletSpeed = 300f;
        Vector3 dir = PlayerPos - overlab_pattern5_3.transform.position;
        StartCoroutine(CameraShaking(0.1f, 0.5f));
        while (Time.time - startTime < 2)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
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
        float startTime = Time.time; // 시작 시간 저장

        SpriteRenderer before_Sprite = overlab_target3.GetComponent<SpriteRenderer>();
        UnityEngine.Color before_Color = before_Sprite.color;
        before_Color.a = 0;

        while (Time.time - startTime < 3)
        {
            Vector3 direction = PlayerPos - overlab_pattern5_4.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            overlab_pattern5_4.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            before_Sprite.color = before_Color;
            overlab_target4.transform.position = PlayerPos;
            overlab_target4.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);

            yield return null;
        }
        Transform bulletPosTransform = overlab_pattern5_4.transform.Find("BulletPos");
        startTime = Time.time;
        GameObject bullet = Instantiate(Bullet.gameObject);
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = overlab_pattern5_4.transform.rotation;
        float bulletSpeed = 300f;
        Vector3 dir = PlayerPos - overlab_pattern5_4.transform.position;
        StartCoroutine(CameraShaking(0.1f, 0.5f));
        while (Time.time - startTime < 2)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;

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
        float startTime = Time.time; // 시작 시간 저장

        SpriteRenderer before_Sprite = overlab_target4.GetComponent<SpriteRenderer>();
        UnityEngine.Color before_Color = before_Sprite.color;
        before_Color.a = 0;

        while (Time.time - startTime < 3)
        {
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
        startTime = Time.time;
        Transform bulletPosTransform = overlab_pattern5_5.transform.Find("BulletPos");
        GameObject bullet = Instantiate(Bullet.gameObject);
        bullet.SetActive(true);
        bullet.transform.position = bulletPosTransform.transform.position;
        bullet.transform.rotation = overlab_pattern5_5.transform.rotation;
        float bulletSpeed = 300f;
        Vector3 dir = PlayerPos - overlab_pattern5_5.transform.position;
        StartCoroutine(CameraShaking(0.1f, 0.5f));
        while (Time.time - startTime < 2)
        {
            if (Time.time - startTime < 1.5f)
            {
                Destroy(overlab_target1);
                Destroy(overlab_target2);
                Destroy(overlab_target3);
                Destroy(overlab_target4);
            } // 조준점 삭제

            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
            Destroy(overlab_target5);
            yield return null;
        }
        Destroy(overlab_pattern5_5);
        Destroy(bullet);
        isOverlab = false;
    }
    #endregion
    public void Scp1_6()
    {
        this.transform.position = new Vector3(0, 7, 0);
        isPattern = true;
        StartCoroutine(Scp1_6_1());
    }
    #region Scp 1_6 패턴로직
    IEnumerator Scp1_6_1()
    {
        #region Pattern6_1 오브젝트 생성및 기본설정
        pattern6_1 = Instantiate(Sword2.gameObject);
        pattern6_1.transform.position = new Vector3(-15, 20, 0);
        pattern6_1.transform.eulerAngles = new Vector3(0, 180, 180);
        SpriteRenderer spritePattern6_1 = pattern6_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern6_1 = spritePattern6_1.color;
        colorPattern6_1.a = 0f;
        spritePattern6_1.color = colorPattern6_1;
        #endregion
        pattern6_1.SetActive(true);

        #region Pattern6_2 오브젝트 생성및 기본설정
        pattern6_2 = Instantiate(Sword2.gameObject);
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
        float MoveSpeed = 60f;
        while (Time.time - startTime<2) // 첫번째 애니메이션
        {
            if(Time.time - startTime < 1)
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
            if (Time.time - startTime < 1)
            {
                dir = (PlayerPos - pattern6_2.transform.position).normalized;
            }
            pattern6_2.transform.eulerAngles += new Vector3(0, 0, +RotateSpeed * 70 * Time.deltaTime);
            pattern6_1.transform.eulerAngles += new Vector3(0, 0, -RotateSpeed * 70 * Time.deltaTime);

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
        isPattern = true;
        StartCoroutine(Scp1_7_1());
    }
    #region Scp 1_7 패턴로직
    IEnumerator Scp1_7_1()
    {
        #region 초기세팅
        pattern7_1 = Instantiate(Kunai.gameObject);
        pattern7_1.transform.position = new Vector3(-28, -40, 0);
        pattern7_1.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_1.SetActive(true);
        SpriteRenderer spritePattern7_1 = pattern7_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_1 = spritePattern7_1.color;
        colorPattern7_1.a = 0f;
        spritePattern7_1.color = colorPattern7_1;

        pattern7_2 = Instantiate(Kunai.gameObject);
        pattern7_2.transform.position = new Vector3(-21, -40, 0);
        pattern7_2.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_2.SetActive(true);
        SpriteRenderer spritePattern7_2 = pattern7_2.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_2 = spritePattern7_2.color;
        colorPattern7_2.a = 0f;
        spritePattern7_2.color = colorPattern7_2;

        pattern7_3 = Instantiate(Kunai.gameObject);
        pattern7_3.transform.position = new Vector3(-14, -40, 0);
        pattern7_3.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_3.SetActive(true);
        SpriteRenderer spritePattern7_3 = pattern7_3.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_3 = spritePattern7_3.color;
        colorPattern7_3.a = 0f;
        spritePattern7_3.color = colorPattern7_3;


        pattern7_4 = Instantiate(Kunai.gameObject);
        pattern7_4.transform.position = new Vector3(-7, -40, 0);
        pattern7_4.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_4.SetActive(true);
        SpriteRenderer spritePattern7_4 = pattern7_4.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_4 = spritePattern7_4.color;
        colorPattern7_4.a = 0f;
        spritePattern7_4.color = colorPattern7_4;

        pattern7_5 = Instantiate(Kunai.gameObject);
        pattern7_5.transform.position = new Vector3(0, -40, 0);
        pattern7_5.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_5.SetActive(true);
        SpriteRenderer spritePattern7_5 = pattern7_5.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_5 = spritePattern7_5.color;
        colorPattern7_5.a = 0f;
        spritePattern7_5.color = colorPattern7_5;

        pattern7_6 = Instantiate(Kunai.gameObject);
        pattern7_6.transform.position = new Vector3(7, -40, 0);
        pattern7_6.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_6.SetActive(true);
        SpriteRenderer spritePattern7_6 = pattern7_6.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_6 = spritePattern7_6.color;
        colorPattern7_6.a = 0f;
        spritePattern7_6.color = colorPattern7_6;

        pattern7_7 = Instantiate(Kunai.gameObject);
        pattern7_7.transform.position = new Vector3(14, -40, 0);
        pattern7_7.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_7.SetActive(true);
        SpriteRenderer spritePattern7_7 = pattern7_7.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_7 = spritePattern7_7.color;
        colorPattern7_7.a = 0f;
        spritePattern7_7.color = colorPattern7_7;

        pattern7_8 = Instantiate(Kunai.gameObject);
        pattern7_8.transform.position = new Vector3(21, -40, 0);
        pattern7_8.transform.eulerAngles = new Vector3(0, 0, 270);
        pattern7_8.SetActive(true);
        SpriteRenderer spritePattern7_8 = pattern7_8.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_8 = spritePattern7_8.color;
        colorPattern7_8.a = 0f;
        spritePattern7_8.color = colorPattern7_8;

        pattern7_9 = Instantiate(Kunai.gameObject);
        pattern7_9.transform.position = new Vector3(28, -40, 0);
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
        while(Time.time - startTime <2)
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
                pattern7_1.transform.position += new Vector3(0, speed1 * Time.deltaTime, 0);
                if (pattern7_1.transform.position.y >= 50)
                {
                    speed1 = 0;
                    pattern7_1.transform.position = new Vector3(-28, 50, 0);
                }
            }
            if (Time.time - startTime > 0.2f)
            {
                pattern7_2.transform.position += new Vector3(0, speed2 * Time.deltaTime, 0);
                if (pattern7_2.transform.position.y >= 50)
                {
                    speed2 = 0;
                    pattern7_2.transform.position = new Vector3(-21, 50, 0);
                }
            }
            if (Time.time - startTime > 0.3f)
            {
                pattern7_3.transform.position += new Vector3(0, speed3 * Time.deltaTime, 0);
                if (pattern7_3.transform.position.y >= 50)
                {
                    speed3 = 0;
                    pattern7_3.transform.position = new Vector3(-14, 50, 0);
                }
            }
            if (Time.time - startTime > 0.4f)
            {
                pattern7_4.transform.position += new Vector3(0, speed4 * Time.deltaTime, 0);
                if (pattern7_4.transform.position.y >= 50)
                {
                    speed4 = 0;
                    pattern7_4.transform.position = new Vector3(-7, 50, 0);
                }
            }
            if (Time.time - startTime > 0.5f)
            {
                pattern7_5.transform.position += new Vector3(0, speed5 * Time.deltaTime, 0);
                if (pattern7_5.transform.position.y >= 50)
                {
                    speed5 = 0;
                    pattern7_5.transform.position = new Vector3(0, 50, 0);
                }
            }
            if (Time.time - startTime > 0.6f)
            {
                pattern7_6.transform.position += new Vector3(0, speed6 * Time.deltaTime, 0);
                if (pattern7_6.transform.position.y >= 50)
                {
                    speed6 = 0;
                    pattern7_6.transform.position = new Vector3(7, 50, 0);
                }
            }
            if (Time.time - startTime > 0.7f)
            {
                pattern7_7.transform.position += new Vector3(0, speed7 * Time.deltaTime, 0);
                if (pattern7_7.transform.position.y >= 50)
                {
                    speed7 = 0;
                    pattern7_7.transform.position = new Vector3(14, 50, 0);
                }
            }
            if (Time.time - startTime > 0.8f)
            {
                pattern7_8.transform.position += new Vector3(0, speed8 * Time.deltaTime, 0);
                if (pattern7_8.transform.position.y >= 50)
                {
                    speed8 = 0;
                    pattern7_8.transform.position = new Vector3(21, 50, 0);
                }
            }
            if (Time.time - startTime > 0.9f)
            {
                pattern7_9.transform.position += new Vector3(0, speed9 * Time.deltaTime, 0);
                if (pattern7_9.transform.position.y >= 50)
                {
                    speed9 = 0;
                    pattern7_9.transform.position = new Vector3(28, 50, 0);
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
        isOverlab = true;
        StartCoroutine(overlab_Scp1_7_1());
    }
    #region overlab_Scp 1_7 패턴로직
    IEnumerator overlab_Scp1_7_1()
    {
        #region 초기세팅
        overlab_pattern7_1 = Instantiate(Kunai.gameObject);
        overlab_pattern7_1.transform.position = new Vector3(-28, -40, 0);
        overlab_pattern7_1.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_1.SetActive(true);
        SpriteRenderer spritePattern7_1 = overlab_pattern7_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_1 = spritePattern7_1.color;
        colorPattern7_1.a = 0f;
        spritePattern7_1.color = colorPattern7_1;

        overlab_pattern7_2 = Instantiate(Kunai.gameObject);
        overlab_pattern7_2.transform.position = new Vector3(-21, -40, 0);
        overlab_pattern7_2.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_2.SetActive(true);
        SpriteRenderer spritePattern7_2 = overlab_pattern7_2.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_2 = spritePattern7_2.color;
        colorPattern7_2.a = 0f;
        spritePattern7_2.color = colorPattern7_2;

        overlab_pattern7_3 = Instantiate(Kunai.gameObject);
        overlab_pattern7_3.transform.position = new Vector3(-14, -40, 0);
        overlab_pattern7_3.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_3.SetActive(true);
        SpriteRenderer spritePattern7_3 = overlab_pattern7_3.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_3 = spritePattern7_3.color;
        colorPattern7_3.a = 0f;
        spritePattern7_3.color = colorPattern7_3;


        overlab_pattern7_4 = Instantiate(Kunai.gameObject);
        overlab_pattern7_4.transform.position = new Vector3(-7, -40, 0);
        overlab_pattern7_4.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_4.SetActive(true);
        SpriteRenderer spritePattern7_4 = overlab_pattern7_4.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_4 = spritePattern7_4.color;
        colorPattern7_4.a = 0f;
        spritePattern7_4.color = colorPattern7_4;

        overlab_pattern7_5 = Instantiate(Kunai.gameObject);
        overlab_pattern7_5.transform.position = new Vector3(0, -40, 0);
        overlab_pattern7_5.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_5.SetActive(true);
        SpriteRenderer spritePattern7_5 = overlab_pattern7_5.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_5 = spritePattern7_5.color;
        colorPattern7_5.a = 0f;
        spritePattern7_5.color = colorPattern7_5;

        overlab_pattern7_6 = Instantiate(Kunai.gameObject);
        overlab_pattern7_6.transform.position = new Vector3(7, -40, 0);
        overlab_pattern7_6.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_6.SetActive(true);
        SpriteRenderer spritePattern7_6 = overlab_pattern7_6.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_6 = spritePattern7_6.color;
        colorPattern7_6.a = 0f;
        spritePattern7_6.color = colorPattern7_6;

        overlab_pattern7_7 = Instantiate(Kunai.gameObject);
        overlab_pattern7_7.transform.position = new Vector3(14, -40, 0);
        overlab_pattern7_7.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_7.SetActive(true);
        SpriteRenderer spritePattern7_7 = overlab_pattern7_7.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_7 = spritePattern7_7.color;
        colorPattern7_7.a = 0f;
        spritePattern7_7.color = colorPattern7_7;

        overlab_pattern7_8 = Instantiate(Kunai.gameObject);
        overlab_pattern7_8.transform.position = new Vector3(21, -40, 0);
        overlab_pattern7_8.transform.eulerAngles = new Vector3(0, 0, 270);
        overlab_pattern7_8.SetActive(true);
        SpriteRenderer spritePattern7_8 = overlab_pattern7_8.GetComponent<SpriteRenderer>();
        UnityEngine.Color colorPattern7_8 = spritePattern7_8.color;
        colorPattern7_8.a = 0f;
        spritePattern7_8.color = colorPattern7_8;

        overlab_pattern7_9 = Instantiate(Kunai.gameObject);
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
        Scp1_8_1();
    }
    #region Scp 1_8 패턴로직
    IEnumerator Scp1_8_Pattern()
    {
        #region 초기세팅 위치, 각도, 투명도0
        pattern8_1 = Instantiate(Bow.gameObject);
        pattern8_2 = Instantiate(Bow.gameObject);
        pattern8_3 = Instantiate(Bow.gameObject);

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

        arrow1 = Instantiate(arrow.gameObject);
        arrow2 = Instantiate(arrow.gameObject);
        arrow3 = Instantiate(arrow.gameObject);

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
        while(Time.time - startTime < 3)
        {
            
            if(Time.time - startTime > 0.7f && bowCnt == 1)
            {
                arrow1.transform.position += new Vector3(0, -2f, 0); // 활 위치 변경
                arrow2.transform.position += new Vector3(-1.75f, -1.75f, 0);
                arrow3.transform.position += new Vector3(1.75f, -1.75f, 0);
                bowCnt++;
            }
            if (Time.time - startTime > 1.4f   && bowCnt == 2)
            {
                arrow1.transform.position += new Vector3(0, -2f, 0); // 활 위치 변경
                arrow2.transform.position += new Vector3(-1.75f, -1.75f, 0);
                arrow3.transform.position += new Vector3(1.75f, -1.75f, 0);
                bowCnt++;
            }
            if (Time.time - startTime > 2.1f && bowCnt == 3)
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
        float bowSpeed = 150f;
        while (Time.time - startTime < 2)
        {
            //    bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
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
        target8_1 = Instantiate(Target.gameObject);
        target8_1.SetActive(true);
        SpriteRenderer target_sprite = target8_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color target_color = target_sprite.color;
        target_color.a = 0;
        target_sprite.color = target_color;
        float startTime = Time.time;

        arrow8_1 = Instantiate(arrow.gameObject);
        arrow8_2 = Instantiate(arrow.gameObject);
        arrow8_3 = Instantiate(arrow.gameObject);

        arrow8_1.transform.position = new Vector3(-10, 67, 0);
        arrow8_2.transform.position = new Vector3(0, 67, 0);
        arrow8_3.transform.position = new Vector3(10, 67, 0);

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
        Vector3 targetPosition = new Vector3(target8_1.transform.position.x, target8_1.transform.position.y + 8f, target8_1.transform.position.z);


        while (Time.time - startTime < 3)
        {
  
            float Distance1 = Vector3.Distance(arrow8_1.transform.position, target8_1.transform.position);
            float Distance2 = Vector3.Distance(arrow8_2.transform.position, target8_1.transform.position);
            float Distance3 = Vector3.Distance(arrow8_3.transform.position, target8_1.transform.position);
            float Speed = 4f;
       
            if (Distance1 <= 1f)
            {
                Debug.Log("1");
                arrow8_1.transform.position = targetPosition;
                arrow8_1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            else if(Distance1 > 1f)
            {
                if (Time.time - startTime > 0.15f)
                {
                    arrow8_1.GetComponent<Rigidbody2D>().velocity = (targetPosition - arrow8_1.transform.position).normalized * (Distance1 / 2f) * Speed;
                }
            }

            if (Distance2 <= 1f)
            {
                Debug.Log("2");
                arrow8_2.transform.position = targetPosition;
                arrow8_2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            else if (Distance2 > 1f)
            {
                if (Time.time - startTime > 0.3f)
                {
                    arrow8_2.GetComponent<Rigidbody2D>().velocity = (targetPosition - arrow8_2.transform.position).normalized * (Distance2 / 2f) * Speed;
                }
            }

            if (Distance3 <= 1f)
            {
                Debug.Log("3");
                arrow8_3.transform.position = targetPosition;
                arrow8_3.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            else if(Distance3 > 1f)
            {
                if (Time.time - startTime > 0.45f)
                {
                    arrow8_3.GetComponent<Rigidbody2D>().velocity = (targetPosition - arrow8_3.transform.position).normalized * (Distance3 / 2f) * Speed;
                }
            }


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
        isOverlab = true;
        StartCoroutine(overlab_Scp1_8_1_Pattern());
    }
    #region overlab_Scp1_8_1 패턴로직
    IEnumerator overlab_Scp1_8_1_Pattern()
    {
        overlab_target8_1 = Instantiate(Target.gameObject);
        overlab_target8_1.SetActive(true);
        SpriteRenderer target_sprite = overlab_target8_1.GetComponent<SpriteRenderer>();
        UnityEngine.Color target_color = target_sprite.color;
        target_color.a = 0;
        target_sprite.color = target_color;
        float startTime = Time.time;

        overlab_arrow8_1 = Instantiate(arrow.gameObject);
        overlab_arrow8_2 = Instantiate(arrow.gameObject);
        overlab_arrow8_3 = Instantiate(arrow.gameObject);

        overlab_arrow8_1.transform.position = new Vector3(-10, 67, 0);
        overlab_arrow8_2.transform.position = new Vector3(0, 67, 0);
        overlab_arrow8_3.transform.position = new Vector3(10, 67, 0);

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
        Vector3 targetPosition = new Vector3(overlab_target8_1.transform.position.x, overlab_target8_1.transform.position.y + 8f, overlab_target8_1.transform.position.z);


        while (Time.time - startTime < 3)
        {

            float Distance1 = Vector3.Distance(overlab_arrow8_1.transform.position, overlab_target8_1.transform.position);
            float Distance2 = Vector3.Distance(overlab_arrow8_2.transform.position, overlab_target8_1.transform.position);
            float Distance3 = Vector3.Distance(overlab_arrow8_3.transform.position, overlab_target8_1.transform.position);
            float Speed = 4f;

            if (Distance1 <= 1f)
            {
                Debug.Log("1");
                overlab_arrow8_1.transform.position = targetPosition;
                overlab_arrow8_1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            else if (Distance1 > 1f)
            {
                if (Time.time - startTime > 0.15f)
                {
                    overlab_arrow8_1.GetComponent<Rigidbody2D>().velocity = (targetPosition - overlab_arrow8_1.transform.position).normalized * (Distance1 / 2f) * Speed;
                }
            }

            if (Distance2 <= 1f)
            {
                Debug.Log("2");
                overlab_arrow8_2.transform.position = targetPosition;
                overlab_arrow8_2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            else if (Distance2 > 1f)
            {
                if (Time.time - startTime > 0.3f)
                {
                    overlab_arrow8_2.GetComponent<Rigidbody2D>().velocity = (targetPosition - overlab_arrow8_2.transform.position).normalized * (Distance2 / 2f) * Speed;
                }
            }

            if (Distance3 <= 1f)
            {
                Debug.Log("3");
                overlab_arrow8_3.transform.position = targetPosition;
                overlab_arrow8_3.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            else if (Distance3 > 1f)
            {
                if (Time.time - startTime > 0.45f)
                {
                    overlab_arrow8_3.GetComponent<Rigidbody2D>().velocity = (targetPosition - overlab_arrow8_3.transform.position).normalized * (Distance3 / 2f) * Speed;
                }
            }


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
        isPattern= true;
        StartCoroutine(Scp1_9_Pattern());
    }
    #region Scp1_9 패턴 로직
    IEnumerator Scp1_9_Pattern()
    {
        #region 초기 세팅
        pattern9_1 = Instantiate(Sword2.gameObject);
        pattern9_2 = Instantiate(Sword2.gameObject);

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
        while(Time.time - startTime < 1)
        {
            float Speed = 250f;
            if(randomValue == 1)
            {
                float X1 = 35f;
                float Y1 = 1f;
                if (pattern9_1.transform.eulerAngles.z < 0)
                {
                    Debug.Log("1");
                    Speed = 0f;
                    X1 = 0f;
                    Y1 = 0f;
                }
                pattern9_1.transform.position += new Vector3(-X1 * Time.deltaTime, -Y1 * Time.deltaTime, 0);
                pattern9_1.transform.eulerAngles += new Vector3(0,0,-Speed*Time.deltaTime);
             } // 위쪽검
           else if (randomValue == 2)
            {
                float X2 = 35f;
                float Y2 = 1f;
                if (pattern9_2.transform.eulerAngles.z < -35 )
                {
                    Debug.Log("2");
                    Speed = 0f;
                    X2= 0f;
                    Y2 = 0f;
                }
                pattern9_2.transform.position += new Vector3(X2 * Time.deltaTime, 0, 0);
                pattern9_2.transform.eulerAngles += new Vector3(0, Y2*Time.deltaTime, -Speed*Time.deltaTime);
            }
           else if(randomValue == 3)
            {
                // 패턴 x
                //continue;
            }
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
    void Update()
    {
        PlayerPos = Player.transform.position;
         if(PlayerController.atkState) // 공격상태이면
        {
            // 체력 감소하는로직
        }

        if (!isPattern && !isOverlab)
        {
            randomPattern = Random.Range(1, 11);
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


            }
        }

    }
}
