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
            laserSource.Play();

            #region Code Grabbed From Video
            //video:
            /*
            https://www.youtube.com/watch?v=FD9HZB0Jn1w
            */
            
            Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;            
            
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 0);
            
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
            
            Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);
            
            Destroy(Temporary_Bullet_Handler, 3.0f);
            #endregion
        }
    }
}