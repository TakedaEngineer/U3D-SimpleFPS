using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;    // Serialize the variable to be seen in the Inspector
    private GameObject _enemy;

    // Update is called once per frame
    void Update()
    {
        // Only spawn an enemy if there isn't one already in the scene
        if (_enemy == null)
        {       
            _enemy = Instantiate(enemyPrefab) as GameObject;    // Copies the enemy prefab object
            _enemy.transform.position = new Vector3(0, 1, 0);   // Spawn point for the enemy
            // Generate a random direction for the enemy to face
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}
