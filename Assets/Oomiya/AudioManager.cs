using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _as;
    void Start()
    {
        
    }

    //�{�^���������Ƃ��p�̃��\�b�h
    public void OnClickButton(AudioClip ac)
    {
        _as.PlayOneShot(ac);
    }
}
