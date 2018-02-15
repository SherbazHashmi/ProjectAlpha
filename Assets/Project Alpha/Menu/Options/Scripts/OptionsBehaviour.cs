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
    [SerializeField] private GameObject keyboardConfigPanel;                                    //Sets keymapping Panel
	[SerializeField] private GameObject optionsPanel;

	/// <summary>
	/// Makes sure that the popups are closed at start
	/// </summary>
	void Start ()
    {
        audioPanel.SetActive(true);                                                             //Sets GameObject Active
        keyboardConfigPanel.SetActive(false);                                                   //Sets GameObject Inactive
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
		if (Input.GetKey (KeyCode.Escape)) {
			audioPanel.SetActive (false);
			keyboardConfigPanel.SetActive (false);
			optionsPanel.SetActive (false);
		}
	}

	/// <summary>
	/// Opens Options Popup
	/// </summary>
	public void OptionsPressed()
	{
		optionsPanel.SetActive (true);
		audioPanel.SetActive (true);
	}

	/// <summary>
	/// Opens Settings part of options and disables keybindings
	/// </summary>
    public void AudioPressed()
    {
        audioPanel.SetActive(true);                                                             //Sets GameObject Active
        keyboardConfigPanel.SetActive(false);                                                   //Sets GameObject Inactive
    }

	/// <summary>
	/// Opens keybindings part of options and disables Settings
	/// </summary>
    public void KeyMappingPressed()
    {
        audioPanel.SetActive(false);                                                            //Sets GameObject Inactive
        keyboardConfigPanel.SetActive(true);                                                    //Sets GameObject Active
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
