using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryOnCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //remove health if needed
        if(collision.collider.tag == "Player")
        {
            Debug.Log("Hit player");
        }
        Destroy(gameObject);
    }
}
