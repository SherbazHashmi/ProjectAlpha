using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    int hasTriggered = 0;
    private GameObject tutorialTextObject;
    [SerializeField] string tutorialText;
    // Start is called before the first frame update
    void Start()
    {
        tutorialTextObject = GameObject.FindGameObjectWithTag("TutorialPopup");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void action()
    {
        Debug.Log(tutorialTextObject);
        tutorialTextObject.SetActive(true);
        GameObject textObject = tutorialTextObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        Text text = textObject.GetComponent<Text>();
        text.text = tutorialText;
    }

    public void close()
    {
        tutorialTextObject.SetActive(false);
    }
}
