using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopUpScript : MonoBehaviour
{
    [SerializeField] private GameObject popup;
    [SerializeField] private Text popupText;

    private void Awake()
    {
    }

    private void Start()
    {
        popup.SetActive(false);
        CheckSceneFortext();
    }

    public void CheckSceneFortext()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "L1 - R1")
        {
            popup.SetActive(true);
            popupText.text = "Hi Room1";
            Time.timeScale = 0;
        }
        else if (sceneName == "L1 - R2")
        {
            popup.SetActive(true);
            popupText.text = "Hi Room2";
            Time.timeScale = 0;
        }
        else if (sceneName == "L1 - R3")
        {
            popup.SetActive(true);
            popupText.text = "Hi Room3";
            Time.timeScale = 0;
        }
        else if (sceneName == "L1 - R7")
        {
            popup.SetActive(true);
            popupText.text = "Hi Room7";
            Time.timeScale = 0;
        }
        else if (sceneName == "L1 - R8")
        {
            popup.SetActive(true);
            popupText.text = "Hi Room8";
            Time.timeScale = 0;
        }
    }

    public void ClosePopup()
    {
        popup.SetActive(false);
        Time.timeScale = 1;
    }
}
