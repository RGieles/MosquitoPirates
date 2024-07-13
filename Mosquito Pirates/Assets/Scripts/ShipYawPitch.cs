using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipYawPitch : MonoBehaviour
{
    public float rollSpeed = 10f;
    public float pitchSpeed = 10f;
    public float maxRoll = 30f; // Maximum roll in degrees
    public float maxPitch = 30f; // Maximum pitch in degrees
    public float levelingSpeed = 2f; // Speed at which the ship levels out

    private float currentRoll = 0f;
    private float currentPitch = 0f;

    void Update()
    {
        // Get input for roll and pitch
        float rollInput = Input.GetKey(KeyCode.A) ? 1f : Input.GetKey(KeyCode.D) ? -1f : 0f;
        float pitchInput = Input.GetKey(KeyCode.S) ? 1f : Input.GetKey(KeyCode.W) ? -1f : 0f;

        // Calculate new roll and pitch values
        currentRoll += rollInput * rollSpeed * Time.deltaTime;
        currentPitch += pitchInput * pitchSpeed * Time.deltaTime;

        // Clamp the roll and pitch values to their maximums
        currentRoll = Mathf.Clamp(currentRoll, -maxRoll, maxRoll);
        currentPitch = Mathf.Clamp(currentPitch, -maxPitch, maxPitch);

        // Level out the ship when there is no input
        if (rollInput == 0)
        {
            currentRoll = Mathf.Lerp(currentRoll, 0f, levelingSpeed * Time.deltaTime);
        }
        if (pitchInput == 0)
        {
            currentPitch = Mathf.Lerp(currentPitch, 0f, levelingSpeed * Time.deltaTime);
        }

        // Apply the rotation to the ship
        transform.localRotation = Quaternion.Euler(currentPitch, 0f, currentRoll);
    }
}
