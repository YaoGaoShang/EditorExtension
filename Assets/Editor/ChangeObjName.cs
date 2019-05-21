// ========================================================
// 描述：  添加菜单项，并添加修改选中的obj的名字
// 作者：MeKey 
// 创建时间：2019-05-21 22:06:37
// 版 本：1.0
using UnityEditor;
using UnityEngine;
public class ChangeObjName : EditorWindow
{
    private static ChangeObjName instance;

    [MenuItem("Tool/ChangeObjName")]
    static void  ChangeNameFun()
    {
        instance = (ChangeObjName)EditorWindow.GetWindow<ChangeObjName>();
        instance.Show();
    }

    static string newName;
    private void OnGUI()
    {
        newName = EditorGUILayout.TextField("修改物体的名字",newName);

        if (GUILayout.Button("修改名字", GUILayout.Height(25)))
        {
            ChangeName(newName);
        }
    }

     static  void ChangeName(string newName)
    {
        Object[] selection = (Object[]) Selection.objects;//选中的物体
        foreach (Object item in selection)
        {
            GameObject temp = item as GameObject;
            temp.name = newName;
        }
        AssetDatabase.Refresh();//刷新面板
    }
    /// <summary>
    /// 当界面改变时重绘
    /// </summary>
    public void OnInspectorUpdate()
    {
        Repaint();
    }
}
