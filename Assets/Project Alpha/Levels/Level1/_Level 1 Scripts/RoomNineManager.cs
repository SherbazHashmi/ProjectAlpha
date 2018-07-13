using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomNineManager : MonoBehaviour
{
    public float cutSceneTimer;
    [SerializeField] private float fadeTime;                                    //Sets fade time of panel
    [SerializeField] private float speed;
    [SerializeField] private Image fadePanel;                                   //Selected Fade Panel
    [SerializeField] private GameObject popup;
    [SerializeField] private Text popupText;

    private bool doorsOpen = false;
    private bool setPopup = false;
    private Color currentColor = Color.black;                                   //Sets panel Colour to black

    void Update()
    {
        popup.SetActive(false);
        cutSceneTimer += Time.deltaTime;
        PanelFadeIn();
        //OpenDoors();
        //DisplayMessage();
    }


    private void PanelFadeIn()                                                  //Fades in the Panel on the Auth Scene.
    {
        if (cutSceneTimer >= 5f)
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
            }
        }
    }

    /*void OpenDoors()
    {
        if (cutSceneTimer >= 6f && cutSceneTimer <= 13f)
        {
            doorsOpen = true;

            if (doorsOpen)
            {
                leftDoor.SetActive(false);
                rightDoor.SetActive(false);
            }
        }
        else
        {
            doorsOpen = false;
            if (!doorsOpen)
            {
                leftDoor.SetActive(true);
                rightDoor.SetActive(true);
            }
        }
    }*/

    /*void DisplayMessage()
    {
        if (cutSceneTimer >= 2f && cutSceneTimer <= 5f)
        {
            setPopup = true;

            if (setPopup)
            {
                popup.SetActive(true);
                popupText.text = "Hi Quantum";
                Time.timeScale = 0;
            }
        }
    }

    public void ClosePopup()
    {
        popup.SetActive(false);
        setPopup = false;
        Time.timeScale = 1;
    }*/
}
