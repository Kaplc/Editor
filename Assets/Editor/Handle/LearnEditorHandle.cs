using System;
using UnityEditor;
using UnityEngine;

namespace Editor.Handle
{
    [CustomEditor(typeof(LearnHandle))]
    public class LearnEditorHandle : UnityEditor.Editor
    {
        private GameObject obj;

        private void OnEnable()
        {
            obj = (target as LearnHandle)?.gameObject;
        }

        private void OnSceneGUI()
        {
            #region 颜色、文本、线段、虚线、弧线、圆形、立方体、多面体

            Handles.color = Color.red;
            // 文本
            Handles.Label(obj.transform.position, "Handles.Label");
            // 线段
            Handles.color = Color.green;
            Handles.DrawLine(obj.transform.position, obj.transform.position + new Vector3(0, 1, 0));
            // 虚线
            Handles.color = Color.blue;
            Handles.DrawDottedLine(obj.transform.position, obj.transform.position + new Vector3(0, -1, 0), 5);
            // 弧线
            Handles.color = Color.red;
            //Handles.DrawWireArc(圆心, 法线, 绘制朝向, 角度, 半径); 
            Handles.DrawWireArc(obj.transform.position, Vector3.up, Vector3.forward, 60, 1); // 非填充
            //Handles.DrawSolidArc(圆心, 法线, 绘制朝向, 角度, 半径); 
            Handles.DrawSolidArc(obj.transform.position, Vector3.up, Vector3.back, 60, 1); // 填充
            // 圆形
            Handles.color = Color.yellow;
            Handles.DrawSolidDisc(obj.transform.position + new Vector3(3, 0, 0), Vector3.up, 1); // 填充
            Handles.DrawWireDisc(obj.transform.position + new Vector3(-3, 0, 0), Vector3.up, 1); // 非填充
            // 立方体
            Handles.color = Color.green;
            Handles.DrawWireCube(obj.transform.position + new Vector3(0, 3, 0), Vector3.one); // 非填充
            // 多面体
            Handles.color = Color.blue;
            Vector3[] vertices = new Vector3[]
            {
                new Vector3(0, 0, 0),
                new Vector3(1, 0, 0),
                new Vector3(1, 1, 0),
                new Vector3(0, 1, 0),
                new Vector3(0, 0, 1),
                new Vector3(1, 0, 1),
                new Vector3(1, 1, 1),
                new Vector3(0, 1, 1),
            };

            Handles.DrawSolidRectangleWithOutline(vertices, Color.red, Color.green);

            #endregion

            #region 显示坐标轴、旋转轴、缩放轴

            // 显示坐标轴
            obj.transform.position = Handles.PositionHandle(obj.transform.position, obj.transform.rotation);
            // 显示旋转轴
            obj.transform.rotation = Handles.RotationHandle(obj.transform.rotation, obj.transform.position);
            // 显示缩放轴
            obj.transform.localScale = Handles.ScaleHandle(obj.transform.localScale, obj.transform.position, obj.transform.rotation,
                HandleUtility.GetHandleSize(obj.transform.position));
            //HandleUtility.GetHandleSize 方法的作用是
            //获取给定位置的操纵器控制柄的世界空间大小
            //使用当前相机计算合适的大小
            //它决定了控制柄的缩放大小

            #endregion

            #region 自由移动、自由旋转

            // 自由移动
            obj.transform.position = Handles.FreeMoveHandle(obj.transform.position, obj.transform.rotation,
                HandleUtility.GetHandleSize(obj.transform.position) * 0.5f, Vector3.one, Handles.RectangleHandleCap);
            // 自由旋转
            obj.transform.rotation = Handles.FreeRotateHandle(obj.transform.rotation, obj.transform.position,
                HandleUtility.GetHandleSize(obj.transform.position) * 0.5f);

            #endregion

            #region Secen窗口显示GUI

            Handles.BeginGUI();

            // 显示文本
            GUI.Label(new Rect(0, 100, 100, 50), "123");

            // 显示按钮
            //获取当前Scene窗口信息
            //SceneView.currentDrawingSceneView
            if (GUI.Button(new Rect(SceneView.currentDrawingSceneView.position.width - 100, SceneView.currentDrawingSceneView.position.height - 75, 100, 50), "按钮"))
            {
                Debug.Log("点击按钮");
            }

            Handles.EndGUI();

            #endregion

            #region HandleUtility

            //1.GetHandleSize(Vector3 position)
            //  我们之前已经使用过的API
            //  获取在场景中给定位置的句柄的合适尺寸
            //  个方法通常用于根据场景中对象的距离来调整句柄的大小，以便在不同的缩放级别下保持合适的显示大小

            //2.WorldToGUIPoint(Vector3 worldPosition)
            //  将世界坐标转换为 GUI 坐标
            //  这个方法通常用于将场景中的某个点的位置转换为屏幕上的像素坐标
            //  以便在 GUI 中绘制相关的信息

            //3.GUIPointToWorldRay(Vector2 position)
            //  将屏幕上的像素坐标转换为射线
            //  这个方法通常用于从屏幕坐标中获取一条射线，用于检测场景中的物体或进行射线投射

            //4.DistanceToLine(Vector3 lineStart, Vector3 lineEnd)
            //  计算场景中一条线段与鼠标光标的最短距离
            //  可以用来制作悬停变色等功能

            //5.PickGameObject(Vector2 position, bool isSelecting)
            //  在编辑器中进行对象的拾取
            //  这个方法通常用于根据鼠标光标位置获取场景中的对象，以实现对象的选择或交互操作

            #endregion
        }
    }
}