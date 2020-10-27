using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    //public fields
    public bool invisible;//make entity invisible
    public bool invincible;//no damage can be taken
    public bool isAlive = true;// is Alive

    //base fields
    public float baseHealth;//max health before modifiers
    public float baseDamage;//max damage before modifiers
    public float baseSpeed;//max speed before modifiers
    public float baseAttackRate;//max attack rate before modifiers

    //attack fields
    public List<Weapon> weapons;//all weapons that can be used
    public int currentWeapon; // index of current weapon
    protected bool isAttacking;// started attacking and can deal damage
    protected int lastAttackTime;// time when last attacked (Time.time)
    protected bool hasShield;// shield effect is on

    //health
    protected float health;//actual health
    protected int regenValue; //health regen value
    protected int regenTime; // ??

    //movement
    protected Vector3 vel = Vector3.zero; // current speed and direction
    protected Vector3 acc = Vector3.zero; // current acc
    
    //other
    protected LayerMask layerMask; // collision mask
    protected Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetMaxHealth();

        foreach (Weapon weapon in weapons)
        {
            weapon.owner = this;
        }

    }

    // Update is called once per frame
    protected void Update()
    {
        transform.position += vel;
        vel += acc;
        acc = Vector3.zero;
    }

    void FixedUpdate(){

    }

    void OnCollisionEnter2D(Collision2D collision){

    }

    public void TakeDamage(float value){
        if(!invincible && !hasShield && isAlive){
            health -= value;
            if(health <= 0){
                Byebye();
            }
        }
        hasShield = false;
    }

    public void Heal(float value){
        if(isAlive) health = Mathf.Min(GetMaxHealth(),health+value);
    }

    public void DealDamage(Entity enemy){
        enemy.TakeDamage(GetDamage());
    }

    public void ApplyPowerup(Powerup powerup){

    }

    public void Byebye(){
        isAlive = false;
        Destroy(gameObject);
    }

    public void Attack(){
        if(isAlive && CanAttack()){//isAttacking
            Weapon current = GetWeapon();
            if(!current.UseWeapon()){
                //weapon is broken
                weapons.RemoveAt(currentWeapon);//remove item
                currentWeapon = 0;//change weapon selection
            }
            isAttacking = false;
        }
    }

    public bool CanAttack(){
        Weapon current = GetWeapon();
        return isAlive && Time.time - lastAttackTime >= GetAttackRate();
    }

    public float GetMaxHealth(){
        Weapon current = GetWeapon();
        return baseHealth * current.healthMultiplier + current.healthBonus;
    }

    public float GetDamage(){
        Weapon current = GetWeapon();
        return baseDamage * current.damageMultiplier + current.damageBonus;
    }

    public float GetSpeed(){
        Weapon current = GetWeapon();
        return baseSpeed * current.speedMultiplier + current.speedBonus;
    }

    public float GetAttackRate(){
        return baseAttackRate * GetWeapon().attackRateMultiplier;
    }

    public void ApplyShield(){
        if(isAlive){
            hasShield = true;
        }
    }

    public Weapon GetWeapon(){
        return weapons[currentWeapon];
    }
}
