// ========================================================
// 描述：
// 作者：MeKey 
// 创建时间：2019-05-21 23:26:23
// 版 本：1.0
// ========================================================
using UnityEditor;
using UnityEngine;

public class AddContextMenuHierarchy : Editor
{
    [MenuItem("GameObject/DebugName")]
    static void DebugName()
    {
        Object[] selection = Selection.objects;
        foreach (Object item in selection)
        {
            GameObject temp = item as GameObject;
            Debug.Log("名字： "+temp.name+"\t"+"位置： "+temp.gameObject.transform.position);
        }
    }
}
