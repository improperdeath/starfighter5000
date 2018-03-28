/************************************************
 * 
 * FrigateHealth.cs
 * This is used to keep the frigates health 
 * bar updated, and to end game when the
 * frigate is destroyed
 * 
 * Matt Dean, 200372929
 * March 25th, 2018
 *
 ************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FrigateHealth : MonoBehaviour
{
    public GameObject frigateMenuUI;
    public GameObject GUI;

    public AudioSource ambiance;
    public AudioSource BGMusic;
    public AudioSource MenuMusic;
    public AudioSource explosion;

    public Image healthBar;
    float maxHealth = 100f;
    public static float health;

    bool frigateDestroyed;

    // Use this for initialization
    void Start()
    {
        frigateDestroyed = false;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        if(health <= 0 && frigateDestroyed == false)
        {
            frigateDestroyed = true;
            frigateDies();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        damageFrigate(0.5f);
    }

    public void damageFrigate(float damage)
    {
        health -= damage;
    }

    void frigateDies()
    {
        explosion.Play();

        //red cover on screen
        frigateMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //audio
        //stop music and ambiance
        ambiance.Stop();
        BGMusic.Stop();
        MenuMusic.Play();

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
