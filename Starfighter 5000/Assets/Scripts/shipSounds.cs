using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipSounds : MonoBehaviour {

    public AudioClip boostStart;
    public AudioClip boostLoop;
    public AudioClip boostEnd;
    public AudioSource boostStartSource;
    public AudioSource boostLoopSource;
    public AudioSource boostEndSource;

    public AudioClip playerLaser;
    public AudioSource playerLaserSource;


    // Use this for initialization
    void Start () {
        boostStartSource.clip = boostStart;
        boostLoopSource.clip = boostLoop;
        boostEndSource.clip = boostEnd;

        playerLaserSource.clip = playerLaser;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            boostStartSource.Play();
            boostLoopSource.loop = true;
            boostLoopSource.PlayDelayed(0.5f);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            boostLoopSource.Stop();
            boostEndSource.Play();
        }

        if (Input.GetMouseButtonDown(0))
        {
            playerLaserSource.Play();
        }
	}
}
