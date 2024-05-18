using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;

public class LearnEditorSelection : EditorWindow
{
    [MenuItem("Editor/LearnEditorSelection")]
    public static void OpenWindow()
    {
        EditorWindow window = GetWindow<LearnEditorSelection>();
        window.Show();
    }

    private StringBuilder str1 = new StringBuilder("未选中对象");
    private StringBuilder str2 = new StringBuilder("未选中对象");
    private StringBuilder str3 = new StringBuilder("未选中对象");
    private StringBuilder str4 = new StringBuilder("未选中对象");

    private GameObject obj;

    private void OnGUI()
    {
        // selection 获取当前选中的对象

        // 获取当前选中的对象
        // Selection.activeObject
        // Selection.activeGameObject
        // Selection.activeInstanceID
        // Selection.activeTransform
        // Selection.activeContext
        // Selection.activeAsset

        if (GUILayout.Button("获取当前选中的对象名字"))
        {
            if (Selection.activeObject)
            {
                str1.Clear();
                str1.Append("当前选中的对象名字：");
                str1.Append(Selection.activeObject.name);

                if (Selection.activeObject is GameObject)
                {
                    str1.Append(" 类型：GameObject");
                }
                else if (Selection.activeObject is Texture)
                {
                    str1.Append(" 类型：Texture");
                }
                else if (Selection.activeObject is TextAsset)
                {
                    str1.Append(" 类型：TextAsset");
                }
                else
                {
                    str1.Append(" 类型：其他");
                }
            }
            else
            {
                str1.Clear();
                str1.Append("未选中对象");
            }

            Debug.Log(str1);
        }

        if (GUILayout.Button("获取当前选中的GameObject的Transform"))
        {
            if (Selection.activeTransform)
            {
                str2.Clear();
                str2.Append("当前选中的GameObject的Transform：");
                str2.Append(Selection.activeTransform.name);
                str2.Append(" ");
                str2.Append(Selection.activeTransform.position);
                str2.Append(" ");
                str2.Append(Selection.activeTransform.rotation);
                str2.Append(" ");
                str2.Append(Selection.activeTransform.localScale);
            }
            else
            {
                str2.Clear();
                str2.Append("未选中GameObject");
            }

            Debug.Log(str2);
        }


        if (GUILayout.Button("获取选中的所有GameObject名字"))
        {
            if (Selection.gameObjects.Length > 0)
            {
                str3.Clear();
                str3.Append("选中的所有GameObject名字：");
                foreach (GameObject go in Selection.gameObjects)
                {
                    str3.Append(go.name);
                    str3.Append(" ");
                }
            }
            else
            {
                str3.Clear();
                str3.Append("未选中GameObject");
            }

            Debug.Log(str3);
        }

        #region 判断选中、筛选对象、选中对象变化的回调
        obj = EditorGUILayout.ObjectField("选择一个对象", obj, typeof(GameObject), true) as GameObject;
        // 判断选中
        if (GUILayout.Button("判断选中的对象是否是指定对象"))
        {
            if (Selection.Contains(obj))
            {
                Debug.Log("选中的对象是指定对象");
            }
            else
            {
                Debug.Log("选中的对象不是指定对象");
            }
        }
        
        // 筛选对象
        if (GUILayout.Button("筛选对象"))
        {
            GameObject[] gameObjects = Selection.GetFiltered<GameObject>(SelectionMode.Unfiltered);
            foreach (var gameObject in gameObjects)
            {
                Debug.Log(gameObject.name);
            }
        }
        #endregion


    }

    private void OnSelectionChange()
    {
        // 当选中对象发生变化时，会调用这个方法
        Debug.Log("选中对象发生变化");
    }
}