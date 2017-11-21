using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class Extension
{

    public static void SetEnabled(this Renderer render, bool val)
    {
        render.enabled = val;
    }

    public static void SetPosition_X(this Transform trans, float val)
    {
        trans.position = new Vector3(val, trans.position.y, trans.position.z);
    }
    public static void SetPosition_Y(this Transform trans, float val)
    {
        trans.position = new Vector3(trans.position.x, val, trans.position.z);
    }
    public static void SetPosition_Z(this Transform trans, float val)
    {
        trans.position = new Vector3(trans.position.x, trans.position.y, val);
    }

    public static void SetLocalPosition_X(this Transform trans, float val)
    {
        trans.localPosition = new Vector3(val, trans.localPosition.y, trans.localPosition.z);
    }
    public static void SetLocalPosition_Y(this Transform trans, float val)
    {
        trans.localPosition = new Vector3(trans.localPosition.x, val, trans.localPosition.z);
    }
    public static void SetLocalPosition_Z(this Transform trans, float val)
    {
        trans.localPosition = new Vector3(trans.localPosition.x, trans.localPosition.y, val);
    }

    public static void SetLocalScale_X(this Transform trans, float val)
    {
        trans.localScale = new Vector3(val, trans.localScale.y, trans.localScale.z);
    }
    public static void SetLocalScale_Y(this Transform trans, float val)
    {
        trans.localScale = new Vector3(trans.localScale.x, val, trans.localScale.z);
    }
    public static void SetLocalScale_Z(this Transform trans, float val)
    {
        trans.localScale = new Vector3(trans.localScale.x, trans.localScale.y, val);
    }

    public static void SetLocalEulerAngles_X(this Transform trans, float val)
    {
        trans.localEulerAngles = new Vector3(val, trans.localEulerAngles.y, trans.localEulerAngles.z);
    }
    public static void SetLocalEulerAngles_Y(this Transform trans, float val)
    {
        trans.localEulerAngles = new Vector3(trans.localEulerAngles.x, val, trans.localEulerAngles.z);
    }
    public static void SetLocalEulerAngles_Z(this Transform trans, float val)
    {
        trans.localEulerAngles = new Vector3(trans.localEulerAngles.x, trans.localEulerAngles.y, val);
    }

    // objs must be like {"pos", {0, 1, 2}, "relavitePos", {0, 0, 1}, "dmg", 20 ...}
    public static Dictionary<string, object> ToDictionary(this object[] objs)
    {
        Dictionary<string, object> result = new Dictionary<string, object>();

        if (objs.Length == 0 || objs.Length % 2 != 0) return result;

        for (int i = 0; i < objs.Length / 2; i++)
        {
            int idx_key = i * 2;
            int idx_val = idx_key + 1;

            object key_obj = objs[idx_key];
            object val_obj = objs[idx_val];

            string key_string = key_obj as string;
            result.Add(key_string, val_obj);
        }
        return result;
    }

    // return the added array
    public static object[] AddKeyValuePair(this object[] objs, string key, object val)
    {
        object[] result = new object[objs.Length + 2];

        List<object> objList = new List<object>(objs);
        objList.Add(key);
        objList.Add(val);

        result = objList.ToArray();

        return result;
    }
    public static object[] ToObjArray(this Dictionary<string, object> dic)
    {
        object[] result = new object[dic.Count * 2];

        List<string> keyList = new List<string>(dic.Keys);
        for (int i = 0; i < keyList.Count; i++)
        {
            int idx_key = i * 2;
            int idx_val = idx_key + 1;
            string key_string = keyList[i];
            object val_obj = dic[key_string];
            result[idx_key] = key_string;
            result[idx_val] = val_obj;
        }

        return result;
    }


    public static bool TryConvertToTime(this float val,
        out string s_min, out string s_sec)
    {
        s_min = s_sec = "xx";

        if (val < 0f) return false;

        int allSec = Mathf.FloorToInt(val);
        int i_sec = allSec % 60;
        int i_min = (allSec - i_sec) / 60;

        s_sec = i_sec.ToString("D2");
        s_min = i_min.ToString();

        return true;
    }
}


// List<T>
[Serializable]
public class Serialization<T>
{
    [SerializeField]
    List<T> target;
    public List<T> ToList() { return target; }

    public Serialization(List<T> target)
    {
        this.target = target;
    }
}

// Dictionary<TKey, TValue>
[Serializable]
public class Serialization<TKey, TValue> : ISerializationCallbackReceiver
{
    [SerializeField]
    List<TKey> keys;
    [SerializeField]
    List<TValue> values;

    Dictionary<TKey, TValue> target;
    public Dictionary<TKey, TValue> ToDictionary() { return target; }

    public Serialization(Dictionary<TKey, TValue> target)
    {
        this.target = target;
    }

    public void OnBeforeSerialize()
    {
        keys = new List<TKey>(target.Keys);
        values = new List<TValue>(target.Values);
    }

    public void OnAfterDeserialize()
    {
        var count = Math.Min(keys.Count, values.Count);
        target = new Dictionary<TKey, TValue>(count);
        for (var i = 0; i < count; ++i)
        {
            target.Add(keys[i], values[i]);
        }
    }
}