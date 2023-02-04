using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class ChinemaForrow : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _forrow;
    [SerializeField] private Vector3 _offset;
    private CinemachineVirtualCamera _virtualCamera;

    private Vector3 _cameraPos;
    private Vector3 _cameraVerocity;

    private Vector3 _minusPos = new Vector3(-15.0f,2.0f, 10.0f);

    private Vector3 TargetPosition => _forrow.position + _offset;
    // Start is called before the first frame update
    void Start()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();

        ReBoot();
    }

    public void ReBoot()
    {
        _player = GameObject.Find("Player(Clone)");
        _forrow = _player.transform;
        _offset = _player.transform.position;
        _cameraPos = TargetPosition;
    }
    private void FixedUpdate()
    {
        
        var targetPos = TargetPosition - _minusPos;

        _cameraPos = Vector3.SmoothDamp(_cameraPos, targetPos, ref _cameraVerocity, 0.5f);

        transform.position = _cameraPos;
    }
}
