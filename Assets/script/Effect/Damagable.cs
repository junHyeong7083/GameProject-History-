using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    //  private void OnParticleCollision(GameObject other)
    //  {
    //      PlayerController player = other.GetComponent<PlayerController>();
    //      if (player != null && player.gameObject.layer == 7)
    //      {
    //          player.DecreaseHp();
    //          Debug.Log("��ƼŬ �浹1");
    //      }
    //  }
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) // ���ϴ� ���̾ üũ
        {
            Debug.Log("��ƼŬ �浹");
            PlayerController player = GetComponent<PlayerController>();
            if (player != null)
            {
                player.DecreaseHp();
                Debug.Log("�÷��̾� ü�� ����");
            }
        }
    }
}
