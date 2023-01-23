using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    [SerializeField, Header("ƒvƒŒƒCƒ„[î•ñ")] GameObject _PlayerObj;

    void Start()
    {
        _PlayerObj = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _PlayerObj)
        {
            Destroy(_PlayerObj);
        }
    }
}
