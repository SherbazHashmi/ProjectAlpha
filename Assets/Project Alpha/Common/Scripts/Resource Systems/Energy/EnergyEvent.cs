namespace MoreMountains.CorgiEngine
{
    /// <summary>
    /// The Possible Energy Events
    /// </summary>

    public enum EnergyEventType {Add, Remove}

    /// <summary>
    /// Energy Event Structure
    /// </summary>

    public struct EnergyEvent
    {
        /// the type of event 
        public EnergyEventType energyEventType;
        public int amount;
        public int multiplier;

        public EnergyEvent (EnergyEventType energyEventType, int amount, int multiplier) {
            this.energyEventType = energyEventType;
            this.amount = amount;
            this.multiplier = multiplier;
        }
    }
}
