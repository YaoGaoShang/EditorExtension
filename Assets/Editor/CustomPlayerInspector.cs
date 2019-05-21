// ========================================================
// 描述：  自定义Inspector面板
// 作者：MeKey 
// 创建时间：2019-05-21 22:37:54
// 版 本：1.0
// ========================================================
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Player))]//这个可以自定义player对象的Inspector面板
public class CustomPlayerInspector : Editor
{
    Player player;
    bool isShow = false;//折叠标志位
    private void OnEnable()
    {
        player = (Player)target;

    }
    /// <summary>
    /// 重写面板
    /// </summary>
    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical();//设置为垂直布局
        EditorGUILayout.Space();//空行
        EditorGUILayout.Space();//空行
        EditorGUILayout.Space();//空行

        EditorGUILayout.LabelField(target.ToString() + "   : 脚本组件信息：");
        player.ID = EditorGUILayout.IntField("Player ID :", player.ID);


        EditorGUILayout.Space();//空行
        EditorGUILayout.Space();//空行


        player.name = EditorGUILayout.TextField("玩家名字：", player.name);


        EditorGUILayout.Space();//空行
        EditorGUILayout.Space();//空行

        player.hp = EditorGUILayout.IntField("玩家血量：", player.hp);


        EditorGUILayout.Space();//空行
        EditorGUILayout.Space();//空行

        player.damage = EditorGUILayout.Slider("玩家伤害", player.damage, 0, 30);
        //根据伤害值的大小设置显示的类型和提示语
        if (player.damage < 10)
        {
            EditorGUILayout.HelpBox("伤害太低了吧！！", MessageType.Error);
        }
        else if (player.damage > 15)
        {
            EditorGUILayout.HelpBox("伤害有点高啊！！", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.HelpBox("伤害适中！！", MessageType.Info);
        }

        EditorGUILayout.Space();//空行
        EditorGUILayout.Space();//空行


        EditorGUILayout.LabelField("脚本描述");//创建一个标题
        player.describe = EditorGUILayout.TextArea(player.describe, GUILayout.MinHeight(50));//创建文本区域




        EditorGUILayout.Space();//空行
        EditorGUILayout.Space();//空行

        //用滑动条设置 玩家的初始蓝量
        player.blue = EditorGUILayout.Slider("玩家蓝量", player.blue, 0, 100);

        if (player.blue < 20)
        {
            GUI.color = Color.red;
            EditorGUILayout.HelpBox("蓝量太低了！！", MessageType.Error);
        }
        else if (player.blue > 80)
        {
            GUI.color = Color.green;
            EditorGUILayout.HelpBox("蓝量很好！！", MessageType.Info);

        }
        else
        {
            GUI.color = Color.grey;
            EditorGUILayout.HelpBox("蓝量正常！！", MessageType.Warning);

        }

        Rect progressRect = GUILayoutUtility.GetRect(50, 25);
        EditorGUI.ProgressBar(progressRect, player.blue / 100f, "blue");
        GUI.color = Color.white;


        EditorGUILayout.Space();//空行
        EditorGUILayout.Space();//空行


        isShow = EditorGUILayout.Foldout(isShow, "weapon");//
        if (isShow)
        {
            player.weapon1 = EditorGUILayout.TextField("第一种武器", player.weapon1);
            player.weapon2 = EditorGUILayout.TextField("第er种武器", player.weapon2);
        }

        EditorGUILayout.Space();//空行
        EditorGUILayout.Space();//空行

        if (GUILayout.Button("删除此组件", GUILayout.Height(25)))
        {

            Debug.Log("删除组件 ");
            DestroyImmediate(this.player);
        }

        EditorGUILayout.Space();//空行
        EditorGUILayout.Space();//空行


        EditorGUILayout.LabelField("玩家个人信息");
        EditorGUILayout.BeginHorizontal();//绘制水平布局
        EditorGUILayout.LabelField("身高", GUILayout.MaxWidth(35));
        player.height = EditorGUILayout.FloatField(player.height);

        EditorGUILayout.LabelField("年龄", GUILayout.MaxWidth(35));
        player.age = EditorGUILayout.FloatField(player.age);

        EditorGUILayout.LabelField("体重", GUILayout.MaxWidth(35));
        player.weight = EditorGUILayout.FloatField(player.weight);
        EditorGUILayout.EndHorizontal();//结束水平绘制和BeginHorizontal()对应


        EditorGUILayout.EndVertical();//结束垂直绘制和BeginVertical()对应
    }

}

