namespace MoreMountains.CorgiEngine.Pellet_Gun
{
    public class PelletGunDefaultUltimate : RangedCombatAbility
    {
        public string Description;
        
        public PelletGunDefaultUltimate () 
        {
            Name = "Ultimate Attack";
            UpgradePath = "Default";
            IsTalentAbility = false;
            RequiredTalentPoints = 0;
            IsUnlocked = true;
            ((Weapon) this).AttackType = TypeOfAttack.Ultimate;
            ((Weapon) this).WeaponType = TypeOfWeapon.PelletGun;
            Description = "Shoot a burst of bullets around you.";
            IsActive = false; 
        }
    }
}