using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //declare variables
    public float moveSpeed; //movement speed. can be adjusted in editor
    public Rigidbody2D rb;  //assign player rigidbody to script
    Vector2 movement;  //Vector2 variable that's important for player responding to keystokes/joystick
    

    // Update is called once per frame
    void Update() 
    {
        //updates to movement.x and movement.y allow player to respond to WASD/joystick
        movement.x = Input.GetAxisRaw("Horizontal");  
        movement.y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(movement.x, movement.y) * moveSpeed;
    }

    // Fixed update is called on a set timer and is better for physics
    void FixedUpdate()
    {
        
    }
}
