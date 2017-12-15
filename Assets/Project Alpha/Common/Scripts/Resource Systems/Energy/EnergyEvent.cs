using UnityEngine;
using System.Collections;
using MoreMountains.CorgiEngine;

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

        public EnergyEvent (EnergyEventType energyEventType, int amount) {
            this.energyEventType = energyEventType;
            this.amount = amount;
        }

    }
}
