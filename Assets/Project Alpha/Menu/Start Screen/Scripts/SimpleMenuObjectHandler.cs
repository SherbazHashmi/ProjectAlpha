using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// This Menu Object Handler is Intended For Use While Movement Key One Isn't Working
// Implemented PC.
// TODO : Implement Mobile Touch Controls for Menu

public class SimpleMenuObjectHandler : MonoBehaviour {

    [SerializeField] Button NewGame;
	[SerializeField] Button LoadGame;
	[SerializeField] Button Options;
	[SerializeField] Button Credits;
	

	// Use this for initialization
	void Start () {
        NewGame.onClick.AddListener(SegueToDemoLevel);
		LoadGame.onClick.AddListener(SegueToDemoLevel);


	}
	
	// Update is called once per frame
	void Update () {

	}

    void SegueToDemoLevel () {

        UnityEngine.SceneManagement.SceneManager.LoadScene("PixelLevel");
        
    }

     
}
