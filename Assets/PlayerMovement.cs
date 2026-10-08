using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;
    private CharacterController controller;
    private float verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = 0f;
        float z = 0f;

        if (Keyboard.current.wKey.isPressed) z = 1f;
        if (Keyboard.current.sKey.isPressed) z = -1f;
        if (Keyboard.current.dKey.isPressed) x = 1f;
        if (Keyboard.current.aKey.isPressed) x = -1f;

        Vector3 horizontal = new Vector3(x, 0f, z);
        horizontal = Vector3.ClampMagnitude(horizontal, 1f) * speed;

        if (controller.isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 total = horizontal + Vector3.up * verticalVelocity;
        controller.Move(total * Time.deltaTime);
    }
}
