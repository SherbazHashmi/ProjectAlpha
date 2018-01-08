﻿using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI; 


public class SaveHandler : MonoBehaviour  
{ 
	public Image playerLevelImage; 

	private float timeSaved = 0f; 
	private bool hasExit; 

	private QuantumStartData quantumStartData; 
	private SavePrefabHandler savePrefabhandler; 

	public bool HasExit 
	{ 
		get { return hasExit; } 
		set { hasExit = value; } 
	} 

	void Start () 
	{ 
		quantumStartData = GetComponent<QuantumStartData> ();                        //Calls StartData script 
		hasExit = false;                                          //set bool to false 
	} 

	/*in here i used QuantumStartData just to check if any errors pops up, but so far error free, as soon as we have a  
  more in depth script that will track quantum progress etc, we can swap out the names to the tracking script. But in 
  all, as soon as the exit button is pressed, this script should "THEORETICALLY" fire and save the data on exit, "Theoretically" 
  we should also be able to attach this scipt to waypoints and it should work just fine as soon as it is done.*/ 
	public void SaveGame() 
	{   
		MoreMountains.Tools.SaveLoadManager.Save (quantumStartData, quantumStartData.playerName, ".sav"); 
	} 
} 