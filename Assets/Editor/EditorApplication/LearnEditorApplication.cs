using System;
using UnityEditor;
using UnityEngine;

namespace Editor.LearnEditorApplication
{
    public class LearnEditorApplication: EditorWindow
    {
        [MenuItem("Editor/LearnEditorApplication")]
        private static void OpenWindow()
        {
            EditorWindow window = GetWindow<LearnEditorApplication>();
            window.Show();
        }

        private void OnEnable()
        {
            EditorApplication.update += MyUpdate;
        }

        private void OnDestroy()
        {
            EditorApplication.update -= MyUpdate;
        }

        private void OnGUI()
        {
            //1.监听编辑器事件
            //  EditorApplication.update：每帧更新事件，可以用于在编辑器中执行一些逻辑
            //  EditorApplication.hierarchyChanged：层级视图变化事件，当场景中的对象发生变化时触发
            //  EditorApplication.projectChanged：项目变化事件，当项目中的资源发生变化时触发
            //  EditorApplication.playModeStateChanged：编辑器播放状态变化时触发
            //  EditorApplication.pauseStateChanged：编辑器暂停状态变化时触发

            //2.管理编辑器生命周期相关
            //  EditorApplication.isPlaying：判断当前是否处于游戏运行状态。
            //  EditorApplication.isPaused：判断当前游戏是否处于暂停状态。
            //  EditorApplication.isCompiling：判断Unity编辑器是否正在编译代码
            //  EditorApplication.isUpdating：判断Unity编辑器是否正在刷新AssetDatabase

            //3.获取Unity应用程序路径相关
            //  EditorApplication.applicationContentsPath：Unity安装目录Data路径
            //  EditorApplication.applicationPath：Unity安装目录可执行程序路径

            //4.常用方法
            //  EditorApplication.Exit(0)：退出Unity编辑器
            //  EditorApplication.ExitPlaymode()：退出播放模式，切换到编辑模式
            //  EditorApplication.EnterPlaymode()：进入播放模式

            if (GUILayout.Button("退出Unity编辑器"))
            {
                EditorApplication.Exit(0);
            }

            if (GUILayout.Button("退出播放模式"))
            {
                EditorApplication.ExitPlaymode();
            }

            if (GUILayout.Button("进入播放模式"))
            {
                EditorApplication.EnterPlaymode();
            }

        }
        
        private void MyUpdate()
        {
            if (EditorApplication.isPlaying)
            {
                Debug.Log("EditorApplication.isPlaying");
            }
        }
    }
}