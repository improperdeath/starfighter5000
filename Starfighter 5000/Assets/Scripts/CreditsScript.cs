using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour {

    public AudioSource creditsMusic;

    void Start()
    {
        StartCoroutine(EndCredits());
    }

    IEnumerator EndCredits()
    {
        yield return new WaitForSeconds(46);

        SceneManager.LoadScene("menu");
    }
}
