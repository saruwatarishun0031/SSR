using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField, Header("�v���C���[���")] GameObject _PlayerObj;
    void Start()
    {
        _PlayerObj = GameObject.Find("Player(Clone)");
    }

    void Update()
    {
        
    }
}
