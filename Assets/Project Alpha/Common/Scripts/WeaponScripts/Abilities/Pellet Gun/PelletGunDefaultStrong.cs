namespace MoreMountains.CorgiEngine.Pellet_Gun
{
    public class PelletGunDefaultStrong : RangedCombatAbility
    {
        public string Description;
        
        public PelletGunDefaultStrong () 
        {
            Name = "Strong Attack";
            UpgradePath = "Default";
            IsTalentAbility = false;
            RequiredTalentPoints = 0;
            IsUnlocked = true;
            ((Weapon) this).AttackType = TypeOfAttack.Strong;
            ((Weapon) this).WeaponType = TypeOfWeapon.PelletGun;
            Description = "Short range strong weapon attack.";
            IsActive = false; 
        }
    }
}