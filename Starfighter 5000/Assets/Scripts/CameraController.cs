/************************************************
 * 
 * CameraController.cs
 * This is used to map the camera to the cockpit 
 * of the player
 * 
 * March 9th, 2018
 *
 ************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    public GameObject ship;

    private Vector3 posOffset;
    private float rotOffset;

	// Use this for initialization
	void Start ()
    {
        posOffset = transform.position - player.transform.position;
        rotOffset = -20.993f;
    }

    // Update is called once per frame
    void LateUpdate () {
        transform.position = player.transform.position - posOffset;
        transform.rotation = player.transform.rotation;
        transform.Rotate(rotOffset, 0f, 0f);
    }
}
