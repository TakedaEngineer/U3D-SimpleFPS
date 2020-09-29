using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    // Reference variable for the camera component
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();   // Get the camera component that's attached to this object
    }

    // Update is called once per frame
    void Update()
    {
        // Triggered when LMB is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Center point of the screen is half the width and height
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            // Create the ray at the position
            Ray ray = _camera.ScreenPointToRay(point);

            RaycastHit hit; // Data structure about the intersection of the ray; coordinate of the intersection and what object was intersected
            if (Physics.Raycast(ray, out hit))  // The raycast fills a referenced variable (hit) with information
            {               
                StartCoroutine(SphereIndicator(hit.point)); // Coroutine to spawn a sphere at intersected ray location
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);   // Create a sphere
        sphere.transform.position = pos;    // Place the sphere at the specified global coordinate
        yield return new WaitForSeconds(1); // Pause coroutine for 1 second
        Destroy(sphere);    // Remove this sphere
    }
}
