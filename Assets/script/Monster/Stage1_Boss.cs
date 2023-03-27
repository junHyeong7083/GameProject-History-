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
    public GameObject pattern2;
    // ----------------- Pattern3 -----------------
    public GameObject pattern3;
    GameObject pattern3_1;
    GameObject pattern3_2;
    GameObject pattern3_3;
    // ----------------- bool -----------------
    bool isOverlab = false;
    void Start()
    {
        // ���� ���� ������ 0, 2
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerController = Player.GetComponent<PlayerController>();

    }
    void OverlabMixPattern()
    {
        // Rand�Ἥ ������������ ���� ����
    }


    public void Scp1_2() // �����Լ�
    {
        OverlabMixPattern();
        isOverlab = true;

       pattern2.transform.position = new Vector3(-10f, 20f, 0);
        pattern2.transform.rotation = Quaternion.Euler(0, 0, 140f);
        StartCoroutine(Scp1_2_1());
    }
    #region Scp1_2 ���Ϸ���
    IEnumerator Scp1_2_1()
    {
        pattern2.SetActive(true);
        float startTime = Time.time; // ���� �ð� ����
        while (Time.time - startTime < 1) // 1�ʰ� rotation.z �� ����
        {
            float backX = 2.5f;
            float upY = 2f;
            float RotateZ = 4.5f;
            pattern2.transform.position += new Vector3(-backX * Time.deltaTime, upY * Time.deltaTime, 0);
            pattern2.transform.Rotate(0, 0, RotateZ * Time.deltaTime);
            yield return null;
        }

        startTime = Time.time; // ���� �ð� �缳��
        while (Time.time - startTime < 2.0f) // 2.5�ʰ� position.y �� ���� �� rotation.z �� ����
        {
            if(pattern2.transform.position.y  > -12)
            {
                float frontX = 30f;
                float downY = 130f;
                float RotateZ = 90f;
                pattern2.transform.position += new Vector3(frontX * Time.deltaTime, -downY * Time.deltaTime, 0);
                pattern2.transform.Rotate(0, 0, -RotateZ *  4 * Time.deltaTime);
            }
  

            yield return null;
        }
        pattern2.SetActive(false);
        nextPtn1State = true;
        if(nextPtn1State)
        {
            pattern2.transform.position = new Vector3(4, -25f, 0);
            pattern2.transform.rotation = Quaternion.Euler(0, 0, 320f);
            StartCoroutine(Scp1_2_2());
        }
    }
    IEnumerator Scp1_2_2()
    {
        pattern2.SetActive(true);
        float startTime = Time.time; // ���� �ð� ����
        while (Time.time - startTime < 1) // 1�ʰ� rotation.z �� ����
        {
            float backX = 2.5f;
            float upY = 2f;
            float RotateZ = 4.5f;
            pattern2.transform.position += new Vector3(+backX * Time.deltaTime, -upY * Time.deltaTime, 0);
            pattern2.transform.Rotate(0, 0, RotateZ * Time.deltaTime);
            yield return null;
        }

        startTime = Time.time; // ���� �ð� �缳��
        while (Time.time - startTime < 2.0f) // 2.5�ʰ� position.y �� ���� �� rotation.z �� ����
        {
            if (pattern2.transform.position.y < 25f)
            {
                float frontX = 30f;
                float upY = 150f;
                float RotateZ = 80;
                pattern2.transform.position += new Vector3(-frontX * Time.deltaTime, upY * Time.deltaTime, 0);
                pattern2.transform.Rotate(0, 0, -RotateZ * 4 * Time.deltaTime);
            }


            yield return null;
        }
        pattern2.SetActive(false);
        nextPtn1State = false;
    }
    #endregion

    public void Scp1_3()
    {
        #region ����
        pattern3_1 = Instantiate(pattern3.gameObject);
        pattern3_2 = Instantiate(pattern3.gameObject);
        pattern3_3 = Instantiate(pattern3.gameObject);
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
    IEnumerator Scp1_3_1()
    {
        pattern3_1.SetActive(true);
        pattern3_2.SetActive(true);
        pattern3_3.SetActive(true);

        Vector3 dir1 = (PlayerPos - pattern3_1.transform.position).normalized;
        Vector3 dir2 = (PlayerPos - pattern3_2.transform.position).normalized;
        Vector3 dir3 = (PlayerPos - pattern3_3.transform.position).normalized;

        float startTime = Time.time; // ���� �ð� ����
        while (Time.time - startTime < 2) // 1�ʰ� rotation.z �� ����
        {
            float backPos = 1f;
            pattern3_1.transform.position += new Vector3(-backPos * Time.deltaTime,-backPos * Time.deltaTime, 0);
            pattern3_2.transform.position += new Vector3(0,-backPos * Time.deltaTime, 0);
            pattern3_3.transform.position += new Vector3( backPos * Time.deltaTime,-backPos * Time.deltaTime, 0);


            yield return null;          
        }
        startTime = Time.time;
        while (Time.time - startTime < 2) // 1�ʰ� rotation.z �� ����
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


    // Update is called once per frame
    void Update()
    {
        PlayerPos = Player.transform.position;
         if(PlayerController.atkState) // ���ݻ����̸�
        {
            // ü�� �����ϴ·���
        }
    }
}
