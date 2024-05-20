using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnInspector : MonoBehaviour, ISerializationCallbackReceiver
{
    public int i;
    public float f;
    public string s;
    public bool b;
    public Vector2 v2;
    public GameObject go;

    public List<int> list = new List<int>();

    public OtherClass otherClass = new OtherClass();

    public Dictionary<string, int> dictionary = new Dictionary<string, int>();
    [SerializeField] private List<string> keys = new List<string>();
    [SerializeField] private List<int> values = new List<int>();

    // 序列化前的回调
    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();
        foreach (var pair in dictionary)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    // 反序列化后的回调
    public void OnAfterDeserialize()
    {
        dictionary.Clear();
        for (int i = 0; i < Math.Min(keys.Count, values.Count); i++)
        {
            if (dictionary.ContainsKey(keys[i]))
            {
                keys.RemoveAt(i);
                values.RemoveAt(i);
            }
            else
            {
                dictionary.Add(keys[i], values[i]);
            }
        }
    }

    private void Update()
    {
        // print(list.Count);
    }
}

[Serializable]
public class OtherClass
{
    [SerializeField] private int pri;
    public int i;
    public float f;
    public string s;
    public bool b;
    public Vector2 v2;
    public GameObject go;

    public List<int> list = new List<int>();
    public Dictionary<string, int> dictionary = new Dictionary<string, int>();
}