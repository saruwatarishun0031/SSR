using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadParent : MonoBehaviour
{
    [SerializeField, Header("�q�I�u�W�F�N�g")] GameObject _deadObj = default;
    [SerializeField, Header("�e�I�u�W�F�N�g")] GameObject _parentObj = default;

    [SerializeField, Range(0f, 10f)] float _popSpan = 1.0f;
    float popCount = 0.0f;
    GameObject Obj;
    [SerializeField] Pop pop = Pop.UP;
    public enum Pop
    {
        UP,
        DOWN,
        PLAYER
    }
    void Update()
    {
        popCount += Time.deltaTime;
        if (popCount >= _popSpan)
        {
            popCount = 0.0f;
            Obj = (GameObject)Instantiate(_deadObj, this.transform.position, transform.rotation);
            Obj.transform.parent = _parentObj.transform;
            DeadSystem _deadSystem = Obj.GetComponent<DeadSystem>();
            switch (this.pop)
            {
                case Pop.UP:
                    _deadSystem.UpPopOut();
                    break;
                case Pop.DOWN:
                    _deadSystem.DownPopOut();
                    break;
                case Pop.PLAYER:
                    _deadSystem.PlayerPopOut();
                    break;
                default:
                    Debug.Log("�ݒ薢�����Ȃ̂Œe���o�܂���");
                    break;
            }
        }
    }
}
