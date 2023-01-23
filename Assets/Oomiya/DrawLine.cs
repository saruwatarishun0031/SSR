using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ドラッグで線を描くコンポーネント
/// </summary>
public class DrawLine : MonoBehaviour
{
    //線の材質
    [SerializeField] Material lineMaterial;
    //線の色
    [SerializeField] Color lineColor;
    //線の太さ
    [Range(0.1f, 0.5f)]
    [SerializeField] float lineWidth;
    /// <summary>線を描く時に、各点をどれくらい離すか</summary>
    [SerializeField] float _distanceBetweenPoints = 0.1f;
    /// <summary>線を描いている間は true になる</summary>
    bool _isDrawing = false;

    //追加　LineRdenerer型のリスト宣言
    [SerializeField] List<LineRenderer> _lineRenderers;

    private void Start()
    {
        //追加　Listの初期化
        _lineRenderers = new List<LineRenderer>();
    }
    void Update()
    {
        // ボタンを押し下げた時
        if (Input.GetMouseButtonDown(0))
        {
            AddLineObject();
            _isDrawing = true;
        }
        // ボタンを離した時
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
        //空のゲームオブジェクト作成
        GameObject lineObj = new GameObject();
        //オブジェクトの名前をbridgeに変更
        lineObj.name = "bridge";
        //lineObjにLineRendererコンポーネント追加
        lineObj.AddComponent<LineRenderer>();
        lineObj.AddComponent<Collider2D>();
        //lineRendererリストにlineObjを追加
        _lineRenderers.Add(lineObj.GetComponent<LineRenderer>());
        //lineObjを自身の子要素に設定
        lineObj.transform.SetParent(transform);
        InitRenderers();
    }

    //lineObj初期化処理
    void InitRenderers()
    {
        //線をつなぐ点を0に初期化
        _lineRenderers[_lineRenderers.Count - 1].positionCount = 0;
        //マテリアルを初期化
        _lineRenderers[_lineRenderers.Count - 1].material = lineMaterial;
        //色の初期化
        _lineRenderers[_lineRenderers.Count - 1].material.color = lineColor;
        //太さの初期化
        _lineRenderers[_lineRenderers.Count - 1].startWidth = lineWidth;
        _lineRenderers[_lineRenderers.Count - 1].endWidth = lineWidth;
    }

    /// <summary>
    /// マウスの座標に線を描く
    /// </summary>
    void Draw()
    {
        //マウスポインタがあるスクリーン座標を取得
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f);

        //スクリーン座標をワールド座標に変換
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //ワールド座標をローカル座標に変換
        Vector3 localPosition = transform.InverseTransformPoint(worldPosition.x, worldPosition.y, -1.0f);

        //lineRenderersの最後のlineObjのローカルポジションを上記のローカルポジションに設定
        _lineRenderers[_lineRenderers.Count-1].transform.localPosition = localPosition;

        //lineObjの線と線をつなぐ点の数を更新
        _lineRenderers[_lineRenderers.Count - 1].positionCount += 1;

        //LineRendererコンポーネントリストを更新
        _lineRenderers[_lineRenderers.Count - 1].SetPosition(_lineRenderers[_lineRenderers.Count - 1].positionCount - 1, worldPosition);


        //// Line Renderer の positions に新たに追加する座標を計算する
        //Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //pos.z = 0;

        //// 最後に追加した Line Renderer の positions よりある程度離れていたら、その座標を Line Renderer に追加する
        //if (_line.positionCount == 0 || (Vector3.Distance(pos, _line.GetPosition(_line.positionCount - 1)) > _distanceBetweenPoints))
        //{
        //    _line.positionCount++;
        //    _line.SetPosition(_line.positionCount - 1, pos);
        //}
    }
}
