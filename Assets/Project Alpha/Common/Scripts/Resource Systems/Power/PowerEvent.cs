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
        public int amount;

        public PowerEvent (PowerEventType powerEventType, int amount) {
            this.powerEventType = powerEventType;
            this.amount = amount;
        }
   
    }

}
