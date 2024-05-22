using System;
using UnityEditor;
using UnityEngine;

namespace Editor.LearnPrefabUtility
{
    public class LearnPrefabUtility : EditorWindow
    {
        [MenuItem("Editor/LearnPrefabUtility")]
        private static void OpenWindow()
        {
            EditorWindow window = GetWindow<LearnPrefabUtility>();
            window.Show();
        }

        private void OnGUI()
        {
            // 创建预设体
            if (GUILayout.Button("创建预设体"))
            {
                GameObject go = new GameObject("Prefab");
                // 创建预设体
                PrefabUtility.SaveAsPrefabAsset(go, "Assets/Prefab/Prefab.prefab");
                DestroyImmediate(go);
            }
            
            // 加载预设体
            if (GUILayout.Button("加载预设体"))
            {
                GameObject prefab = PrefabUtility.LoadPrefabContents("Assets/Prefab/Prefab.prefab"); // 已经实例化到预设体的预览场景中
                // 释放预设体
                PrefabUtility.UnloadPrefabContents(prefab);
            }
            
            // 实例化预设体
            if (GUILayout.Button("实例化预设体"))
            {
                GameObject prefab = PrefabUtility.LoadPrefabContents("Assets/Prefab/Prefab.prefab");
                Instantiate(prefab);
                PrefabUtility.UnloadPrefabContents(prefab);
            }
            
            // 修改预设体
            if (GUILayout.Button("另存为修改预设体"))
            {
                // 先加载
                GameObject prefab = PrefabUtility.LoadPrefabContents("Assets/Prefab/Prefab.prefab");
                prefab.name = "Prefab666";
                prefab.AddComponent<Rigidbody>();
                // 另存为
                PrefabUtility.SaveAsPrefabAsset(prefab, "Assets/Prefab/Prefab666.prefab");
                PrefabUtility.UnloadPrefabContents(prefab);
            }

            if (GUILayout.Button("直接修改预设体"))
            {
                // 先加载
                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/Prefab.prefab");
                prefab.name = "Prefab666";
                prefab.AddComponent<Rigidbody>();
            }
        }
    }
}