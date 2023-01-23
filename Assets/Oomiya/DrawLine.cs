using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// �h���b�O�Ő���`���R���|�[�l���g
/// </summary>
public class DrawLine : MonoBehaviour
{
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
        lineObj.AddComponent<LineRenderer>();
        lineObj.AddComponent<Collider2D>();
        //lineRenderer���X�g��lineObj��ǉ�
        _lineRenderers.Add(lineObj.GetComponent<LineRenderer>());
        //lineObj�����g�̎q�v�f�ɐݒ�
        lineObj.transform.SetParent(transform);
        InitRenderers();
    }

    //lineObj����������
    void InitRenderers()
    {
        //�����Ȃ��_��0�ɏ�����
        _lineRenderers[_lineRenderers.Count - 1].positionCount = 0;
        //�}�e���A����������
        _lineRenderers[_lineRenderers.Count - 1].material = lineMaterial;
        //�F�̏�����
        _lineRenderers[_lineRenderers.Count - 1].material.color = lineColor;
        //�����̏�����
        _lineRenderers[_lineRenderers.Count - 1].startWidth = lineWidth;
        _lineRenderers[_lineRenderers.Count - 1].endWidth = lineWidth;
    }

    /// <summary>
    /// �}�E�X�̍��W�ɐ���`��
    /// </summary>
    void Draw()
    {
        //�}�E�X�|�C���^������X�N���[�����W���擾
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f);

        //�X�N���[�����W�����[���h���W�ɕϊ�
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //���[���h���W�����[�J�����W�ɕϊ�
        Vector3 localPosition = transform.InverseTransformPoint(worldPosition.x, worldPosition.y, -1.0f);

        //lineRenderers�̍Ō��lineObj�̃��[�J���|�W�V��������L�̃��[�J���|�W�V�����ɐݒ�
        _lineRenderers[_lineRenderers.Count-1].transform.localPosition = localPosition;

        //lineObj�̐��Ɛ����Ȃ��_�̐����X�V
        _lineRenderers[_lineRenderers.Count - 1].positionCount += 1;

        //LineRenderer�R���|�[�l���g���X�g���X�V
        _lineRenderers[_lineRenderers.Count - 1].SetPosition(_lineRenderers[_lineRenderers.Count - 1].positionCount - 1, worldPosition);


        //// Line Renderer �� positions �ɐV���ɒǉ�������W���v�Z����
        //Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //pos.z = 0;

        //// �Ō�ɒǉ����� Line Renderer �� positions ��肠����x����Ă�����A���̍��W�� Line Renderer �ɒǉ�����
        //if (_line.positionCount == 0 || (Vector3.Distance(pos, _line.GetPosition(_line.positionCount - 1)) > _distanceBetweenPoints))
        //{
        //    _line.positionCount++;
        //    _line.SetPosition(_line.positionCount - 1, pos);
        //}
    }
}
