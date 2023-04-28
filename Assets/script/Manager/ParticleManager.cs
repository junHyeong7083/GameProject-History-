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

            return instance; // ���� ������ ���������� ��ȯ
        }
    }
    private void Awake()
    {
        // ���� ����
        if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        // ��ƼŬ �ý��� �迭�� �ִ� ��ƼŬ �ý��۵��� ��ųʸ��� ����
        foreach (ParticleSystem particle in particleArray)
        {
            particleDic.Add(particle.name, particle);
        }
    }
    public ParticleSystem StartParticle(string name)
    {
        // ���� ����
        if (particleDic.ContainsKey(name) == false)
        {
            Debug.Log(name + " is not Contained atternDic");
            return null;
        }

        // ���� ����
        return Instantiate(particleDic[name]);
    }
}
