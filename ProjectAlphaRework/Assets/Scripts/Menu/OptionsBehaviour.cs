/*Dataloader.cs Script done by Kevern, everything will be marked and explained, if any changes are made, please state changes and place your name at the changed places.*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsBehaviour : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Text headerText;

    [Header("Panel Navigation")]
    [SerializeField] private GameObject displayPanel;
    [SerializeField] private GameObject audioPanel;
    [SerializeField] private GameObject keyboardPanel;


    /// <summary>
    /// Sets Required panels to false at Load
    /// </summary>
    private void Start()
    {
        displayPanel.SetActive(true);
        audioPanel.SetActive(false);
        keyboardPanel.SetActive(false);
    }

    private void Update()
    {
        CheckEscapePressed();
    }


    /// <summary>
    /// Sets all Panels but required to false
    /// updates Header Text
    /// </summary>
    public void DisplaySettings()
    {
        displayPanel.SetActive(true);
        headerText.text = "Display";
        audioPanel.SetActive(false);
        keyboardPanel.SetActive(false);
    }

    /// <summary>
    /// Sets all Panels but required to false
    /// updates Header Text
    /// </summary>
    public void AudioSettings()
    {
        audioPanel.SetActive(true);
        headerText.text = "Audio";
        displayPanel.SetActive(false);
        keyboardPanel.SetActive(false);
    }

    /// <summary>
    /// Sets all Panels but required to false
    /// updates Header Text
    /// </summary>
    public void KeyboardSettings()
    {
        keyboardPanel.SetActive(true);
        headerText.text = "Keyboard Bindings";
        displayPanel.SetActive(false);
        audioPanel.SetActive(false);
    }

    /// <summary>
    /// Check if escape is pressed for pause menu
    /// </summary>
    private void CheckEscapePressed()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            //will update to make sure it only works on pause menu
            displayPanel.SetActive(false);
            audioPanel.SetActive(false);
            keyboardPanel.SetActive(false);
        }
    }

    /// <summary>
    /// goes back to indicated Scene
    /// </summary>
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
