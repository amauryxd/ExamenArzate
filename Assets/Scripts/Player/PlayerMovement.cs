using UnityEngine;

public class PlayerMovement : InputHandler
{
    [SerializeField]
    private float speed;
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    public void MovePlayer()
    {
        if (!cantMove && !(controllerInput == Vector2.zero))
        {
            transform.position += new Vector3(controllerInput.y, 0, -controllerInput.x) * Time.deltaTime * speed;
        }
    }
    public void RotatePlayer()
    {
        if (!(controllerInput == Vector2.zero))
        {
            Vector3 direction = new Vector3(controllerInput.x, 0f, controllerInput.y);
            Quaternion targetRot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Euler(0, targetRot.eulerAngles.y, 0);
        }
    }
}
