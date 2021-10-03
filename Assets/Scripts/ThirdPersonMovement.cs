using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    // Grab the CharacterController component
    public CharacterController controller;

    // Grab the Camera Transform component
    public Transform cam;

    private float speed = 6f;

    // Smooth the turning movement of the character
    private float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    void Update()
    {
        // Get the horizontal and vertical axis.
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Compose a vector representing the direction we want to move in.
        Vector3 direction = new Vector3(x, 0, z).normalized;

        // Check for any change in direction.
        if (direction.sqrMagnitude > 0)
        // If the direction is non-zero, then move the character.
        {
            // Calculate target angle from direction. Add camera's y-rotation to account for camera's rotation.
            float targetAngle =
                Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg +
                cam.eulerAngles.y;

            // Divide the angle by the turnSmoothTime to get the angle per second.
            float angle =
                Mathf
                    .SmoothDampAngle(transform.eulerAngles.y,
                    targetAngle,
                    ref turnSmoothVelocity,
                    turnSmoothTime);

            // Transform the rotation using the newly created subdivisions.
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // Calculate the rotation of movement, then convert it to a direction by multiplying it by the forward struct.
            Vector3 moveDir =
                Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            // use the Move method of the controller to move the character linearly.
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    // Setter for speed
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
