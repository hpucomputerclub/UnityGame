using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public Enemy enemyType;
    public int enemyCount;

    public void Spawn(){
        if(enemyCount > 0){
            enemyCount--;
            //ADD SPAWN CODE
            //pick x coord

            //instiantate enemy
        }
    }
}
