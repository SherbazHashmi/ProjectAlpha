using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseSaveLoadHandler : MonoBehaviour 
{
	[Header ("Save and Load Panels")]
	[SerializeField] private GameObject savePanel;
	[SerializeField] private GameObject loadPanel;

	/// <summary>
	/// Makes sure that the popups are closed at start
	/// </summary>
	void Start () 
	{	
		savePanel.SetActive (false);
		loadPanel.SetActive (false);
	}

	void Update () 
	{
		EscapedPressedCheck ();
	}

	/// <summary>
	/// Checks if Escape was pressed, then deactivates popups if pressed, otherwise popups will stay active when pause menu gets opened again.
	/// </summary>
	void EscapedPressedCheck ()
	{
		if (Input.GetKey (KeyCode.Escape))
        {
			savePanel.SetActive (false);
			loadPanel.SetActive (false);
		}
	}

	/// <summary>
	/// Opens Save Game Popup
	/// </summary>
	public void SaveButtonPressed()
	{
		savePanel.SetActive (true);
		loadPanel.SetActive (false);
	}

	/// <summary>
	/// Opens Load Game Popup
	/// </summary>
	public void LoadButtonPressed()
	{
		savePanel.SetActive (false);
		loadPanel.SetActive (true);
	}

	/// <summary>
	/// Close Save and Load Game Popup
	/// </summary>
	public void backButtonPressed()
	{
		savePanel.SetActive (false);
		loadPanel.SetActive (false);
	}
}
