using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    //public fields
    public float health;//actual health
    public bool invisible;//make entity invisible
    public bool invincible;//no damage can be taken
    public bool isAlive;// is Alive

    //base fields
    protected float baseHealth;//max health before modifiers
    protected float baseDamage;//max damage before modifiers
    protected float baseSpeed;//max speed before modifiers
    protected float baseAttackRate;//max attack rate before modifiers

    //attack fields
    protected List<Weapon> weapons;//all weapons that can be used
    protected int currentWeapon; // index of current weapon
    protected bool isAttacking;// started attacking and can deal damage
    protected int lastAttackTime;// time when last attacked (Time.time)
    protected int reloadTime;// seconds to reload
    protected float magSize;//max bullet count
    protected float bulletCount;//actual bullet count
    protected int lastReloadTime;//time start reloading
    protected bool hasShield;// shield effect is on

    //regen
    protected int regenValue; //health regen value
    protected int regenTime; // ??

    //movement
    protected Vector2 vel = Vector2.zero; // current speed and direction
    protected Vector2 acc= Vector2.zero; // current acc
    
    //other
    protected LayerMask layerMask; // collision mask

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate(){

    }

    void OnCollisionEnter2D(Collision2D collision){

    }

    void TakeDamage(float value){
        if(!invincible && !hasShield && isAlive){
            health -= value;
            if(health <= 0){
                Byebye();
            }
        }
        hasShield = false;
    }

    void Heal(float value){
        if(isAlive) health = Mathf.min(GetMaxHealth(),health+value);
    }

    void DealDamage(Entity enemy){
        if(isAlive && isAttacking){
            enemy.TakeDamage(GetDamage());

            Weapon current = getWeapon();
            if(!current.useWeapon()){
                //weapon is broken
                weapons.RemoveAt(currentWeapon);//remove item
                currentWeapon = 0;//change weapon selection
            }
            isAttacking = false;
        }
    }

    void ApplyPowerup(Powerup powerup){

    }

    void Byebye(){
        isAlive = false;
        Destroy(gameObject);
    }

    void Shoot(){

    }

    bool CanShoot(){
        Weapon current = getWeapon();
        return isAlive && bulletCount > 0 && current.isRanged && Time.time - lastAttackTime > GetAttackRate();
    }

    float GetMaxHealth(){
        Weapon current = getWeapon();
        return baseHealth * current.healthMultiplier + current.healthBonus;
    }

    float GetDamage(){
        Weapon current = getWeapon();
        return baseDamage * current.damageMultiplier + current.damageBonus;
    }

    float GetSpeed(){
        Weapon current = getWeapon();
        return baseSpeed * current.speedMultiplier + current.speedBonus;
    }

    float GetAttackRate(){
        return baseAttackRate * getWeapon().attackRateMultiplier;
    }

    void ApplyShield(){
        if(isAlive){
            hasShield = true;
        }
    }

    Weapon getWeapon(){
        return weapons[currentWeapon];
    }
}
