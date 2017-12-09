/*Dataloader.cs Script done by Kevern, everything will be marked and explained, if any changes are made, please state changes and place your name at the changed places.*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsBehaviour : MonoBehaviour
{
    [Header ("Panel and Slider Sets")]                                                          //Sets header in unity heirarchy
    [SerializeField] private GameObject audioPanel;                                             //Sets audioPanel
    //[SerializeField] private GameObject graphicsOptionsPanel;                                   //Sets Graphics Panel
    [SerializeField] private GameObject keyboardConfigPanel;                                    //Sets keymapping Panel

	void Start ()
    {
        audioPanel.SetActive(true);                                                             //Sets GameObject Active
        //graphicsOptionsPanel.SetActive(false);                                                  //Sets GameObject Inactive
        keyboardConfigPanel.SetActive(false);                                                   //Sets GameObject Inactive
    }

    public void AudioPressed()
    {
        audioPanel.SetActive(true);                                                             //Sets GameObject Active
        //graphicsOptionsPanel.SetActive(false);                                                  //Sets GameObject Inactive
        keyboardConfigPanel.SetActive(false);                                                   //Sets GameObject Inactive
    }

    /*public void DisplayButtonPressed()
    {
        audioPanel.SetActive(false);                                                            //Sets GameObject Inactive
        graphicsOptionsPanel.SetActive(true);                                                   //Sets GameObject Active
        keyboardConfigPanel.SetActive(false);                                                   //Sets GameObject Inactive
    }*/

    public void KeyMappingPressed()
    {
        audioPanel.SetActive(false);                                                            //Sets GameObject Inactive
        //graphicsOptionsPanel.SetActive(false);                                                //Sets GameObject Inactive
        keyboardConfigPanel.SetActive(true);                                                    //Sets GameObject Active
    }

    public void BackButtonPressed()
    {
        SceneManager.LoadScene("MainMenuScene");                                                //Load scene indicated with ""
    }
}
