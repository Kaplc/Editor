using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LearnInspector))]
public class LearnEditorInspector : UnityEditor.Editor
{
    // SerializedObject 代表脚本对象
    // SerializedProperty 代表脚本对象中的属性
    private SerializedProperty i;
    private SerializedProperty f;
    private SerializedProperty s;
    private SerializedProperty b;
    private SerializedProperty v2;

    private SerializedProperty go;
    // private SerializedObject serializedObject;

    private SerializedProperty list;


    private SerializedProperty otherClass;
    private SerializedProperty otherClassGo;
    private SerializedProperty otherClassList;

    private int dictionaryCount;
    private SerializedProperty keysList;
    private SerializedProperty valuesList;
    private HashSet<string> hashKeys = new HashSet<string>();

    private bool isFoldout = true;
    private bool isFoldout2 = true;
    private bool isFoldoutCustomList = true;
    private bool isFoldoutCustomDictionary = true;
    private bool isFoldout3 = true;

    private void OnEnable()
    {
        // 获取脚本对象
        // LearnInspector learnInspector = (LearnInspector) target;
        // 创建一个SerializedObject对象
        // serializedObject = new SerializedObject(learnInspector);
        // 获取脚本对象中的属性
        i = serializedObject.FindProperty("i");
        f = serializedObject.FindProperty("f");
        s = serializedObject.FindProperty("s");
        b = serializedObject.FindProperty("b");
        v2 = serializedObject.FindProperty("v2");
        go = serializedObject.FindProperty("go");

        list = serializedObject.FindProperty("list");

        otherClass = serializedObject.FindProperty("otherClass");
        // 获取OtherClass中的属性, 两种方法
        otherClassList = otherClass.FindPropertyRelative("list");
        otherClassList = serializedObject.FindProperty("otherClass.list");

        keysList = serializedObject.FindProperty("keys");
        valuesList = serializedObject.FindProperty("values");
        dictionaryCount = keysList.arraySize;
        // 读取keysList中的key值
        hashKeys.Clear();
        for (int i = 0; i < keysList.arraySize; i++)
        {
            hashKeys.Add(keysList.GetArrayElementAtIndex(i).stringValue);
        }
    }
    
    // 重写OnInspectorGUI函数
    public override void OnInspectorGUI()
    {
        // 更新序列化对象的表示形式
        serializedObject.Update();

        #region 常用类型自定义显示

        // 折叠按钮
        isFoldout = EditorGUILayout.Foldout(isFoldout, "折叠");
        if (isFoldout)
        {
            // 显示属性
            EditorGUILayout.IntSlider(i, 0, 100, "整数滑动条");
            f.floatValue = EditorGUILayout.FloatField("浮点数输入框", f.floatValue);
            s.stringValue = EditorGUILayout.TextField("字符串输入框", s.stringValue);
            b.boolValue = EditorGUILayout.Toggle("布尔开关", b.boolValue);
            v2.vector2Value = EditorGUILayout.Vector2Field("二维向量", v2.vector2Value);
            EditorGUILayout.ObjectField("游戏对象", go.objectReferenceValue, typeof(GameObject), true);
        }

        #endregion
        
        #region 自定义list、array、dictionary显示

        //EditorGUILayout.PropertyField(SerializedProperty对象, 标题); 该API会按照属性类型自己去处理控件绘制的逻辑

        isFoldout2 = EditorGUILayout.Foldout(isFoldout2, "自定义list、array、dictionary显示折叠");
        if (isFoldout2)
        {
            // 设置list长度
            list.arraySize = EditorGUILayout.IntField("List长度", list.arraySize);
            isFoldoutCustomList = EditorGUILayout.Foldout(isFoldoutCustomList, "List折叠");
            if (isFoldoutCustomList)
            {
                // list.InsertArrayElementAtIndex(索引)为数组在指定索引插入默认元素(容量会变化)
                // list.DeleteArrayElementAtIndex(索引)为数组在指定索引删除元素(容量会变化)

                // 自定义显示list
                for (int i = 0; i < list.arraySize; i++)
                {
                    // GetArrayElementAtIndex(索引)获取数组中指定索引位置的SerializedProperty对象
                    SerializedProperty element = list.GetArrayElementAtIndex(i);
                    element.intValue = EditorGUILayout.IntField(i.ToString(), element.intValue);
                }
            }

            EditorGUILayout.Space(10);
            // 设置dictionary长度
            dictionaryCount = EditorGUILayout.IntField("Dictionary长度", dictionaryCount);
            isFoldoutCustomDictionary = EditorGUILayout.Foldout(isFoldoutCustomDictionary, "Dictionary折叠");
            if (isFoldoutCustomDictionary)
            {
                // 自定义显示dictionary
                for (int i = 0; i < keysList.arraySize; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    keysList.GetArrayElementAtIndex(i).stringValue = EditorGUILayout.TextField("Key", keysList.GetArrayElementAtIndex(i).stringValue);
                    valuesList.GetArrayElementAtIndex(i).intValue = EditorGUILayout.IntField("Value", valuesList.GetArrayElementAtIndex(i).intValue);
                    EditorGUILayout.EndHorizontal();
                }
                
                // 显示添加的键值对
                for (int i = keysList.arraySize; i < dictionaryCount; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    string key = EditorGUILayout.TextField("Key", "");
                    int value = EditorGUILayout.IntField("Value", 0);
                    EditorGUILayout.EndHorizontal();
                    if (hashKeys.Contains(key))
                    {
                        EditorGUILayout.HelpBox("Key值重复", MessageType.Error);
                    }
                    else
                    {
                        hashKeys.Add(key);
                        keysList.InsertArrayElementAtIndex(keysList.arraySize);
                        keysList.GetArrayElementAtIndex(keysList.arraySize - 1).stringValue = key;
                        valuesList.InsertArrayElementAtIndex(valuesList.arraySize);
                        valuesList.GetArrayElementAtIndex(valuesList.arraySize - 1).intValue = value;
                    }
                }
            }
        }

        #endregion

        #region 自定义类显示

        isFoldout3 = EditorGUILayout.Foldout(isFoldout3, "自定义类显示折叠");
        if (isFoldout3)
        {
            EditorGUILayout.PropertyField(otherClass);
        }

        #endregion

        // 应用属性修改
        serializedObject.ApplyModifiedProperties();
    }

    // serializedObject.ApplyModifiedProperties();之间应用属性修改
}