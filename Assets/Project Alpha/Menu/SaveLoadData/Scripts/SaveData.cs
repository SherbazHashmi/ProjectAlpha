using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

namespace MoreMountains.CorgiEngine
{
    /// <summary>
    /// Save Data Class
    /// Implements Save Fields and Behaviours. 
    /// Utilised in Checkpoint & Load Scripts.
    /// </summary>

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
        // Current Play Time is is Minutes!
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
        
        // Talent Collection 

        private TalentCollection _talentCollection;

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
            _totalCogs = new float[7];
            
            // Setting Image Directory Using SetImageDirectory.
            
            _imageDirectory = SetPathDirectory(DirectoryUseCase.Image);
            
            // Setting Image 
            
            SetImage();
            
            // Initialising Talent Collection
            
            _talentCollection.initTalents();
            

        }

        /// <summary>
        /// Save Data Constructor To Load From A File
        /// </summary>
        public SaveData(string saveText)
        {
            LoadSaveData(saveText);
        }


        /// <summary>
        /// Loads save data from file, if it returns null, there was not a save file match in folder.
        /// </summary>
        /// <param name="saveText"></param> 
        
                
        private SaveData LoadSaveData(string saveText)
        {
           // Create An List Of Saves from Current Save Files (Maybe Filter By Save Extension) 

            BinaryFormatter formatter = new BinaryFormatter();
            
            List<SaveData> saves = new List<SaveData>();

            string saveDirectory = Application.persistentDataPath + "/SaveData/";
            
            
            
            foreach (var fileName in Directory.GetFiles(saveDirectory))
            {
                try
                {
                    // NOTE : If Loading Doesn't Work, Fix The Deserialisation Force Typcast. 
                    
                    FileStream saveFileStream = File.Open(saveDirectory + "/" + fileName + "/", FileMode.Open, FileAccess.Read, FileShare.Read);
                    
                    var save = (SaveData) formatter.Deserialize(saveFileStream);

                    if (save._saveGameText == saveText)
                    {
                        _chips = save._chips;
                        _cogs = save._cogs;
                        _currentPlayTime = save._currentPlayTime;
                        _dateCreated = save._dateCreated;
                        _dateSaved = save._dateSaved;
                        _imageDirectory = save._imageDirectory;
                        _lastCheckPointName = save._lastCheckPointName;
                        _levelImage = save._levelImage;
                        _saveGameText = save._saveGameText;
                        _scene = save._scene;
                        _talentCollection = save._talentCollection;
                        _totalCogs = save._totalCogs;
                    }
                   
                    saveFileStream.Close();
                    return save;

                }
                
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            Debug.LogError("Save File Doesn't Exist For The Following Save Text : "+saveText+". Actual save file names : "+saves+".");
            return null;
        }

        /// <summary>
        /// Produces All Save Files Names And Populates Them Into An Array
        /// </summary>
        /// <returns>Array of Save Files</returns>

        public string[] ShowSaveFiles()
        {
            List<string> savesList = new List<string>();

            string saveDirectory = Application.persistentDataPath + "/SaveData/";

            return Directory.GetFiles(saveDirectory);
        }
        
        /// <summary>
        /// Deletes Save File given a saveText parameter.
        /// </summary>
        /// <param name="saveText"></param>


        public void DeleteSave(string saveText)
        {
            string saveDirectory = Application.persistentDataPath + "/SaveData/" + saveText + ".dat/";

            if (File.Exists(saveDirectory))
            {
                File.Delete(saveDirectory);
            }
            else
            {
                Debug.LogError("Save File : "+saveDirectory+", does not exist!");
            }
        }


        /// <summary>
        /// Populate Save Object With Fields From a Game Manager.
        /// </summary>
        
        
        /// TODO : Populate The Save Object From Game. 
        
        public void PopulateSaveObject(GameManager gameManager, LevelManager levelManager )
        {
            // Pulling Currency Data 

            _chips = gameManager.ChipPoints;
            _cogs = gameManager.Points;

            // Pulling Checkpoint Data
            _lastCheckPointName = levelManager.Checkpoints[levelManager.Checkpoints.Count - 1].name;
            
            
            // Date Saved Modification
            
            _dateSaved = DateTime.Now;
            _currentPlayTime = _currentPlayTime + levelManager.RunningTime.Minutes;

        }
        
        
        /// <summary>
        /// Saves The Current Save Object To Memory
        /// </summary>        
        
        private void Save()
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
        /// Images should already be present and matching viewer. Takes a directory use case parameter.
        /// </summary>
        /// <param name="duc"></param>
        
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
        /// <param name="levelIndex"></param>  

        private void UpdateHighScore(string sceneName)
        {
            _totalCogs[sceneIndex(sceneName)] = _cogs;
        }
        
        /// <summary>
        /// Updates Last Checkpoint Value To The Parsed Checkpoint.
        /// </summary>
        /// <param name="checkPoint"></param>
        
        public void UpdateLastCheckPoint(CheckPoint checkPoint)
        {
            _lastCheckPointName = checkPoint.name;
        }

        
        /// <summary>
        /// Based on Scene Name, It Will Produce the Index (Used in HighScoreFunction)
        /// </summary>
        /// <param name="sceneName"></param>
        /// <returns>Index Of Scene (Level) </returns>

        private int sceneIndex(string sceneName)
        {
            switch (sceneName)
            {
                    case "scene1" :
                        return 1;
                    case "scene2" :
                        return 2;
            }
            return 0;
        }
              
    }
}