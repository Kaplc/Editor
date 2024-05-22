using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class LearnEditorAssetDatabase : EditorWindow
{
    [MenuItem("Editor/LearnEditorAssetDatabase")]
    private static void OpenWindow()
    {
        EditorWindow window = GetWindow<LearnEditorAssetDatabase>();
        window.Show();
    }

    private void OnGUI()
    {
        #region 加载资源
        
        // 创建资源
        // 不能在StreamingAssets中创建资源，
        // 不能创建预设体（预设体创建之后会讲），
        // 只能创建资源相关，例如材质球等
        // 路径需要写后缀名
        // 确保路径使用的是支持的扩展名（材质是 '.mat'、立方体贴图是 '.cubemap'、 皮肤是 '.GUISkin'、动画是 '.anim'、其他任意资源是 '.asset'）
        if (GUILayout.Button("创建资源"))
        {
            Material material = new Material(Shader.Find("Standard"));
            AssetDatabase.CreateAsset(material, "Assets/Editor/LearnEditorAssetDatabase/Material.mat");
        }
        
        // 创建文件夹
        if (GUILayout.Button("创建文件夹"))
        {
            AssetDatabase.CreateFolder("Assets/Editor/LearnEditorAssetDatabase", "Folder");
        }
        
        // 拷贝资源
        if (GUILayout.Button("拷贝资源"))
        {
            AssetDatabase.CopyAsset("Assets/Editor/LearnEditorAssetDatabase/Material.mat", "Assets/Editor/LearnEditorAssetDatabase/MaterialCopy.mat");
        }
        
        // 移动资源
        if (GUILayout.Button("移动资源"))
        {
            AssetDatabase.MoveAsset("Assets/Editor/LearnEditorAssetDatabase/Material.mat", "Assets/Editor/LearnEditorAssetDatabase/Folder/Material.mat");
        }
        
        // 删除资源
        if (GUILayout.Button("删除资源"))
        {
            AssetDatabase.DeleteAsset("Assets/Editor/LearnEditorAssetDatabase/MaterialCopy.mat");
        }
        
        // 批量删除
        // AssetDatabase.DeleteAssets(string[] 路径们, List<string> 用于存储删除失败的路径)
        if (GUILayout.Button("批量删除"))
        {
            string[] assets = new string[]
            {
                "Assets/Editor/LearnEditorAssetDatabase/Material.mat",
                "Assets/Editor/LearnEditorAssetDatabase/Folder"
            };
            List<string> deleteFailed = new List<string>();
            AssetDatabase.DeleteAssets(assets, deleteFailed);
        }
        
        // 获取资源路径
        if (GUILayout.Button("获取资源路径"))
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            Debug.Log("资源路径：" + path);
        }
        
        // 加载资源
        if (GUILayout.Button("加载资源"))
        {
            Material material = AssetDatabase.LoadAssetAtPath<Material>("Assets/Editor/LearnEditorAssetDatabase/Material.mat");
            Debug.Log("加载资源：" + material);
        }
        
        // 加载所有资源
        // 一般可以用来加载图集资源，返回值为Object数据
        // 如果是图集，第一个为图集本身，之后的便是图集中的所有Sprite
        if (GUILayout.Button("加载所有资源"))
        {
            Object[] objects = AssetDatabase.LoadAllAssetsAtPath("");
        }
        
        // 刷新资源
        if (GUILayout.Button("刷新资源"))
        {
            AssetDatabase.Refresh();
        }
        #endregion
    }
}