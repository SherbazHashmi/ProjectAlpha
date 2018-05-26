/*DifficultyBackgroundChange.cs Script done by Kevern, everything will be marked and explained, if any changes are made, please state changes and place your name at the changed places.*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultyBackgroundChange : MonoBehaviour
{
    [SerializeField] private Sprite easyImage;                                                  //Select Easy Image
    [SerializeField] private Sprite normalImage;                                                //Select Normal Image
    [SerializeField] private Sprite hardImage;                                                  //Select Easy Image
    [SerializeField] private GameObject confirmPoppup;                                          //Apply Confirmation popup

    private SpriteRenderer imageChange;                                                         //Needed to change the sprite via script

	void Start ()
    {
        imageChange = GetComponentInChildren<SpriteRenderer>();                                 //Gets the sprite renderer component from the Child object
        confirmPoppup.SetActive(false);                                                         //disables confirm popup
	}

    public void EasyPressed()
    {
        imageChange.sprite = easyImage;                                                         //Changes the images to easyImage
        confirmPoppup.SetActive(true);                                                          //enables confirm popup
    }

    public void NormalPressed()
    {
        imageChange.sprite = normalImage;                                                       //Changes the images to normalImage
        confirmPoppup.SetActive(true);                                                          //enables confirm popup
    }

    public void HardPressed()
    {
        imageChange.sprite = hardImage;                                                         //Changes the images to hardImage
        confirmPoppup.SetActive(true);                                                          //enables confirm popup
    }

    public void ConfirmPressed()
    {
        SceneManager.LoadScene("L1 - R1");                                                    //Loads scene indicated with ""
    }

    public void CancelPressed()
    {
        confirmPoppup.SetActive(false);                                                         //disbales confirm popup
    }
}
