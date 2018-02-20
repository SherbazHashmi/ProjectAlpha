namespace MoreMountains.CorgiEngine.Pellet_Gun
{
    public class PelletGunDefaultStrong : RangedCombatAbility
    {        
        public PelletGunDefaultStrong () 
        {
            Name = "Strong Attack";
            UpgradePath = "Default";
            IsTalentAbility = false;
            RequiredTalentPoints = 0;
            IsUnlocked = true;
            IsActive = false; 
        }
    }
}