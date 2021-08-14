using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    
    private Rigidbody2D rb2d;

    private Vector2 velocity = Vector2.zero;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
       GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            velocity.x = -movementSpeed;
            Move();
        }
        else if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            velocity.x = movementSpeed;
            Move();
        } 
    }

    private void Move()
    {
        rb2d.velocity = velocity;
    }
}
