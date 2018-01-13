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

	void Start ()
    {
        audioPanel.SetActive(true);                                                             //Sets GameObject Active
        keyboardConfigPanel.SetActive(false);                                                   //Sets GameObject Inactive
    }

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape)) 
		{
			audioPanel.SetActive (false);
			keyboardConfigPanel.SetActive (false);
			optionsPanel.SetActive (false);
		}
	}

	public void OptionsPressed()
	{
		optionsPanel.SetActive (true);
		audioPanel.SetActive (true);
	}

    public void AudioPressed()
    {
        audioPanel.SetActive(true);                                                             //Sets GameObject Active
        keyboardConfigPanel.SetActive(false);                                                   //Sets GameObject Inactive
    }
		
    public void KeyMappingPressed()
    {
        audioPanel.SetActive(false);                                                            //Sets GameObject Inactive
        keyboardConfigPanel.SetActive(true);                                                    //Sets GameObject Active
    }

    public void BackButtonPressed()
    {
        SceneManager.LoadScene("MainMenuScene");                                                //Load scene indicated with ""
    }

	public void PauseMenuBackPressed()
	{
		optionsPanel.SetActive (false);
	}
}
