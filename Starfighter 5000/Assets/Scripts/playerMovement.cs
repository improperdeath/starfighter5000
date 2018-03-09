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

public class playerMovement : MonoBehaviour {

    //global character speed
    float playerSpeed = 2.0f;

	// Use this for initialization
	void Start () {
        //lock cursor to playarea
        Cursor.lockState = CursorLockMode.Locked;

    }
	
	// Update is called once per frame
	void Update () {
        movement();
	}

    void movement()
    {
        //y axis will be pivoted via the cursor
        float h = Input.GetAxis("Mouse X") * 3.0f;
        float v = Input.GetAxis("Mouse Y") * 3.0f;
        transform.Rotate(-v, h, 0f);

        //speed up
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, 0f, (2.0f * playerSpeed));
        }

        //slow down
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, 0f, (0.5f * playerSpeed));
        }

        //otherwise move forward at default speed
        else
        {
            transform.Translate(0f, 0f, playerSpeed);
        }

        //strafe left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.1f, 0f, 0f);
        }

        //strafe right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.1f, 0f, 0f);
        }


    }
}
