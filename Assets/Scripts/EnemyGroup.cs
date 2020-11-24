using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{

    public EnemySpawn[] spawns;
    public int spawnRate;
    public int lastSpawn;
    int enemiesLeft;

    // Start is called before the first frame update
    protected void Start()
    {
        GetEnemyCount();
    }

    // Update is called once per frame

    public void Spawn(){
        if(enemiesLeft > 0){
            EnemySpawn rand = GetRandomSpawn();
            if(rand != null && rand.enemyCount > 0){
                enemiesLeft--;
                rand.Spawn();
            }
        }
    }

    //should only run once to get the enemy count then use 'enemiesLeft' property
    private void GetEnemyCount(){
        enemiesLeft = 0;
        foreach(EnemySpawn spawn in spawns){
            enemiesLeft += spawn.enemyCount;
        }
    }

    private EnemySpawn GetRandomSpawn(){
        return spawns.Length == 0 ? null : (spawns[Random.Range(0,spawns.Length-1)]);
    }
}
