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

    public float baseTurnSpeed;
    public float currentTurnSpeed;
    public float decel;

    public Vector3 moveAngle;

    public bool stopMovement = false;
    Rigidbody thisBody;

    public Transform target;

    void Start()
    {
        thisBody =  GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        accel = 1 * Time.time;
        decel = 1 * Time.time;
    }

    void Update()
    {
        if(!stopMovement)
        {
            currentSpeed = baseSpeed * accel;
            currentTurnSpeed = baseTurnSpeed - decel;

             Vector3 targetDirection = target.position - transform.position;

            // The step size is equal to speed times frame time.
            float singleStep = currentSpeed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);


            thisBody.AddForce(transform.forward * currentSpeed);

            if(Input.GetKey(KeyCode.A))
            {
                thisBody.AddForce(transform.right * currentTurnSpeed);
            }

            if(Input.GetKey(KeyCode.D))
            {
               thisBody.AddForce(transform.right * -currentTurnSpeed);
            }

            if(Input.GetKey(KeyCode.W))
            {
               thisBody.AddForce(transform.up * -currentTurnSpeed);
            }

            if(Input.GetKey(KeyCode.S))
            {
                thisBody.AddForce(transform.up * currentTurnSpeed);
            }
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        //Ew, tags
        if(coll.gameObject.tag == "BodyPart")
        {
            stopMovement = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;

            int multiplier = coll.gameObject.GetComponent<BodyPart>().GetMultiplier();
            score *= multiplier;
            scoreLabel.text = "" + score;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        score += perPickupScore;
        Destroy(coll.gameObject);

        scoreLabel.text = "" + score;
    }
}
