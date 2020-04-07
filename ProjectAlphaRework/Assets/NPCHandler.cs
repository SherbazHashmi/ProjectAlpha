using UnityEngine;

public class NPCHandler : MonoBehaviour
{
    public NonPlayableCharacter[] nonPlayableCharacters;
    // Start is called before the first frame update
    void Start()
    {
        nonPlayableCharacters = FindObjectsOfType<NonPlayableCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(NonPlayableCharacter npc in nonPlayableCharacters)
        {
        }
    }

}
