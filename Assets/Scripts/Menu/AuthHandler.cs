using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AuthHandler : MonoBehaviour
{
    [Header("Fade Panel Variables")]
    [SerializeField] private float fadeTime;                                    //Sets fade time of panel on auth scene
    [SerializeField] private float timeToLoad;                                  //Sets time to change scene
    [SerializeField] private Image fadePanel;                                   //Selected Fade Panel

    [Header("Alpha Logo Variables")]
    [SerializeField] private int pulseFrames;
    [SerializeField] private float pulseTimer;
    [SerializeField] private Image logoImage;

    [Header("Conitnue button")]
    [SerializeField] private GameObject continueButton;

    [Header("Logo Animator")]
    [SerializeField] private Animator logoAnim;

    [SerializeField] private float loadTimer = 0f;                                               //Timer to change scene according to timeToLoad Var

    private Color currentColor = Color.black;                                   //Sets panel Colour to black

    private void Start()
    {
        logoAnim.enabled = false;
        continueButton.SetActive(false);
    }

    void Update()
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

            logoAnim.enabled = true;
            logoAnim.Play("logoDropAnim");
        }

        if (!fadePanel && loadTimer >= 1.365023f)                              //Checks that panel is destroyed and that the time before switching scenes is correct. 
        {
            LogoPulsing();
            continueButton.SetActive(true);
        }
    }

    private void LogoPulsing()
    {
        pulseTimer += Time.deltaTime;

        if (pulseTimer >= 0f)
        {
            pulseFrames = Random.Range(1, 10);
            Debug.Log(pulseFrames);

            if (pulseFrames <= 5)
            {
                logoImage.color = Color.black;
            }
            else if (pulseFrames >= 6)
            {
                logoImage.color = Color.white;
            }
        } 
    }

    public void ClickedToContinue()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
