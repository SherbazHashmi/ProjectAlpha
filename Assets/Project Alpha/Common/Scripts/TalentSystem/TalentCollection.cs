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


        Dictionary<CombatAbility, bool> talents () {
			Dictionary<CombatAbility, bool> tals = new Dictionary<CombatAbility, bool>();
            return tals;
		}

        Dictionary<CombatAbility, bool> activateTalent (Dictionary<CombatAbility, bool> talents, CombatAbility talentToActivate) {
            bool isActiveInDictionary;
            talents.TryGetValue(talentToActivate, out isActiveInDictionary);
            if (isActiveInDictionary == false) {
                CombatAbility desiredCombatAbility = talentToActivate;
                talents.Remove(desiredCombatAbility);
                talents.Add(desiredCombatAbility,true);
            } else {
                // Either the talent is already active or is not in dictionary.
                return null;
            }
            return talents;
        }

        Dictionary<CombatAbility, bool> deactivateTalent (Dictionary<CombatAbility, bool> talents, CombatAbility talentToDeactivate){
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
