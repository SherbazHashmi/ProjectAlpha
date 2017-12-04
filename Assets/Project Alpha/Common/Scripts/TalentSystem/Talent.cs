using UnityEngine;
using System.Collections;


using namespace MoreMountains.CorgiEngine {
    
	/// <summary>
	/// Type of Attack This Talent Replaces (As Outlined in Documentation)
	/// Ref : https://docs.google.com/document/d/14MyKsqf8reATkkiQ2IGxU-T1GgR7HDV_C2v7vzJpwIs
	/// </summary>

	public enum TypeOfAttack {
        Weak,
        Strong,
        Ultimate,
        Movement
    }


    /// <summary>
    ///  Type of Weapon That This Talent Applies To
    /// </summary>


    public enum TypeOfWeapon {
        SawDropper,
        RocketLauncher,
        Shotgun,
        PelletGun
    }


    /// <summary>
    /// Talent Class denoting the name, ability, whether the talent is active, type of weapon, type of attack to replace, and the level of the talent. 
    /// </summary>

    public class Talent
    {

        string name;
        bool isActive;
        CharacterAbility ability;
        TypeOfWeapon typeOfWeapon;
        TypeOfAttack typeOfAttackToReplace;
        int level;


        public Talent (string name, bool isActive, CharacterAbility ability) {
            this.name = name;
            this.isActive = isActive;
            this.ability = ability;
            this.typeOfWeapon = ability.typeOfWeapon;
            this.typeOfAttackToReplace = ability.typeOfAttack;
        }

    }

}
