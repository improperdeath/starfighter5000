using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public float Bullet_Forward_Force;


    public AudioClip laserSound;
    public AudioSource laserSource;

    // Use this for initialization
    void Start()
    {
        laserSource.clip = laserSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            var newBullet = (GameObject)Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation);

            newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * Bullet_Forward_Force);

            Destroy(newBullet, 3.0f);

            //sound effect
            laserSource.Play();
        }
    }
}