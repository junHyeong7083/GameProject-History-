using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkPoint : MonoBehaviour
{
    public GameObject Monster;
    public float rotateSpeed;
    public GameObject TestPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        if(Monster != null)
        {
            Vector2 direction = new Vector2(transform.position.x - Monster.transform.position.x, transform.position.y - Monster.transform.position.y);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion angleAxis = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, rotateSpeed * Time.deltaTime);
            transform.rotation = rotation;
        }

        print("PosX : " + TestPos.transform.position.x + "PosY : " + TestPos.transform.position.y);
       
    }
}
