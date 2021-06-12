using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Order_food_button_2 : MonoBehaviour
{
    public static int which_rest1 ;
    public Button b1;

    void Start()
    {
        which_rest1 = 0;
        Order_food_button_1.which_rest = 0;
        Order_food_button_3.which_rest2 = 0;
    }
    public void clickbutton1()
    {
        which_rest1 = 1; //滿客屋
        SceneManager.LoadSceneAsync(9);
    }

}
