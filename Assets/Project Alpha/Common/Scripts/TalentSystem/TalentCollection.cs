using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace MoreMountains.CorgiEngine
{
    public class TalentCollection : MonoBehaviour
    {
        public ProjectileWeapon pelletGunDefaultWeak;
        private Dictionary<Weapon, bool> talents { get; set; }

        /// Datatype To Store Talents. 
        /// I hope they have it hashed in C#, if not we will have to implement a new datatype.
        /// Talents (CombatAbility, isActive)
        /// Add all abilities to here.


        public Dictionary<Weapon, bool> getTalents()
        {
            return talents;
        }
      
        /// <summary>
        /// Initialises Talents
        /// </summary>
        
        public void initTalents () {
			talents = new Dictionary<Weapon, bool>();
            ProjectileWeapon pelletGunDefaultWeak = Instantiate<ProjectileWeapon>(this.pelletGunDefaultWeak);                                          
			talents.Add(pelletGunDefaultWeak, false);
		}
        
        
        /// <summary>
        /// Activates Talents, returns true if talent activation was successful, false if it is not. 
        /// </summary>        
        /// <param name="talentToActivate"></param>
        /// <returns>Was Talent Activation Successful</returns>

        public bool activateTalent (Weapon talentToActivate) {
            bool isActiveInDictionary;
            talents.TryGetValue(talentToActivate, out isActiveInDictionary);
            if (isActiveInDictionary == false) {
                Weapon desiredCombatAbility = talentToActivate;
                talents.Remove(desiredCombatAbility);
                talents.Add(desiredCombatAbility,true);
                
                // Dealing With Binary File 
                SaveTalents();
                return true;
            }

            return false;
        }
        
        /// <summary>
        /// Deactivates talents, returns true if talent deactivation was successful, false if it is not.
        /// </summary>
        /// <param name="talentToDeactivate"></param>
        /// <returns>Was Talent Deactivation Successful</returns>

        public bool deactivateTalent (Weapon talentToDeactivate){
			bool isActiveInDictionary;
            talents.TryGetValue(talentToDeactivate, out isActiveInDictionary);
            if (isActiveInDictionary == true) {
                talents[talentToDeactivate] = false;
   
                // Dealing With Binary File
                SaveTalents();
                return true;
            } 
            return false;
        }

       
        /// <summary>
        /// Reads Talents Object from Binary File and Sets It To Current Talents Object.
        /// Used In Initialisation
        /// </summary>
        
        public void SetTalents()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream memoryStream = new FileStream(Application.persistentDataPath + "/talents.data", FileMode.Open);
                Dictionary<String, bool> stringTalents = new Dictionary<String, bool>();
                stringTalents = bf.Deserialize(memoryStream) as Dictionary<String, bool>;              
              
              
                foreach (KeyValuePair<Weapon, bool> talent in talents)
                {
                    if (stringTalents.ContainsKey(talent.Key.weaponName))
                    {
                        talents[talent.Key] = stringTalents[talent.Key.weaponName];
                    }
                    else
                    {
                        Debug.Log(talent.Key.weaponName+" is not contained in the file. \nString Talents (File) : "+stringTalents+"\nTalent Collection (Object) : "+talents);
                    }
                }

            }
            catch (Exception e)
            {
                Debug.Log("Talent Setting Failed");
            }
        }

        /// <summary>
        /// Saves Talents Object To Binary File.
        /// Used in any talents changes. (Activate or Deactivate)
        /// </summary>
        
        public void SaveTalents()
        {
            try
            {
                // Creates Instances of Binary Formatter, Stream and Data.
                
                BinaryFormatter bf = new BinaryFormatter();
                FileStream stream = new FileStream(Application.persistentDataPath + "/talents.data", FileMode.OpenOrCreate);
                Dictionary<String, bool> data = toStringDictionary();
                
                // Serialize Object To File.
                bf.Serialize(stream,data);
                
                // Close File Stream.
                stream.Close();
               
            }
            catch (Exception e)
            {
                Debug.Log("Refresh Talents Failed");
            }
        }
        
        /// <summary>
        /// Converts Class Dictionary of Weapon and Boolean to Dictionary of String and Boolean. 
        /// </summary>
        /// <returns>Dictionary of String, Boolean which the binary file will recognise </returns>
    
        public Dictionary<String, bool> toStringDictionary () 
        {
            Dictionary<String, bool> stringOutput = new Dictionary<string, bool>();

            foreach (KeyValuePair<Weapon,bool> entry in talents)    
                
            {
                stringOutput.Add(entry.Key.weaponName,entry.Value);
            }

            return stringOutput;
        }
  
    }
}
