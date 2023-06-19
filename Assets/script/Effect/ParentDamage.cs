using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentDamage : MonoBehaviour
{
    public static bool parentChecker;
    private void Start()
    {
        parentChecker = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("parentCheckTrue");
            parentChecker = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("parentCheckFalse");
            parentChecker = false;
        }
    }
}
