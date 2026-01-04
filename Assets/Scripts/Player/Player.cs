using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;
    bool isWalking = false;
    
    float bias = 0.1f; // Small bias to prevent floating point precision issues

    private void Update()
    {
        var playerPos = transform.position;
        PlayerMovement();
        isWalking = Vector3.Distance(playerPos, transform.position) > bias;
    }

    private Vector2 PlayerInput()
    {
        Vector2 input = new Vector2();

        if (Input.GetKey(KeyCode.W))
        {
            input.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            input.y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            input.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input.x += 1;
        }

        return input;
        //Debug.Log($"Input Vector: {input}");
    }

    private Vector3 PlayerMovement()
    {
        Vector2 movementInput = new Vector2();
        movementInput = PlayerInput().normalized;
        Vector3 movementDirection = new Vector3(movementInput.x, 0, movementInput.y);

        transform.position +=  movementDirection * Time.deltaTime * moveSpeed;
        if(movementInput.magnitude > 0) //TODO: Eventually, rotation should respond to movement delta, just like walking state not Input.
            transform.forward = Vector3.Slerp(transform.forward,-movementDirection,Time.deltaTime * rotationSpeed); // Smoothly rotate towards movement direction

        return transform.position;

    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
