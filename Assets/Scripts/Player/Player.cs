using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] GameInput gameInput;
    Vector3 movementDirection;
    Vector3 movementDeltaVector;
    bool isWalking = false;
    
    float bias = 0.1f; // Small bias to prevent floating point precision issues

    private void Update()
    {
        var playerPos = transform.position;
        movementDirection = MovementDirection();
        PlayerMovement();
        movementDeltaVector = transform.position - playerPos;
        

        isWalking = movementDeltaVector.magnitude > bias;
        if(movementDeltaVector.magnitude > 0 )
        {
            PlayerRotation();
        }
    }

    // Move the player based on input and return the new position
    private Vector3 PlayerMovement()
    {
        transform.position += movementDirection * Time.deltaTime * moveSpeed;
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

    // Check if the player is currently walking
    public bool IsWalking()
    {
        return isWalking;
    }
}
