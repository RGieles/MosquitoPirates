using UnityEngine;
using Cinemachine;

public class EndGameTrigger : MonoBehaviour
{
    public CinemachinePathBase cinemachinePath;
    public GameObject endCanvas;
    public Transform shipTransform;  // Add this line

    private bool gameEnded = false;

    void Start()
    {
        // Ensure endCanvas is initially inactive
        if (endCanvas != null)
        {
            endCanvas.SetActive(false);
            Debug.Log("End canvas set to inactive");
        }
        else
        {
            Debug.LogError("End canvas is not assigned");
        }
    }

    void Update()
    {
        if (!gameEnded && cinemachinePath != null && shipTransform != null)
        {
            // Calculate the distance travelled along the path
            float pathPosition = cinemachinePath.FindClosestPoint(shipTransform.position, -1, -1, 10);

            Debug.Log("Distance Travelled: " + pathPosition);

            // Check if ship has reached the end of the path
            if (pathPosition >= 8.9)
            {
                Debug.Log("End of path reached");
                // Trigger end game sequence
                EndGame();
            }
        }
        else
        {
            if (cinemachinePath == null)
            {
                Debug.LogError("Cinemachine path is not assigned");
            }
            if (shipTransform == null)
            {
                Debug.LogError("Ship transform is not assigned");
            }
        }
    }

    void EndGame()
    {
        // Activate end canvas
        if (endCanvas != null)
        {
            endCanvas.SetActive(true);
            Debug.Log("End game canvas activated");
        }
        else
        {
            Debug.LogError("End canvas is not assigned");
        }

        gameEnded = true; // Prevents multiple triggers
    }
}

