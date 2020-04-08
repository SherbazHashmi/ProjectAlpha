using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    static public float damage;
    static public int range;
    static public double timeBtwAttack;
    [SerializeField] private int chooseWeapon = 1;
    void Start()
    {
        switch (chooseWeapon)
        {
            case 1:
                NeonStriker neonStriker = new NeonStriker();
                damage = neonStriker.damage;
                range = neonStriker.range;
                timeBtwAttack = neonStriker.timeBtwAttack;
                break;
        }
    }
    void weaponStats()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
