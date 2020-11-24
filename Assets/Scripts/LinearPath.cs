using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearPath : Path
{

    public override void MoveEnemy(Enemy enemy)
    {

        enemy.vel = Vector2.down * enemy.speed;

    }


}
