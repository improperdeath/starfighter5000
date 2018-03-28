/************************************************
 * 
 * EnemyScript.cs
 * This is used to handle the enemy ships
 * 
 * March 11th, 2018
 *
 ************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public GameObject redOrb;
    public GameObject greenOrb;
    public GameObject player;
    public GameObject frigate;
    public GameObject enemyGlow;

    public GameObject explosionObj;
    public AudioSource explosion;

    public GameObject scoreObj;

    public GameObject enemyCountObj;

    private bool isPlayer;

    public float speed;

    // Use this for initialization
    void Start()
    {
        speed = 10f;
        //enemyGlow = (Behaviour)GetComponent("Halo");
        enemyCountObj = GameObject.FindGameObjectWithTag("enemyCount");
        player = GameObject.FindGameObjectWithTag("Player");
        frigate = GameObject.FindGameObjectWithTag("Frigate");
        explosionObj = GameObject.FindGameObjectWithTag("boom");
        explosion = explosionObj.GetComponent<AudioSource>();
        //give it 50% chance of targeting player or frigate
        if(Random.Range(1,3) == 1)
        {
            isPlayer = true;
        }
        else
        {
            isPlayer = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        //point at enemy (shooting happens in another script)
        if (isPlayer)
        {
            transform.LookAt(player.transform);
        }
        else
        {
            transform.LookAt(frigate.transform);
        }

        ////slowly move towards frigate
        //if (Time.timeScale == 1)
        //{
        //    var step = speed * Time.deltaTime;
        //    //Debug.Log("Speed: " + speed + "Step: " + step);
        //    transform.position = Vector3.MoveTowards(transform.position, frigate.transform.position, step);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "greenOrb(Clone)")
        {
            //play explosion sound
            explosion.Play();

            //add one to total enemies destroyed
            enemyCountObj.gameObject.GetComponent<EnemyTotalCount>().totalDestroyedShips++;

            //destory object
            Destroy(gameObject);
        }
    }
}