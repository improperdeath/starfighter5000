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
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour {

    public GameObject MenuUI;
    public GameObject SettingsUI;

    public bool particlesToggle = true;

    public string MainGame;

	// Use this for initialization
	void Start () {
        particlesToggle = true;
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

    public void MenuBtn()
    {
        //hide settings canvas
        SettingsUI.SetActive(false);

        //show menu canvas
        MenuUI.SetActive(true);

    }

    public void QuitButton()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    public void SettingsButton()
    {
        Debug.Log("starting settings...");

        //hide menu canvas
        MenuUI.SetActive(false);

        //show settings canvas
        SettingsUI.SetActive(true);

    }
}
