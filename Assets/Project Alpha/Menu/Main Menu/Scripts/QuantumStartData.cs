using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class QuantumStartData : MonoBehaviour  
{ 
	public InputField enterPlayerName; 

	private float timePlayed = 0f; 
	private Scene playerCurrentScene; 

	public string playerName = ""; 

	public float TimePlayed 
	{ 
		get { return timePlayed; } 
		set { timePlayed = value; } 
	} 

	public Scene PlayerCurrentScene 
	{ 
		get  { return playerCurrentScene; } 
		set { playerCurrentScene = value; } 
	} 

	void Start ()  
	{   
		playerName = "Enter Name";                    //Set Input text 
	} 

	void Update ()  
	{   
		UnityEngine.PlayerPrefs.SetString ("Name", playerName);      //Save dedicated Name to PlayerPrefs 
		//timePlayed += Time.deltaTime;                  //Keeps track of time 
	} 

	void OnGUI() 
	{ 
		enterPlayerName.text = "";                    //Allows text to be entered into inputfield 
		playerName = enterPlayerName.ToString();            //Sets playerName to text entered in inputfield 
	} 
}