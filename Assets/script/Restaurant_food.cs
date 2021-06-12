using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restaurant_food : MonoBehaviour
{
    public Image food_img;
    public Sprite food_s;
    public Dropdown dropDownFood;
    public InputField input;
    public static Restaurant_food connect;

    //~~~蘭潭
    public static List<string> food_1_1 = new List<string> { "黃金大豬便當", "排骨便當", "照燒雞排便當" };
    public static List<string> food_1_2 = new List<string> { "水餃(小份)", "鍋貼(小份)" };
    public static List<string> food_1_3 = new List<string> { "雞肉飯", "超大雞排飯" };
    //
    //~~~新民
    public static List<string> food_2_1 = new List<string> { "經濟便當" };
    //
    //~~~民雄
    public static List<string> food_3_1 = new List<string> { "經濟便當" };
    public static List<string> food_3_2 = new List<string> { "牛排" };
    //
    //
    void Start()
    {
        dropDownFood.ClearOptions();
        if (order_where.str_where == "蘭潭校區")
        {
            if (Order_food_button_1.which_rest == 1)
            {
                dropDownFood.AddOptions(food_1_1);
                
            }
            else if (Order_food_button_1.which_rest == 2)
            {
                dropDownFood.AddOptions(food_1_2);
            }
            else if (Order_food_button_1.which_rest == 3)
            {
                dropDownFood.AddOptions(food_1_3);
            }
        }
        else if (order_where.str_where == "新民校區")
        {
            if (Order_food_button_2.which_rest1 == 1)
            {
                dropDownFood.AddOptions(food_2_1);
            }
        }
        else if (order_where.str_where == "民雄校區")
        {
            if (Order_food_button_3.which_rest2 == 1)
            {
                dropDownFood.AddOptions(food_3_1);
            }
            else if (Order_food_button_3.which_rest2 == 2)
            {
                dropDownFood.AddOptions(food_3_2);
            }
        }
        dropDownFood.value = -1;
        connect = this;
    }
    public void update_food_where()
    {
        if (order_where.str_where == "蘭潭校區")
        {
            if (Order_food_button_1.which_rest == 1)
            {
                food_img.sprite = food_s;
            }
            else if (Order_food_button_1.which_rest == 2)
            {
                food_img.sprite = food_s;
            }
            else if (Order_food_button_1.which_rest == 3)
            {
                food_img.sprite = food_s;
            }
        }
        else if (order_where.str_where == "新民校區")
        {
            if (Order_food_button_2.which_rest1 == 1)
            {
                food_img.sprite = food_s;
            }
        }
        else if (order_where.str_where == "民雄校區")
        {
            if (Order_food_button_3.which_rest2 == 1)
            {
                food_img.sprite = food_s;
            }
            else if (Order_food_button_3.which_rest2 == 2)
            {
                food_img.sprite = food_s;
            }
        }
        
    } 
}
