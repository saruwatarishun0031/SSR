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
    [SerializeField] ChinemaForrow _cinemaForrow;
    private bool _isGameOver;


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

        Instantiate(_plyaer, _respawn.transform.position, _respawn.transform.rotation);
        _isGameOver = false;
    }
    //シングルトン（ここまで）
    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
        //object2D = GetComponent<MoveObject2D>();
    }

    public void GameOver()
    {
        if (_isGameOver == false)
        {
            _isGameOver = true;
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Clear()
    {
        SceneManager.LoadScene("Result");
    }

    public void PlayerSpawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //_isGameOver = false;
        //_result.gameObject.SetActive(false);
        
        //_cinemaForrow.ReBoot();
    }

    public void BackTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
