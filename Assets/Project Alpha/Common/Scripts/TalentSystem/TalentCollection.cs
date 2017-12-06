using UnityEngine;
using System.Collections.Generic;


namespace MoreMountains.CorgiEngine
{
    public class TalentCollection
    {

        /// Datatype To Store Talents. 
        /// I hope they have it hashed in C#, if not we will have to implement a new datatype.
        /// Talents (CombatAbility, isActive)
        /// Add all abilities to here.


        Dictionary<Weapon, bool> talents () {
			Dictionary<Weapon, bool> tals = new Dictionary<Weapon, bool>();
            return tals;
		}

        Dictionary<Weapon, bool> activateTalent (Dictionary<Weapon, bool> talents, Weapon talentToActivate) {
            bool isActiveInDictionary;
            talents.TryGetValue(talentToActivate, out isActiveInDictionary);
            if (isActiveInDictionary == false) {
                Weapon desiredCombatAbility = talentToActivate;
                talents.Remove(desiredCombatAbility);
                talents.Add(desiredCombatAbility,true);
            } else {
                // Either the talent is already active or is not in dictionary.
                return null;
            }
            return talents;
        }

        Dictionary<Weapon, bool> deactivateTalent (Dictionary<Weapon, bool> talents, Weapon talentToDeactivate){
			bool isActiveInDictionary;
            talents.TryGetValue(talentToDeactivate, out isActiveInDictionary);
            if (isActiveInDictionary == true) {
                talents[talentToDeactivate] = false;
            } else {
                // Either the talent is already deactivated or is not in dictionary.
                return null;
            }
            return talents;
        }




    }
}
