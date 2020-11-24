using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : Entity
{

    public float baseAttackRate;//max attack rate before modifiers

    //attack fields
    protected bool isAttacking;// started attacking and can deal damage
    protected float lastAttackTime;// time when last attacked (Time.time)
    public List<Weapon> weapons;//all weapons that can be used
    public int currentWeapon; // index of current weapon
    

    //health
    protected int regenValue; //health regen value
    protected int regenTime; // ??

    // Start is called before the first frame update
    protected override void Start(){
        base.Start();
        UpdateAttackRate();
        lastAttackTime=0;
        foreach (Weapon weapon in weapons){
            weapon.owner = this;
        }

    }

    public bool CanAttack()    {
        return isAlive && Time.time - lastAttackTime >= attackRate;
    }

    public void Attack()    {
        if (CanAttack()){//isAttacking
            isAttacking = true;
            Weapon current = GetWeapon();
            lastAttackTime = Time.time;
            if (!current.UseWeapon()){
                //weapon is broken
                weapons.RemoveAt(currentWeapon);//remove item
                currentWeapon = 0;//change weapon selection
            }
            isAttacking = false;
        }
    }

    public override void UpdateMaxHealth(){
        Weapon current = GetWeapon();
        maxHealth = baseHealth * current.healthMultiplier + current.healthBonus;
    }

    public override void UpdateDamage(){
        Weapon current = GetWeapon();
        damage = baseDamage * current.damageMultiplier + current.damageBonus;
    }

    public override void UpdateSpeed(){
        Weapon current = GetWeapon();
        speed = baseSpeed * current.speedMultiplier + current.speedBonus;
    }

    public void UpdateAttackRate(){
        attackRate = baseAttackRate * GetWeapon().attackRateMultiplier;
    }

    public Weapon GetWeapon(){
        return weapons[currentWeapon];
    }
}
