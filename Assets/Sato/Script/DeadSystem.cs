using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSystem : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    void Update()
    {
        transform.Translate(transform.localScale * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
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
