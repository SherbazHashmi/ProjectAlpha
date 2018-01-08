/*LoadHandler.cs Script done by Kevern, everything will be marked and explained, if any changes are made, please state changes and place your name at the changed places.*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHandler : MonoBehaviour
{
    public void BackButtonPressed()
    {
        SceneManager.LoadScene("MainMenuScene");
        //Load scene indicated with ""
    }
}
