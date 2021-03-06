﻿/************************************************
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
    public GameObject ControlsUI;
    public Toggle particlesToggleUI;

    public Text difficultyString;
    public Slider soundSlider;

    public bool particlesToggle = true;

    public string MainGame;

    // Use this for initialization
    void Start() {

        if (PlayerPrefs.HasKey("soundVol") == true)
        {
            soundSlider.value = PlayerPrefs.GetFloat("soundVol");
        }
        else
        {
            soundSlider.value = 1;
            PlayerPrefs.SetFloat("soundVol", 1f);
        }
        int i;
        if (PlayerPrefs.HasKey("difficulty"))
        {
            i = PlayerPrefs.GetInt("difficulty");
        }
        else
        {
            i = 1;
        }
        if (i == 1)
        {
            //set to easy
            difficultyString.text = "Difficulty Set to \"Easy\"";
        }
        else if (i == 3)
        {
            //set to hard
            difficultyString.text = "Difficulty Set to \"Hard\"";
        }
        else
        {
            //set to normal
            difficultyString.text = "Difficulty Set to \"Normal\"";
        }

        if (PlayerPrefs.HasKey("particles"))
        {
            if (PlayerPrefs.GetInt("particles") == 1)
            {
                particlesToggle = true;
                particlesToggleUI.isOn = true;
            }
            else
            {
                particlesToggle = false;
                particlesToggleUI.isOn = false;
            }
        }
        else
        {
            PlayerPrefs.SetInt("particles", 1);
            particlesToggle = true;
            particlesToggleUI.isOn = true;
        }

        PlayerPrefs.SetFloat("soundVol", 1f);
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
        //hide settings and controls canvas
        SettingsUI.SetActive(false);
        ControlsUI.SetActive(false);

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
        //show settings canvas
        SettingsUI.SetActive(true);

        //hide menu and controls canvas
        ControlsUI.SetActive(false);
        MenuUI.SetActive(false);
    }

    public void ControlsButton()
    {
        //hide settings
        SettingsUI.SetActive(false);

        //show controls
        ControlsUI.SetActive(true);
    }

    public void difficultySetting(int i)
    {
        PlayerPrefs.SetInt("difficulty", i);
        if (i == 1)
        {
            //set to easy
            difficultyString.text = "Difficulty Set to \"Easy\"";
        }
        if(i == 2)
        {
            //set to normal
            difficultyString.text = "Difficulty Set to \"Normal\"";
        }
        if(i == 3)
        {
            //set to hard
            difficultyString.text = "Difficulty Set to \"Hard\""; 
        }
    }

    public void MusicSlider(float f)
    {
        PlayerPrefs.SetFloat("musicVol", f);
    }

    public void SoundSlider(float f)
    {
        PlayerPrefs.SetFloat("soundVol", f);
    }

    public void particlesChanged(bool b)
    {
        int temp = 0;
        if (b)
        {
            temp = 1;
        }
        PlayerPrefs.SetInt("particles", temp);

        Debug.Log(PlayerPrefs.GetInt("particles"));
    }
}
