using System;
using UnityEditor;
using UnityEngine;

namespace Editor.Handle
{
    public class LearnEditorHandleWindow: EditorWindow
    {
        [MenuItem("Editor/LearnEditorHandle")]
        private static void OpenWindow()
        {
            EditorWindow window = GetWindow<LearnEditorHandleWindow>();
            window.Show();
        }

        private void OnEnable()
        {
            // SceneView.duringSceneGui 用于在场景视图中绘制GUI
            SceneView.duringSceneGui += TestSceneGUI;
        }
        
        private void OnDestroy()
        {
            SceneView.duringSceneGui -= TestSceneGUI;
        }
        
        private void TestSceneGUI(SceneView view)
        {
            // Debug.Log("TestSceneGUI");
        }
    }
}