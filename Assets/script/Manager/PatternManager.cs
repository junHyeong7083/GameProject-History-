using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    private static PatternManager instance; // 다른 곳에서 즉시 사용 불가능한 instance

    [SerializeField]
    private GameObject[] patternArray; // 패턴 배열, Inspecter에서 패턴 프리팹을 받아오는 역할

    Dictionary<string, GameObject> patternDic = new Dictionary<string, GameObject>(); // 패턴 딕셔너리, 패턴 이름을 통해 패턴을 불러오게 하는 역할

    public static PatternManager Instance // 다른 곳에서 사용 가능하여 instance를 반환
    {
        get
        {
            // 오류 방지
            if (instance == null)
            {
                instance = FindObjectOfType<PatternManager>();
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
     //   DontDestroyOnLoad(this.gameObject);

        // 패턴 배열에 있는 패턴들을 패턴 딕셔너리에 삽입
        foreach (GameObject pattern in patternArray)
        {
            patternDic.Add(pattern.name, pattern);
        }
    }

    public GameObject StartPattern(string name)
    {
        // 오류 방지
        if (patternDic.ContainsKey(name) == false)
        {
            Debug.Log(name + " is not Contained atternDic");
            return null;
        }

        // 패턴 생성
         return Instantiate(patternDic[name]);
    }
}
