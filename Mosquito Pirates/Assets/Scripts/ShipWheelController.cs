using UnityEngine;

public class ShipWheelController : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation

    void Update()
    {
        // Check for input
        if (Input.GetKey(KeyCode.A))
        {
            // Rotate left
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Rotate right
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
    }
}
