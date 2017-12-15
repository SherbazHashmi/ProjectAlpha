using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using MoreMountains.InventoryEngine;
using MoreMountains.CorgiEngine;

namespace MoreMountains.CorgiEngine
{
    [RequireComponent(typeof(Weapon))]
    public class Power : MonoBehaviour 
    {

        public int Energy = 200;

        public Weapon weapon;

        public virtual void ConsumeEnergy () {
            
        } 
   
    }

}
