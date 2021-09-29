using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using System;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(BasicMapTile))]
public class BasicMapTileEditor:Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        BasicMapTile tile = target as BasicMapTile;

        if (tile.MapType == null)
        {
            tile.MapType = new List<EMapRectType>() { EMapRectType.Base };
        }

        GUILayout.Space(20);
        GUILayout.Label("格子类型");
        GUILayout.Space(10);

        string[] names = Enum.GetNames(typeof(EMapRectType));

        for (int i = 0; i < names.Length; i++)
        {
            var name = names[i];
            GUILayout.BeginHorizontal();
            GUILayout.Label(name);
            EMapRectType type = (EMapRectType)i;
            bool existType = tile.MapType.Contains(type);
            bool notSelect =  EditorGUILayout.Toggle(existType);
            if (!notSelect && existType)
            {
                tile.MapType.Remove(type);
            }
            else if (notSelect && !existType)
            {
                tile.MapType.Add(type);
            }
            GUILayout.EndHorizontal();
        }
    }

    // 下面是添加菜单项以创建 RoadTile 资源的 helper 函数
    [MenuItem("Assets/Create/格子/基础格子")]
    public static void CreateBasicTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save BasicMapTile", "New CodeZ Tile", "Asset", "Save BasicMapTile", "Assets");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<BasicMapTile>(), path);
    }

    [MenuItem("Assets/地图工具/以当前贴图创建格子")]
    public static void CreateTile()
    {
        Texture2D tex = Selection.activeObject as Texture2D;
        Debug.Log("tex name:" + tex);

        string path = AssetDatabase.GetAssetPath(tex.GetInstanceID());
        Debug.Log("tex path:" + path);

        object[] objs = AssetDatabase.LoadAllAssetsAtPath(path);
        List<Sprite> sps = new List<Sprite>();
        foreach(var obj in objs)
        {
            Debug.Log("obj name:" + obj.ToString());
            var sp = obj as Sprite;
            if (sp == null)
            {
                continue;
            }
            sps.Add(sp);
        }
        Debug.Log("sp count :" + sps.Count);

        string tilePath = EditorUtility.SaveFolderPanel("创建BasicTile", "Assets", "New CodeZ Tile");

        if (tilePath == "")
            return;

        tilePath = tilePath.Replace(Application.dataPath + "/", "");

        foreach (var sp in sps)
        {
            BasicMapTile tile = ScriptableObject.CreateInstance<BasicMapTile>();
            tile.sprite = sp;
            tile.name = sp.name;

            //先这么写，之后优化一下这种hardcode
            AssetDatabase.CreateAsset(tile, "Assets/" + tilePath+"/"+tile.name+".Asset");
        }
    }
}

# endif

public class BasicMapTile : Tile
{
    /// <summary>
    /// 相对_GameAssets下的路径
    /// </summary>
    public const string BasePathParent = "Map/";

    [Header("格子类型")]
    public List<EMapRectType> MapType;
}