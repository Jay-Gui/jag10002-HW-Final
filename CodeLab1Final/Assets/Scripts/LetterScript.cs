using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LetterScript : MonoBehaviour
{
    //health
    public float health = 100;

    //for the shake coroutine
    public Vector3 enemyStartPosition;
    public Vector3 enemyShakePosition;
    
    public float distance = 0.1f;
    public float time = 0.2f;
    private float timer;
    public float xRange = 2;
    public float speed = 5;
    
    //get rigidbody2D
    Rigidbody2D rb;
    
    public bool isShaking = false;

    public void Start()
    {
        enemyStartPosition = transform.position;
    }

    //spawn the next wave of enemies within a set range and at a set y position
    public void Reset()
    {
        if(rb == null){
            rb = GetComponent<Rigidbody2D>();
        }

        transform.position = new Vector2(
            Random.Range(-xRange, xRange),
            50f);

        rb.velocity = Vector2.down * speed;
    }

   //TODO: comment
    void Update()
    {
        if(transform.position.y < -10){
            LetterPool.instance.Push(gameObject);
        }
    }
    
    public void BeginShake()
    {
        //so srry Matt, (asked friends outside of code lab for help) just didn't know what else to do
        StopAllCoroutines();
        StartCoroutine(Shake());
    }
    
    private IEnumerator Shake()
    {
        timer = 0f;

        while (timer < time)
        {
            timer += Time.deltaTime;

            enemyShakePosition = enemyStartPosition + (Random.insideUnitSphere * distance);

            transform.position = enemyShakePosition;

        }

        transform.position = enemyStartPosition;
        yield return null;
    } 

    //set up different damage values and destroy instantiated bullet (except for bounceAttack bullet)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if letter gets hit by bullet
        if (collision.gameObject.tag == "BaseAttack")
        {
            TakeDamage(10);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "SpreadAttack")
        {
            TakeDamage(20);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "BounceAttack")
        {
            TakeDamage(5);
        }
    }
    
    public void TakeDamage(float damageAmt)
    {
        if (health >= 1) // if you have any health at all
        {
            health -= damageAmt; //reduce health by damage
            BeginShake();
            StopAllCoroutines();
        }
        
        //if the health is 0 or below
        if (health <= 0)
        {
            Destroy(gameObject); //die
        }
    }
}
