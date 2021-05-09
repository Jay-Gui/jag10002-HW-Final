using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSwitch : MonoBehaviour
{
    public enum BulletType
    {
        //set enums for my two bullet types
        RedTriple,
        GreenBurst
    }

    public BulletType bulletType;

    public GameObject playerObj;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if the player runs over the bullet type gameObjects
        if (other.tag == "Player")
        {
            //Debug.Log("Hit!");

            //set all weapon types to false
            playerObj.GetComponent<BaseAttack>().enabled = false;
            playerObj.GetComponent<SpreadAttack>().enabled = false;
            playerObj.GetComponent<BounceAttack>().enabled = false;

            //then switch between whichever one has been picked up
            switch (bulletType)
            {
                case BulletType.RedTriple:
                    playerObj.GetComponent<SpreadAttack>().enabled = true;
                    break;
                case BulletType.GreenBurst:
                    playerObj.GetComponent<BounceAttack>().enabled = true;
                    break;
            }
            //finally, destroy the bullet type sprite
            Destroy(gameObject);
        }
    }
}
