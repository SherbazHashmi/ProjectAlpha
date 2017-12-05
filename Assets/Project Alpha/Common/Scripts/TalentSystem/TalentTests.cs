using UnityEngine;
using NUnit.Framework;

namespace MoreMountains.CorgiEngine
{
    
[TestFixture]
    public class TalentTest 
{
    [Test, Category("TalentTest")]
    void addTest () {
        TalentCollection talents = new TalentCollection();
        Assert.IsTrue((talents.ToString() != ""),"Talents should return empty, but returning :"+talents.ToString());
    }
}
}