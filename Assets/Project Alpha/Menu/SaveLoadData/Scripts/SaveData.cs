using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MoreMountains.CorgiEngine
{
    /// <summary>
    /// Save Data Class
    /// Implements Save Fields and Behaviours. 
    /// Utilised in Checkpoint & Load Scripts.
    /// </summary>
    /// 
    
    public class SaveData
    {
        
        /// <summary>
        /// Stating Global Variables 
        /// </summary>
       
        // General Data (Image, Game Text, Play Time)
        private Image _levelImage;
        private string _saveGameText;
        private int _currentPlayTime;
        
        // Currency Data (Chips, Cogs)
        private float _chips;
        private float _cogs;
        
        // Scene and Checkpoint Data.
        private Scene _scene;
        private string _lastCheckPointName;
        
        // Dates (Created & Saved) 
        private DateTime _dateCreated;
        private DateTime _dateSaved;

        /// <summary>
        /// Constructor used whenever a new SaveData instance is created. 
        /// </summary>
        
        public SaveData(Image levelImage, string saveGameText, int currentPlayTime, Scene scene, string lastCheckPointName, DateTime dateCreated, DateTime dateSaved, float chips, float cogs)
        {
            _levelImage = levelImage;
            _saveGameText = saveGameText;
            _currentPlayTime = currentPlayTime;

            _scene = scene;
            _lastCheckPointName = lastCheckPointName;

            _dateCreated = dateCreated;
            _dateSaved = dateSaved;

            _chips = chips;
            _cogs = cogs;

        }
    }
}