using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System;

public class TcpClientHandler : MonoBehaviour
{
    Socket socketSend;
    public int _port;
    public  void InitSocket()
    {
        try
        {

            IPHostEntry hostEntry = Dns.GetHostEntry("socket.delivery.csie.linwebs.tw");
            Debug.Log(hostEntry.AddressList[0].ToString());
            //建立客戶端Socket，獲得遠端ip和埠號
            socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = hostEntry.AddressList[0];
            IPEndPoint point = new IPEndPoint(ip, _port);

            socketSend.Connect(point);
            Debug.Log("連線成功!");
            //開啟新的執行緒，不停的接收伺服器發來的訊息
            //Thread c_thread = new Thread(Received);
            //c_thread.IsBackground = true;
            //c_thread.Start();
        }
        catch (Exception)
        {
            Debug.Log("IP或者埠號錯誤...");
        }

    }

    /// <summary>
    /// 接收服務端返回的訊息
    /// </summary>
    public string Received()
    {
        while (true)
        {
            try
            {
                byte[] buffer = new byte[1024 * 1024 * 3];
                //實際接收到的有效位元組數
                int len = socketSend.Receive(buffer);
                if (len == 0)
                {
                    break;
                }
                string str = Encoding.UTF8.GetString(buffer, 0, len);
                Debug.Log("客戶端列印：" + socketSend.RemoteEndPoint + ":" + str);
                return str;
            }
            catch { }
        }
        return null;
    }

    /// <summary>
    /// 向伺服器傳送訊息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public  void SocketSend(string str)
    {
        try
        {
            string msg = str;
            byte[] buffer = new byte[1024 * 1024 * 3];
            buffer = Encoding.UTF8.GetBytes(msg);
            socketSend.Send(buffer);
        }
        catch { }
    }

    public void SocketStop()
    {
        socketSend.Close();
    }
}