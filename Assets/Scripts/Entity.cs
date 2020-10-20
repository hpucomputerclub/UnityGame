using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float baseHealth;
    public float baseDamage;
    public float baseSpeed;
    public float attackRate;
    public int lastAttackTime;
    public int reloadTime;
    public float magSize;
    public float bulletCount;
    public int lastReloadTime;
    public bool invisible;
    public bool invincible;
    public Vector2 vel;
    public Vector2 acc;
    public int regenValue;
   public int  regenTime;
//    public Weapon[]  weapons;
    public int currentWeapon;
    public bool isAlive;
    public bool hasShield;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
