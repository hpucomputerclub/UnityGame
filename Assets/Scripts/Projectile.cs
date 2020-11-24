using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Entity
{
    public Weapon firedFrom;
    public int impactRange=0;

    protected override void Start(){
        base.Start();
        vel.y = firedFrom.owner.transform.forward.z * speed;
        print("Velocity Proj: " + vel.y);
    }

}
