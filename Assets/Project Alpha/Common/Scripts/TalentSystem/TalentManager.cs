using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    public class TalentManager : MonoBehaviour
    {
        // Talent Collection Class. 

        private TalentCollection talents;
        
        private void Start()
        {
            // Initialise talent collection (Add All Abilities/Weapons)
            
           talents.InitTalentCollection();
            
        }

        private void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}