using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Path[] paths;
    public int pathIndex;
    // Start is called before the first frame update
    void Start()
    {

        paths[pathIndex].MoveEnemy(this);
        print("Enemy start");

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
