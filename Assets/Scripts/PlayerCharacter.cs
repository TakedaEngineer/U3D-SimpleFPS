using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int _health;

    // Start is called before the first frame update
    void Start()
    {
        _health = 5;    // Initialize the health value
    }

    public void Hurt(int damage)
    {
        _health -= damage;  // Decrement the player's health
        Debug.Log("Health: " + _health);
    }
}
