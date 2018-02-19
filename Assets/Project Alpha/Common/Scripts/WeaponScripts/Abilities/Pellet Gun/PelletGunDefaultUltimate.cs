namespace MoreMountains.CorgiEngine.Pellet_Gun
{
    public class PelletGunDefaultUltimate : RangedCombatAbility
    {
        
        public PelletGunDefaultUltimate () 
        {
            Name = "Ultimate Attack";
            UpgradePath = "Default";
            IsTalentAbility = false;
            RequiredTalentPoints = 0;
            IsUnlocked = true;
            IsActive = false; 
        }
    }
}