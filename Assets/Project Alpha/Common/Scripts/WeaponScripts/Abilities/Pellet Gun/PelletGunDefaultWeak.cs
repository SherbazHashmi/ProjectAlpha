namespace MoreMountains.CorgiEngine.Pellet_Gun
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
