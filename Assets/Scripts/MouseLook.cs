using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Define an enum data structure to associate names with settings
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    // Variable to select the axes
    public RotationAxes axes = RotationAxes.MouseXAndY;
    // Controls the speed of horizontal and vertical rotation
    public float sensitivityHor = 2.0f;
    public float sensitivityVert = 2.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    // Vertical angle
    private float _rotationX = 0;

    // Update is called once per frame
    void Update()
    {
        // Horizontal rotation only
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        // Vertical rotation only
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert); // Limit the camera angle

            // Directly apply the new angle
            transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y, 0);
        }
        // Both horizontal and vertical rotation
        else
        {
            // Vertical rotation
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            // Increment the horizontal rotation by 'delta'
            float delta = Input.GetAxis("Mouse X") * sensitivityHor;

            // Directly apply the new angle
            transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y + delta, 0);
        }
    }
}
