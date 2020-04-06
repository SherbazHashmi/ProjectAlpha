using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class QuantumSpawn : MonoBehaviour
{
    public GameObject quantumSpawner;
    public GameObject quantumPrefab;

    /// <summary>
    /// Checks if public vars are set
    /// </summary>
    private void Awake()
    {
        Assert.IsNotNull(quantumSpawner);
        Assert.IsNotNull(quantumPrefab);
    }

    private void Start()
    {
        SpawnQuantum();
    }

    /// <summary>
    /// Spawn Quantum at Spawn Location
    /// </summary>
    void SpawnQuantum()
    {
        Scene currentScene = SceneManager.GetActiveScene();                     //creates a current scene and saves the current scene into var
        string sceneName = currentScene.name;                                   //saves the current scene to a string

        if (sceneName == "LevelOne")
        {
            GameObject newSpawn = Instantiate(quantumPrefab) as GameObject;     //creates a clone of the quantum GameObject and instantiates the objact as a GameObject
            newSpawn.transform.position = quantumSpawner.transform.position;    //Sets spawn point for quantum
        }
    }
}
