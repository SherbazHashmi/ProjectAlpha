using System;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    public class TalentManager : MonoBehaviour

    {
        private GameManager _gameManager;
        private TalentCollection _talentCollection;
        
        /// <summary>
        /// Initialises the Game Manager and Talent Collection
        /// </summary>
        /// 
        private void Initialise()
        {
            try
            {
                GameObject gameManagerObject = GameObject.Find("GameManager");
                _gameManager = gameManagerObject.GetComponent<GameManager>();
                _talentCollection = _gameManager.talents;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                throw;
            }
            if (_gameManager.SaveData == null)
                _talentCollection.initTalents();
            else
            {
                _talentCollection = _gameManager.SaveData.TalentCollection;
            }
        }

        /// <summary>
        /// Saves Talents To SaveData Object in Game Manger 
        /// </summary>
        public void SaveTalents()
        {
            _gameManager.SaveData.TalentCollection =  _talentCollection;
        }
        
        private void Awake()
        {
            Initialise();
            
        }
    }
}