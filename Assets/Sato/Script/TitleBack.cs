using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBack : MonoBehaviour
{
    bool _isBackTitle = false;
    // Start is called before the first frame update
    void Start()
    {
        _isBackTitle = false;
    }

    public void PushBack()
    {
        if (_isBackTitle == false)
        {
            _isBackTitle = false;
            GameManager.Instance.BackTitle();
        }
        _isBackTitle = false;
    }
}
