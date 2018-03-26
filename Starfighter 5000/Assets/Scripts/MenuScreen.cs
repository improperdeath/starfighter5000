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
    public Toggle particlesToggleUI;

    public Text difficultyString;

    public bool particlesToggle = true;

    public string MainGame;

	// Use this for initialization
	void Start () {
        int i = PlayerPrefs.GetInt("difficulty");
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

        if (PlayerPrefs.GetInt("particles") == 1)
        {
            particlesToggle = true;
            particlesToggleUI.isOn = true;
        }
        else if (PlayerPrefs.GetInt("particles") == 0)
        {
            particlesToggle = false;
            particlesToggleUI.isOn = false;
        }
        else
        {
            particlesToggle = true;
            particlesToggleUI.isOn = true;
        }

        PlayerPrefs.SetFloat("soundVol", 1f);
        PlayerPrefs.SetFloat("musicVol", 1f);
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
