using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject2D : MonoBehaviour
{
    Rigidbody2D _rb;

    [SerializeField, Range(1, 100), Header("速さ")]
    private float Speed;
    [SerializeField, Header("ゲームオーバー")] string _name;
    [SerializeField, Header("ゲームオーバー")] string _name2;
    [SerializeField,Header("クリア")] string _name3;

    public bool _gameover;
    public bool _clear;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        _rb.velocity = _rb.transform.right * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == _name || collision.gameObject.name == "")
        {
            _gameover = true;
        }
        else if (collision.gameObject.name == "")
        {
            _clear = true;
        }
    }
}
