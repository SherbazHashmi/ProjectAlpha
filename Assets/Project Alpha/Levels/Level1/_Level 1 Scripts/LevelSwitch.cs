using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    private GameObject topDoor;
    private GameObject botDoor;

    // Init Doors : Sets references to public game objects above. 
    // Returns : Boolean if successful or not
    private bool initDoors()
    {
        try
        {
            topDoor = GameObject.Find("TopDoor");
            botDoor = GameObject.Find("BotDoor");
        }
        catch (System.Exception excep)
        {

            Debug.Log("Error : " + excep.Message);
            return false;
        }
        return true;
    }   

    private void Start()
    {
        bool succ = initDoors();
        Debug.Log("Success : " + succ);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Debug.Log("Other : "+ other);
        if (other.tag == "Player" )
        {
            if (sceneName == "L1 - R5")
            {
                if (this == topDoor && other.tag == "Player")
                {
                    Debug.Log("Teleporting to Level 1 R6");
                    SceneManager.LoadScene("L1 - R6");
                }
                else if (this == botDoor && other.tag == "Player")
                {
                    Debug.Log("Teleporting to Level 1 R7");
                    SceneManager.LoadScene("L1 - R7");
                }
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
