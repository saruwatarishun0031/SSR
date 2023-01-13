using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadParent : MonoBehaviour
{
    [SerializeField] GameObject _deadObj = default;

    [SerializeField] float _popSpan = 1.0f;
    float popCount = 0.0f;
    void Start()
    {
        
    }

    void Update()
    {
        popCount += Time.deltaTime;
        Debug.Log(popCount);
        if (popCount >= _popSpan)
        {
            popCount = 0.0f;
            Instantiate(_deadObj, new Vector3(0.0f, 0.0f, 10.0f), Quaternion.identity);
        }
    }
}
