using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSystem : MonoBehaviour
{
    Rigidbody2D _rb;

    [SerializeField, Header("�v���C���[���")] GameObject _PlayerObj;
    [SerializeField] float _moveSpeed = 1.0f;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _PlayerObj = GameObject.Find("Player(Clone)");
    }
    /// <summary>
    /// ��Ɍ����Ďˏo����AParent�ɓn��
    /// </summary>
    public void UpPopOut()
    {
        _rb.AddForce(Vector2.up * _moveSpeed, ForceMode2D.Impulse);
    }
    /// <summary>
    /// ���Ɍ����Ďˏo����AParent�ɓn��
    /// </summary>
    public void DownPopOut()
    {
        _rb.AddForce(Vector2.down * _moveSpeed, ForceMode2D.Impulse);
    }
    /// <summary>
    /// �v���C���[�Ɍ����Ďˏo����AParent�ɓn��
    /// </summary>
    public void PlayerPopOut()
    {
        var PPos = _PlayerObj.transform.position;
        Vector2 aimPos = PPos - this.transform.position;
        _rb.AddForce(aimPos.normalized * _moveSpeed, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _PlayerObj)
        {
            Destroy(_PlayerObj);
            GameManager.Instance.GameOver();
        }
        if (collision.gameObject)
        {
            Destroy(this.gameObject);
        }
        if (collision.TryGetComponent(out LineRenderer lr))
        {
            Destroy(this.gameObject);
        }
        
    }

    void OnBecameInvisible()
    {
        Debug.Log("������");
        Destroy(this.gameObject);
    }
}
