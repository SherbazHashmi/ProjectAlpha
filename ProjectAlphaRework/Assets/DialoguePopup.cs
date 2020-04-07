using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialoguePopup : MonoBehaviour
{
    private Text nameText;
    private Text dialogueText;
    private CanvasGroup canvasGroup; // Use this to hide and show.
    public bool isVisible = false;


    // Start is called before the first frame update
    void Start()
    {
        nameText = transform.GetChild(0).transform.GetChild(1).GetComponent<Text>();
        dialogueText = transform.GetChild(0).transform.GetChild(2).GetComponent<Text>();
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void show()
    {
        canvasGroup.alpha = 1;
        isVisible = true;

    }

    public void hide()
    {
        canvasGroup.alpha = 0;
        isVisible = false;
    }

    public void displayText(string name, string dialogue, string imageSource)
    {
        if(imageSource != "")
        {
            // Set Image
        }

        nameText.text = name;
        dialogueText.text = dialogue;
    }
}
