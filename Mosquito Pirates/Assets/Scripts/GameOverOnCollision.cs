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
            GameObject.Find("DeathSound").GetComponent<AudioSource>().Play();
            // Activate the game-over canvas
            if (loseCanvas != null)
            {
                Time.timeScale = 0;
                loseCanvas.SetActive(true);
            }
            else
            {
                Debug.LogError("Lose canvas is not assigned in the inspector.");
            }


        }
    }
}
