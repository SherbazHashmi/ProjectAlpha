using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HuDHandler : MonoBehaviour
{
    [Header("Sliders Bars")]
    public Slider healthSlider;
    public Slider energySlider;

    [Header("Currencies")]
    public Text currentBoltsText;
    public Text currentChipsText;

    [Header("Weapon Data")]
    public Image equiptWeaponImage;
    public Text ammoCount;

    [Header("Buttons")]
    public Image playerPortrait;

    private void Start()
    {
        LoadPlayerIcon();
    }

    private void Update()
    {
        //QuantumHealth();
        //QuantumEnergy();
        DisplayCurrentBolts();
        DisplayCurrentChips();
        QuantumCurrentWeapon();
    }

    public void LoadPlayerIcon()
    {
        //Load player Image here
    }

    public void QuantumHealth(float health)
    {
        //link quantum hp here, slider will update according
    }

    public void QuantumEnergy(float energy)
    {
        //link quantum energy here, slider will update according
    }

    public void DisplayCurrentBolts()
    {
        //update bolt count here
        currentBoltsText.text = "Current Bolts";
    }

    public void DisplayCurrentChips()
    {
        //update Chip count here
        currentChipsText.text = "Current Bolts";
    }

    public void QuantumCurrentWeapon()
    {
        //set weapon image here

        //update Quantum ammo here
        ammoCount.text = "Quantum Ammo";
    }
}
