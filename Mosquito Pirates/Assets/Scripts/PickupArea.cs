using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupArea : MonoBehaviour
{
    public GameObject pickupPrefab;
    public float pickupAmount;

    public int randomPlacementFactor;

    void Start()
    {
        for(int i = 0; i < pickupAmount; i++)
        {
            int tempRandomX = Random.Range(-randomPlacementFactor, randomPlacementFactor);
            int tempRandomY = Random.Range(-randomPlacementFactor, randomPlacementFactor);
            int tempRandomZ = Random.Range(-randomPlacementFactor, randomPlacementFactor);

            GameObject newPickUp = Instantiate(pickupPrefab, new Vector3(transform.position.x - tempRandomX,transform.position.y - tempRandomY, transform.position.z - tempRandomZ), Quaternion.identity) as GameObject;
        }
    }
}
