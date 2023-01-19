using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSystem : MonoBehaviour
{
    Rigidbody2D _rb;

    [SerializeField] float _moveSpeed = 1.0f;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _rb.AddForce(Vector2.up * _moveSpeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Debug.Log("è¡Ç¶ÇΩ");
        Destroy(this.gameObject);
    }
}
