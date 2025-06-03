using UnityEngine;
using UnityEngine.UI;

public class PolygonGraph : Graphic
{
    private const int _statusCnt = 6;
    private Vector2 _vertexPos;
    private UIVertex _vertex;
    private float[] _radians = new float[_statusCnt];
    [SerializeField]
    private float[] _status = new float[_statusCnt];
    private int[,] _triangles = new int[_statusCnt, 3];

    public void UpdateGraph(in float[] status)
    {
        _status = status;
        SetAllDirty();
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();
        _vertex = UIVertex.simpleVert;
        float radius = Mathf.Min(rectTransform.rect.width, rectTransform.rect.height) * 0.5f;
        _vertex.position = rectTransform.rect.center;
        _vertex.color = Color.white;
        vh.AddVert(_vertex);

        for (int i = 0; i < _statusCnt; i++)
        {
            float statusRadiusLen = radius * _status[i];
            _vertexPos.x = rectTransform.rect.center.x + Mathf.Cos(_radians[i]) * statusRadiusLen;
            _vertexPos.y = rectTransform.rect.center.y + Mathf.Sin(_radians[i]) * statusRadiusLen;

            _vertex.position = _vertexPos;
            _vertex.color = Color.white;
            vh.AddVert(_vertex);
        }

        for (int i = 0; i < _statusCnt; i++)
        {
            vh.AddTriangle(_triangles[i, 0], _triangles[i, 1], _triangles[i, 2]);
        }

    }

    protected override void Awake()
    {
        for (int i = 1; i <= _statusCnt; i++)
        {
            _triangles[i - 1, 0] = 0;
            _triangles[i - 1, 1] = i;
            _triangles[i - 1, 2] = (i % _statusCnt) + 1;
            _radians[i - 1] = Mathf.Deg2Rad * (360f / _statusCnt * (i - 1) + 90);
        }

        UpdateGraph(_status);
    }
}