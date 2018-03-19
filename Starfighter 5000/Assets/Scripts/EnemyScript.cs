using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    public GameObject redOrb;
    public GameObject greenOrb;
    public GameObject player;
    public GameObject frigate;

    private GameObject enemy;

    // Use this for initialization
    void Start()
    {
        //give it 50% chance of targeting player or frigate
        if(Random.Range(1,2) == 1)
        {
            enemy = player;
        }
        else
        {
            enemy = frigate;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //point at enemy (shooting happens in another script)
        transform.LookAt(enemy.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        if (collision.collider.name == "greenOrb(Clone)")
        {
            Destroy(gameObject);
        }
    }
}