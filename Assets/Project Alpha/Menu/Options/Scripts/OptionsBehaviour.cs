using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsBehaviour : MonoBehaviour
{
    [Header ("Panel and Slider Sets")]
    [SerializeField] private GameObject audioPanel;
    //[SerializeField] private GameObject graphicsOptionsPanel;
    [SerializeField] private GameObject keyboardConfigPanel;

	void Start ()
    {
        audioPanel.SetActive(true);
        //graphicsOptionsPanel.SetActive(false);
        keyboardConfigPanel.SetActive(false);
    }

    public void AudioPressed()
    {
        audioPanel.SetActive(true);
        //graphicsOptionsPanel.SetActive(false);
        keyboardConfigPanel.SetActive(false);
    }

    public void DisplayButtonPressed()
    {
        audioPanel.SetActive(false);
        //graphicsOptionsPanel.SetActive(true);
        keyboardConfigPanel.SetActive(false);
    }

    public void KeyMappingPressed()
    {
        audioPanel.SetActive(false);
        //graphicsOptionsPanel.SetActive(false);
        keyboardConfigPanel.SetActive(true);
    }

    public void BackButtonPressed()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
