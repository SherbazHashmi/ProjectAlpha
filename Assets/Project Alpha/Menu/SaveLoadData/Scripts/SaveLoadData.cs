﻿using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI; 

public class SavePrefabHandler : MonoBehaviour  
{ 
	public Image levelImage; 
	public Text savegameName; 
	public Text currentPlayTime; 
	public Text playerScene; 
	public Text dateSaved; 

	private SaveHandler saveHandler; 
	private QuantumStartData quantumStartData; 

	void Start() 
	{ 
		saveHandler = GetComponent<SaveHandler> ();                    //calling the saveHandler to populate data 
		quantumStartData = GetComponent<QuantumStartData> ();              //calling quantumstartdata to populate data; 
	} 

	public void SavePrefab() 
	{ 
		levelImage = saveHandler.playerLevelImage;                    //setting the image to required level iamge 
		savegameName.text = quantumStartData.playerName;                //setting save game name to player name 
		currentPlayTime.text = quantumStartData.TimePlayed.ToString ();          //recording time played 

	} 
} 