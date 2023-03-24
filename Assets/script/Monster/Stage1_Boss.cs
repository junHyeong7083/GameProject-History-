using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stage1_Boss : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    private PlayerController playerController;
    public GameObject Player;
    // ----------------- Pattern2 -----------------
    bool nextPtn1State = false;
    public GameObject pattern2;
    // ----------------- Pattern3 -----------------
    public GameObject pattern3_1;
    GameObject pattern3_2;
    GameObject pattern3_3;
    float pattern3speed = 3f;
    // ----------------- bool -----------------
    bool isOverlab = false;
    void Start()
    {
        // 보스 현재 포지션 0, 2
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerController = Player.GetComponent<PlayerController>();

        #region 오브젝트 복제
        pattern3_2 = Instantiate(pattern3_1);
        pattern3_3 = Instantiate(pattern3_1);
        #endregion
    }
    void OverlabMixPattern()
    {
        // Rand써서 오버랩가능한 패턴 섞기
    }


    public void Scp1_2() // 실행함수
    {
        OverlabMixPattern();
        isOverlab = true;

       pattern2.transform.position = new Vector3(-0.3f, 2f, 0);
        pattern2.transform.rotation = Quaternion.Euler(0, 0, 140f);
        StartCoroutine(Scp1_2_1());
    }
    #region Scp1_2 패턴로직
    IEnumerator Scp1_2_1()
    {
        pattern2.SetActive(true);
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 1) // 1초간 rotation.z 값 변경
        {
            pattern2.transform.position += new Vector3(-0.05f * Time.deltaTime, 0, 0);
            pattern2.transform.Rotate(0, 0, 4.5f * Time.deltaTime);
            yield return null;
        }

        startTime = Time.time; // 시작 시간 재설정
        while (Time.time - startTime < 2.5f) // 2.5초간 position.y 값 변경 및 rotation.z 값 변경
        {
            if(pattern2.transform.position.y  > -2)
            {
                pattern2.transform.position += new Vector3(1.0f * Time.deltaTime, -4 * 3 * Time.deltaTime, 0);
                pattern2.transform.Rotate(0, 0, -70 *  4 * Time.deltaTime);
            }
  

            yield return null;
        }
        pattern2.SetActive(false);
        nextPtn1State = true;
        if(nextPtn1State)
        {
            pattern2.transform.position = new Vector3(0.3f, -2.5f, 0);
            pattern2.transform.rotation = Quaternion.Euler(0, 0, 320f);
            StartCoroutine(Scp1_2_2());
        }
    }
    IEnumerator Scp1_2_2()
    {
        pattern2.SetActive(true);
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 1) // 1초간 rotation.z 값 변경
        {
            pattern2.transform.position += new Vector3(+0.05f * Time.deltaTime, 0, 0);
            pattern2.transform.Rotate(0, 0, 4.5f * Time.deltaTime);
            yield return null;
        }

        startTime = Time.time; // 시작 시간 재설정
        while (Time.time - startTime < 2.5f) // 2.5초간 position.y 값 변경 및 rotation.z 값 변경
        {
            if (pattern2.transform.position.y < 2)
            {
                pattern2.transform.position += new Vector3(-1.0f * Time.deltaTime, 4 * 3 * Time.deltaTime, 0);
                pattern2.transform.Rotate(0, 0, -70 * 4 * Time.deltaTime);
            }


            yield return null;
        }
        pattern2.SetActive(false);
        nextPtn1State = false;
    }
    #endregion

    public void Scp1_3()
    {
        isOverlab = true;
        #region Pattern3 Setting Pos
        pattern3_1.transform.position =  new Vector3(Player.transform.position.x - 0.7f , Player.transform.position.y - 1f, 0);
        pattern3_1.transform.Rotate(0, 0, 220);
        pattern3_2.transform.position = new Vector3(0, Player.transform.position.y- 1.3f, 0);
        pattern3_2.transform.Rotate(0, 0, 270);
        pattern3_3.transform.position =new Vector3(Player.transform.position.x + 0.7f, Player.transform.position.y - 1f, 0);
        pattern3_3.transform.Rotate(0, 0, 320);
        #endregion
        StartCoroutine(Scp1_3_1());
    }
    IEnumerator Scp1_3_1()
    {
        pattern3_1.SetActive(true);
        pattern3_2.SetActive(true);
        pattern3_3.SetActive(true);
        float startTime = Time.time; // 시작 시간 저장
        while (Time.time - startTime < 2) // 1초간 rotation.z 값 변경
        {
            float backPos = 0.1f;
          pattern3_1.transform.position += new Vector3(-backPos * Time.deltaTime, -backPos * Time.deltaTime, 0);
          pattern3_2.transform.position += new Vector3(0, -backPos * Time.deltaTime, 0);
          pattern3_3.transform.position += new Vector3(backPos * Time.deltaTime, -backPos * Time.deltaTime, 0);
                yield return null;
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (PlayerController.atkState) // 공격상태이면
        {
            // 체력 감소하는로직
        }
    }
}
