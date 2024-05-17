using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
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
        ActionReference.Player1.Horizontal.performed += moving =>
        {
            MovementDirection = moving.ReadValue<float>();
        };

        //Jumping the player
        ActionReference.Player1.Jump.performed += jumping => { JumpThePlayer(); };
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

    //Attempt 2
    /*public float speed = 5;
    private Vector2 movementInput;
    public float JumpingPower = 8f;

    

    public Rigidbody2D rb;

    private void Update()
    {
        transform.Translate (new Vector2 (movementInput.x, movementInput.y) * speed * Time.deltaTime);

       // transform.Translate(new Vector2(0, JumpingPower.y) * speed * Time.deltaTime);        
        


    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void OnJump(InputAction.CallbackContext ctx)
    {
        rb.AddForce(Vector2.up * JumpingPower, ForceMode2D.Impulse);
        JumpingPower = ctx.ReadValue<float>();
    }*/

    //Attempt 1
    //public void OnJump(InputAction.CallbackContext ctx) => JumpingPower = ctx.ReadValue<Vector2>();

}
//Code Reference: https://blog.yarsalabs.com/player-movement-with-new-input-system-in-unity/