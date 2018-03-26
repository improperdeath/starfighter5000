/************************************************
 * 
 * FrigateDeathMenu.cs
 * This is used to handle the death screen
 * 
 * March 25th, 2018
 *
 ************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrigateDeathMenu : MonoBehaviour
{

    public GameObject FrigateDeathMenuUI;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
