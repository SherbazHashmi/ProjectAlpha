using UnityEngine;
using System.Collections;

namespace MoreMountains.CorgiEngine {

    public class HulkHands : MeleeCombatAbility {

        public HulkHands () {
            this.name = "Hulk Hands";
            this.isTalentAbility = true;
            this.upgradePath = "Unarmed";
            this.requiredTalentPoints = 5;
            this.attackType = TypeOfAttack.Strong;
            this.weaponType = TypeOfWeapon.Unarmed;
        }


    }

}
