using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearPath : Path
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveEnemy(Enemy enemy)
    {

        enemy.vel = Vector2.down * enemy.GetSpeed();

    }


}
