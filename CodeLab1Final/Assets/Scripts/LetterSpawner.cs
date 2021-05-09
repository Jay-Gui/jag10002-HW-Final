using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner : MonoBehaviour
{
    public float interval = 10f; //time to spawn a new enemy
    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", interval, interval); //call SpawnEnemy after interval time
    }

    void SpawnEnemy()
    {
        //get the instance of the enemy to use for spawning
        GameObject enemy = LetterPool.instance.GetEnemy();
    }
}
