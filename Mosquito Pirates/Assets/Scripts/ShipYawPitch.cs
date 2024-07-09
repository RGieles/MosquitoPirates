using UnityEngine;

public class ShipYawPitch : MonoBehaviour
{
    public float yawSpeed = 100f;  // Speed of yaw (left/right rotation)
    public float pitchSpeed = 50f; // Speed of pitch (up/down rotation)
    public float maxYawAngle = 10f; // Maximum yaw angle
    public float maxPitchAngle = 10f; // Maximum pitch angle

    void Update()
    {
        float yaw = 0f;
        float pitch = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            yaw = -yawSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            yaw = yawSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            pitch = -pitchSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            pitch = pitchSpeed * Time.deltaTime;
        }

        Vector3 currentRotation = transform.localEulerAngles;
        float newYaw = Mathf.Clamp(NormalizeAngle(currentRotation.y + yaw), -maxYawAngle, maxYawAngle);
        float newPitch = Mathf.Clamp(NormalizeAngle(currentRotation.x + pitch), -maxPitchAngle, maxPitchAngle);

        transform.localEulerAngles = new Vector3(newPitch, newYaw, currentRotation.z);
    }

    float NormalizeAngle(float angle)
    {
        angle = angle % 360;
        if (angle > 180)
            angle -= 360;
        else if (angle < -180)
            angle += 360;
        return angle;
    }
}
