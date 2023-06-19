using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public GameObject ParentObj;
    public GameObject ChildObj;
    GameObject player;

    PlayerController playerController;


    CircleCollider2D parentCollider;
    CircleCollider2D childCollider;


    float delayTime;
    private void Start()
    {
        player =  GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        parentCollider = ParentObj.GetComponent<CircleCollider2D>();
        childCollider = ChildObj.GetComponent<CircleCollider2D>();

        parentCollider.radius = 12f;
        childCollider.radius = 7f;

        delayTime = 0f;
    }

 




    private void Update()
    {
        delayTime += Time.deltaTime;
        if(delayTime > 2.5f)
        {
            delayTime = 4f;
            parentCollider.radius += Time.deltaTime*80;
            childCollider.radius += Time.deltaTime * 80;
        }


        if(ParentDamage.parentChecker && ! ChildDamageable.childChecker)
        {
            playerController.DecreaseHp();
        }
    }


}
