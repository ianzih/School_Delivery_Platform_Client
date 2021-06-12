using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Order_food_button_1 : MonoBehaviour
{
    public static int which_rest ;
    public Button b1;
    public Button b3;
    public Button b2;

    void Start()
    {
        which_rest = 0;
        Order_food_button_2.which_rest1 = 0;
        Order_food_button_3.which_rest2 = 0;
    }
    public void clickbutton1()
    {
        which_rest = 1; //學員簡餐
        SceneManager.LoadSceneAsync(9);
    }
    public void clickbutton2()
    {
        which_rest = 2; //水餃
        SceneManager.LoadSceneAsync(9);
    }
    public void clickbutton3()
    {
        which_rest = 3; //陽光
        SceneManager.LoadSceneAsync(9);
    }

}
