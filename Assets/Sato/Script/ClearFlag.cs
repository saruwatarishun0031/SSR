using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearFlag : MonoBehaviour
{
    [SerializeField] GameObject _playerObj;
    // Start is called before the first frame update
    void Start()
    {
        _playerObj = GameObject.Find("Player(Clone)");
    }

    IEnumerator ClearProg()
    {
        Debug.Log("clear!");

        yield return new WaitForSeconds(5.0f);

        GameManager.Instance.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == _playerObj)
        {
            StartCoroutine("ClearProg");
        }
    }
}
