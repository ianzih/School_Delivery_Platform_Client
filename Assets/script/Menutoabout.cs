using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menutoabout : MonoBehaviour
{
    public Button return_button;

    public void buttonclick1()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
