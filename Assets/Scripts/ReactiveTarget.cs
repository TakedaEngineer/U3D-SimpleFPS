using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    // Method called by the shooting script
    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();

        if (behavior != null)
        {
            // Set the target state to false to indicate the target's current state is dead
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());
    }

    // Coroutine to topple the target and destroy it after 1.5 seconds
    private IEnumerator Die()
    {
        // Topple the target
        this.transform.Rotate(-75, 0, 0);
        // Target remains alive for 1.5 seconds after the hit
        yield return new WaitForSeconds(1.5f);
        // Remove target from the scene
        Destroy(this.gameObject);
    }
}
