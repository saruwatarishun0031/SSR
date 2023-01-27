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

    //ボタン押したとき用のメソッド
    public void OnClickButton(AudioClip ac)
    {
        _as.PlayOneShot(ac);
    }
}
