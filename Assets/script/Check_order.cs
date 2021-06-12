using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class Check_order : MonoBehaviour
{
    public Text area;
    public Text building;
    public Text room;
    public Text shop;
    public Text food;
    public Text quantity;
    public Text order_status;
    public Text msg;
    public Button return_interface;
    public Button send_check;
    public Dropdown count_dropdown;

    public List<string> DropOptions1;

    public static Check_order connect;
    TcpClientHandler tcpClient;
    UdpClientHandler ucpClient;
    //傳送&接收 訂單數量
    public class Json_send_order
    {
        public string action;
        public string token;
    }
    public class Json_recv_order
    {
        public string action;
        public string status;
        public string msg;
        public int count;
    }
    public Json_recv_order recv_order;


    //傳送&接收 單一訂單
    public class Json_send_one_order
    {
        public string action;
        public string token;
        public int id;
    }
    public class Json_recv_one_order
    {
        public string action;
        public string status;
        public string msg;
        public int id;
        public int area;
        public int build;
        public int room;
        public int shop;
        public int meal;
        public int quantity;
        public int order_status;
    }
    public Json_recv_one_order recv_one_order;

    //先接收有幾筆訂單數量
    void Start()
    {
        connect = this;
        ucpClient = gameObject.AddComponent<UdpClientHandler>();
        ucpClient._port = 5701;
        ucpClient.InitSocket();

        Json_send_order send_order_count = new Json_send_order
        {
            action = "count_ticket",
            token = Login.connect.token,
        };
        string jsonInfo = JsonUtility.ToJson(send_order_count, true);
        string len = jsonInfo.Length.ToString();
        while (len.Length < 4)
        {
            len = "0" + len;
        }
        jsonInfo = len + jsonInfo;
        File.WriteAllText("./send_order_count.json", jsonInfo);
        ucpClient.SocketSend(jsonInfo);

        string recv_str = ucpClient.Received();
        int recv_len = int.Parse(recv_str.Substring(0, 4).ToString()); //字串長度
        string recv_json = recv_str.Substring(4, recv_str.Length - 4).ToString();
        //len 不同就重送
        if (recv_len != recv_json.Length - 1)
        {
            msg.text = "請返回介面，重新進入訂單查詢";
        }
        else
        {
            recv_order = JsonUtility.FromJson<Json_recv_order>(recv_json);
            if (recv_order.status == "error")
            {
                msg.text = recv_order.msg.ToString();
            }
            else if (recv_order.status == "ok")
            {
                if (recv_order.count >= 1)
                {
                    for (int i = 1; i <= recv_order.count; i++)
                    {
                        DropOptions1.Add(i.ToString());
                    }
                    count_dropdown.AddOptions(DropOptions1);
                }
                else
                {
                    msg.text = "此用戶查無訂單";
                }
            }
        }
    }
    public void send_order_num()
    {
        tcpClient._port = 5701;
        tcpClient.InitSocket();

        Json_send_one_order send_one_order = new Json_send_one_order
        {
            action = "ticket_status",
            token = Login.connect.token,
            id = int.Parse(DropOptions1[count_dropdown.value])
        };
        //send 資訊
        string jsonInfo = JsonUtility.ToJson(send_one_order, true);
        string len = jsonInfo.Length.ToString();
        while (len.Length < 4)
        {
            len = "0" + len;
        }
        jsonInfo = len + jsonInfo;
        File.WriteAllText("./send_one_order.json", jsonInfo);
        tcpClient.SocketSend(jsonInfo);

        //分割長度與JSON 再確認長度
        string recv_str = tcpClient.Received();
        int recv_len = int.Parse(recv_str.Substring(0, 4).ToString()); //字串長度
        string recv_json = recv_str.Substring(4, recv_str.Length - 4).ToString();
        if (recv_len != recv_json.Length - 1)
        {
            msg.text = "請重新按送出查詢";
        }
        else //確認status為ERROR | OK 
        {
            recv_one_order = JsonUtility.FromJson<Json_recv_one_order>(recv_json);
            if (recv_one_order.status == "error")
            {
                msg.text = recv_one_order.msg.ToString();
            }
            else if (recv_one_order.status == "ok") //印出JSON資訊
            {
                //area
                switch (recv_one_order.area)
                {
                    case 1:
                        area.text = "蘭潭校區";
                        break;
                    case 2:
                        area.text = "新民校區";
                        break;
                    case 3:
                        area.text = "民雄校區";
                        break;
                    case 4:
                        area.text = "林森校區";
                        break;
                }

                //build
                switch (recv_one_order.area)
                {
                    case 1:
                        building.text = "行政中心";
                        break;
                    case 2:
                        building.text = "理工大樓";
                        break;
                    case 3:
                        building.text = "學生宿舍";
                        break;
                    case 4:
                        building.text = "管理學院A";
                        break;
                    case 5:
                        building.text = "管理學院B";
                        break;
                    case 6:
                        building.text = "學生宿舍";
                        break;
                    case 7:
                        building.text = "行政大樓";
                        break;
                    case 8:
                        building.text = "人文館";
                        break;
                    case 9:
                        building.text = "圖書館";
                        break;
                    case 10:
                        building.text = "輔導大樓";
                        break;
                    case 11:
                        building.text = "圖書館";
                        break;
                }

                //room
                switch (recv_one_order.room)
                {
                    case 1:
                        room.text = "教務處";
                        break;
                    case 2:
                        room.text = "學務處";
                        break;
                    case 3:
                        room.text = "瑞穗廳";
                        break;
                    case 4:
                        room.text = "資工系辦";
                        break;
                    case 5:
                        room.text = "401教室";
                        break;
                    case 6:
                        room.text = "理工學院辦公室";
                        break;
                    case 7:
                        room.text = "五舍";
                        break;
                    case 8:
                        room.text = "一舍";
                        break;
                    case 9:
                        room.text = "宿舍辦公室";
                        break;
                    case 10:
                        room.text = "1F";
                        break;
                    case 11:
                        room.text = "1F";
                        break;
                    case 12:
                        room.text = "門口";
                        break;
                    case 13:
                        room.text = "宿舍辦公室";
                        break;
                    case 14:
                        room.text = "1F";
                        break;
                    case 15:
                        room.text = "2F";
                        break;
                    case 16:
                        room.text = "門口";
                        break;
                    case 17:
                        room.text = "1F";
                        break;
                    case 18:
                        room.text = "門口";
                        break;
                    case 19:
                        room.text = "門口";
                        break;
                    case 20:
                        room.text = "圖書辦公室";
                        break;
                    case 21:
                        room.text = "1F";
                        break;
                    case 22:
                        room.text = "門口";
                        break;
                    case 23:
                        room.text = "門口";
                        break;
                    case 24:
                        room.text = "圖書辦公室";
                        break;
                }

                //shop
                switch (recv_one_order.shop)
                {
                    case 1:
                        shop.text = "學員簡速餐";
                        break;
                    case 2:
                        shop.text = "卡好喫手工大水餃";
                        break;
                    case 3:
                        shop.text = "陽光雞肉飯";
                        break;
                    case 4:
                        shop.text = "滿客屋餐廳";
                        break;
                    case 5:
                        shop.text = "學園餐廳";
                        break;
                    case 6:
                        area.text = "京品餐飲";
                        break;
                }

                //meal
                switch (recv_one_order.meal)
                {
                    case 1:
                        food.text = "黃金大豬便當";
                        break;
                    case 2:
                        food.text = "排骨便當";
                        break;
                    case 3:
                        food.text = "照燒雞排便當";
                        break;
                    case 4:
                        food.text = "水餃(小份)";
                        break;
                    case 5:
                        food.text = "鍋貼(小份)";
                        break;
                    case 6:
                        food.text = "雞肉飯";
                        break;
                    case 7:
                        food.text = "超大雞排飯";
                        break;
                    case 8:
                        food.text = "經濟便當";
                        break;
                    case 9:
                        food.text = "經濟便當";
                        break;
                    case 10:
                        food.text = "牛排";
                        break;
                }

                //quantity
                quantity.text = recv_one_order.quantity.ToString();

                //order_status
                switch (recv_one_order.order_status)
                {
                    case 1:
                        order_status.text = "新訂單";
                        break;
                    case 2:
                        order_status.text = "餐點準備中";
                        break;
                    case 3:
                        order_status.text = "等待送餐中";
                        break;
                    case 4:
                        order_status.text = "餐點外送中";
                        break;
                    case 5:
                        order_status.text = "餐點已送達";
                        break;
                    case 6:
                        order_status.text = "訂單已完成";
                        break;
                    case 7:
                        order_status.text = "訂單已取消";
                        break;
                    case 0:
                        order_status.text = "訂單未成立";
                        break;
                }
            }
        }
    }
    public void tointerface()
    {
        DropOptions1.Clear();
        SceneManager.LoadSceneAsync(1);
    }
}
