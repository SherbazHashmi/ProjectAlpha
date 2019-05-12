using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToturialTriggerOne : MonoBehaviour
{
    private Text tutorialText;
    private GameObject tutorialPopup;
    private Sprite[] tutorialImage;

    [SerializeField] private GameObject[] tutorialCollider;
    private string[] tutorialMessages;

    private void Awake()
    {
        tutorialPopup = GameObject.Find("tutorialTextPopup");

        tutorialMessages = new string[] 
        {
            "",
            "",
            "",
            "",
            ""
        };
    }

    private void Start()
    {
        tutorialPopup.SetActive(false);
    }

    public void ContinuePressed()
    {
        tutorialPopup.SetActive(false);
        Time.timeScale = 1;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            for (int i = 0; i < tutorialCollider.Length; i++)
            {
                if (tutorialCollider[0])
                {
                    Time.timeScale = 0;
                    tutorialPopup.SetActive(true);

                    tutorialText.text = tutorialMessages[0];
                }
                else if (tutorialCollider[1])
                {
                    Time.timeScale = 0;
                    tutorialPopup.SetActive(true);

                    tutorialText.text = tutorialMessages[1];
                }
                else if (tutorialCollider[2])
                {
                    Time.timeScale = 0;
                    tutorialPopup.SetActive(true);

                    tutorialText.text = tutorialMessages[2];
                }
                else if (tutorialCollider[3])
                {
                    Time.timeScale = 0;
                    tutorialPopup.SetActive(true);

                    tutorialText.text = tutorialMessages[3];
                }
                else if (tutorialCollider[4])
                {
                    Time.timeScale = 0;
                    tutorialPopup.SetActive(true);

                    tutorialText.text = tutorialMessages[4];
                }
            }

            tutorialPopup.SetActive(true);
        }
    }
}
