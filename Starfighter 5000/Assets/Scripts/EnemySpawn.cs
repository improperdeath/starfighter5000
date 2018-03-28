using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour {

    public int countOfEnemies = 3;

    public GameObject enemyShip;
    public GameObject frigate;
    public GameObject playerShip;
    public Text waveCount;
    int wave;

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
        wave = 0;
        //change depending on difficulty
        int difficulty = PlayerPrefs.GetInt("difficulty");

        if (difficulty == 1)
        {
            countOfEnemies = 1;
        }
        else if (difficulty == 2)
        {
            countOfEnemies = 3;
        }
        else if (difficulty == 3)
        {
            countOfEnemies = 5;
        }

        spawnedShips = false;
        enemyVector = transform.position;
        playerVector = playerShip.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (spawnedShips == false)
        {
                spawnShips();
                wave++;
                waveCount.text = "Wave: " + wave;

            //increase size of next wave depending on difficulty
            int difficulty = PlayerPrefs.GetInt("difficulty");

            if (difficulty == 1)
            {
                countOfEnemies += 1;
            }
            else if (difficulty == 2)
            {
                countOfEnemies += 3;
            }
            else if (difficulty == 3)
            {
                countOfEnemies += 5;
            }
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
        for (int i = 0; i < countOfEnemies; i++)
        {
            step = speed * Time.deltaTime;
            //randomLocation = Random.insideUnitSphere * 2000;      //inside playarea (including frigate... bad news here)
            randomLocation = Random.insideUnitSphere * 2000;      //inside playarea (including frigate... bad news here)
            //verify random location
            if(Vector3.Distance(randomLocation, frigate.transform.position) < 600)
            {
                randomLocation = Random.onUnitSphere * 2000;
            }
            //randomLocation = Random.onUnitSphere * 2000;            //on surface of playarea
            rotation = Vector3.RotateTowards(enemyVector, playerVector, step, 0.0f);
            rotationQuaternion = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
            GameObject enemyShipSpawn = Instantiate(enemyShip, randomLocation, rotationQuaternion);
            enemyShipSpawn.transform.LookAt(frigate.transform);
        }
    }
}
