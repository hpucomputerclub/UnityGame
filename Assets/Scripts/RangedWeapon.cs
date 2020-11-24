using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    public Projectile[] projectileTypes;

    public override bool UseWeapon(){
        print("Ranged Attack");
        if(projectileTypes.Length > 0){
            Projectile projectile = (Projectile)Instantiate(projectileTypes[Random.Range(0,projectileTypes.Length-1)],owner.transform.position,Quaternion.Euler(owner.transform.forward));
            projectile.firedFrom = this;
        }
        return base.UseWeapon();
    }
}
