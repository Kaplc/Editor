using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Editor.LearnEditorUtility
{
    public class LearnEditorUtility: EditorWindow
    {
        [MenuItem("Editor/LearnEditorUtility")]
        private static void OpenWindow()
        {
            EditorWindow window = GetWindow<LearnEditorUtility>();
            window.Show();
        }
        
        public GameObject obj;
        
        private void OnGUI()
        {
            #region 提示窗口、进度条

            // 单键提示
            if (GUILayout.Button("显示提示窗口"))
            {
                // 显示提示窗口
                EditorUtility.DisplayDialog("提示", "这是一个提示窗口", "确定");
            }
            
            // 三键提示
            if (GUILayout.Button("显示三键提示窗口"))
            {
                int res = EditorUtility.DisplayDialogComplex("三键提示", "这是一个三键提示窗口", "确定", "取消", "其他");
                switch (res)
                {
                    case 0:
                        Debug.Log("确定");
                        break;
                    case 1:
                        Debug.Log("取消");
                        break;
                    case 2:
                        Debug.Log("其他");
                        break;
                }
            }
            
            // 进度条
            if (GUILayout.Button("显示进度条"))
            {
                // 显示进度条
                EditorUtility.DisplayProgressBar("进度条", "正在加载", 0.5f);
                // 模拟进度条
                for (int i = 0; i < 100; i++)
                {
                    EditorUtility.DisplayProgressBar("进度条", "正在加载", i / 100f);
                    System.Threading.Thread.Sleep(100);
                }
               
            }

            if (GUILayout.Button("关闭进度条"))
            {
                // 关闭进度条
                EditorUtility.ClearProgressBar();
            }
            

            #endregion

            #region 文件浏览器
            
            // string path = EditorUtility.OpenFilePanel(窗口标题, 打开的目录, 文件后缀格式)
            if (GUILayout.Button("打开文件浏览器"))
            {
                // 显示文件浏览器
                string path = EditorUtility.OpenFilePanel("打开文件", Application.dataPath, "txt");
                Debug.Log(path);
            }
            
            // string path = EditorUtility.OpenFolderPanel(窗口标题, 打开的目录, "")
            if (GUILayout.Button("打开文件夹浏览器"))
            {
                // 显示文件夹浏览器
                string path = EditorUtility.OpenFolderPanel("打开文件夹", Application.dataPath, "");
                Debug.Log(path);
            }
            
            //string path = EditorUtility.SaveFilePanel("窗口标题", "打开的目录", "保存的文件的名称", "文件后缀格式")
            if (GUILayout.Button("保存文件浏览器"))
            {
                // 显示保存文件浏览器
                string path = EditorUtility.SaveFilePanel("保存文件", Application.dataPath, "test", "txt");
                Debug.Log(path);
            }
            
            // string path = EditorUtility.SaveFilePanelInProject("窗口标题", "打开的目录", "文件后缀格式", "保存的文件的名称")
            if (GUILayout.Button("保存文件浏览器指定Assets目录"))
            {
                string path = EditorUtility.SaveFilePanelInProject("保存文件", Application.dataPath, "txt", "保存文件");
                Debug.Log(path);
            }
            
            // string path = EditorUtility.SaveFolderPanel("窗口标题", "打开的目录", "保存的文件的名称")
            if (GUILayout.Button("保存文件夹浏览器"))
            {
                // 显示保存文件夹浏览器
                string path = EditorUtility.SaveFolderPanel("保存文件夹", Application.dataPath, "");
                Debug.Log(path);
            }
            
            #endregion

            #region 压缩纹理、查找资源所有依赖

            if (GUILayout.Button("压缩纹理"))
            {
                // 压缩纹理
                Texture2D texture = EditorGUIUtility.Load("1.png") as Texture2D;
                EditorUtility.CompressTexture(texture, TextureFormat.DXT5, 100);
            }

            if (GUILayout.Button("查找资源所有依赖"))
            {
                obj = Selection.activeObject as GameObject;
                if (obj)
                {
                    Object[] objs = EditorUtility.CollectDependencies(new Object[] { obj });
                    foreach (Object o in objs)
                    {
                        EditorGUIUtility.PingObject(o);
                        Debug.Log(o);
                    }
                }
            }

            #endregion
        }
    }
}