using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image DeathUI;
    public Text deathScore;
    public Text maxScore;
    public int sceneCheck;
    public static bool isStop = false;
    private void Start()
    {
        SoundManager.Instance.LoadVolume();
        SoundManager.Instance.SetBGMSound(1, SoundManager.Instance.bgmVolume);
        SoundManager.Instance.PlaySound();
        DeathUI.gameObject.SetActive(false);

    }

    public void OnStopBtn() // 일시정지
    {
        SoundManager.Instance.PauseSound();
        Time.timeScale = 0f;
        PlayerController.Hp = 2000;
    }
    public void OutStopBtn() // 계속하기
    {
        SoundManager.Instance.PlaySound();
        Time.timeScale = 1f;
    }
    public void ReStartGame() // 게임 다시시작
    {
        if(sceneCheck == 1)
        {
            SceneManager.LoadScene(1);
        }
        if (sceneCheck == 2)
        {
            SceneManager.LoadScene(3);
        }
        if (sceneCheck == 3)
        {
            SceneManager.LoadScene(4);
        }
        else if(sceneCheck == 4)
            SceneManager.LoadScene(2);
    }

    public void GoTitleMenu()
    {
        SceneManager.LoadScene("TitleScene");
        Time.timeScale = 1f;
    }


    private void Update()
    {
        if (PlayerController.isDie && sceneCheck == 1 )
        {
            SoundManager.Instance.PauseSound();

            deathScore.text = Stage1_Boss.currentHp.ToString();
            DeathUI.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        if (PlayerController.isDie && sceneCheck == 2)
        {
            SoundManager.Instance.PauseSound();

            deathScore.text = Stage2_Boss.currentHp.ToString();
            DeathUI.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        if (PlayerController.isDie && sceneCheck == 3)
        {
            SoundManager.Instance.PauseSound();

            deathScore.text = Stage3_Boss.currentHp.ToString();
            DeathUI.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        if (PlayerController.isDie && sceneCheck == 4)
        {
            SoundManager.Instance.PauseSound();

            DeathUI.gameObject.SetActive(true);
            deathScore.text = Stage_infinity.currentTime.ToString();
            maxScore.text = Stage_infinity.maxTime.ToString();
            Time.timeScale = 0f;
        }
    }
}
