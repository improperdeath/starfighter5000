using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                //Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1;
                //Cursor.visible = false;
            }
        }
	}
}
