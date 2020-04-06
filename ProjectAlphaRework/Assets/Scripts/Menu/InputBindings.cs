using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputBindings : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    private GameObject currentKey;

    public GameObject confirmationPopup;

    [Header("Movement")]
    public Text up;
    public Text down;
    public Text left;
    public Text right;
    public Text jump;

    [Header("Actions")]
    public Text fire;
    public Text meleeAttack;
    public Text meleeSkill;
    public Text ulimateAttack;
    public Text armourBoost;
    public Text quantumCancel;
    public Text switchWeapon;

    private void Start()
    {
        SetKeys();
        confirmationPopup.SetActive(false);
    }

    /// <summary>
    /// First part sets all key's to default if not changed, and sets to saved keys if changed on load.
    /// Second part sets the value of the text, to whichever key is bound by button
    /// </summary>
    private void SetKeys()
    {
        keys.Add("Up", (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
        keys.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "S")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));

        keys.Add("Fire", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Fire", "Z")));
        keys.Add("MeleeAttack", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MeleeAttack", "X")));
        keys.Add("MeleeSkill", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MeleeSkill", "C")));
        keys.Add("UltimateAttack", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("UltimateAttack", "V")));
        keys.Add("ArmourBoost", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ArmourBoost", "B")));
        keys.Add("QuantumCancel", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("QuantumCancel", "N")));
        keys.Add("SwitchWeapons", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("SwitchWeapons", "M")));

        up.text = keys["Up"].ToString();
        down.text = keys["Down"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();

        fire.text = keys["Fire"].ToString();
        meleeAttack.text = keys["MeleeAttack"].ToString();
        meleeSkill.text = keys["MeleeSkill"].ToString();
        ulimateAttack.text = keys["UltimateAttack"].ToString();
        armourBoost.text = keys["ArmourBoost"].ToString();
        quantumCancel.text = keys["QuantumCancel"].ToString();
        switchWeapon.text = keys["SwitchWeapons"].ToString();
    }

    private void Update()
    {
    }

    /// <summary>
    /// Checks if key is pressed, if a key is pressed, create and event and set current key to desired key.
    /// then sets the current key string to the value of key that was pressed
    /// </summary>
    private void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey = null;

                if (currentKey == null)
                {
                    confirmationPopup.SetActive(false);
                }
            }
        }
    }

    /// <summary>
    /// Allows button to be pressed to change a key value
    /// Each key needs to be assigned to itself on the button component in the Inspector Panel
    /// </summary>
    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
        confirmationPopup.SetActive(true);
    }

    /// <summary>
    /// loops through the key dictionary and save changes when save button is pressed
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