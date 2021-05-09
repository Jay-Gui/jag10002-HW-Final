using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadAttack : BaseAttack
{
    Vector3 aboveBullet, belowBullet;
    
    public override void Shoot()
    {
        //spawn bullets above/below original bullet to create weird spread pattern
        aboveBullet = new Vector3(firePoint.position.x, firePoint.position.y + 1, 0f);
        belowBullet = new Vector3(firePoint.position.x, firePoint.position.y - 1, 0f);
        
        //when shooting, instantiate bullet at position/rotation of firePoint
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletPrefab, aboveBullet, firePoint.rotation);
        Instantiate(bulletPrefab, belowBullet, firePoint.rotation);
    }
}