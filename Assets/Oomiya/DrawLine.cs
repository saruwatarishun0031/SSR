using UnityEngine;

/// <summary>
/// �h���b�O�Ő���`���R���|�[�l���g
/// </summary>
public class DrawLine : MonoBehaviour
{
    /// <summary>����`�����߂Ɏg�� Line Renderer</summary>
    [SerializeField] LineRenderer _line;
    /// <summary>����`�����ɁA�e�_���ǂꂭ�炢������</summary>
    [SerializeField] float _distanceBetweenPoints = 0.1f;
    /// <summary>����`������ɂ��̐��ɉ����ăI�u�W�F�N�g�𓮂����R���|�[�l���g</summary>
    //[SerializeField] MoveOnLine _moveOnLine;
    /// <summary>����`���Ă���Ԃ� true �ɂȂ�</summary>
    bool _isDrawing = false;

    void Update()
    {
        // �{�^����������������
        if (Input.GetMouseButtonDown(0))
        {
            _isDrawing = true;
            //Reset();
            //_moveOnLine.Stop();
        }
        // �{�^���𗣂�����
        else if (Input.GetMouseButtonUp(0))
        {
            _isDrawing = false;
            // Line Renderer �� positions ���擾���AMoveOnLine �R���|�[�l���g������������
            Vector3[] positions = new Vector3[_line.positionCount];
            _line.GetPositions(positions);
            //_moveOnLine.Init(positions);
        }

        if (_isDrawing)
        {
            Draw();
        }
    }

    /// <summary>
    /// ����`�����W�����ׂď����āA��ʏ�̐�������
    /// </summary>
    //void Reset()
    //{
    //    _line.positionCount = 0;
    //}

    /// <summary>
    /// �}�E�X�̍��W�ɐ���`��
    /// </summary>
    void Draw()
    {
        // Line Renderer �� positions �ɐV���ɒǉ�������W���v�Z����
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        // �Ō�ɒǉ����� Line Renderer �� positions ��肠����x����Ă�����A���̍��W�� Line Renderer �ɒǉ�����
        if (_line.positionCount == 0 || (Vector3.Distance(pos, _line.GetPosition(_line.positionCount - 1)) > _distanceBetweenPoints))
        {
            _line.positionCount++;
            _line.SetPosition(_line.positionCount - 1, pos);
        }
    }
}
