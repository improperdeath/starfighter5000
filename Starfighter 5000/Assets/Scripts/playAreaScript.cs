using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAreaScript : MonoBehaviour {

    private playerMovement playerScript;

    public GameObject player;

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Left");
        playerScript.isInPlayArea = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        playerScript.isInPlayArea = true;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
