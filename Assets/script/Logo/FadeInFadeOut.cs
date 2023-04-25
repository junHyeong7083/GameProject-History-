using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum FadeState {  FadeIn = 0, FadeOut , FadeInOut, FadeLoop };

public class FadeInFadeOut : MonoBehaviour
{
    [Header("설정한 값이 원하는 시간의 절반")]
    [SerializeField]
    private float fadeTime;
    [SerializeField]
    private Image image;
    private FadeState fadeState;
    public Image Logo;
    bool isLogo = false;
    public Image Title;
    bool isTitle = false;   

    private void Awake()
    {
        image = GetComponent<Image>();

        OnFade(FadeState.FadeInOut);
    }

    public void OnFade(FadeState state)
    {
        fadeState = state;
        switch(fadeState)
        {
            case FadeState.FadeIn:
                StartCoroutine(Fade(1, 0)); // FadeIn ,배경의 알파값이 1에서 0
                break;
            case FadeState.FadeOut:
                StartCoroutine(Fade(0, 1)); // FadeOut 배경의 알파값이 0 에서 1
                break;
            case FadeState.FadeInOut: // 1회 반복
            case FadeState.FadeLoop:
                StartCoroutine(FadeInOut());
                break;
        }
    }
    int cnt = 1; // cnt = 1 logo , cnt =2 Title
    bool NextScene = false;
    public IEnumerator FadeInOut()
    {
        while(true)
        {
            if(cnt <= 2)
            {
                yield return StartCoroutine(Fade(0, 1)); // fade out
                yield return StartCoroutine(Fade(1, 0)); // fade in
            }
            if(cnt == 3)
                yield return StartCoroutine(Fade(0, 1));

            if (fadeState == FadeState.FadeInOut && cnt == 4)
            {
                NextScene = true;
                break;
            }
            cnt++;
        }
    }

    private IEnumerator Fade(float start, float end)
    {
        float currentTime = 0f;
        float percent = 0f;

        while(percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = image.color;
            color.a = Mathf.Lerp(start,end, percent);
            image.color = color;

            if(cnt == 1)
            { 
                Color color1 = Logo.color;
                color1.a = Mathf.Lerp(start, end, percent);
                Logo.color = color1;
            }
            if(cnt == 2)
            {
                Color color2 = Title.color;
                color2.a = Mathf.Lerp(start, end, percent);
                Title.color = color2;
            }



            yield return null;
        }
    }

    private void Update()
    {
        if(NextScene)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
