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
        GameObject Temporary_Bullet_Handler;
        randomNumber = Random.Range(1, 500);
        if (randomNumber == 1 && Time.timeScale == 1)
        {
            //sound effect
            if (PlayerPrefs.HasKey("soundVol"))
            {
                laserSource.volume *= (PlayerPrefs.GetFloat("soundVol"));
            }
            else
            {
                laserSource.volume *= 1f;
            }
            laserSource.Play();

            #region Code Grabbed From Video
            //video:
            /*
            https://www.youtube.com/watch?v=FD9HZB0Jn1w
            */
            //rotate ship
            //ship.transform.Rotate(90f, 0f, 0f);

            //fire laser
            Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

            //rotate ship back
            //ship.transform.Rotate(90f, 0f, 0f);

            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 0);

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force. 
            Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

            //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
            Destroy(Temporary_Bullet_Handler, 3.0f);
            #endregion
        }
    }
}