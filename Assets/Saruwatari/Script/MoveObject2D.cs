using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject2D : MonoBehaviour
{
    Rigidbody2D _rb;

    LineRenderer _currentLine;
    [SerializeField, Range(1, 100), Header("速さ")]
    private float Speed;
    [SerializeField, Header("ゲームオーバー")] string _name;
    [SerializeField, Header("ゲームオーバー")] string _name2;
    [SerializeField, Header("クリア")] string _name3;

    public bool _gameover;
    public bool _clear;

    private bool _onLine;

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
        if (_onLine == false)
        {
            _rb.velocity = _rb.transform.right * Speed;
            Vector2 newGravity = new Vector2(0, -9.81f);
            _rb.AddForce(newGravity);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out LineRenderer lr))
        {
            _onLine = true;

            Vector3 hitPos = collision.contacts[0].point;

            Vector3 diffGravity = hitPos - this.transform.position;

            Vector3 forceDir = diffGravity.normalized * 3f;

            _rb.velocity = _rb.transform.right * Speed;

        }


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _onLine = false;
    }

    //修正：佐藤
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.name == _name || collision.gameObject.name == "")
    //    {
    //        _gameover = true;
    //    }
    //    else if (collision.gameObject.name == "")
    //    {
    //        _clear = true;
    //    }
    //}
}
