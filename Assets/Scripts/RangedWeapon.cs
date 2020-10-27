using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    public Projectile[] projectileTypes;

    public Projectile arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool UseWeapon(){
        Instantiate(arrow,owner.transform.position,Quaternion.Euler(owner.transform.forward));
        return base.UseWeapon();
    }
}
