using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    public GameObject enemy;

    //once you trigger collider, load next level, destroy all words/ammo types, and turn enemy gameObject on
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.instance.GetComponent<ASCIILevelLoader>().CurrentLevel++; 
        Destroy(GameObject.FindWithTag("Enemy"));
        Destroy(GameObject.FindWithTag("Ammo"));
        enemy.SetActive(true);
    }
}
