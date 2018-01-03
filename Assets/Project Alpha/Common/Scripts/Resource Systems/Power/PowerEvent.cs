using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using MoreMountains.InventoryEngine;
using MoreMountains.CorgiEngine;

namespace MoreMountains.CorgiEngine
{
    public enum PowerEventType {Add, Remove, Set}


    public struct PowerEvent 
    {
        public PowerEventType powerEventType;
        public float amount;

        public PowerEvent (PowerEventType powerEventType, float amount) {
            this.powerEventType = powerEventType;
            this.amount = amount;
        }
   
    }

}
