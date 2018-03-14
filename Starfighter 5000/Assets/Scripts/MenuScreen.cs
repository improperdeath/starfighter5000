/************************************************
 * 
 * CameraController.cs
 * This is used to control the main menu screen
 * 
 * March 11th, 2018
 *
 ************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour {

    public GameObject MenuUI;

    public string MainGame;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void PlayButton()
    {
        Debug.Log("Starting game...");
        SceneManager.LoadScene("main");
    }

    public void CreditsButton()
    {
        Debug.Log("Starting credits...");
        SceneManager.LoadScene("credits");
    }

    public void QuitButton()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
