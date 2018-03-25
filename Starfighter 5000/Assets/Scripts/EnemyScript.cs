using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public GameObject redOrb;
    public GameObject greenOrb;
    public GameObject player;
    public GameObject frigate;

    public AudioSource explosion;

    public GameObject scoreObj;

    public GameObject enemyCountObj;

    private bool isPlayer;

    // Use this for initialization
    void Start()
    {
        enemyCountObj = GameObject.FindGameObjectWithTag("enemyCount");
        player = GameObject.FindGameObjectWithTag("Player");
        //give it 50% chance of targeting player or frigate
        if(Random.Range(1,2) == 1)
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.name == "greenOrb(Clone)")
        {
            //increase score by 10
            scoreObj.GetComponent<ScoreScript>().score += 10;

            //play explosion sound
            explosion.Play();

            //add one to total enemies destroyed
            Debug.Log("BEFORE death: " + enemyCountObj.gameObject.GetComponent<EnemyTotalCount>().totalDestroyedShips);
            enemyCountObj.gameObject.GetComponent<EnemyTotalCount>().totalDestroyedShips++;
            Debug.Log("AFTER death: " + enemyCountObj.gameObject.GetComponent<EnemyTotalCount>().totalDestroyedShips);

            //destory object
            Destroy(gameObject);
        }
    }
}