using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum ETestEnum
{
    A,
    B,
    C
}

public enum ETestMoreSelectEnum
{
    A = 1,
    B = 2,
    C = 4,
    D = 8,
    A_B = A | B,
    C_D = C | D,
    B_C = B | C
}

public class LearnEditorWindow : EditorWindow
{
    int layerIndex = 0;
    string tagIndex;
    Color color;
    private ETestEnum e1;
    private ETestMoreSelectEnum e2;

    string[] strings = new string[] { "A", "B", "C" };
    int[] values = new int[] { 1, 2, 3 };
    int index = 0;

    private GameObject gameObject;
    private Animation animation;

    private string oneLine;
    private string multiLine;
    private int intValue;
    private float floatValue;
    private bool boolValue;
    private double doubleValue;
    private Vector2 vector2Value;
    private Vector3 vector3Value;
    private Vector4 vector4Value;
    private Rect rectValue;
    private Bounds boundsValue;
    private BoundsInt boundsIntValue;

    private bool isFoldout = false;
    private bool isFoldoutHeader = false;

    private bool toggle = false;
    private bool toggleLeft = false;
    private bool toggleGroup = false;
    
    private float sliderValue = 0.5f;
    private int sliderIntValue = 50;
    private float sliderMinValue = 0;
    private float sliderMaxValue = 100;
    
    private AnimationCurve curve = AnimationCurve.Linear(0, 0, 1, 1);
    
    private void OnEnable()
    {
    }

    [MenuItem("GameObject/扩展GameObject")]
    public static void AddGameObjectContent()
    {
        Debug.Log("扩展GameObject");
    }

    [MenuItem("Editor/LearnEditorWindow")]
    public static void OpenEditorWindow()
    {
        LearnEditorWindow window = GetWindow<LearnEditorWindow>();
        window.minSize = new Vector2(800, 600);
        window.Show();
    }

