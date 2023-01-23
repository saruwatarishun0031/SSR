using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    MoveObject2D object2D;

    [SerializeField] Canvas _result;
    [SerializeField] GameObject _respawn;
    [SerializeField] GameObject _plyaer;

    //シングルトンパターン（簡易型、呼び出される）
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        PlayerSpawn();
    }
    //シングルトン（ここまで）
    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
        object2D = GetComponent<MoveObject2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        Clear();
    }

    void GameOver()
    {
       if (object2D._gameover == true)
       {
            _result.gameObject.SetActive(true);
       }
    }

    void Clear()
    {
        if (object2D._clear == true)
        {
            SceneManager.LoadScene("Result");
        }
    }

    void PlayerSpawn()
    {
        Instantiate(_plyaer, _respawn.transform.position, _respawn.transform.rotation);
    }
}
