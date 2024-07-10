using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic.time = 5;
        backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
