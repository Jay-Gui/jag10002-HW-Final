using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;
    void Awake()
    {
        //set up singleton
        if (instance == null) 
        {
            DontDestroyOnLoad(gameObject); 
            instance = this; 
        }
        else //if this gameObject already exists
        {
            Destroy(gameObject); //destroy it so that there's only one
        }
    }
}
