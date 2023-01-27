using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// ドラッグで線を描くコンポーネント
/// </summary>
public class DrawLine : MonoBehaviour
{
    //現在のライン
    LineRenderer _correntline;
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

    List<Vector2> _linePoints = new List<Vector2>();

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
       var lr =  lineObj.AddComponent<LineRenderer>();
        //lr.useWorldSpace = false;
        lineObj.AddComponent<EdgeCollider2D>();
        //lineRendererリストにlineObjを追加
        _lineRenderers.Add(lr);
        //lineObjを自身の子要素に設定
        lineObj.transform.SetParent(transform);

        //今書いているラインを変数に格納
        _correntline = _lineRenderers.Last();
        //初期化
        InitRenderers();
    }

    //lineObj初期化処理
    void InitRenderers()
    {
        //線をつなぐ点を0に初期化
        _correntline.positionCount = 0;
        //マテリアルを初期化
        _correntline.material = lineMaterial;
        //色の初期化
        _correntline.material.color = lineColor;
        //太さの初期化
        _correntline.startWidth = lineWidth;
        _correntline.endWidth = lineWidth;
    }

    /// <summary>
    /// マウスの座標に線を描く
    /// </summary>
    void Draw()
    {
        //マウスポインタがあるスクリーン座標を取得
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f);

        //スクリーン座標をワールド座標に変換
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePosition);

        //ワールド座標をローカル座標に変換
        Vector3 localPosition = transform.InverseTransformPoint(worldPos.x, worldPos.y, -1.0f);

        //lineObjの線と線をつなぐ点の数を更新
        _correntline.positionCount += 1;

        //LineRendererコンポーネントリストを更新
        _correntline.SetPosition(_correntline.positionCount - 1, worldPos);

        //linePointsに線の座標を追加
        _linePoints.Add(localPosition);

        //LineRendererにEdgeCollider2Dを貼り付け
        _correntline.GetComponent<EdgeCollider2D>().SetPoints(_linePoints);
    }
}
