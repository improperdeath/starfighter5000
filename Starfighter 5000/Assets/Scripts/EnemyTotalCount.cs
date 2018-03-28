using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTotalCount : MonoBehaviour {

    public int totalDestroyedShips;

    public Text pauseText;
    public Text dieText;
    public Text frigateText;
    public Text difficultyText;
    public Text difficultyTextFrigate;

	// Use this for initialization
	void Start () {
        totalDestroyedShips = 0;
        if (PlayerPrefs.HasKey("difficulty"))
        {
            difficultyText.text = "Difficulty: ";
            difficultyTextFrigate.text = "Difficulty: ";
            if (PlayerPrefs.GetInt("difficulty") == 1)
            {
                //easy
                difficultyText.text += "Easy";
                difficultyTextFrigate.text += "Easy";
            }
            if (PlayerPrefs.GetInt("difficulty") == 2)
            {
                //normal
                difficultyText.text += "Normal";
                difficultyTextFrigate.text += "Normal";
            }
            if (PlayerPrefs.GetInt("difficulty") == 3)
            {
                //hard
                difficultyText.text += "Hard";
                difficultyTextFrigate.text += "Hard";
            }
        }
        else
        {
            difficultyText.text = "Difficulty: Normal";
            difficultyTextFrigate.text = difficultyText.text;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        dieText.text = "Total Enemies Destroyed: " + totalDestroyedShips;
        frigateText.text = "Total Enemies Destroyed: " + totalDestroyedShips;
        pauseText.text = "Enemies Destroyed: " + totalDestroyedShips;
    }
}
