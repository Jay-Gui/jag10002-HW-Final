using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    //make public variable to drop firePoint into
    public Transform firePoint;

    //grab bullet prefab for shoot function
    public GameObject bulletPrefab;

    //variables for bullet delay
    public float fireRate = 1f;
    private float nextFire = 0f;

    
    public virtual void Update()
    {
        //if left mouse button is pressed down and time is greater than 0
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            //add delay
            nextFire = Time.time + fireRate;
            //and shoot bullet
            Shoot();
        }
    }

    //function for shooting logic
    public virtual void Shoot()
    {
        //when shooting, instantiate bullet at position/rotation of firePoint
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
