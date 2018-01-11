using System.IO;
using MoreMountains.CorgiEngine;
using UnityEngine;

namespace Project_Alpha.Common.Scripts.Setup
{
    public class Setup : MonoBehaviour
    {
        private void Awake()
        {
            // Setup Directories 
            
            // Create Save Directory

            string saveDataPath = Application.persistentDataPath + "/SaveData/";
            
            if (!Directory.Exists(saveDataPath))
            {
                Directory.CreateDirectory(saveDataPath);
            }
            
            
        }
    }
}