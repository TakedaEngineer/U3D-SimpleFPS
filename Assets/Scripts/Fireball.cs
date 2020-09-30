using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Parameters of the fireball
    public float speed = 10.0f;
    public int damage = 1;

    // Update is called once per frame
    void Update()
    {
        // Fireball continues to travel in a straight path
        transform.Translate(0, 0, speed * Time.deltaTime);        
    }

    // Function called when another object collides with this trigger
    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        // Check if the fireball hit the player
        if (player != null)
        {
            player.Hurt(damage);
        }
        Destroy(this.gameObject);
    }
}
