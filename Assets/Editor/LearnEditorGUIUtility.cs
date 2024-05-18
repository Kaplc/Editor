using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LearnEditorGUIUtility : EditorWindow
{
    private Texture texture1;
    private Texture texture2;

    private Color color;
    private AnimationCurve curve;
    
    [MenuItem("Editor/LearnEditorGUIUtility")]
    private static void OpenWindow()
    {
        EditorWindow window = GetWindow<LearnEditorGUIUtility>();
        window.Show();
    }

    private void OnGUI()
    {
        #region 加载资源
        //Editor Default Resources 也是Unity当中的一个特殊文件夹
        //它的主要作用是放置提供给 EditorGUIUtility 加载的资源
        //想要使用EditorGUIUtility公共类来加载资源
        //我们需要将资源放置在 Editor Default Resources 文件夹中
        if (GUILayout.Button("编辑器加载图片"))
        {
            //对应API：
            //EditorGUIUtility.Load
            //注意事项：
            //1.只能加载Assets/Editor Default Resources/文件夹下的资源
            //2.加载资源时，需要填写资源后缀名
            // EditorGUIUtility.Load资源不存在时会返回null
            texture1 = EditorGUIUtility.Load("1.png") as Texture;
            //对应API：
            //EditorGUIUtility.LoadRequired
            //注意事项：
            //1.只能加载Assets/Editor Default Resources/文件夹下的资源
            //2.加载资源时，需要填写资源后缀名
            // EditorGUIUtility.LoadRequired资源不存在时会报错
            texture2 = EditorGUIUtility.LoadRequired("2.png") as Texture;
        }
        if (texture1)
        {
            // GUI.DrawTexture(new Rect(0, 50, 200, 100), texture1);
        }
        
        if (texture2)
        {
            // GUI.DrawTexture(new Rect(0, 175, 200, 100), texture2);
        }
        #endregion

        #region 搜索框，对象选中提示

        if (GUILayout.Button("打开搜索框"))
        {
            //  EditorGUIUtility.ShowObjectPicker<资源类型>(默认被选中的对象, 是否允许查找场景对象, "查找对象名称过滤", 0);
            //  参数1. 默认被选中的对象的引用
            //  参数2. 是否允许查找场景对象
            //  参数3. 查找对象名称过滤（比如这里的normal是指文件名称中有normal的会被搜索到）
            //  参数4. controlID, 默认写0
            EditorGUIUtility.ShowObjectPicker<Texture>(null, false, "", 0);
        }
        
        // 然后在搜索框中选中一个对象，就会触发ObjectSelectorUpdated事件
        if (Event.current.commandName == "ObjectSelectorUpdated")
        {
            //EditorGUIUtility.GetObjectPickerObject() 获取搜索框中选中的对象
            Texture texture = EditorGUIUtility.GetObjectPickerObject() as Texture;
            if (texture)
            {
                Debug.Log("选中的对象是：" + texture.name);
            }
        }
        
        // 关闭搜索框，就会触发ObjectSelectorClosed事件
        if (Event.current.commandName == "ObjectSelectorClosed")
        {
            Debug.Log("搜索框关闭");
        }
        
        // 高亮选中对象
        if (GUILayout.Button("高亮选中对象"))
        {
            if (texture1)
            {
                EditorGUIUtility.PingObject(texture1);
            }
        }
        #endregion

        #region 窗口事件, 坐标转换

        if (Event.current.commandName == "WindowEvent")
        {
            Debug.Log("接收到窗口事件");
        }

        if (GUILayout.Button("坐标转换"))
        {
            //对应API：
            //EditorGUIUtility.ScreenToGUIPoint
            //EditorGUIUtility.GUIToScreenPoint
            //注意事项：
            //1.坐标转换时，需要传入的是Vector2类型的坐标
            //2.坐标转换时，需要传入的是相对于屏幕的坐标
            //3.ScreenToGUIPoint是将屏幕坐标转换为GUI坐标
            //4.GUIToScreenPoint是将GUI坐标转换为屏幕坐标
            Vector2 screenPoint = new Vector2(100, 100);
            Vector2 guiPoint = EditorGUIUtility.ScreenToGUIPoint(screenPoint);
            Debug.Log("屏幕坐标：" + screenPoint + " 转换为GUI坐标：" + guiPoint);
        }
        
        #endregion

        #region 指定区域使用对应鼠标形式    

        //  AddCursorRect(Rect position, MouseCursor mouse);

        //  MouseCursor鼠标光标类型枚举
        //  Arrow	            普通指针箭头
        //  Text                文本文本光标
        //  ResizeVertical      调整大小垂直调整大小箭头
        //  ResizeHorizontal    调整大小水平调整大小箭头
        //  Link                带有链接徽章的链接箭头
        //  SlideArrow          滑动箭头带有小箭头的箭头，用于指示在数字字段处滑动
        //  ResizeUpRight       调整大小向上向右调整窗口边缘的大小
        //  ResizeUpLeft        窗口边缘为左
        //  MoveArrow           带有移动符号的箭头旁边用于场景视图
        //  RotateArrow         旁边有用于场景视图的旋转符号
        //  ScaleArrow          旁边有用于场景视图的缩放符号
        //  ArrowPlus           旁边带有加号的箭头
        //  ArrowMinus          旁边带有减号的箭头
        //  Pan                 用拖动的手拖动光标进行平移
        //  Orbit               用眼睛观察轨道的光标
        //  Zoom                使用放大镜进行缩放的光标
        //  FPS                 带眼睛的光标和用于FPS导航的样式化箭头键
        //  CustomCursor        当前用户定义的光标
        //  SplitResizeUpDown   向上-向下调整窗口拆分器的大小箭头
        //  SplitResizeLeftRight窗口拆分器的左-右调整大小箭头
        
        EditorGUI.DrawRect(new Rect(0, 200, 100,100), Color.green);
        EditorGUIUtility.AddCursorRect(new Rect(0, 200, 100,100), MouseCursor.ResizeVertical);

        #endregion

        #region 绘制色板，绘制曲线

        color = EditorGUILayout.ColorField("绘制色板", color);
        EditorGUIUtility.DrawColorSwatch(new Rect(150, 300, 100, 100), color);

        //EditorGUIUtility.DrawCurveSwatch(Rect 绘制曲线的范围,
        //                                 AnimationCurve 曲线,
        //                                 SerializedProperty 要绘制为SerializedProperty的曲线,
        //                                 Color 绘制曲线的颜色,
        //                                 Color 绘制背景的颜色);
        if (curve != null)
        {
            curve = EditorGUILayout.CurveField("绘制曲线", curve); 
        }
        EditorGUIUtility.DrawCurveSwatch(new Rect(0, 400, 100,100), curve, null, Color.red, Color.white);

        #endregion
    }
}
