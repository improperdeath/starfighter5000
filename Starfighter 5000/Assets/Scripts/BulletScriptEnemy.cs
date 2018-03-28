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
        if (PlayerPrefs.HasKey("difficulty"))
        {
            if (PlayerPrefs.GetInt("difficulty") == 1)
            {
                randomNumber = Random.Range(1, 1000);
            }
            if (PlayerPrefs.GetInt("difficulty") == 2)
            {
                randomNumber = Random.Range(1, 500);
            }
            if (PlayerPrefs.GetInt("difficulty") == 3)
            {
                randomNumber = Random.Range(1, 200);
            }
        }
        else
        {
            randomNumber = Random.Range(1, 500);
        }
        if (randomNumber == 1 && Time.timeScale == 1)
        {
            var newBullet = (GameObject)Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation);
            
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = newBullet.GetComponent<Rigidbody>();

            newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * Bullet_Forward_Force);
            
            Destroy(newBullet, 3.0f);

            //sound effect
            laserSource.Play();
        }
    }
}