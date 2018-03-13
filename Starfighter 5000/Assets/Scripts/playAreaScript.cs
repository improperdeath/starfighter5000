using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAreaScript : MonoBehaviour {

    public playerMovement otherScript; 

    private void OnTriggerExit(Collider other)
    {
        otherScript.damagePlayer(100f);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
