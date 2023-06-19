using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial_CutScene : MonoBehaviour
{
    Touch touch1;

    public CanvasGroup[] panels; // 1~8까지의 패널을 순서대로 배열에 저장
    [SerializeField]
    private int currentPanelIndex = 0; // 현재 활성화된 패널 인덱스

    public Image clearPanel; // 클리어 패널

    private bool canTransition = true; // 패널 전환 가능 여부를 나타내는 변수

    private void Start()
    {
        // 시작 시 0번째 패널을 활성화하고 페이드 인 시작
        panels[currentPanelIndex].gameObject.SetActive(true);
        StartCoroutine(FadeInPanel(panels[currentPanelIndex]));
    }

    bool check = false;

    private void Update()
    {
        if (Input.touchCount > 0) // 첫 입력
        {
            touch1 = FindTouchById(0);
            if (FindTouchById(0).phase == TouchPhase.Began)
            {
                check = true;
                Debug.Log("입력");
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
        } // 터치 순서따라 finger id값 저장

        if (currentPanelIndex == 9) //&& canTransition
        {
            // 현재 패널 페이드 아웃
            StartCoroutine(FadeOutPanel(panels[currentPanelIndex]));

            SceneManager.LoadScene("TitleScene");
            Time.timeScale = 1f;
        }
    }

    public void NextPanel()
    {
        int nextPanelIndex = currentPanelIndex + 1; // 다음 패널 인덱스 계산

        if (nextPanelIndex <= panels.Length)
        {
            // 현재 패널 페이드 아웃
            StartCoroutine(FadeOutPanel(panels[currentPanelIndex]));

            // 다음 패널 페이드 인
            StartCoroutine(FadeInPanel(panels[nextPanelIndex]));

            currentPanelIndex = nextPanelIndex; // 현재 패널 인덱스 갱신

            canTransition = false; // 패널 전환 중에는 다시 클릭되지 않도록 전환 가능 여부를 비활성화
        }
    }

    private System.Collections.IEnumerator FadeOutPanel(CanvasGroup panel)
    {
        while (panel.alpha > 0f)
        {
            panel.alpha -= Time.deltaTime; // 시간에 따라 투명도 감소
            yield return null;
        }

        panel.alpha = 0f; // 투명도를 0으로 설정
        panel.gameObject.SetActive(false); // 패널 비활성화

        canTransition = true; // 패널 전환이 완료되면 전환 가능 여부를 활성화
    }

    private System.Collections.IEnumerator FadeInPanel(CanvasGroup panel)
    {
        panel.gameObject.SetActive(true); // 패널 활성화

        while (panel.alpha < 1f)
        {
            panel.alpha += Time.deltaTime; // 시간에 따라 투명도 증가
            yield return null;
        }

        panel.alpha = 1f; // 투명도를 1로 설정
    }
}
