using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadNav : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject saveLoadPrefab;

    public void BackButtonPressed()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
