using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Order_where_building : MonoBehaviour
{
    public Sprite m_Sprite1;
    public Sprite m_Sprite2;
    public Sprite m_Sprite3;
    public Sprite m_Sprite4;

    public Text where_text;
    public Image where_img;

    public Dropdown dropDownItem;


    string Str_where = order_where.str_where;
    public static Order_where_building connect;
    //增加option(蘭潭
    public static List<string> DropOptions1 = new List<string> { "行政中心", "理工大樓", "學生宿舍" };

    //增加option(新民
    public static List<string> DropOptions2 = new List<string> { "管理學院A", "管理學院B", "學生宿舍" };

    //增加option(民雄
    public static List<string> DropOptions3 = new List<string> { "行政大樓", "人文館", "圖書館" };

    //增加option(林森
    public static List<string> DropOptions4 = new List<string> { "輔導大樓", "圖書館" };
    void Start()
    {
        where_text.text = Str_where;
        {
            if (Str_where == "蘭潭校區")
            {
                where_img.sprite = m_Sprite1;
                dropDownItem.AddOptions(DropOptions1);
                dropDownItem.value = -1;
            }
            else if (Str_where == "新民校區")
            {
                where_img.sprite = m_Sprite2;
                dropDownItem.AddOptions(DropOptions2);
                dropDownItem.value = -1;
            }
            else if (Str_where == "民雄校區")
            {
                where_img.sprite = m_Sprite3;
                dropDownItem.AddOptions(DropOptions3);
                dropDownItem.value = -1;
            }
            else if (Str_where == "林森校區")
            {
                where_img.sprite = m_Sprite4;
                dropDownItem.AddOptions(DropOptions4);
                dropDownItem.value = -1;
            }
        }
        connect = this;
    }
    void Update()
    {
        
    }

}
