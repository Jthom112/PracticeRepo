using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public int ringValue = 1; // Points awarded per ring

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Add ring to player score
            PlayerManager.instance.AddRing(ringValue);
            Destroy(gameObject); // Remove ring from the scene
        }
    }
}
