/************************************************
 * 
 * PauseMenu.cs
 * This is used to deal with the pause menu
 * 
 * March 11th, 2018
 *
 ************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GamePaused = false;

    public GameObject GUI;
    public GameObject PauseMenuUI;
    public GameObject DeathMenuUI;
    public GameObject FrigateMenuUI;

    public Scene Menu;

    // Use this for initialization
    void Start() {
        GamePaused = false;
    }

    // Update is called once per frame
    void Update() {
        if ((Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1))
        {
            Debug.Log("ESC pressed");
            if (GamePaused == true)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }
    }

    public void ResumeGame()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        GUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        GUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    #region Buttons
    
    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }

    public void QuitButton()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    #endregion
}
