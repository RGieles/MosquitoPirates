using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ship : MonoBehaviour
{
    public int score;
    public int perPickupScore;

    public TMP_Text scoreLabel;

    public float baseSpeed;
    public float baseTurnSpeed;

    public GameObject endScreen;

    public bool stopMovement = false;
    Rigidbody thisBody;

    public AudioSource deathSound;
    public AudioSource pickupSound;

    public float vertSpeed;
    public float horSpeed;
    public float forwardSpeed;

    void Start()
    {
        thisBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!stopMovement)
        {
            Vector3 movement = Vector3.zero;
            movement += transform.right * Input.GetAxis("Horizontal") * horSpeed * Time.deltaTime;
            movement += Vector3.up * Input.GetAxis("Vertical") * vertSpeed * Time.deltaTime;
            movement += transform.forward * forwardSpeed * Time.deltaTime;

            thisBody.velocity = movement;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        //Ew, tags
        if (coll.gameObject.tag == "BodyPart")
        {
            deathSound.Play();
            stopMovement = true;
            thisBody.velocity = Vector3.zero;

            int multiplier = coll.gameObject.GetComponent<BodyPart>().GetMultiplier();
            score *= multiplier;
            scoreLabel.text = "" + score;
            Time.timeScale = 0;
            endScreen.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        score += perPickupScore;
        Destroy(coll.gameObject);
        pickupSound.Play();
        scoreLabel.text = "" + score;
    }
}
