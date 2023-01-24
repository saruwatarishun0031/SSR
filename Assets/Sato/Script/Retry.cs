using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retry : MonoBehaviour
{
    bool _isRetry = false;

    // Start is called before the first frame update
    void Start()
    {
        _isRetry = false;
    }

    public void PushRetry()
    {
        if (_isRetry == true) return;
        else if (_isRetry == false)
        {
            _isRetry = true;
            GameManager.Instance.PlayerSpawn();
        }
    }
}
