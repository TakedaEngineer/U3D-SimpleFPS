using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    // Values for the speed of movement and distance from obstacles before reacting
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    
    // Update is called once per frame
    void Update()
    {
        // Target moves forward continuously every frames, regardless of turning
        transform.Translate(0, 0, speed * Time.deltaTime);

        // Create a ray at the same position and pointing the same direction as the character
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Do raycasting with a circumference around the ray
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            // R
            if (hit.distance < obstacleRange)
            {
                // Generate a random angle and rotate the target with that new angle
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}
