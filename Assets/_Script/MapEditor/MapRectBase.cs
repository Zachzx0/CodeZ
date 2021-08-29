using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;
using UnityEngine.UIElements;

public struct Grid
{
    public int Index;

    [Header("格子类型")]
    public EMapRectType RectType;

    public Vector2 Center;

    public float Width;
    public float Height;
}

public enum EMapRectType
{
    Base,       //可以移动的
    Block,      //不可移动的
}

[CustomEditor(typeof(MapRectBase))]
public class MapRectBaseEditor:Editor
{
    public override void OnInspectorGUI()
    {
        MapRectBase rectBase = target as MapRectBase;

        if (rectBase == null)
        {
            return;
        }

        int.TryParse(GUILayout.TextField(rectBase.GridSizeRatio.ToString()), out rectBase.GridSizeRatio);

        if (GUILayout.Button("刷新格子"))
        {
            rectBase.RefreshGrids();
        }

        if (GUILayout.Button("输出包围盒信息"))
        {
            var render = rectBase.GetComponent<SpriteRenderer>();
            Debug.Log(render.bounds);
        }
    }


    bool _isMouseDown = false;

    private void OnSceneGUI()
    {
        if (Event.current.type == EventType.MouseDown)
        {
            _isMouseDown = true;
        }

        if (Event.current.type == EventType.MouseUp)
        {
            if (_isMouseDown)
            {
                Debug.Log($"点击当前物体,Pos[{Event.current.mousePosition}]");
            }
            _isMouseDown = false;
        }
    }
}

[RequireComponent(typeof(SpriteRenderer))]
public class MapRectBase : MonoBehaviour
{
    protected List<Grid> _grids = new List<Grid>();

    protected SpriteRenderer _mRenderer;

    /// <summary>
    /// 格子与当前sprit大小比例
    /// </summary>
    public int GridSizeRatio = 1;

    public float GridCount
    {
        get
        {
            return _grids.Count;
        }
    }

    private void Awake()
    {
        _mRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        RefreshGrids();
    }

    public void RefreshGrids()
    {
        if (_mRenderer == null)
        {
            Debug.LogError("当前渲染器为空");
            _mRenderer = this.GetComponent<SpriteRenderer>();
            //return;
        }

        int countX = GridSizeRatio;
        int countY = GridSizeRatio;

        //float sizeW = this.
        Bounds rectBound = _mRenderer.bounds;
        float cellXSize = rectBound.extents.x / countX * 2;
        float cellYSize = rectBound.extents.y / countY * 2;

        //Vector3 min

        _grids.Clear();

        _grids.Capacity = countX * countY;

        float tmpX = 0;
        float tmpY = 0;

        for (int x = 0; x < countX; x++)
        {
            for (int y = 0; y < countY; y++)
            {
                int id = x * countY + y;
                _grids.Add(new Grid()
                {
                    Index = id,
                    Center = rectBound.min + new Vector3(cellXSize / 2 + tmpX, cellYSize / 2 + tmpY, 0),
                    Width = cellXSize,
                    Height = cellYSize
                });
                tmpY += cellYSize;
            }
            tmpX += cellXSize;
            tmpY = 0;
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < _grids.Count; i++)
        {
            DrawGrid(_grids[i], Color.yellow);
        }
    }

    void DrawGrid(Grid g, Color color)
    {
        float offsetX = g.Width / 2;
        float offsetY = g.Height / 2;

        Vector3 posLB = new Vector3(g.Center.x - offsetX, g.Center.y - offsetY, this.transform.position.z);
        Vector3 posLT = new Vector3(g.Center.x - offsetX, g.Center.y + offsetY, this.transform.position.z);
        Vector3 posRB = new Vector3(g.Center.x + offsetX, g.Center.y - offsetY, this.transform.position.z);
        Vector3 posRT = new Vector3(g.Center.x + offsetX, g.Center.y + offsetY, this.transform.position.z);

        Debug.DrawLine(posLB, posLT, color);
        Debug.DrawLine(posLT, posRT, color);
        Debug.DrawLine(posRT, posRB, color);
        Debug.DrawLine(posRB, posLB, color);
    }
}
