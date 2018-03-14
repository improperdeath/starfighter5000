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
    public GameObject deathscreen;
    public GameObject GUI;
    float height;
    public GameObject WarningMessage;

    //audio files
    public AudioClip playerExplosion;
    public AudioSource playerExplosionSource;
    public AudioSource ambiance;
    public AudioSource BGMusic;
    public AudioSource MenuMusic;

    public bool isInPlayArea;

    bool playerDead = false;

    //global character speed
    float playerSpeed = 0.5f;

    //playerhealth
    float playerHealth;

	// Use this for initialization
	void Start () {
        //lock cursor to playarea
        Cursor.lockState = CursorLockMode.Locked;

        playerHealth = 100f;

        playerExplosionSource.clip = playerExplosion;

        isInPlayArea = true;

        //run check every second
        InvokeRepeating("CheckPlayArea", 1, 1);
    }
	
	// Update is called once per frame
	void Update () {

        if(Time.timeScale == 1)
        {
            movement();
        }

        //check health
        if (playerHealth <= 0 && playerDead == false)
        {
            playerDies();
        }

        //check if in playarea to determine if we need to show the warning message
        if(isInPlayArea == false)
        {
            //show warning message
            WarningMessage.SetActive(true);
        }
        else
        {
            //stop showing message
            WarningMessage.SetActive(false);
        }
    }

    void CheckPlayArea()
    {
        if(isInPlayArea == false)
        {
            damagePlayer(5f);
            Debug.Log(playerHealth);
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

    public void damagePlayer(float amount)
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
        if (collision.gameObject.name == "frigate")
        {
            damagePlayer(30f);
        }
        if (collision.gameObject.name == "redOrb")
        {
            damagePlayer(5f);
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
        playerDead = true;
        //start death sequence
        //explosion sound
        playerExplosionSource.Play();

        //red cover on screen
        deathscreen.SetActive(true);
        Time.timeScale = 0f;
        GUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //audio
        //stop music and ambiance
        ambiance.Stop();
        BGMusic.Stop();
        MenuMusic.Play();
    }

    private void stopMoving()
    {
        GetComponent<Rigidbody>().maxAngularVelocity = 0.0f;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
