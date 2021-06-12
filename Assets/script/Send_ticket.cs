using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class Send_ticket : MonoBehaviour
{
    public Button return_order_interface;
    public Button return_loginout;
    public Text order_msg;
    public Text order_id;

    public static Send_ticket connect;

    void Start()
    {
        connect = this;

        order_msg.text = Final_order.connect.JsonRecv.msg.ToString();
        order_id.text="此訂單為此帳號的第 "+ Final_order.connect.JsonRecv.id.ToString() + " 筆";
    }

    public void return_order()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void login_out()
    {
        TcpClientHandler tcpClient;
        tcpClient = gameObject.AddComponent<TcpClientHandler>();
        tcpClient.SocketStop();
        SceneManager.LoadSceneAsync(0);
    }
}
