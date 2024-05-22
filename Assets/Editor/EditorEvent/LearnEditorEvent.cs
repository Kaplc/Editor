using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LearnEditorEvent : EditorWindow
{
    [MenuItem("Editor/LearnEditorEvent")]
    private static void OpenWindow()
    {
        EditorWindow window = GetWindow<LearnEditorEvent>();
        window.Show();
    }
    
    private void OnGUI()
    {
        #region 键盘Event

        // alt键按下
        if (Event.current.alt)
        {
            Debug.Log("Alt键按下");
        }
        
        // shift键按下
        if (Event.current.shift)
        {
            Debug.Log("Shift键按下");
        }
        
        // control键按下
        if (Event.current.control)
        {
            Debug.Log("Control键按下");
        }
        
        // 鼠标按下
        if (Event.current.isMouse)
        {
            if (Event.current.button == 0)
            {
                Debug.Log("鼠标左键按下");
            }
            else if (Event.current.button == 1)
            {
                Debug.Log("鼠标右键按下");
            }
            else if (Event.current.button == 2)
            {
                Debug.Log("鼠标中键按下");
            }
            // 鼠标位置
            Debug.Log("鼠标位置：" + Event.current.mousePosition);
        }
        
        // 键盘按下
        if (Event.current.isKey)
        {
            Debug.Log("键盘按下：" + Event.current.keyCode);
            Debug.Log("键盘输入的字符：" + Event.current.character);
        }
        
        // 在处理完对应输入事件后，调用该方法，可以阻止事件继续派发，放置和Unity其他编辑器事件逻辑冲突
        // Event.current.Use();
        
        // 判断输入类型
        if (Event.current.type == EventType.MouseDown)
        {
            Debug.Log("判断输入类型：鼠标按下");
        }
        
        // 是否大写键
        if (Event.current.capsLock)
        {
            Debug.Log("大写键开启");
        }
        
        // 功能键
        if (Event.current.functionKey)
        {
            Debug.Log("功能键按下");
        }
        
        // 数字键
        if (Event.current.numeric)
        {
            Debug.Log("数字键按下");
        }
        
        // 判断复制、粘贴、剪切
        if (Event.current.commandName == "Copy")
        {
            Debug.Log("复制");
        }
        else if (Event.current.commandName == "Paste")
        {
            Debug.Log("粘贴");
        }
        else if (Event.current.commandName == "Cut")
        {
            Debug.Log("剪切");
        }
        
        // 鼠标移动间隔
        if (Event.current.type == EventType.MouseMove)
        {
            Debug.Log("鼠标移动间隔：" + Event.current.delta);
        }
        
        
        #endregion
    }
}
