using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour {

    public int countOfEnemies = 1;

    public GameObject enemyShip;
    public GameObject frigate;
    public GameObject playerShip;
    public Text waveCount;
    public int score;

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
        playerVector = playerShip.transform.position;
        score = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (spawnedShips == false)
        {
            for (int i = 0; i < countOfEnemies; i++)
            {
                spawnShips();             
                waveCount.text = "Wave: " + (((countOfEnemies - 1) / 2) + 1);
            }

            //increase size of next wave
            countOfEnemies += 2;
            spawnedShips = true;
        }
        else
        {
            if (GameObject.FindGameObjectsWithTag("enemy").Length < 1)
            {
                Debug.Log("Enemies: " + countOfEnemies);
                spawnedShips = false;
            }
        }
    }

    void spawnShips()
    {
        step = speed * Time.deltaTime;
        randomLocation = Random.insideUnitSphere * 2000; //5 is radius
        rotation = Vector3.RotateTowards(enemyVector, playerVector, step, 0.0f);
        rotationQuaternion = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        GameObject enemyShipSpawn = Instantiate(enemyShip, randomLocation, rotationQuaternion);
        enemyShipSpawn.transform.LookAt(frigate.transform);
    }
}
