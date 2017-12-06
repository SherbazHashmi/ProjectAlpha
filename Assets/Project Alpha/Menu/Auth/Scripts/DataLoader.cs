/*Everything that needs to be loaded for project alpah to run can be called here, everything like sound settings, input settings, player profile etc
 * if changes are made to anything to accompany for a load of a function, please indicate where changes were made and also please put your name down at the location of change.*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataLoader : MonoBehaviour
{
    [SerializeField] private float fadeTime;                                    //Sets fade time of panel on auth scene
    [SerializeField] private float timeToLoad;                                  //Sets time to change scene
    [SerializeField] private Image fadePanel;                                   //Selected Fade Panel

    private float loadTimer = 0f;                                               //Timer to change scene according to timeToLoad Var

    private Color currentColor = Color.black;                                   //Sets panel Colour to black
	
	void Update ()
    {
        PanelFadeIn();
    }

   
    private void PanelFadeIn()                                                  //Fades in the Panel on the Auth Scene.
    {
        if (Time.timeSinceLevelLoad < fadeTime)                                 //Checks time since scene load to keep fade in given timeframe
        {
            float alphaChange = Time.deltaTime / fadeTime;                      //sets alphachange on timer
            currentColor.a -= alphaChange;                                      //changes alpha value from black to clear over given time 
            fadePanel.color = currentColor;                                     //sets the alpha colour to given colour each frame for display
        }   
        else
        {
            Destroy(fadePanel);                                                 //Destroy the panel after cleared up.
            loadTimer += Time.deltaTime;
        }

        if (!fadePanel && loadTimer >= timeToLoad)                              //Checks that panel is destroyed and that the time before switching scenes is correct. 
        {
            SceneManager.LoadScene("MainMenuScene");                            //Loads Main Menu Scene after fade is done.
        }
    }
}
