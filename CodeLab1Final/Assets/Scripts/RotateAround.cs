using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    //speed variable for rotation
    public float speed;
    
    //target to rotate around
    public Transform target;

    //set which vector to rotate on
    private Vector3 zAxis = new Vector3(0, 0, 1);
    
    void FixedUpdate()
    {
        //rotate gameObject
        transform.RotateAround(target.position, zAxis, speed);
    }
}
