using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private static ParticleManager instance;
    [SerializeField]
    private ParticleSystem[] particleArray;

    Dictionary<string, ParticleSystem> particleDic = new Dictionary<string, ParticleSystem>();

    public static ParticleManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ParticleManager>();
            }

            return instance; // 오류 없으면 정상적으로 반환
        }
    }
    private void Awake()
    {
        // 오류 방지
        if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        // 파티클 시스템 배열에 있는 파티클 시스템들을 딕셔너리에 삽입
        foreach (ParticleSystem particle in particleArray)
        {
            particleDic.Add(particle.name, particle);
        }
    }
    public ParticleSystem StartParticle(string name)
    {
        // 오류 방지
        if (particleDic.ContainsKey(name) == false)
        {
            Debug.Log(name + " is not Contained atternDic");
            return null;
        }

        // 패턴 생성
        return Instantiate(particleDic[name]);
    }
}
