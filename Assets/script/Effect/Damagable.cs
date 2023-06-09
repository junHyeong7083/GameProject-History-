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
    //          Debug.Log("파티클 충돌1");
    //      }
    //  }
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) // 원하는 레이어를 체크
        {
            Debug.Log("파티클 충돌");
            PlayerController player = GetComponent<PlayerController>();
            if (player != null)
            {
                player.DecreaseHp();
                Debug.Log("플레이어 체력 감소");
            }
        }
    }
}
