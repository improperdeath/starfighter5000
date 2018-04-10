using UnityEngine;
using System.Collections;

public class BulletScriptEnemy : MonoBehaviour
{
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public float Bullet_Forward_Force;
    public GameObject ship;

    int randomNumber;

    public AudioClip laserSound;
    public AudioSource laserSource;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		//determine difficulty to change speed of bullet firing
        if (PlayerPrefs.HasKey("difficulty"))
        {
            if (PlayerPrefs.GetInt("difficulty") == 1)	//easy
            {
                randomNumber = Random.Range(1, 1000);
            }
            if (PlayerPrefs.GetInt("difficulty") == 2)	//normal
            {
                randomNumber = Random.Range(1, 500);
            }
            if (PlayerPrefs.GetInt("difficulty") == 3)	//hard
            {
                randomNumber = Random.Range(1, 200);
            }
        }
        else
        {
            randomNumber = Random.Range(1, 500);	//default to normal
        }
        if (randomNumber == 1 && Time.timeScale == 1)	//if game is running and it is the time to fire a bullet
        {
			//create bullet
            var newBullet = (GameObject)Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation);

			//push bullet forward
            newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * Bullet_Forward_Force);
            
			//destory bullet after 3 seconds
            Destroy(newBullet, 3.0f);

            //play sound effect
            laserSource.Play();
        }
    }
}