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
       
        // General Data (Image, Image Directory, Game Text, Play Time)
        private Image _levelImage;
        private string _imageDirectory;
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
            
            // Setting Image Directory Using SetImageDirectory.
            
            SetImageDirectory();
        }


        /// <summary>
        /// Save Data Load Constructor
        /// </summary>
        
        
        // TODO : Create Load Constructor To Be Used When Loading A Save File!
        
        public SaveData(int indexSaveFile)
        {
           // Create An Array Of Saves from Current Save Files (Maybe Filter By Save Extension) 
            
           // Select The Index Of Save File Required From Array
            
           // Set Instance Fields to File Fields From Array
  
        }
        
        
        
        // TODO : Create A Save Function! This will serialise the data into a file!! 
        
        public void Save()
        {
            
        }
        
        /// <summary>
        /// Used In Initialisation of Image Directory, it will set the correct directory (string)
        /// for the corresponding image based on which scene it is loading.
        /// Images should already be present and matching viewer. 
        /// </summary>
        
        private void SetImageDirectory()
        {
            // Root (Where All The Level Images Are Saved)
            const string root = "/data/lvlimgs/";
            // File Name (based on scene)
            var filename = _scene.name;
            // Sets Image Directory
            _imageDirectory = root + filename;
        }


    }
}