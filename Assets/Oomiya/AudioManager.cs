using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _as;
    [SerializeField] AudioClip _clearSE;
 
    //ボタン押したとき用のメソッド
    public void OnClickButton(AudioClip ac)
    {
        _as.PlayOneShot(ac);
    }

    //ゴールについたら呼ぶ
    public void GameClear()
    {
        _as.PlayOneShot(_clearSE);
    }
}
