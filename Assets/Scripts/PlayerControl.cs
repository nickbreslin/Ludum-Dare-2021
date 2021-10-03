using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private CharacterController controller;

    public float movementSpeed = 5.0f;
    public float rotationSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the rigidbody component
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical axis
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        // Normalize the movement vector and make it proportional to the speed per second
        movement = movement.normalized * movementSpeed * Time.deltaTime;

        // Rotate the player
        transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);

        // Move the player
        controller.Move(movement);
    }
}