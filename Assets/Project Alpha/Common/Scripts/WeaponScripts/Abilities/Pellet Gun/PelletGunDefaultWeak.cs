using MoreMountains.CorgiEngine;

namespace Project_Alpha.Common.Scripts.WeaponScripts.Abilities.Pellet_Gun
{

    public class PelletGunDefaultWeak : RangedCombatAbility
    {
        public PelletGunDefaultWeak()
        {
            Name = "Weak Attack";
            UpgradePath = "Default";
            IsTalentAbility = false;
            RequiredTalentPoints = 0;
            IsUnlocked = true;
            IsActive = false; 
        }

    }
}
