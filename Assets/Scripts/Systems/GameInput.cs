using UnityEngine;

//TODO : New Input Actions for Interaction
public class GameInput : MonoBehaviour
{
    PlayerInputActions inputActions;

    private void Awake()
    {        
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();
    }
    // Get the movement vector from player input
    public Vector2 GetMovementVector()
    {
        Vector2 input = inputActions.Player.Move.ReadValue<Vector2>(); // Read movement input from the Player action map
        return input;
    }
}