    private void OnGUI()
    {
        // 绘制文本
        EditorGUILayout.LabelField("hello world");
        EditorGUILayout.LabelField("hello world", "123");

        GUIStyle style = new GUIStyle();
        style.fontSize = 16;
        style.normal.textColor = Color.red;
        EditorGUILayout.LabelField(new GUIContent("GUIContent"), style, GUILayout.Height(30), GUILayout.Width(200));
        // 绘制层级选择控件
        layerIndex = EditorGUILayout.LayerField("层级获取", layerIndex);
        // 标签选择
        tagIndex = EditorGUILayout.TagField("标签获取", tagIndex, GUILayout.Width(500));
        // 颜色获取
        color = EditorGUILayout.ColorField("颜色获取", color);
        // 枚举选择
        e1 = (ETestEnum)EditorGUILayout.EnumPopup("枚举单选", e1);
        e2 = (ETestMoreSelectEnum)EditorGUILayout.EnumFlagsField("枚举多选", e2);
        // 整数选择
        index = EditorGUILayout.IntPopup("整数选择", index, strings, values);
        EditorGUILayout.LabelField(index.ToString());


        isFoldout = EditorGUILayout.Foldout(isFoldout, "折叠");
        if (isFoldout)
        {
            #region 对象选择和各种类型输入

            gameObject = EditorGUILayout.ObjectField("游戏对象选择", gameObject, typeof(GameObject), true) as GameObject;
            animation = EditorGUILayout.ObjectField("动画对象选择", animation, typeof(Animation), true) as Animation;

            // 输入框
            oneLine = EditorGUILayout.TextField("输入框", "输入框");
            // 多行输入框
            multiLine = EditorGUILayout.TextArea("多行输入框", GUILayout.Height(50));
            // int
            intValue = EditorGUILayout.IntField("整数输入", intValue);
            // float
            floatValue = EditorGUILayout.FloatField("浮点数输入", floatValue);
            // bool
            boolValue = EditorGUILayout.Toggle("布尔输入", boolValue);
            // double
            doubleValue = EditorGUILayout.DoubleField("双精度浮点数输入", doubleValue);
            // Vector2
            vector2Value = EditorGUILayout.Vector2Field("Vector2输入", vector2Value);
            // Vector3
            vector3Value = EditorGUILayout.Vector3Field("Vector3输入", vector3Value);
            // Vector4
            vector4Value = EditorGUILayout.Vector4Field("Vector4输入", vector4Value);
            // Rect
            rectValue = EditorGUILayout.RectField("Rect输入", rectValue);
            // Bounds
            boundsValue = EditorGUILayout.BoundsField("Bounds输入", boundsValue);
            // BoundsInt
            boundsIntValue = EditorGUILayout.BoundsIntField("BoundsInt输入", boundsIntValue);

            #endregion
        }

        isFoldoutHeader = EditorGUILayout.BeginFoldoutHeaderGroup(isFoldoutHeader, "折叠组");
        if (isFoldoutHeader)
        {
            EditorGUILayout.LabelField("折叠组内容");
            // 按钮
            if (GUILayout.Button("按钮"))
            {
                Debug.Log("按钮");
            }

            if (EditorGUILayout.DropdownButton(new GUIContent("按下触发按钮"), FocusType.Passive))
            {
                Debug.Log("按下触发按钮");
            }
        }

        EditorGUILayout.EndFoldoutHeaderGroup();
        
        #region 按钮、开关

        // 按钮
        if (GUILayout.Button("按钮", GUILayout.Width(100)))
        {
            Debug.Log("按钮");
        }

        if (EditorGUILayout.DropdownButton(new GUIContent("按下触发按钮"), FocusType.Passive))
        {
            Debug.Log("按下触发按钮");
        }
        
        // 开关
        toggle = EditorGUILayout.Toggle("开关", toggle);
        toggleLeft = EditorGUILayout.ToggleLeft("开关左", toggleLeft);
        
        toggleGroup = EditorGUILayout.BeginToggleGroup("开关组", toggleGroup);
        if (toggleGroup)
        {
            EditorGUILayout.LabelField("开关组内容");
        }
        
        EditorGUILayout.EndToggleGroup();

        #endregion
        
        #region 滑动条
        
        sliderValue = EditorGUILayout.Slider("滑动条", sliderValue, 0, 1);
        sliderIntValue = EditorGUILayout.IntSlider("整数滑动条", sliderIntValue, 0, 100);
        EditorGUILayout.MinMaxSlider("最小最大滑动条", ref sliderMinValue, ref sliderMaxValue, 0, 1);
        
        #endregion

        #region 帮助框、间隔
        
        EditorGUILayout.Space(10);
        EditorGUILayout.HelpBox("提示框", MessageType.None);
        EditorGUILayout.Space(10);
        EditorGUILayout.HelpBox("帮助框", MessageType.Info);
        EditorGUILayout.Space(10);
        EditorGUILayout.HelpBox("警告框", MessageType.Warning);
        EditorGUILayout.Space(10);
        EditorGUILayout.HelpBox("错误框", MessageType.Error);
        EditorGUILayout.Space(10);

        #endregion

        #region 动画曲线和布局 
        
        // 动画曲线
        curve = EditorGUILayout.CurveField("动画曲线", curve);

        //布局API
        EditorGUILayout.BeginHorizontal(); //开始水平布局
        EditorGUILayout.LabelField("123123");
        EditorGUILayout.LabelField("123123");
        EditorGUILayout.LabelField("123123");
        EditorGUILayout.EndHorizontal();//结束水平布局

        EditorGUILayout.BeginVertical();//开始垂直布局
        EditorGUILayout.LabelField("123123");
        EditorGUILayout.LabelField("123123");
        EditorGUILayout.LabelField("123123");
        EditorGUILayout.EndVertical();//结束垂直布局

        #endregion
    }

    private void OnFocus()
    {
    }
}