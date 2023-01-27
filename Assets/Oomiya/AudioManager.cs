using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _as;
    [SerializeField] AudioClip _clearSE;
 
    //�{�^���������Ƃ��p�̃��\�b�h
    public void OnClickButton(AudioClip ac)
    {
        _as.PlayOneShot(ac);
    }

    //�S�[���ɂ�����Ă�
    public void GameClear()
    {
        _as.PlayOneShot(_clearSE);
    }
}
