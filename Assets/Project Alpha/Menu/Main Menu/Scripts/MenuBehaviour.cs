/*Menu Script done by Kevern, everything will be marked and explained, if any changes are made, please state changes and place your name at the changed places.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject startGamePopup;                     //selected popup for start game display
    [SerializeField] private GameObject quitGamePopup;                      //selected popup for start game display

    void Start ()
    {
        startGamePopup.SetActive(false);                                    //Hides popup
        quitGamePopup.SetActive(false);
	}

    public void StartGamePressed()
    {
        startGamePopup.SetActive(true);                                     //activates popup
    }

    public void CancelPressed()
    {
        startGamePopup.SetActive(false);                                    //hides popup
        quitGamePopup.SetActive(false);                                    //hides popup
    }

    public void NewGamePressed()
    {
        startGamePopup.SetActive(false);                                    //hides popup, if player wants to return to menu, this makes sure the popup is not still displayed
        SceneManager.LoadScene("DifficultySelectScene");                    //loads scene indicated with ""
    }

    public void ConitnuePressed()
    {
        //need to pupulate save game list first.                            //this will load the last saved game
    }

    public void OptionsPressed()
    {
        SceneManager.LoadScene("Options");                                  //loads options scene
    }

    public void CreditsPressed()
    {
        SceneManager.LoadScene("Credits");                                  //loads credits scene
    }

    public void QuitButtonPressed()
    {
        quitGamePopup.SetActive(true);                                      //displayes quit popup
    }

    public void LoadPressed()
    {
        SceneManager.LoadScene("loadScene");                                //loads scene indicated with ""
    }

    public void ExitGame()
    {
        Application.Quit();                                                 //exits project alpha
        Debug.Log("Application quit");
    }
}
