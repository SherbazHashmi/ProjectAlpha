using UnityEngine;
using NUnit.Framework;
using MoreMountains.CorgiEngine;
using System.Collections.Generic;


[TestFixture]
    public class TalentTest 
{
		class TestActivate {
		[Test, Category("TalentTest")]
			public void testAddOne () {
			TalentCollection talentInterface = new TalentCollection ();
            Dictionary<Weapon, bool> talents = talentInterface.getTalents();
		}
		
}
}
