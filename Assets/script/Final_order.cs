using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class Final_order : MonoBehaviour
{
    public Text area;
    public Text building;
    public Text room;
    public Text shop;
    public Text food;
    public Text quantity;
    public Text total;
    public Button send;
    public Text msg;

    private int area_tmp;
    private int building_tmp;
    private int room_tmp;
    private int shop_tmp;
    private int food_tmp;
    private int quantity_tmp;

    public static Final_order connect;
    TcpClientHandler tcpClient;

    public string recv_json;
    public class Json_Data
    {
        public string action;
        public string token;
        public int area;
        public int build;
        public int room;
        public int shop;
        public int meal;
        public int quantity;
    }

    public class Json_recv
    {
        public string action;
        public string status;
        public string msg;
        public int id;
    }
    public Json_recv JsonRecv;

    public void Send_button()
    {
        Debug.Log(Login.connect.token);
        Json_Data json_data = new Json_Data
        {
            action = "send_ticket",
            token = Login.connect.token,
            area = area_tmp,
            build = building_tmp,
            room = room_tmp,
            shop = shop_tmp,
            meal = food_tmp,
            quantity = quantity_tmp
        };

        string jsonInfo = JsonUtility.ToJson(json_data, true);
        string len = jsonInfo.Length.ToString();
        while (len.Length < 4)
        {
            len = "0" + len;
        }
        jsonInfo = len + jsonInfo;

        File.WriteAllText("./tmp.json", jsonInfo);
        tcpClient.SocketSend(jsonInfo);

        string recv_str = tcpClient.Received();
        int recv_len = int.Parse(recv_str.Substring(0, 4).ToString()); //字串長度
        string recv_json = recv_str.Substring(4, recv_str.Length - 4).ToString();
        //len 不同就重送
        if (recv_len != recv_json.Length-1)
        {
            msg.text = "請重新按Send";
            tcpClient.InitSocket();
        }
        else
        {
            JsonRecv = JsonUtility.FromJson<Json_recv>(recv_json);
            if (JsonRecv.status == "ok")
            {
                File.WriteAllText("./send_ticket.json", recv_json);
                SceneManager.LoadSceneAsync(11);
            }
            else if (JsonRecv.status == "error")
            {
                msg.text = JsonRecv.msg.ToString()+",再送出一次";
                tcpClient.InitSocket();
            }
        }
    }

    void Start()
    {
        connect = this;

        //socket
        tcpClient = gameObject.AddComponent<TcpClientHandler>();
        tcpClient._port = 5701;
        tcpClient.InitSocket();

        //area
        area.text = order_where.str_where;

        //building&&room&&shop
        if (order_where.str_where == "蘭潭校區")
        {
            area_tmp = 1;

            //build
            building.text = Order_where_building.DropOptions1[Order_where_building.connect.dropDownItem.value].ToString();

            //room
            int room_val = Order_where_space.connect.dropDownItem1.value;
            if (building.text == "行政中心")
            {
                room.text = Order_where_space.DropOptions1_1[room_val].ToString();

                //json
                building_tmp = 1;

                if (room.text == "教務處") room_tmp = 1;
                else if (room.text == "學務處") room_tmp = 2;
                else if (room.text == "瑞穗廳") room_tmp = 3;
            }
            else if (building.text == "理工大樓")
            {
                room.text = Order_where_space.DropOptions1_2[room_val].ToString();

                //json
                building_tmp = 2;

                if (room.text == "資工系辦") room_tmp = 4;
                else if (room.text == "401教室") room_tmp = 5;
                else if (room.text == "理工學院辦公室") room_tmp = 6;
            }
            else if (building.text == "學生宿舍")
            {
                room.text = Order_where_space.DropOptions1_3[room_val].ToString();

                //json
                building_tmp = 3;

                if (room.text == "五舍") room_tmp = 7;
                else if (room.text == "一舍") room_tmp = 8;
                else if (room.text == "宿舍辦公室") room_tmp = 9;
            }

            //shop
            int shop_val = Order_food_button_1.which_rest;
            if (shop_val == 1) { shop.text = "學員簡速餐"; shop_tmp = 1; }
            else if (shop_val == 2) { shop.text = "卡好喫手工大水餃"; shop_tmp = 2; }
            else if (shop_val == 3) { shop.text = "陽光雞肉飯"; shop_tmp = 3; }
        }
        else if (order_where.str_where == "新民校區")
        {

            area_tmp = 2;

            //build
            building.text = Order_where_building.DropOptions2[Order_where_building.connect.dropDownItem.value].ToString();

            //room
            int room_val = Order_where_space.connect.dropDownItem1.value;
            if (building.text == "管理學院A")
            {
                room.text = Order_where_space.DropOptions2_1[room_val].ToString();

                //json
                building_tmp = 4;
                if (room.text == "1F") room_tmp = 10;
            }
            else if (building.text == "管理學院B")
            {
                room.text = Order_where_space.DropOptions2_2[room_val].ToString();

                //json
                building_tmp = 5;

                if (room.text == "1F") room_tmp = 11;
            }
            else if (building.text == "學生宿舍")
            {
                room.text = Order_where_space.DropOptions2_3[room_val].ToString();

                //json
                building_tmp = 6;

                if (room.text == "門口") room_tmp = 12;
                else if (room.text == "宿舍辦公室") room_tmp = 13;
            }

            //shop
            int shop_val = Order_food_button_2.which_rest1;
            if (shop_val == 1) { shop.text = "滿客屋餐廳"; shop_tmp = 4; }
        }
        else if (order_where.str_where == "民雄校區")
        {

            area_tmp = 3;

            //build
            building.text = Order_where_building.DropOptions3[Order_where_building.connect.dropDownItem.value].ToString();

            //room
            int room_val = Order_where_space.connect.dropDownItem1.value;
            if (building.text == "行政大樓")
            {
                room.text = Order_where_space.DropOptions3_1[room_val].ToString();

                //json
                building_tmp = 7;

                if (room.text == "1F") room_tmp = 14;
                else if (room.text == "2F") room_tmp = 15;
                else if (room.text == "門口") room_tmp = 16;
            }
            else if (building.text == "人文館")
            {
                room.text = Order_where_space.DropOptions3_2[room_val].ToString();

                //json
                building_tmp = 8;

                if (room.text == "1F") room_tmp = 17;
                else if (room.text == "門口") room_tmp = 18;
            }
            else if (building.text == "圖書館")
            {
                room.text = Order_where_space.DropOptions3_3[room_val].ToString();

                //json
                building_tmp = 9;

                if (room.text == "圖書辦公室") room_tmp = 20;
                else if (room.text == "門口") room_tmp = 19;
            }

            //shop
            int shop_val = Order_food_button_3.which_rest2;
            if (shop_val == 1) { shop.text = "學園餐廳"; shop_tmp = 5; }
            else if (shop_val == 2) { shop.text = "京品餐飲"; shop_tmp = 6; }
        }
        else if (order_where.str_where == "林森校區")
        {

            area_tmp = 4;

            building.text = Order_where_building.DropOptions4[Order_where_building.connect.dropDownItem.value].ToString();

            int room_val = Order_where_space.connect.dropDownItem1.value;
            if (building.text == "輔導大樓")
            {
                room.text = Order_where_space.DropOptions4_1[room_val].ToString();

                //json
                building_tmp = 10;

                if (room.text == "1F") room_tmp = 21;
                else if (room.text == "門口") room_tmp = 22;
            }
            else if (building.text == "圖書館")
            {
                room.text = Order_where_space.DropOptions4_2[room_val].ToString();

                //json
                building_tmp = 11;

                if (room.text == "圖書辦公室") room_tmp = 24;
                else if (room.text == "門口") room_tmp = 23;
            }
        }

        //food
        if (order_where.str_where == "蘭潭校區")
        {
            if (Order_food_button_1.which_rest == 1)
            {
                food.text = Restaurant_food.food_1_1[Restaurant_food.connect.dropDownFood.value].ToString();

                //json
                if (food.text == "黃金大豬便當") food_tmp = 1;
                else if (food.text == "排骨便當") food_tmp = 2;
                else if (food.text == "照燒雞排便當") food_tmp = 3;
            }
            else if (Order_food_button_1.which_rest == 2)
            {
                food.text = Restaurant_food.food_1_2[Restaurant_food.connect.dropDownFood.value].ToString();

                //json
                if (food.text == "水餃(小份)") food_tmp = 4;
                else if (food.text == "鍋貼(小份)") food_tmp = 5;
            }
            else if (Order_food_button_1.which_rest == 3)
            {
                food.text = Restaurant_food.food_1_3[Restaurant_food.connect.dropDownFood.value].ToString();

                //json
                if (food.text == "雞肉飯") food_tmp = 6;
                else if (food.text == "超大雞排飯") food_tmp = 7;
            }
        }
        else if (order_where.str_where == "新民校區")
        {
            if (Order_food_button_2.which_rest1 == 1)
            {
                food.text = Restaurant_food.food_2_1[Restaurant_food.connect.dropDownFood.value].ToString();

                //json
                if (food.text == "經濟便當") food_tmp = 8;
            }
        }
        else if (order_where.str_where == "民雄校區")
        {
            if (Order_food_button_3.which_rest2 == 1)
            {
                food.text = Restaurant_food.food_3_1[Restaurant_food.connect.dropDownFood.value].ToString();

                //json
                if (food.text == "經濟便當") food_tmp = 9;
            }
            else if (Order_food_button_3.which_rest2 == 2)
            {
                food.text = Restaurant_food.food_3_2[Restaurant_food.connect.dropDownFood.value].ToString();

                //json
                if (food.text == "牛排") food_tmp = 10;
            }
        }

        //quantity
        quantity.text = Restaurant_food.connect.input.text.ToString();
        quantity_tmp = int.Parse(quantity.text);

        //money
        int money = 65 * int.Parse(quantity.text) + 15;
        total.text = money.ToString();
    }

}
