using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDamageable : MonoBehaviour
{
    public static bool childChecker;
    private void Start()
    {
        childChecker = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("childCheckTrue");
            childChecker = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("childCheckFalse");
            childChecker = false;
        }
    }
}
