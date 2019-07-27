using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToturialTriggerOne : MonoBehaviour
{
    private Text tutorialText;                                                  //Creates text object var
    private GameObject tutorialPopup;                                           //creates tutorial popup var    
    private Sprite[] tutorialImage;                                             //creates image var to swap tutorial images 

    [SerializeField] private GameObject[] tutorialCollider;                     //creates an array of Colliders
    private string[] tutorialMessages;                                          //creates an array of Tutorial messages

    private void Awake()
    {
        tutorialPopup = GameObject.Find("tutorialTextPopup");                   //Finds the Tutorial Pupup in the heirarchy
        tutorialText = GameObject.Find("tutorialText").GetComponent<Text>();    //Finds tutorials text Object

        tutorialMessages = new string[]                                         //sets the array of string array
        {
            "text 1",                                                           //Sets tutorial Message one
            "text 2",                                                           //Sets second tutorial Message
            "text 3",                                                           //Sets third tutorial Message
            "text 4",                                                           //Sets fourth tutorial Message
            "text 5",                                                           //Sets fifth tutorial message
            "Room nine Conversation part one"                                   //Sets Room Nine conversation
        };
    }

    private void Start()
    {
        tutorialPopup.SetActive(false);                                         //deactivated the tutorial popup
    }

    public void ContinuePressed()
    {
        tutorialPopup.SetActive(false);                                         //deactivates popup if continue is pressed
        Time.timeScale = 1;                                                     //Unfreeze game
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < tutorialCollider.Length; i++)                                   //Loops through the Tutorial collider array
            {
                if (tutorialCollider[0] && this.gameObject.tag == "TutorialOne")                //checks that tutorial element one is triggered
                {
                    Time.timeScale = 0;                                                         //freeze game time
                    tutorialPopup.SetActive(true);                                              //Activates tutorial popup

                    tutorialText.text = tutorialMessages[0];                                    //sets text to required message in text array
                    tutorialCollider[0].SetActive(false);                                       //disables tutorial collider so it doesnt trigger again
                }
                else if (tutorialCollider[1] && this.gameObject.tag == "TutorialTwo")           //checks that tutorial element two is triggered
                {
                    Time.timeScale = 0;                                                         //freeze game time
                    tutorialPopup.SetActive(true);                                              //Activates tutorial popup

                    tutorialText.text = tutorialMessages[1];                                    //sets text to required message in text array
                    tutorialCollider[1].SetActive(false);                                       //disables tutorial collider so it doesnt trigger again
                }
                else if (tutorialCollider[2] && this.gameObject.tag == "TutorialThree")         //checks that tutorial element three is triggered
                {
                    Time.timeScale = 0;                                                         //freeze game time
                    tutorialPopup.SetActive(true);                                              //Activates tutorial popup

                    tutorialText.text = tutorialMessages[2];                                    //sets text to required message in text array
                    tutorialCollider[2].SetActive(false);                                       //disables tutorial collider so it doesnt trigger again
                }
                else if (tutorialCollider[3] && this.gameObject.tag == "TutorialFour")          //checks that tutorial element four is triggered
                {
                    Time.timeScale = 0;                                                         //freeze game time
                    tutorialPopup.SetActive(true);                                              //Activates tutorial popup

                    tutorialText.text = tutorialMessages[3];                                    //sets text to required message in text array
                    tutorialCollider[3].SetActive(false);                                       //disables tutorial collider so it doesnt trigger again
                }
                else if (tutorialCollider[4] && this.gameObject.tag == "TutorialFive")          //checks that tutorial element five is triggered
                {
                    Time.timeScale = 0;                                                         //freeze game time
                    tutorialPopup.SetActive(true);                                              //Activates tutorial popup

                    tutorialText.text = tutorialMessages[4];                                    //sets text to required message in text array
                    tutorialCollider[4].SetActive(false);                                       //disables tutorial collider so it doesnt trigger again
                }
            }

            tutorialPopup.SetActive(true);                                                      //Activates Popup
        }
    }
}
