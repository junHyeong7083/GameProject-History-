using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRender : MonoBehaviour
{
    public static bool showTrail = false;
    public TrailRenderer trailRenderer;
    public float trailWidthMultiplier = 2f; // ���ϴ� ���� ��� ��

    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.widthMultiplier = trailWidthMultiplier;
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
