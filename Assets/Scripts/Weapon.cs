using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon: MonoBehaviour{
    public Entity owner;
    public float damageMultiplier=1f;
    public int damageBonus=0;
    public float healthMultiplier=1f;
    public int healthBonus=0;
    public float speedMultiplier=1f;
    public int speedBonus=0;
    public float attackRateMultiplier=1f;
    public int uses=-1;
    public bool infiniteUse = true;
    public int cost = 0;
    public float effectTime=0f;
    public bool isRanged;

    public bool UseWeapon(){//remove 1 from uses if not infinite and return false if broken
        print("USE WEAPON");
        return infiniteUse || --uses <= 0;
    }
}
