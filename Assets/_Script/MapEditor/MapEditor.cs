using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/*
 * 此编辑器可以构建场景（待定）
 * 此编辑器包含图片预处理：生成格子（各自包含具体类型，用于逻辑碰撞检测，每个格子存储相对与左下角的相对位置），最后将序列化后的数据以及prefab生成到具体路径下
 *
 * 可以在场景内加载prefab，最后通过场景生成具体map（格子集合【可能需要找到一种新的方式在有图形覆盖的情况下重新切分格子】）
 *
 * **/

public class MapEditor : EditorWindow
{

    bool _inFocus = false;
    //Texture curTexture = null;


    [MenuItem("Tools/地图编辑器")]
    public static void OpenMapEditor()
    {
        EditorWindow editorWindow = EditorWindow.GetWindow(typeof(MapEditor), true, "地图编辑器", true);
    }

    private void OnFocus()
    {
        _inFocus = true;
    }

    private void OnLostFocus()
    {
        _inFocus = false;
    }

    private void OnGUI()
    {
        if (!_inFocus)
        {
            return;
        }

        GUILayout.Label("得到焦点");

        //EditorGUILayout.c

    }
}
