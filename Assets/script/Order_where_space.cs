using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order_where_space : MonoBehaviour
{
    public static Order_where_space connect;
    public Dropdown dropDownItem;
    public Dropdown dropDownItem1;
    string Str_where = order_where.str_where;

    //~~~蘭潭
    //行政中心
    public static List<string> DropOptions1_1 = new List<string> { "教務處", "學務處", "瑞穗廳" };
    //理工大樓
    public static List<string> DropOptions1_2 = new List<string> { "資工系辦", "401教室","理工學院辦公室" };
    //宿舍
    public static List<string> DropOptions1_3 = new List<string> { "五舍", "一舍", "宿舍辦公室" };
    //

    //~~~新民
    //管理學院A
    public static List<string> DropOptions2_1 = new List<string> { "1F" };
    //管理學院B
    public static List<string> DropOptions2_2 = new List<string> { "1F" };
    //宿舍
    public static List<string> DropOptions2_3 = new List<string> { "門口", "宿舍辦公室" };
    //

    //~~~民雄
    //行政
    public static List<string> DropOptions3_1 = new List<string> { "1F","2F","門口" };
    //人文館
    public static List<string> DropOptions3_2 = new List<string> { "1F", "門口" };
    //圖書館
    public static List<string> DropOptions3_3 = new List<string> { "門口", "圖書辦公室" };
    //

    //~~~林森
    //輔導大樓
    public static List<string> DropOptions4_1 = new List<string> { "1F", "門口" };
    //圖書館
    public static List<string> DropOptions4_2 = new List<string> { "門口", "圖書辦公室" };
    //

    void Start()
    {
        connect = this;
    }
    public void update_build_where()
    {
        dropDownItem1.ClearOptions();
        if (Str_where == "蘭潭校區")
        {
            if (dropDownItem.value == 0)//行政中心
            {
                dropDownItem1.AddOptions(DropOptions1_1);
            }
            else if (dropDownItem.value == 1)//理工大樓
            {
                dropDownItem1.AddOptions(DropOptions1_2);
            }
            else if (dropDownItem.value == 2)//宿舍
            {
                dropDownItem1.AddOptions(DropOptions1_3);
            }
        }
        else if (Str_where == "新民校區")
        {
            if (dropDownItem.value == 0)//管理學院A
            {
                dropDownItem1.AddOptions(DropOptions2_1);
            }
            else if (dropDownItem.value == 1)//管理學院B
            {
                dropDownItem1.AddOptions(DropOptions2_2);
            }
            else if (dropDownItem.value == 2)//宿舍
            {
                dropDownItem1.AddOptions(DropOptions3_3);
            }
        }
        else if (Str_where == "民雄校區")
        {
            if (dropDownItem.value == 0)//管理學院A
            {
                dropDownItem1.AddOptions(DropOptions3_1);
            }
            else if (dropDownItem.value == 1)//管理學院B
            {
                dropDownItem1.AddOptions(DropOptions3_2);
            }
            else if (dropDownItem.value == 2)//宿舍
            {
                dropDownItem1.AddOptions(DropOptions3_3);
            }
        }
        else if (Str_where == "林森校區")
        {
            if (dropDownItem.value == 0)//輔導
            {
                dropDownItem1.AddOptions(DropOptions4_1);
            }
            else if (dropDownItem.value == 1)//圖書
            {
                dropDownItem1.AddOptions(DropOptions4_2);
            }
        }
    }
}
