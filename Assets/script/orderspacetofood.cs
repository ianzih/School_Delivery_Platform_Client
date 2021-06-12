using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class orderspacetofood : MonoBehaviour
{
    public Button return_button;
    string Str_where = order_where.str_where;

    public void buttonclick1()
    {
        if(Str_where== "蘭潭校區")
            SceneManager.LoadSceneAsync(5);
        else if (Str_where == "新民校區")
            SceneManager.LoadSceneAsync(6);
        else if (Str_where == "民雄校區")
            SceneManager.LoadSceneAsync(7);
        else if (Str_where == "林森校區")
            SceneManager.LoadSceneAsync(8);
    }

    public void buttonclick2()
    {
        SceneManager.LoadSceneAsync(3);      
    }
    public void buttonclick3()
    {
        SceneManager.LoadSceneAsync(10);
    }
}
