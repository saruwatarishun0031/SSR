using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField, Range(1, 100), Header("‘¬‚³")]
    private float Speed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
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
}
