using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    protected Vector2 controllerInput;
    protected bool isShooting = false;
    protected bool cantMove = false;
    void Update()
    {
        //transform.position += new Vector3(controllerInput.x, 0, controllerInput.y);
        if (!(controllerInput == Vector2.zero))
        {
            Vector3 direction = new Vector3(controllerInput.x, 0f, controllerInput.y);
            Quaternion targetRot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Euler(0, targetRot.eulerAngles.y, 0);
            //transform.position += new Vector3(controllerInput.y, 0, -controllerInput.x) * Time.deltaTime * speed;
        }
    }
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
