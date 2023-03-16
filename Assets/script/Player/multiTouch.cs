using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiTouch : MonoBehaviour
{
    Vector2 touchPos;
    Vector2 targetPos;
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void PlayerMove()
    {
        if(Input.touchCount > 0)
        {
            touchPos = Input.GetTouch(0).position;
            targetPos = Camera.main.ScreenToWorldPoint(touchPos);
        }
    }
}
