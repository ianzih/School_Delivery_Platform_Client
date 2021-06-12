using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class order_where : MonoBehaviour
{
    public Button where_1;
    public Button where_2;
    public Button where_3;
    public Button where_4;

    public static string str_where = "";

    // Update is called once per frame
    void Update()
    {
  
    }
    public void buttonclick1()
    {
        str_where = "蘭潭校區";
        SceneManager.LoadSceneAsync(4);
    }
    public void buttonclick2()
    {
        str_where = "新民校區";
        SceneManager.LoadSceneAsync(4);
    }
    public void buttonclick3()
    {
        str_where = "民雄校區";
        SceneManager.LoadSceneAsync(4);
    }
    public void buttonclick4()
    {
        str_where = "林森校區";
        SceneManager.LoadSceneAsync(4);

    }
}
