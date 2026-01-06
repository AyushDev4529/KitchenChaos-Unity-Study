using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] GameInput gameInput;
    Vector3 movementDirection;
    Vector3 movementDeltaVector;
    float moveDistance;
    bool isWalking = false;
    
    float bias = 0.1f; // Small bias to prevent floating point precision issues

    private void Update()
    {
        HandleMovement();
    }

    //TODO : to be moved to separate player Interaction Script with IInteractable interface
    //Handle Interaction Logic
    private void HandleInteractions()
    {

    }


    // NOTE: Manual collision resolution experiment. We will change this
    //TODO : to be moved to separate player Movement Script
    //Goal: Understand collision prediction, not implement a full controller.
    // Handle Movement Logic 
    private void HandleMovement()
    {
        moveDistance = Time.deltaTime * moveSpeed;
        var playerPos = transform.position;
        movementDirection = MovementDirection();
        bool canMove = CanMove();

        if (!canMove)
        {

            // Try moving only along the X axis
            movementDirection = MovementDirectionX();
            if (canMove)
            {
                PlayerMovement();
            }
            else
            {
                // Try moving only along the Z axis
                movementDirection = MovementDirectionZ();
                if (canMove)
                {
                    PlayerMovement();
                }
            }


        }

        if (CanMove())
        {
            PlayerMovement();
        }

        movementDeltaVector = transform.position - playerPos;
        isWalking = movementDeltaVector.magnitude > bias;

        if (movementDeltaVector.magnitude > 0)
        {
            PlayerRotation();
        }
    }

    // Move the player based on input and return the new position
    private Vector3 PlayerMovement()
    {
        transform.position += movementDirection * moveDistance;
        return transform.position;
    }

    // Rotate the player to face the movement direction
    private void PlayerRotation()
    {
        transform.forward = Vector3.Slerp(transform.forward, -movementDeltaVector.normalized, Time.deltaTime * rotationSpeed);
    }

    // Get the movement direction based on input
    private Vector3 MovementDirection()
    {
        Vector2 movementInput = new Vector2();
        movementInput = gameInput.GetMovementVector().normalized; // Normalize to prevent faster diagonal movement
        Vector3 movementDirection = new Vector3(movementInput.x, 0, movementInput.y);
        return movementDirection;
    }

    // Get the movement direction along the X axis based on input
    private Vector3 MovementDirectionX()
    {  
        Vector3 movementDirectionX = new Vector3(MovementDirection().x, 0, 0);
        return movementDirectionX;
    }

    // Get the movement direction along the Z axis based on input
    private Vector3 MovementDirectionZ()
    {    
        Vector3 movementDirectionZ = new Vector3(0, 0, MovementDirection().z);
        return movementDirectionZ;
    }



    // Check if the player is currently walking
    public bool IsWalking()
    {
        return isWalking;
    }

    private bool CanMove()
    {
        float playerRadius = 0.7f;
        float playerHight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHight, playerRadius, movementDirection, moveDistance);
        return canMove;
    }
}
