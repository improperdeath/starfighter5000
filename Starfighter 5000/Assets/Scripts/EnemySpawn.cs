using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public int countOfEnemies = 1;

    public GameObject enemyShip;
    public GameObject player;

    public float speed = 0.0f;
    float step;

    bool spawnedShips;
    Vector3 rotation;
    Vector3 randomLocation;

    Vector3 enemyVector;
    Vector3 playerVector;

    Quaternion rotationQuaternion;

	// Use this for initialization
	void Start () {
        spawnedShips = false;
        enemyVector = transform.position;
        playerVector = player.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {

        step = speed * Time.deltaTime;
        randomLocation = Random.insideUnitSphere * 2000; //5 is radius
        rotation = Vector3.RotateTowards(enemyVector, playerVector, step, 0.0f);
        rotationQuaternion = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        Instantiate(enemyShip, randomLocation, rotationQuaternion);
        //if (spawnedShips == false)
        //{
        //    for (int i = 0; i < countOfEnemies; i++)
        //    {
        //        spawnShip();
        //    }
        //}
        //else
        //{
        //    if (GameObject.FindGameObjectsWithTag("enemy").Length < 1)
        //    {
        //        Debug.Log("Enemies: " + countOfEnemies);
        //        spawnedShips = false;
        //    }
        //}
    }

    void spawnShip()
    {
        randomLocation = Random.insideUnitSphere * 2000; //5 is radius
        Instantiate(enemyShip, randomLocation, enemyShip.transform.rotation);
        spawnedShips = true;
        countOfEnemies += 2;
    }
}
