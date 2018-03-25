using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour {

    public Text enemyCountText;
    public int enemyCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        enemyCountText.text = "Enemies Remaining: " + enemyCount;
	}
}
