using UnityEngine;
using System.Collections;
using MoreMountains.Tools;


namespace MoreMountains.CorgiEngine {
 

    /// <summary>
    /// Chip Manager
    /// </summary>
    /// 

    [AddComponentMenu("ProjectAlpha/Common/Chip")]


public class Chip : PickableItem
{
   
    public int ChipPointsToAdd = 1;

		/// <summary>
		/// Triggered when something collides with the chip
		/// </summary>
		/// <param name="collider">Other.</param>
        /// a

		protected override void Pick()
    {
        MMEventManager.TriggerEvent(new CorgiEngineChipsEvent(ChipsMethods.Add, ChipPointsToAdd));
    }

}
}
