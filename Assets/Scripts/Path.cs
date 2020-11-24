using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Path : MonoBehaviour
{
    public Vector2 destination;
    // Start is called before the first frame update


    public abstract void MoveEnemy(Enemy enemy);


}
