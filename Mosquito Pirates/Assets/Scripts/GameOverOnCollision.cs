using UnityEngine;
using Cinemachine;

public class GameOverOnCollision : MonoBehaviour
{
    public GameObject loseCanvas; // Reference to the game-over canvas
    public CinemachineDollyCart dollyCart; // Reference to the Cinemachine Dolly Cart

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the object tagged as "Ship"
        if (collision.gameObject.CompareTag("Ship"))
        {
            // Activate the game-over canvas
            if (loseCanvas != null)
            {
                loseCanvas.SetActive(true);
            }
            else
            {
                Debug.LogError("Lose canvas is not assigned in the inspector.");
            }

            // Disable the Ship script to stop player movement
            Ship shipScript = collision.gameObject.GetComponent<Ship>();
            if (shipScript != null)
            {
                shipScript.enabled = false;
            }
            else
            {
                Debug.LogError("Ship script is not found on the object tagged as 'Ship'.");
            }

            // Stop the Cinemachine Dolly Cart movement
            if (dollyCart != null)
            {
                dollyCart.m_Speed = 0;
            }
            else
            {
                Debug.LogError("Dolly cart is not assigned in the inspector.");
            }
        }
    }
}
