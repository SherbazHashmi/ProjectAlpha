/*Dataloader.cs Script done by Kevern, everything will be marked and explained, if any changes are made, please state changes and place your name at the changed places.*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsBehaviour : MonoBehaviour
{
    [Header ("Panel and Slider Sets")]                                                          //Sets header in unity heirarchy
    [SerializeField] private GameObject settingsPanel;                                          //Sets audioPanel
    [SerializeField] private GameObject keyboardConfigPanel;                                    //Sets keymapping Panel
	[SerializeField] private GameObject optionsPanel;

    [Header("Panel and Slider Sets")]                                                          //Sets header in unity heirarchy
    [SerializeField] private GameObject keyboardControls;
    [SerializeField] private GameObject consoleControls;

    /// <summary>
    /// Makes sure that the popups are closed at start
    /// </summary>
    void Start ()
    {
        settingsPanel.SetActive(true);                                                          //Sets GameObject Active
        keyboardConfigPanel.SetActive(false);                                                   //Sets GameObject Inactive
        keyboardControls.SetActive(false);
    }

	void Update()
	{
		CheckEscapePressed ();
	}

	/// <summary>
	/// Checks if Escape was pressed, then deactivates popups if pressed, otherwise popups will stay active when pause menu gets opened again.
	/// </summary>
	void CheckEscapePressed ()
	{
		if (Input.GetKey (KeyCode.Escape))
        {
            settingsPanel.SetActive (false);
            keyboardControls.SetActive (false);
			optionsPanel.SetActive (false);
            keyboardControls.SetActive(false);
            consoleControls.SetActive(false);
        }
	}

	/// <summary>
	/// Opens Options Popup
	/// </summary>
	public void OptionsPressed()
	{
        optionsPanel.SetActive(true);
        settingsPanel.SetActive(true);
        keyboardControls.SetActive(false);
        keyboardControls.SetActive(false);
        consoleControls.SetActive(false);
    }

	/// <summary>
	/// Opens Settings part of options and disables keybindings
	/// </summary>
    public void SettingsPressed()
    {
        settingsPanel.SetActive(true);
        keyboardConfigPanel.SetActive(false);
        keyboardControls.SetActive(false);
        consoleControls.SetActive(false);
    }

    /// <summary>
    /// Opens controls panel
    /// </summary>
    public void ControllPressed()
    {
        settingsPanel.SetActive(false);
        keyboardConfigPanel.SetActive(true);
        keyboardControls.SetActive(true);
        consoleControls.SetActive(false);
    }

    /// <summary>
    /// Opens keyboard panel
    /// </summary>
    public void KeyboardConfigPressed()
    {
        keyboardControls.SetActive(true);
        consoleControls.SetActive(false);
    }

    /// <summary>
    /// Opens Console remote panel
    /// </summary>
    public void GamePadConfigPressed()
    {
        keyboardControls.SetActive(false);
        consoleControls.SetActive(true);
    }

    /// <summary>
    /// Returns to main menu Scene if in main menu options, does not affect pause menu
    /// </summary>
    public void BackButtonPressed()
    {
        SceneManager.LoadScene("MainMenuScene");                                                //Load scene indicated with ""
    }

	/// <summary>
	/// goes back to pause menu, if in game
	/// </summary>
	public void PauseMenuBackPressed()
	{
		optionsPanel.SetActive (false);
	}
}
