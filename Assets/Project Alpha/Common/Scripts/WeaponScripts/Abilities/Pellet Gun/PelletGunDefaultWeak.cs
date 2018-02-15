using MoreMountains.CorgiEngine;

namespace Project_Alpha.Common.Scripts.WeaponScripts.Abilities.Pellet_Gun
{

    public class PelletGunDefaultWeak : RangedCombatAbility
    {
        public string Description;
        public PelletGunDefaultWeak()
        {
            Name = "Weak Attack";
            UpgradePath = "Default";
            IsTalentAbility = false;
            RequiredTalentPoints = 0;
            IsUnlocked = true;
            ((Weapon) this).AttackType = TypeOfAttack.Weak;
            ((Weapon) this).WeaponType = TypeOfWeapon.PelletGun;
            Description = "Short range basic weapon attack.";
            IsActive = false; 
        }

    }
}
