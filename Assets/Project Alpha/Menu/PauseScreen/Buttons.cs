using System;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.CorgiEngine
{
    public class Buttons : MonoBehaviour
    {
       
        [SerializeField] GameObject _weaponSelectionPopUp;
        private GameObject _pauseSpalsh;
        private GameObject _talentPopup;
        private Weapon.TypeOfWeapon _btnPressed;
        private GameManager _gameManager;

        void Initialisation()
        {
            // Initialises Game Manager 
            try
            {
                GameObject _gameManagerObject = GameObject.Find("GameManager");
                _gameManager = _gameManagerObject.GetComponent<GameManager>();
            }
            catch (Exception e)
            {
                Debug.Log(e);
                throw;
            }
            
            
            // Initialises Images (Gets References) and places them in an array.
        }
        
        
        private void Awake()
        {
            try
            {
                Initialisation();
                Debug.Log("Calling from Awake!");
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        public void onClickTalentBackButton()
        {
            _weaponSelectionPopUp.SetActive(false);
        }

        public void OnClickTalentsButton()
        {
            if (_weaponSelectionPopUp == null)
            {
                _weaponSelectionPopUp = GameObject.Find("weaponSelectionPopup");
            }
            _weaponSelectionPopUp.SetActive(true);
        }

        public void OnClickWeaponOne()
        {
            PopulateTalentWindow(Weapon.TypeOfWeapon.PelletGun);
        }
        
        public void OnClickWeaponTwo()
        {
            PopulateTalentWindow(Weapon.TypeOfWeapon.RocketLauncher);
        }
        
        public void OnClickWeaponThree()
        {
            PopulateTalentWindow(Weapon.TypeOfWeapon.SawDropper);
        }
        
        public void OnClickWeaponFour()
        {
            PopulateTalentWindow(Weapon.TypeOfWeapon.Shotgun);
        }
        
        public void OnClickWeaponFive()
        {
            PopulateTalentWindow(Weapon.TypeOfWeapon.Unarmed);
        }

        private void PopulateTalentWindow (Weapon.TypeOfWeapon weapon)
        {
            TalentCollection talents = _gameManager.Talents;
            Dictionary<Weapon, bool> weapons = talents.GetTalents(weapon, "Default");
            
            // Populate Weapons Into Different Images (Possibly By Adding The Images Into An Array)
        }
         
        
        
 
 
 
        
    }
}