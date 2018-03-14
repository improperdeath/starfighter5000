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
        GameObject Temporary_Bullet_Handler;
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            //sound effect
            laserSource.Play();

            #region Code Grabbed From Video
            //video:
            /*
            https://www.youtube.com/watch?v=FD9HZB0Jn1w
            */
            Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 270);

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