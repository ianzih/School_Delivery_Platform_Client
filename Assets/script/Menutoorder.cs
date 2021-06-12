using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menutoorder : MonoBehaviour
{
    public Button return_button;
    public Button loginout;
    public Button checkorder;
    public void buttonclick1()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void login_out()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void check_order()
    {
        SceneManager.LoadSceneAsync(12);
    }
}
