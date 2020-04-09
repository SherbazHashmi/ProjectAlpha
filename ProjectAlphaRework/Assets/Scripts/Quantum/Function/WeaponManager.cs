using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    static public float damage;
    static public float range;
    static public double timeBtwAttack;
    [SerializeField] private int chooseWeapon = 1;
    void Start()
    {
        switch (chooseWeapon)
        {
            case 1:
                
                damage = 20;
                range = 3;
                timeBtwAttack = 0.8;
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
