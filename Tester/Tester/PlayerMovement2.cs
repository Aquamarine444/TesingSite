using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float MovementSpeed = 8f; //this is players movement speed.
    public float JumpingForce = 8f; //this is players jumping force.
    private float MovementDirection = 0; //this will give the direction of the players movement.
    private InputMaster ActionReference; // reference of the generated c# script form the Input Action
    private Rigidbody2D rb; //player's rigidbody.


    private void Start()
    {
        //Getting the player's rigidbody.
        rb ??= GetComponent<Rigidbody2D>();

        ActionReference = new InputMaster();
        //enabling the Input actions
        ActionReference.Enable();
        //reading the values of the player movement direction for the player.
        ActionReference.Player2.Movement.performed += moving =>
        {
            MovementDirection = moving.ReadValue<float>();
        };

        //Jumping the player
        ActionReference.Player2.Up.performed += jumping => { JumpThePlayer(); };
    }


    private void FixedUpdate()
    {
        //Moving player using rigidbody.
        rb.velocity =
            new Vector2(MovementDirection * MovementSpeed, rb.velocity.y);
    }


    private void JumpThePlayer()
    {
        //Moving player using rigidbody.
        rb.velocity = Vector2.up * JumpingForce;
    }

    //Code Reference: https://blog.yarsalabs.com/player-movement-with-new-input-system-in-unity/
}
