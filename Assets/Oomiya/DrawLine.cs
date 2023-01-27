using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// �h���b�O�Ő���`���R���|�[�l���g
/// </summary>
public class DrawLine : MonoBehaviour
{
    //���݂̃��C��
    LineRenderer _correntline;
    //���̍ގ�
    [SerializeField] Material lineMaterial;
    //���̐F
    [SerializeField] Color lineColor;
    //���̑���
    [Range(0.1f, 0.5f)]
    [SerializeField] float lineWidth;
    /// <summary>����`�����ɁA�e�_���ǂꂭ�炢������</summary>
    [SerializeField] float _distanceBetweenPoints = 0.1f;
    /// <summary>����`���Ă���Ԃ� true �ɂȂ�</summary>
    bool _isDrawing = false;

    //�ǉ��@LineRdenerer�^�̃��X�g�錾
    [SerializeField] List<LineRenderer> _lineRenderers;

    List<Vector2> _linePoints = new List<Vector2>();

    private void Start()
    {
        //�ǉ��@List�̏�����
        _lineRenderers = new List<LineRenderer>();
    }
    void Update()
    {
        // �{�^����������������
        if (Input.GetMouseButtonDown(0))
        {
            AddLineObject();
            _isDrawing = true;
        }
        // �{�^���𗣂�����
        else if (Input.GetMouseButtonUp(0))
        {
            _isDrawing = false;
        }

        if (_isDrawing)
        {
            Draw();
        }
    }

    void AddLineObject()
    {
        //��̃Q�[���I�u�W�F�N�g�쐬
        GameObject lineObj = new GameObject();
        //�I�u�W�F�N�g�̖��O��bridge�ɕύX
        lineObj.name = "bridge";
        //lineObj��LineRenderer�R���|�[�l���g�ǉ�
       var lr =  lineObj.AddComponent<LineRenderer>();
        //lr.useWorldSpace = false;
        lineObj.AddComponent<EdgeCollider2D>();
        //lineRenderer���X�g��lineObj��ǉ�
        _lineRenderers.Add(lr);
        //lineObj�����g�̎q�v�f�ɐݒ�
        lineObj.transform.SetParent(transform);

        //�������Ă��郉�C����ϐ��Ɋi�[
        _correntline = _lineRenderers.Last();
        //������
        InitRenderers();
    }

    //lineObj����������
    void InitRenderers()
    {
        //�����Ȃ��_��0�ɏ�����
        _correntline.positionCount = 0;
        //�}�e���A����������
        _correntline.material = lineMaterial;
        //�F�̏�����
        _correntline.material.color = lineColor;
        //�����̏�����
        _correntline.startWidth = lineWidth;
        _correntline.endWidth = lineWidth;
    }

    /// <summary>
    /// �}�E�X�̍��W�ɐ���`��
    /// </summary>
    void Draw()
    {
        //�}�E�X�|�C���^������X�N���[�����W���擾
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f);

        //�X�N���[�����W�����[���h���W�ɕϊ�
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePosition);

        //���[���h���W�����[�J�����W�ɕϊ�
        Vector3 localPosition = transform.InverseTransformPoint(worldPos.x, worldPos.y, -1.0f);

        //lineObj�̐��Ɛ����Ȃ��_�̐����X�V
        _correntline.positionCount += 1;

        //LineRenderer�R���|�[�l���g���X�g���X�V
        _correntline.SetPosition(_correntline.positionCount - 1, worldPos);

        //linePoints�ɐ��̍��W��ǉ�
        _linePoints.Add(localPosition);

        //LineRenderer��EdgeCollider2D��\��t��
        _correntline.GetComponent<EdgeCollider2D>().SetPoints(_linePoints);
    }
}
