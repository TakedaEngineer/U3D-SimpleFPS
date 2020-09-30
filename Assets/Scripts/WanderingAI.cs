using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    // Values for the speed of movement and distance from obstacles before reacting
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    // Boolean value to track whether the enemy is alive
    private bool _alive;

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    void Start()
    {
        _alive = true;
    }
    void Update()
    {
        // Target moves forward continuously every frames, regardless of turning
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            // Create a ray at the same position and pointing the same direction as the character
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            // Do raycasting with a circumference around the ray
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                // Player is detected in the same way as the target object in RayShooter
                if (hitObject.GetComponent<PlayerCharacter>() && _fireball == null)
                {
                    _fireball = Instantiate(fireballPrefab) as GameObject;
                    // Place the fireball in front of the enemy and point it in the same direction
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;                    
                }
                // Target turns only when it's close enough to the obstacle
                else if (hit.distance < obstacleRange)
                {
                    // Generate a random angle and rotate the target with that new angle
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    // Function to set the 'alive' state outside this code
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
