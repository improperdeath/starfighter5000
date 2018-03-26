/************************************************
 * 
 * shipSounds.cs
 * this is used to play the spaceship sounds
 * 
 * March 9th, 2018
 *
 ************************************************/
 
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


    // Use this for initialization
    void Start () {
        boostStartSource.clip = boostStart;
        boostLoopSource.clip = boostLoop;
        boostEndSource.clip = boostEnd;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (PlayerPrefs.HasKey("soundVol"))
            {
                boostStartSource.volume *= (PlayerPrefs.GetFloat("soundVol"));
                boostLoopSource.volume *= (PlayerPrefs.GetFloat("soundVol"));
            }
            else
            {
                boostStartSource.volume *= 1f;
                boostLoopSource.volume *= 1f;
            }
            boostStartSource.Play();
            boostLoopSource.loop = true;
            boostLoopSource.PlayDelayed(0.5f);
        }
        if(Time.timeScale != 1)
        {
            boostEndSource.Stop();
            boostStartSource.Stop();
            boostLoopSource.Stop();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (PlayerPrefs.HasKey("soundVol"))
            {
                boostEndSource.volume *= (PlayerPrefs.GetFloat("soundVol"));
            }
            else
            {
                boostEndSource.volume *= 1f;
            }
            boostLoopSource.Stop();
            boostEndSource.Play();
        }
	}
}
