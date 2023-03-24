using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> patternPool;

    [Range(1,10)]
    public int poolSize;

    public int poolCursor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
