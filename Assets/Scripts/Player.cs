using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public int money;
    // public Powerup[] powerups;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get keyboard input
        vel = Vector3.right *Input.GetAxisRaw("Horizontal")* GetSpeed();//

        if(Input.GetKeyDown("space")){
            Attack();
        }
        base.Update();
    }
}
