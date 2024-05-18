using System;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class LearnEditorGUIUtilityEvent: EditorWindow
    {
        [MenuItem("Editor/LearnEditorGUIUtilityEvent")]
        private static void OpenWindow()
        {
            EditorWindow window = GetWindow<LearnEditorGUIUtilityEvent>();
            window.Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("传递窗口事件"))
            {
                // 定义事件
                Event e = EditorGUIUtility.CommandEvent("WindowEvent");
                LearnEditorGUIUtility window = GetWindow<LearnEditorGUIUtility>();
                // 传递事件
                window.SendEvent(e);
            }
        }
    }
}