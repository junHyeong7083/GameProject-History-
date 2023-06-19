using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial_CutScene : MonoBehaviour
{
    Touch touch1;

    public CanvasGroup[] panels; // 1~8������ �г��� ������� �迭�� ����
    [SerializeField]
    private int currentPanelIndex = 0; // ���� Ȱ��ȭ�� �г� �ε���

    public Image clearPanel; // Ŭ���� �г�

    private bool canTransition = true; // �г� ��ȯ ���� ���θ� ��Ÿ���� ����

    private void Start()
    {
        // ���� �� 0��° �г��� Ȱ��ȭ�ϰ� ���̵� �� ����
        panels[currentPanelIndex].gameObject.SetActive(true);
        StartCoroutine(FadeInPanel(panels[currentPanelIndex]));
    }

    bool check = false;

    private void Update()
    {
        if (Input.touchCount > 0) // ù �Է�
        {
            touch1 = FindTouchById(0);
            if (FindTouchById(0).phase == TouchPhase.Began)
            {
                check = true;
                Debug.Log("�Է�");
            }
            if (FindTouchById(0).phase == TouchPhase.Ended)
            {
                if (check)
                {
                    check = false;
                    NextPanel();
                }
            }
        }

        Touch FindTouchById(int id)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                Touch t = Input.GetTouch(i);
                if (t.fingerId == id) return t;
            }

            return default(Touch);
        } // ��ġ �������� finger id�� ����

        if (currentPanelIndex == 9) //&& canTransition
        {
            // ���� �г� ���̵� �ƿ�
            StartCoroutine(FadeOutPanel(panels[currentPanelIndex]));

            SceneManager.LoadScene("TitleScene");
            Time.timeScale = 1f;
        }
    }

    public void NextPanel()
    {
        int nextPanelIndex = currentPanelIndex + 1; // ���� �г� �ε��� ���

        if (nextPanelIndex <= panels.Length)
        {
            // ���� �г� ���̵� �ƿ�
            StartCoroutine(FadeOutPanel(panels[currentPanelIndex]));

            // ���� �г� ���̵� ��
            StartCoroutine(FadeInPanel(panels[nextPanelIndex]));

            currentPanelIndex = nextPanelIndex; // ���� �г� �ε��� ����

            canTransition = false; // �г� ��ȯ �߿��� �ٽ� Ŭ������ �ʵ��� ��ȯ ���� ���θ� ��Ȱ��ȭ
        }
    }

    private System.Collections.IEnumerator FadeOutPanel(CanvasGroup panel)
    {
        while (panel.alpha > 0f)
        {
            panel.alpha -= Time.deltaTime; // �ð��� ���� ���� ����
            yield return null;
        }

        panel.alpha = 0f; // ������ 0���� ����
        panel.gameObject.SetActive(false); // �г� ��Ȱ��ȭ

        canTransition = true; // �г� ��ȯ�� �Ϸ�Ǹ� ��ȯ ���� ���θ� Ȱ��ȭ
    }

    private System.Collections.IEnumerator FadeInPanel(CanvasGroup panel)
    {
        panel.gameObject.SetActive(true); // �г� Ȱ��ȭ

        while (panel.alpha < 1f)
        {
            panel.alpha += Time.deltaTime; // �ð��� ���� ���� ����
            yield return null;
        }

        panel.alpha = 1f; // ������ 1�� ����
    }
}
