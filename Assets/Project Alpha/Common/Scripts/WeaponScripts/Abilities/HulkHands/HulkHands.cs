using UnityEngine;
using System.Collections;

namespace MoreMountains.CorgiEngine {

    public class HulkHands : MeleeCombatAbility {
        
        

        public HulkHands () {
            this.name = "Hulk Hands";
            this.IsTalentAbility = true;
            this.UpgradePath = "Unarmed";
            this.RequiredTalentPoints = 5;
            this.AttackType = TypeOfAttack.Strong;
            this.WeaponType = TypeOfWeapon.Unarmed;
            
        }


    }

}
