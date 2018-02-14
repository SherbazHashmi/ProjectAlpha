using System;
using UnityEngine;
using UnityEngine.UI;

namespace Project_Alpha.Menu.PauseScreen
{
    public class Buttons : MonoBehaviour
    {
       
        [SerializeField] GameObject _weaponSelectionPopUp;
        private GameObject _pauseSpalsh;
        private GameObject _talentPopup;
        private TalentButtons _btnPressed;

        enum TalentButtons
        {
            WeaponOne, WeaponTwo, WeaponThree, WeaponFour, WeaponFive
        }

        private void Awake()
        {
            try
            {
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
            _btnPressed = TalentButtons.WeaponOne;
        }
        
        public void OnClickWeaponTwo()
        {
            _btnPressed = TalentButtons.WeaponOne;
        }
        
        public void OnClickWeaponThree()
        {
            _btnPressed = TalentButtons.WeaponOne;
        }
        
        public void OnClickWeaponFour()
        {
            _btnPressed = TalentButtons.WeaponOne;
        }
        
        public void OnClickWeaponFive()
        {
            _btnPressed = TalentButtons.WeaponOne;
        }

        private void PopulateTalentWindow ()
        {
            
        }
        
        
        
 
 
 
        
    }
}