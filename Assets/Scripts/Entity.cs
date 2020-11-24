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

    //attack fields
    protected bool hasShield;// shield effect is on

    //health
    protected float health;//actual health
    protected float maxHealth;

    protected float damage;
    public float speed;
    protected float attackRate;


    //movement
    public Vector3 vel = Vector3.zero; // current speed and direction
    protected Vector3 acc = Vector3.zero; // current acc

    //other
    protected LayerMask layerMask; // collision mask
    protected Rigidbody2D rb;

    // Start is called before the first frame update
    protected virtual void Start()    {
        rb = GetComponent<Rigidbody2D>();
        UpdateMaxHealth();
        UpdateSpeed();
        UpdateDamage();
    }

    // Update is called once per frame
    protected virtual void Update()    {
        //display forward direction
        // Debug.DrawRay (transform.position, transform.right, Color.red, 15f, true);
        transform.position += vel;
        if(Mathf.Abs(transform.position.y) > 10){
            Byebye();
        }
        // vel += acc;
        // acc = Vector3.zero;
    }

    void FixedUpdate()    {

    }

    void OnCollisionEnter2D(Collision2D collision)    {
        Attacker hitObject = collision.gameObject.GetComponent<Attacker>();
        if (hitObject != null)
        {
            DealDamage(hitObject);
        }
    }

    public virtual void UpdateMaxHealth()    {
        maxHealth = baseHealth;
    }

    public virtual void UpdateDamage(){
        damage = baseDamage;
    }

    public virtual void UpdateSpeed(){
        speed = baseSpeed;
    }

    public void TakeDamage(float value)    {
        if (!invincible && !hasShield && isAlive)
        {
            health -= value;
            if (health <= 0)
            {
                Byebye();
            }
        }
        hasShield = false;
    }

    public void Heal(float value)    {
        if (isAlive) health = Mathf.Min(maxHealth, health + value);
    }

    public void DealDamage(Entity enemy)    {
        enemy.TakeDamage(damage);
    }

    public void ApplyPowerup(Powerup powerup)    {

    }

    public void Byebye()    {
        isAlive = false;
        Destroy(gameObject);
    }

    public void ApplyShield()    {
        if (isAlive)
        {
            hasShield = true;
        }
    }
}
