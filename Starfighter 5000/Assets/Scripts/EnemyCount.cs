using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour {

    public Text enemyCountText;
    public int enemyCount;

	// Use this for initialization
	void Start () {
        enemyCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //grab the number of enemies present
        enemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;

        enemyCountText.text = "Enemies Remaining: " + enemyCount;
	}
}
