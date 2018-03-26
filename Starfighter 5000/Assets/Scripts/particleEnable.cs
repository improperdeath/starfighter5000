using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleEnable : MonoBehaviour {

    public GameObject playarea;
    public GameObject sunParticles;
    public GameObject sunSphere;


    // Use this for initialization
    void Start () {
        //determine if enabled or disabled
        if (PlayerPrefs.HasKey("particles"))
        {
            if(PlayerPrefs.GetInt("particles") == 1)
            {
                //enable playarea and sun particles
                playarea.SetActive(true);
                sunParticles.SetActive(true);

                //disable sphere
                sunSphere.SetActive(false);
            }
            else
            {
                //disable playarea and sun particles
                playarea.SetActive(false);
                sunParticles.SetActive(false);

                //enable sphere
                sunSphere.SetActive(true);
            }
        }
        else
        {
            Debug.Log("particles has no key???");
            //enable playarea and sun particles
            playarea.SetActive(true);
            sunParticles.SetActive(true);
            PlayerPrefs.SetInt("particles", 1);            

            //disable sphere
            sunSphere.SetActive(false);

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
