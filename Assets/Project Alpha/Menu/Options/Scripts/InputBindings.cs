using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputBindings : MonoBehaviour
{
    public GameObject keyPressedPopup;

    [Header("Movement")]
	public Text up;
	public Text left;
	public Text right;
	public Text down;
	public Text jump;

    [Header("Actions")]
	public Text fire;
	public Text meleeAttack;
	public Text meleeSkill;
	public Text ulimateAttack;
	public Text armourBoost;
	public Text quantumCancel;
	public Text switchWeapon;

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    private GameObject currentKey;

    private void Start()
    {
        AddKeysToDictionary();
        keyPressedPopup.SetActive(false);
    }

    /// <summary>
    /// Adds all key bindings to the dictionary, saves it to player prefs and set a default value if not changed
    /// </summary>
    private void AddKeysToDictionary()
    {
        //Movement
        keys.Add("Up", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
        keys.Add("Down", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "S")));
        keys.Add("Left", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        keys.Add("Right", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        keys.Add("Jump", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));

        //Actions
        keys.Add("Fire", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Fire", "LeftControl")));
        keys.Add("Melee Attack",(KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Melee Attack", "LeftAlt")));
        keys.Add("Melee Skill", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Melee Skill", "Keypad1")));
        keys.Add("Ultimate Attack", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Ultimate Attack", "Keypad2")));
        keys.Add("Armour Boost", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Armour Boost", "Keypad3")));
        keys.Add("Quantum Cancel", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Quantum Cancel", "Keypad4")));
        keys.Add("Switch Weapons", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Switch Weapons", "L")));

        SetKeyText();
    }

    /// <summary>
    /// Sets key texts to required binding
    /// </summary>
    private void SetKeyText()
    {
        //Sets Keys Movement text
        up.text = keys["Up"].ToString();
        down.text = keys["Down"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        jump.text = keys["Jump"].ToString();

        //Sets Keys Actions text
        fire.text = keys["Fire"].ToString();
        meleeAttack.text = keys["Melee Attack"].ToString();
        meleeSkill.text = keys["Melee Skill"].ToString();
        ulimateAttack.text = keys["Ultimate Attack"].ToString();
        armourBoost.text = keys["Armour Boost"].ToString();
        quantumCancel.text = keys["Quantum Cancel"].ToString();
        switchWeapon.text = keys["Switch Weapons"].ToString();
    }

    /// <summary>
	/// Checks if key isnt null, then sets pressed key to the created event (e), if the event (e) is pressed, it deactivates the key press popup, then sets the current key (e) to the desired binding.
	/// currentKey = null just counters selecting multiple keys.
    /// </summary>
    private void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;

            if (e.isKey)
            {
                keyPressedPopup.SetActive(false);
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(1).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey = null;
            }
        }
    }
    
	/// <summary>
	/// activates popup and allows for the OnGUI method to run
	/// </summary>
    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
        keyPressedPopup.SetActive(true);
    }

    /// <summary>
    /// Save keys to Player prefs
    /// </summary>
    public void SaveKeys()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }
}