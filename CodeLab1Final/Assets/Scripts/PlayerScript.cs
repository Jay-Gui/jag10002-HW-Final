using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float forceAmount = 5; //variable for force amount

    Rigidbody2D rb2D; //variable for Rigidbody2D
    public CircleCollider2D cc2D; //variable for BoxCollider2D

    //static variable means the value is the same for all objects of this class type and the class itself
    public static PlayerScript instance; //static variable holds player singleton

    //jump height variable
    public float jumpVelocity;
    
    //need to set the layers for when player can jump
    public LayerMask layerMask;
    
    //used to set a jump delay between jumps
    private float canJump = 0;
    
    //create singleton for player
    void Awake()
    {
        if (instance == null) //instance hasn't been set yet
        {
            DontDestroyOnLoad(gameObject); //Dont destroy object when loading new scene
            instance = this; //set instance to object
        }
        else //if instance is already set to object
        {
            Destroy(gameObject); //destroy new object, so there is only ever one
        }
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); //get Rigidbody2D off gameObject
        cc2D = transform.GetComponent<CircleCollider2D>(); //get BoxCollider2D off gameObject
        
        //set which attacks are available at start
        this.gameObject.GetComponent<BaseAttack>().enabled = true;
        this.gameObject.GetComponent<SpreadAttack>().enabled = false;
        this.gameObject.GetComponent<BounceAttack>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A)) //if A is pressed
        {
            rb2D.AddForce(Vector2.left * forceAmount); //go left multiplied by "force" variable
        }

        if (Input.GetKey(KeyCode.D)) //if D is pressed
        {
            rb2D.AddForce(Vector2.right * forceAmount); //go right multiplied by "force" variable
        }
        
        // jump if correct layermasks (ground, platform, enemy) are detected and spacebar is pressed
        if (IsGrounded() && Input.GetButtonUp("Jump") && Time.time > canJump)
        {
            rb2D.velocity = Vector2.up * jumpVelocity;
            canJump = Time.time + 3f;
        }
    }
    
    private bool IsGrounded()
    {
        // use raycast to determine if gameObject is colliding with correct layermasks (ground, platform, enemy)
        RaycastHit2D raycast = Physics2D.BoxCast(cc2D.bounds.center, cc2D.bounds.size, 0f, Vector2.down, .1f, layerMask);
        // Debug.Log(raycast.collider);
        return raycast.collider != null;
    }
}