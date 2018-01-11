using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace MoreMountains.CorgiEngine
{
    /// <summary>
    /// Save Data Class
    /// Implements Save Fields and Behaviours. 
    /// Utilised in Checkpoint & Load Scripts.
    /// </summary>
    /// 
    /// TODO: For Images, Store Images in Memory! This way you won't have to pull images over and over again.
    
    [Serializable]
    public class SaveData
    {
        
        /// <summary>
        /// Stating Global Variables 
        /// </summary>
       
        // General Data (Image, Image Directory, Game Text, Play Time)
        // Image is encoded as a png file;
        private byte[] _levelImage;
        private string _imageDirectory;
        private string _saveGameText;
        private int _currentPlayTime;
        
        // Currency Data (Chips, Cogs, Array of High Cog Scores for Previous Levels)
        private float _chips;
        private float _cogs;
        private float[] _totalCogs;
        
        // Scene and Checkpoint Data.
        private Scene _scene;
        private string _lastCheckPointName;
        
        // Dates (Created & Saved) 
        private DateTime _dateCreated;
        private DateTime _dateSaved;

        /// <summary>
        /// Constructor used whenever a new SaveData instance is created. 
        /// </summary>
        
        public SaveData(string saveGameText, int currentPlayTime, Scene scene, string lastCheckPointName, DateTime dateCreated, DateTime dateSaved, float chips, float cogs)
        {
            _saveGameText = saveGameText;
            _currentPlayTime = currentPlayTime;

            _scene = scene;
            _lastCheckPointName = lastCheckPointName;

            _dateCreated = dateCreated;
            _dateSaved = dateSaved;

            _chips = chips;
            _cogs = cogs;
            
            // Setting Image Directory Using SetImageDirectory.
            
            _imageDirectory = SetPathDirectory(DirectoryUseCase.Image);
            
            //
            
            // Setting Image 
            
            SetImage();
        }


        /// <summary>
        /// Save Data Load Constructor
        /// </summary>
        
        
        // TODO : Create Load Constructor To Be Used When Loading A Save File!
        
        public SaveData LoadSaveData(int indexSaveFile)
        {
           // Create An Array (Create Dynamic) Of Saves from Current Save Files (Maybe Filter By Save Extension) 
           
           // Select The Index Of Save File Required From Array
            
           // Set Instance Fields to File Fields From Array

            return null;

        }
        

        
        public void Save()
        {
            // Initiliasing Binary Formatter.             
            BinaryFormatter formatter = new BinaryFormatter();
            
            // Setting Up File Directory            
            string fileDir = SetPathDirectory(DirectoryUseCase.SaveFile);
            
            // Updating Date Created and Saved Variables
            _dateSaved = DateTime.Now;

            if (!File.Exists(fileDir))
            {
                _dateCreated = _dateSaved;
            }

            // Handle Save File Based on Whether the File Exists or Not.
            FileStream saveFile = (File.Exists(fileDir)) ? File.Open(fileDir, FileMode.Open) : File.Create(fileDir);
            
            // Serialising the File (Writing the Data)
            formatter.Serialize(saveFile, this);
            
            // Closing The File
            saveFile.Close();
        }
        
        /// <summary>
        /// Used In Initialisation of Directories, it will set the correct directory (string)
        /// for the corresponding object.
        /// Images should already be present and matching viewer. 
        /// </summary>
        
        private string SetPathDirectory(DirectoryUseCase duc)
        {
            
            string subdirectory;
            string fileName;
            
            // Setting Subdirectory and File Name Based On Directory USe Case. 
            
            switch (duc)
            {
                case DirectoryUseCase.SaveFile :
                    subdirectory = "SaveData";
                    fileName = _saveGameText;
                    break;
                case DirectoryUseCase.Image :
                    subdirectory = "LevelImg";
                    fileName = _scene.name;
                    break;
                default:
                    Debug.Log("Incorrect Subdirectory Passed :"+duc);
                    subdirectory = null;
                    fileName = null;
                    break;
            }
            
            // Root (Where All The Level Images Are Saved)
            string root = Application.persistentDataPath;
            
            // File Name (based on scene)
            fileName += ".dat";
            
            // Sets Image Directory
            return root + "/" + subdirectory + "/" + fileName + "/";
        }

        /// <summary>
        /// Directory Use Case are the types of use cases for using directories
        /// Interacts With SetPathDirectory Function
        /// </summary>
        private enum DirectoryUseCase 
        {
            SaveFile, Image
        }

        private void SetImage()
        {

            if (File.Exists(_imageDirectory))
            {
                _levelImage = File.ReadAllBytes(_imageDirectory);
                
            }
            else
            {
                Debug.LogError("The file '" + _imageDirectory +"' does not exist.");
            }
          
        }

        
        /// <summary>
        /// Changes High Cog Score For Whichever Level You Wish To Update For. Index denotes the level to ammend.
        /// </summary>
        /// <param name="index"></param>

        private void ModifyTotalCogs(int index)
        {
            _totalCogs[index] = _cogs;
        }
        
        // TODO : Use Hash Tables For Hash Table Implementation, Faster Searching.

        /// <summary>
        /// Updates Last Checkpoint Value To The Parsed Checkpoint.
        /// </summary>
        /// <param name="checkPoint"></param>
        
        public void UpdateLastCheckPoint(CheckPoint checkPoint)
        {
            _lastCheckPointName = checkPoint.name;
        }
        
        
         
        


    }
}