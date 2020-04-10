using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    static public float damage;
    static public float range;
    static public double timeBtwAttack;
    [SerializeField] static public int chooseWeapon = 2;
    
    

    void Start()
    {
        switch (chooseWeapon)
        {
            case 1:

                damage = 20;
                range = 3;
                
                break;

            case 2:
                damage = 30;
                range = 4;
                
                break;

        }
    }
    
    // Update is called once per frame
    void Update()
    {
       
    }
}
