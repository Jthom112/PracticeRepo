using System.Collections;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostSpeed = 30f;        // The speed during boost
    public float boostDuration = 2f;      // How long the boost lasts
    private float originalSpeed;          // To store the original speed of the player

    private bool boosting = false;        // Flag to prevent multiple boosts at the same time

    // OnTriggerEnter is called when the player enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering is the player
        if (other.CompareTag("Player") && !boosting)
        {
            // Get the player's movement controller
            SonicController playerController = other.GetComponent<SonicController>();

            if (playerController != null)
            {
                // Start the speed boost
                StartCoroutine(BoostPlayerSpeed(playerController));
            }
        }
    }

    private IEnumerator BoostPlayerSpeed(SonicController playerController)
    {
        boosting = true;

        // Store the original speed
        originalSpeed = playerController.moveSpeed;

        // Apply the boost speed
        playerController.moveSpeed = boostSpeed;

        // Wait for the duration of the boost
        yield return new WaitForSeconds(boostDuration);

        // Revert to the original speed after boost ends
        playerController.moveSpeed = originalSpeed;

        boosting = false;
    }
}
