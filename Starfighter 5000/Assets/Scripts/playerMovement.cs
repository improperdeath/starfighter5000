//***********************************************************
/*
 * Matt Dean
 * Used to create movement controls for the player
 * March 9/2018
 */
//***********************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour {

    //gameObjects
    public GameObject fullHealthBar;
    float height;

    //global character speed
    float playerSpeed =0.5f;

    //playerhealth
    float playerHealth;

	// Use this for initialization
	void Start () {
        //lock cursor to playarea
        Cursor.lockState = CursorLockMode.Locked;

        playerHealth = 100f;
    }
	
	// Update is called once per frame
	void Update () {
        movement();

        //check health
        if (playerHealth <= 0)
        {
            playerDies();
        }
    }

    void movement()
    {
        //y axis will be pivoted via the cursor
        float x = (Input.GetAxis("Mouse X") * 3.0f);
        float y = Input.GetAxis("Mouse Y") * 3.0f;
        
        //do rotation by mouse
        transform.Rotate(-y, x, 0f);

        //boost
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0f, 0.3f, (2.0f * playerSpeed));
        }

        //speed up
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, 0.3f, (1f * playerSpeed));
        }

        //back up
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, -0.3f, (-1f * playerSpeed));
        }

        //otherwise move forward at default speed
        else
        {
            transform.Translate(0f, 0f, 0f);
        }

        //strafe left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate((-playerSpeed), 0f, 0f);
        }

        //strafe right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate((playerSpeed), 0f, 0f);
        }

        //hover up
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0f, (playerSpeed), 0f);
        }

        //hover down
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(0f, (-playerSpeed), 0f);
        }

        //rotate left
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, 0f, playerSpeed);
        }

        //rotate right
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, 0f, -playerSpeed);
        }
    }

    void damagePlayer(float amount)
    {
        //update health
        playerHealth -= amount;

        //update healthbar
        HealthBar.health = (playerHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //stop movement
        stopMoving();

        //determine other object
        if(collision.gameObject.name == "frigate")
        {
            damagePlayer(30f);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //stop movement
        stopMoving();

        //determine other object
        if (collision.gameObject.name == "frigate")
        {
            damagePlayer(30f);
        }
    }

    public void playerDies()
    {
        //start death sequence
        //explosion sound


        //red cover on screen


        //death music


        //stop movement and angling
    }

    private void stopMoving()
    {
        GetComponent<Rigidbody>().maxAngularVelocity = 0.0f;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
