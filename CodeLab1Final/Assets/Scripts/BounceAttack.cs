using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAttack : BaseAttack
{
    public override void Shoot()
    {
        //use BaseAttack Shoot function to also spawn bounceBullet
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
