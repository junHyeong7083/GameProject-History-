using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stage1_Boss : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    private PlayerController playerController;
    public GameObject Player;
    Vector3 PlayerPos;
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
    // ----------------- bool -----------------
    bool isOverlab = false;
    void Start()
    {
        // 보스 현재 포지션 0, 2
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerController = Player.GetComponent<PlayerController>();

    }
    void OverlabMixPattern()
    {
        // Rand써서 오버랩가능한 패턴 섞기
    }


    public void Scp1_2()
    {
        OverlabMixPattern();
        isOverlab = true;

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
    }
    #endregion
    public void Scp1_3()
    {
        #region 복제
        pattern3_1 = Instantiate(Kunai.gameObject);
        pattern3_2 = Instantiate(Kunai.gameObject);
        pattern3_3 = Instantiate(Kunai.gameObject);
        #endregion
        isOverlab = true;
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
            
            pattern3_1.transform.position += new Vector3(-backPos * Time.deltaTime,-backPos * Time.deltaTime, 0);
            pattern3_2.transform.position += new Vector3(0,-backPos * Time.deltaTime, 0);
            pattern3_3.transform.position += new Vector3( backPos * Time.deltaTime,-backPos * Time.deltaTime, 0);


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

        StopCoroutine(Scp1_3_1());
    }
    #endregion 
    public void Scp1_4()
    {
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
            if(pattern4_1.transform.position.x < 25)
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
            if (pattern4_2.transform.position.x > -25)
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
            if (pattern4_3.transform.position.x < 25)
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
            if (pattern4_4.transform.position.x > -25)
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
            if (pattern4_5.transform.position.x < 25)
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
            if (pattern4_6.transform.position.x > -25)
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
            if (pattern4_7.transform.position.x < 25)
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
            if (pattern4_8.transform.position.x > -25)
            {
                float speed = 200f;
                pattern4_8.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }

            yield return null;
        }
        Destroy(pattern4_8);
        StopCoroutine(Scp1_4_8());
    }
    #endregion
    public void Scp1_5()
    {
        StartCoroutine(Scp1_5_total());
    }
    #region Scp 1_5 패턴로직
    IEnumerator Scp1_5_total()
    {
        int cnt = 5;
        while(cnt > 0)
        {
            if(cnt  == 5)
            {
                pattern5_1 = Instantiate(Gun.gameObject);       
                pattern5_1.transform.position = new Vector3(-30, 44f, 0);
                pattern5_1.transform.eulerAngles = new Vector3(0, 0 ,0);

               target_1 = Instantiate(Target.gameObject);
                StartCoroutine(Scp1_5_1());
            }
            if (cnt == 4)
            {
                pattern5_2 = Instantiate(Gun.gameObject);
                pattern5_2.transform.position = new Vector3(30f, 24f, 0);
                pattern5_2.transform.eulerAngles = new Vector3(0, 0, 0);
                target_2 = Instantiate(Target.gameObject);
                StartCoroutine(Scp1_5_2());
            }
            if (cnt == 3)
            {
                pattern5_3 = Instantiate(Gun.gameObject);
                pattern5_3.transform.position = new Vector3(-30f, 4f, 0);
                pattern5_3.transform.eulerAngles = new Vector3(0, 0 - 0);
                target_3 = Instantiate(Target.gameObject);
                StartCoroutine(Scp1_5_3());
            }
            if (cnt == 2)
            {
                pattern5_4 = Instantiate(Gun.gameObject);
                pattern5_4.transform.position = new Vector3(30f, -24f, 0);
                pattern5_4.transform.eulerAngles = new Vector3(0, 0, 0);
                target_4 = Instantiate(Target.gameObject);
                StartCoroutine(Scp1_5_4());
            }
            if (cnt == 1)
            {
                pattern5_5 = Instantiate(Gun.gameObject);
                pattern5_5.transform.position = new Vector3(-30f, -44f, 0);
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
        while(Time.time - startTime < 3)
        {
            Vector3 direction = PlayerPos - pattern5_1.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            pattern5_1.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            target_1.transform.position = PlayerPos;
            target_1.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);
            yield return null;
        }
        startTime = Time.time;

        GameObject bullet = Instantiate(Bullet.gameObject);
        bullet.SetActive(true);
        bullet.transform.position = pattern5_1.transform.position;
        bullet.transform.rotation = pattern5_1.transform.rotation;
        float bulletSpeed = 300f;
        Vector3 dir = PlayerPos - pattern5_1.transform.position;
        while (Time.time - startTime < 2)
        {
            if(Time.time - startTime < 1.5f)
                Destroy(target_1);

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
        while (Time.time - startTime < 3)
        {
            Vector3 direction = PlayerPos - pattern5_2.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            pattern5_2.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            target_2.transform.position = PlayerPos;
            target_2.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);

            yield return null;
        }
        startTime = Time.time;
        GameObject bullet = Instantiate(Bullet.gameObject);
        bullet.SetActive(true);
        bullet.transform.position = pattern5_2.transform.position;
        bullet.transform.rotation = pattern5_2.transform.rotation;
        float bulletSpeed = 300f;
        Vector3 dir = PlayerPos - pattern5_2.transform.position;
        while (Time.time - startTime < 2)
        {
            if (Time.time - startTime < 1.5f)
                Destroy(target_2);

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
        while (Time.time - startTime < 3)
        {
            Vector3 direction = PlayerPos - pattern5_3.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            pattern5_3.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            target_3.transform.position = PlayerPos;
            target_3.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);
            yield return null;
        }
        startTime = Time.time;


        GameObject bullet = Instantiate(Bullet.gameObject);
        bullet.SetActive(true);
        bullet.transform.position = pattern5_3.transform.position;
        bullet.transform.rotation = pattern5_3.transform.rotation;
        float bulletSpeed = 300f;
        Vector3 dir = PlayerPos - pattern5_3.transform.position;
        while (Time.time - startTime < 2)
        {
            if (Time.time - startTime < 1.5f)
                Destroy(target_3);

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
        while (Time.time - startTime < 3)
        {
            Vector3 direction = PlayerPos - pattern5_4.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            pattern5_4.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            target_4.transform.position = PlayerPos;
            target_4.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);

            yield return null;
        }
        startTime = Time.time;
        GameObject bullet = Instantiate(Bullet.gameObject);
        bullet.SetActive(true);
        bullet.transform.position = pattern5_4.transform.position;
        bullet.transform.rotation = pattern5_4.transform.rotation;
        float bulletSpeed = 300f;
        Vector3 dir = PlayerPos - pattern5_4.transform.position;
        while (Time.time - startTime < 2)
        {
            if (Time.time - startTime < 1.5f)
                Destroy(target_4);

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
        while (Time.time - startTime < 3)
        {
            Vector3 direction = PlayerPos - pattern5_5.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            pattern5_5.transform.rotation = Quaternion.Euler(0, 0, lookRotation.eulerAngles.z + 90); // 총구가 바라보는 방향으로 회전

            target_5.transform.position = PlayerPos;
            target_5.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);

            yield return null;
        }
        startTime = Time.time;
        GameObject bullet = Instantiate(Bullet.gameObject);
        bullet.SetActive(true);
        bullet.transform.position = pattern5_5.transform.position;
        bullet.transform.rotation = pattern5_5.transform.rotation;
        float bulletSpeed = 300f;
        Vector3 dir = PlayerPos - pattern5_5.transform.position;
        while (Time.time - startTime < 2)
        {
            if (Time.time - startTime < 1.5f)
                Destroy(target_5);

            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;

            yield return null;
        }
        Destroy(pattern5_5);
        Destroy(bullet);
        StopCoroutine(Scp1_5_5());
    }
    #endregion





    // Update is called once per frame
    void Update()
    {
        PlayerPos = Player.transform.position;
         if(PlayerController.atkState) // 공격상태이면
        {
            // 체력 감소하는로직
        }
    }
}
