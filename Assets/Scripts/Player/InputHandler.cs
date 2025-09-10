using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    protected Vector2 controllerInput;
    protected bool isShooting = false;
    protected bool cantMove = false;

    public void OnMove(InputAction.CallbackContext context)
    {
        controllerInput = context.action.ReadValue<Vector2>();
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        isShooting = context.ReadValueAsButton();
    }
    public void OnStop(InputAction.CallbackContext context)
    {
        cantMove = context.ReadValueAsButton();
    }
}
