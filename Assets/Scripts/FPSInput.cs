using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] // Make CharacterController component mandatory for this script to work
[AddComponentMenu("Control Script/FPS Input")]  // Adds this component to the 'Add Component' menu
public class FPSInput : MonoBehaviour
{
    // Variable that adjusts the movement speed
    public float speed = 6.0f;
    // Variable to reference the Player's CharacterController component
    private CharacterController _charController;
    // Variable for gravity's acceleration
    public float gravity = -9.8f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the CharacterController component that's attached to this object (Player)
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        // Problem with using transform as movement is that the Player freely clips through the wall
        //transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed); // Limit the movement speed of this vector
        movement.y = gravity;   // Apply gravity
        movement *= Time.deltaTime; // Make the movement frame rate independent
        movement = transform.TransformDirection(movement);  // Transform movement vector from local to global coordinates
        _charController.Move(movement); // Use the Charactercontroller to move by that vector
    }
}
