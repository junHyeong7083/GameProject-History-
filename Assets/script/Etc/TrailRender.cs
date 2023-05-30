using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRender : MonoBehaviour
{
    public static bool showTrail = false;
    public TrailRenderer trailRenderer;
    public float trailWidthMultiplier = 2f; // 원하는 넓이 배수 값

    Gradient alphaGradient = new Gradient();
    GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
    GradientColorKey[] colorKeys = new GradientColorKey[2];
    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.widthMultiplier = trailWidthMultiplier;

        alphaKeys[0].alpha = 0.3f;
        alphaKeys[0].time = 0f;
        alphaKeys[1].alpha = 0.3f;
        alphaKeys[1].time = 0f;

        colorKeys[0].color= Color.grey;
        colorKeys[0].time = 0f;
        colorKeys[1].color = Color.grey;
        colorKeys[1].time = 1f;


        alphaGradient.SetKeys(colorKeys, alphaKeys);
        trailRenderer.colorGradient = alphaGradient;
    }

    private void Update()
    {
        if(!showTrail)
        {
            trailRenderer.Clear();
            trailRenderer.enabled = false;
        }

        if (showTrail)
            trailRenderer.enabled = true;
    }
}
