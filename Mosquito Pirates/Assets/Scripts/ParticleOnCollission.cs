using UnityEngine;

public class ParticleOnCollision : MonoBehaviour
{
    public ParticleSystem collisionParticle; // Reference to the particle system

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the specific object
        if (collision.gameObject.CompareTag("SpecificObjectTag"))
        {
            // Instantiate the particle system at the collision point
            Instantiate(collisionParticle, collision.contacts[0].point, Quaternion.identity);

            // Optionally, you can play the particle effect directly
            // collisionParticle.Play();

            // You might want to destroy the particle effect after it finishes
            Destroy(collisionParticle.gameObject, collisionParticle.main.duration);
        }
    }
}
