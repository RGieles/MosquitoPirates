using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VofAdjust : MonoBehaviour
{
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cam.GetComponent<Camera>().fieldOfView < 150)
        {
            cam.GetComponent<Camera>().fieldOfView += 1.25f * Time.deltaTime;
        }
    }
}
