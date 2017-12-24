using UnityEngine;
using System.Collections;
using MoreMountains.CorgiEngine;

namespace MoreMountains.CorgiEngine
{

    public class PelletGunDefaultWeak : ProjectileWeapon
    {
        public PelletGunDefaultWeak () {
            TriggerMode = TriggerModes.Auto;
            TimeBetweenUses = 0.1f;
            MagazineBased = false;

        } 
    }
}
