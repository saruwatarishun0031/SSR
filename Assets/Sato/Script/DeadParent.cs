using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadParent : MonoBehaviour
{
    [SerializeField] GameObject _deadObj = default;
    [SerializeField, Header("親オブジェクト")] GameObject _parentObj = default;

    [SerializeField,Range(0f, 10f)] float _popSpan = 1.0f;
    float popCount = 0.0f;

    void Update()
    {
        popCount += Time.deltaTime;
        if (popCount >= _popSpan)
        {
            popCount = 0.0f;
            Instantiate(_deadObj, this.transform.position, Quaternion.identity);
            _deadObj.transform.parent = _parentObj.transform;
        }
    }
}
