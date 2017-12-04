using UnityEngine;
using System.Collections;


namespace MoreMountains.CorgiEngine {
    
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


    // TODO : Modify CharacterAbility class to work with talent class by adding TypeOfWeapon and TypeOfAbility parameters. 

    public class Talent
    {

        string name;
        string upgradePath;
        bool isActive;
        CharacterAbility ability;
        TypeOfWeapon typeOfWeapon;
        TypeOfAttack typeOfAttackToReplace;
        int level;


        public Talent (string upgradePath, bool isActive, CharacterAbility ability) {
            this.name = ability.name;
            this.upgradePath = upgradePath;
            this.isActive = isActive;
            this.ability = ability;
            this.typeOfWeapon = ability.typeOfWeapon;
            this.typeOfAttackToReplace = ability.typeOfAttack;
        }


		/// <summary>
		/// Produces a HashCode for a given Talent.
		/// Used for implementing the BST of talents. 
		/// </summary>
		/// <returns>The code.</returns>
		/// <param name="talent">Talent.</param>

		int hashCode()
		{
			int hash = 0;
			string name = this.name;

			for (int i = 0; i < name.Length; i++)
			{
				hash = name[i] + (31 * hash);
			}

			return hash;
		}

        public string toString () {
            return "name : " + name + ", upgrade path : " + upgradePath + ", isActive : " + isActive + ", type of weapon : " + typeOfWeapon + ", type of attack to replace : " + typeOfAttackToReplace+".";
        }

    }

}
