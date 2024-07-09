using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupLane : MonoBehaviour
{
    public GameObject pickupPrefab;
    public int laneLength;
    public float pickupAmount;
    public float turnDegree;

    public int randomPlacementFactor;
    public int safeZone;

    void Start()
    {
        for(int i = 0; i < pickupAmount; i++)
        {
            int tempRandomX = Random.Range(-randomPlacementFactor, randomPlacementFactor);
            int tempRandomY = Random.Range(-randomPlacementFactor, randomPlacementFactor);

            GameObject newPickUp = Instantiate(pickupPrefab, new Vector3((turnDegree * i) + tempRandomX,tempRandomY,safeZone + i*laneLength), Quaternion.identity) as GameObject;
        }
    }
}
