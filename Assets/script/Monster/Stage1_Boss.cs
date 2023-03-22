using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stage1_Boss : MonoBehaviour
{
    Rigidbody2D rigidbody2D;


    // ----------------- bool -----------------
    bool isOverRab = false;
    void Start()
    {
        // 보스 현재 포지션 0, 2
        rigidbody2D = GetComponent<Rigidbody2D>();
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
