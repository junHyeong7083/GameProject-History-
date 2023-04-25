using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    private static PatternManager instance; // �ٸ� ������ ��� ��� �Ұ����� instance

    [SerializeField]
    private GameObject[] patternArray; // ���� �迭, Inspecter���� ���� �������� �޾ƿ��� ����

    Dictionary<string, GameObject> patternDic = new Dictionary<string, GameObject>(); // ���� ��ųʸ�, ���� �̸��� ���� ������ �ҷ����� �ϴ� ����

    public static PatternManager Instance // �ٸ� ������ ��� �����Ͽ� instance�� ��ȯ
    {
        get
        {
            // ���� ����
            if (instance == null)
            {
                instance = FindObjectOfType<PatternManager>();
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

        // ���� �迭�� �ִ� ���ϵ��� ���� ��ųʸ��� ����
        foreach (GameObject pattern in patternArray)
        {
            patternDic.Add(pattern.name, pattern);
        }
    }

    public void StartPattern(string name)
    {
        // ���� ����
        if (patternDic.ContainsKey(name) == false)
        {
            Debug.Log(name + " is not Contained atternDic");
            return;
        }

        // ���� ����
         Instantiate(patternDic[name]);
    }
}
