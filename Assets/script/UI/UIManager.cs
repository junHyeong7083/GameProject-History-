using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void OnStopBtn()
    {
        Time.timeScale = 0f;
    }
    public void OutStopBtn()
    {
        Time.timeScale = 1f;
    }
    public void ReStartGame()
    {
        GameObject[] gameObjects = FindObjectsOfType<GameObject>();

        // �˻��� ��� ���� ������Ʈ�� �����մϴ�.
        foreach (GameObject gameObject in gameObjects)
        {
            Destroy(gameObject);
        }
        SceneManager.LoadScene(1);

    }
    public void GoTitleMenu()
    {
        SceneManager.LoadScene("TitleScene");
        Time.timeScale = 1f;
    }
}
