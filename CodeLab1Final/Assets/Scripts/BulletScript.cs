using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //speed for bullet
    public float speed;

    //get bullet rigidbody
    public Rigidbody2D rb;

    //lifeTime variable for bullet to eventually be destroyed
    public float lifeTime;
    
    void Start()
    {
        //move rigidbody to the right according to speed 
        rb.velocity = transform.right * speed; 
        
        //destroy bullet after set lifeTime
        Destroy(gameObject, lifeTime);
    }
}
