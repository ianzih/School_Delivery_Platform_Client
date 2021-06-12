using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class Login : MonoBehaviour
{
    public InputField account_in;
    public InputField password_in;
    public Button send_button;
    public Text msg_recv;

    public static Login connect;
    TcpClientHandler tcpClient;
    private string recv_str;


    public string token;

    //send 格式
    public class Json_send
    {
        public string action;
        public string account;
        public string password;
    }
    //recv 格式
    public class Json_recv
    {
        public string action;
        public string status;
        public string msg;
        public string token;
        public string type;
    }
    Json_recv JsonRecv;
    public void Send()
    {
        //account&password != null
        if (account_in.text != "" && password_in.text != "")
        {
            //send account & password
            Json_send json_data = new Json_send
            {
                action = "login",
                account = account_in.text.ToString(),
                password = password_in.text.ToString()
            };

            string jsonSend = JsonUtility.ToJson(json_data, true);
            string len = jsonSend.Length.ToString();
            while (len.Length < 4)
            {
                len = "0" + len;
            }
            jsonSend = len + jsonSend;
            File.WriteAllText("./login.json", jsonSend);
            tcpClient.SocketSend(jsonSend);

            //recv token
            recv_str = tcpClient.Received();
            Debug.Log(recv_str);

            int recv_len = int.Parse(recv_str.Substring(0, 4).ToString()); //字串長度
            Debug.Log(recv_str.Substring(0, 4).ToString()); 
            string recv_json = recv_str.Substring(4, recv_str.Length - 4).ToString();
            Debug.Log(recv_len);
            Debug.Log(recv_json.Length);
            Debug.Log(recv_json);

            //len 不同就重送
            if (recv_len != recv_json.Length-1)
            {
                msg_recv.text = "請重新再按登入";
                tcpClient.InitSocket();
            }
            else
            {
                JsonRecv = JsonUtility.FromJson<Json_recv>(recv_json);
                if (JsonRecv.status == "ok")
                {
                    token = JsonRecv.token;
                    File.WriteAllText("./ttt.json", recv_json);
                    SceneManager.LoadSceneAsync(1);
                }
                else if (JsonRecv.status == "error")
                {
                    msg_recv.text = JsonRecv.msg.ToString();
                    tcpClient.InitSocket();
                }
            }       
        }
    }
    void Start()
    {
        //socket
        tcpClient = gameObject.AddComponent<TcpClientHandler>();
        tcpClient._port = 5701;
        tcpClient.InitSocket();
        connect = this;
    }
}
