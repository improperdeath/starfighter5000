using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour {

    float volumeMultiplier = 0f;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("soundVol"))
        {
            volumeMultiplier = PlayerPrefs.GetFloat("soundVol");

            AudioListener.volume *= volumeMultiplier;
        }
        else
        {
            AudioListener.volume = 1f;
        }
	}
	
	// Update is called once per frame
	void Update () {
    }
}
