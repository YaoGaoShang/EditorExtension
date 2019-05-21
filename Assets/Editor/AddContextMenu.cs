// ========================================================
// 描述：Project  面板 添加右键菜单
// 作者：MeKey 
// 创建时间：2019-05-21 22:54:30
// 版 本：1.0
// ========================================================
using System.IO;
using UnityEditor;
using UnityEngine;

public class AddContextMenu : MonoBehaviour
{
    [MenuItem("Assets/创建文件夹", false, 5)]
    static void CreateDic()
    {
        CreateFile("Resources");
        CreateFile("StreamingAssets");
        CreateFile("MeKey");
        CreateFile("Prefabs");
    }

    [MenuItem("Assets/创建Prefabs文件夹",false,5)]
    static void CreatePrefabs()
    {
        CreateFile("Prefabs");
    }
    [MenuItem("Assets/创建Resouces文件夹",false,0)]
    static void CreateResources()
    {
        CreateFile("Resources");
    }
    [MenuItem("Assets/创建StreamingAssets文件夹")]
    static void CreateStreamingAssets()
    {
        CreateFile("StreamingAssets");
    }

    [MenuItem("Assets/创建Plugins文件夹")]
    static void CreatePlugins()
    {
        CreateFile("Plugins");
    }


    [MenuItem("Assets/创建MeKey文件夹")]
    static void CreateMeKey()
    {
        CreateFile("MeKey");
    }


    /// <summary>
    /// 创建文件夹
    /// </summary>
    /// <param name="fileName"></param>
    static void CreateFile(string fileName)
    {
        string path = Application.dataPath + "/";
        Directory.CreateDirectory(path + fileName);
        AssetDatabase.Refresh();
    }
}
