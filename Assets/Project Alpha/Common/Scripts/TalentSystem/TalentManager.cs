using System;
using System.Collections.Generic;
using MoreMountains.CorgiEngine.Pellet_Gun;
using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.CorgiEngine
{
    public class TalentManager : MonoBehaviour

    {
        private GameManager _gameManager;
        private TalentCollection _talentCollection;
        [SerializeField] private GameObject _textObject;
        private Text _text;
        
        /// <summary>
        /// Initialises the Game Manager and Talent Collection
        /// </summary>
        
        private void Initialise()
        {
            try
            {
                GameObject gameManagerObject = GameObject.Find("GameManager");
                _gameManager = gameManagerObject.GetComponent<GameManager>();
                _text = _textObject.GetComponent<Text>();
            }
            catch (Exception e)
            {
                Debug.Log(e);
                throw;
            }
            if (_gameManager.SaveData == null)
            {
                _talentCollection = _gameManager.Talents;
                _talentCollection.WeaponsObject = gameObject;
                initTalents();
            }
            else
            {
                //_talentCollection = _gameManager.SaveData.TalentCollection;
            }
        }

        /// <summary>
        /// Saves Talents To SaveData Object in Game Manger 
        /// </summary>
        public void SaveTalents()
        {
            _gameManager.SaveData.TalentCollection =  _talentCollection;
        }
        
        /// <summary>
        /// Initialises Talents
        /// Should Be Done Within Loading Scene
        /// </summary>
        /// 
        public void initTalents () {
            
            // Adding Types To Talents
            
            Dictionary<Weapon.TypeOfWeapon, Dictionary<string, Dictionary<Weapon, bool>>> Talents = new Dictionary<Weapon.TypeOfWeapon, Dictionary<string, Dictionary<Weapon, bool>>>();
            
            // Instantiating Type of Weapon 
            
            Dictionary<String, Dictionary<Weapon, bool>> pelletGuns = new Dictionary<string, Dictionary<Weapon, bool>>();
            
            // Instantiating Weapon Branch
            
            Dictionary<Weapon, bool> pelletGunDefault = new Dictionary<Weapon, bool>();
                 
            
            // Getting References to Weapons

            PelletGunDefaultWeak pelletGunDefaultWeak;
            PelletGunDefaultStrong pelletGunDefaultStrong;
            PelletGunDefaultUltimate pelletGunDefaultUltimate;
            
            try
            {
                pelletGunDefaultWeak = GetComponentInParent<PelletGunDefaultWeak>();
                pelletGunDefaultStrong = GetComponentInParent<PelletGunDefaultStrong>();
                pelletGunDefaultUltimate = GetComponentInParent<PelletGunDefaultUltimate>();
               // Debug.Log("Pellet Gun Weak Has " + pelletGunDefaultWeak);
                Debug.Log("Pellet Gun Strong Has " + pelletGunDefaultStrong);
                Debug.Log("Pellet Gun Ultimate Has " + pelletGunDefaultUltimate);


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            // Adding Weapon Scripts to Branch to Later Be Activated or Deactivated. 

            // Debug.Log("Pellet Gun Default Has " + pelletGunDefault.Count + " elements.");
           
            

            pelletGunDefault.Add(pelletGunDefaultWeak, false);
            pelletGunDefault.Add(pelletGunDefaultStrong, false);
            pelletGunDefault.Add(pelletGunDefaultUltimate, false);

           // Debug.Log("Pellet Gun Default Has " + pelletGunDefaultWeak.Equals(null));

            foreach (var GunPair in pelletGunDefault)
            {
                Debug.Log(GunPair.Key.WeaponType+ " "+ GunPair.Key.AttackType + " " + GunPair.Value);
            }
            // Adding Branch To Weapon Type 
            
            pelletGuns.Add("Default", pelletGunDefault);
            
            
            // Adding Weapon Type To Talents 
            
            Talents.Add(Weapon.TypeOfWeapon.PelletGun, pelletGuns);
            
            
            // Rocket Launcher
            
            Dictionary<String, Dictionary<Weapon, bool>> rocketLaunchers = new Dictionary<string, Dictionary<Weapon, bool>>();
            Dictionary<Weapon, bool> rocketLauncherDefault = new Dictionary<Weapon, bool>();
            
            // TODO : Add Rocket Launcher Abilities When Created
            
            
            Talents.Add(Weapon.TypeOfWeapon.RocketLauncher, rocketLaunchers);
            
            // Saw Dropper
            
            Dictionary<String, Dictionary<Weapon, bool>> sawDroppers = new Dictionary<string, Dictionary<Weapon, bool>>();
            Dictionary<Weapon, bool> SawDroppperDefault = new Dictionary<Weapon, bool>();
            
            // TODO : Add Saw Dropper Abilities When Created
            
            Talents.Add(Weapon.TypeOfWeapon.SawDropper, sawDroppers);

            // Shotgun
            Dictionary<String, Dictionary<Weapon, bool>> shotGuns = new Dictionary<string, Dictionary<Weapon, bool>>();
            Dictionary<Weapon, bool> shotGunDefault = new Dictionary<Weapon, bool>();
            
            // TODO : Add Shot Gun Abilities When Created
            
            Talents.Add(Weapon.TypeOfWeapon.Shotgun, shotGuns);
            
            
            // Unarmed
            
            Dictionary<String, Dictionary<Weapon, bool>> unarmedAttacks = new Dictionary<string, Dictionary<Weapon, bool>>();
            Dictionary<Weapon, bool> unaramedDefault = new Dictionary<Weapon, bool>();
            
            // TODO : Add Unarmed Abilities When Created
            
            Talents.Add(Weapon.TypeOfWeapon.Unarmed,unarmedAttacks);

            _gameManager.Talents.Talents = Talents;
        }


        private void Awake()
        {
            Initialise();
            
        }
    }
}