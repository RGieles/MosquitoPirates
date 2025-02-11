using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ship : MonoBehaviour
{
    public int score;
    public int perPickupScore;

    public TMP_Text scoreLabel;

    float currentSpeed;
    public float baseSpeed;
    public float accel;

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
        thisBody =  GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        accel = 1 * Time.time;
    }

    void Update()
    {
        if(!stopMovement)
        {
            //currentSpeed = baseSpeed * accel;
            //currentTurnSpeed = baseTurnSpeed - decel;

            // thisBody.AddForce(transform.forward * currentSpeed);

            //if(Input.GetKey(KeyCode.A))
            //{
            //    thisBody.AddForce(transform.right * currentTurnSpeed);
            //}

            //if(Input.GetKey(KeyCode.D))
            //{
            //   thisBody.AddForce(transform.right * -currentTurnSpeed);
            //}

            //if(Input.GetKey(KeyCode.W))
            //{
            //   thisBody.AddForce(transform.up * -currentTurnSpeed);
            //}

            //if(Input.GetKey(KeyCode.S))
            //{
            //    thisBody.AddForce(transform.up * currentTurnSpeed);
            //}
            thisBody.velocity = new Vector3();
            thisBody.velocity += transform.right * Input.GetAxis("Horizontal") * horSpeed * Time.deltaTime;
            thisBody.velocity += Vector3.up * Input.GetAxis("Vertical") * vertSpeed * Time.deltaTime;
            thisBody.velocity += transform.forward * forwardSpeed * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        //Ew, tags
        if(coll.gameObject.tag == "BodyPart")
        {
            deathSound.Play();
            stopMovement = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;

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