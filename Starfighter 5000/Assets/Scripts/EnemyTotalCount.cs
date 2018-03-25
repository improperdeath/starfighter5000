using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTotalCount : MonoBehaviour {

    public int totalDestroyedShips;

    public Text pauseText;
    public Text dieText;

	// Use this for initialization
	void Start () {
        totalDestroyedShips = 0;
	}
	
	// Update is called once per frame
	void Update () {
        dieText.text = "Total Enemies Destoryed: " + totalDestroyedShips;
        pauseText.text = "Enemies Destoryed: " + totalDestroyedShips;
    }
}
