using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

    public GameObject DeathMenuUI;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #region Buttons

    public void MenuButton()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene("scene thing here");
    }

    public void QuitButton()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    #endregion
}
