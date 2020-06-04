using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndHighscore : MonoBehaviour
{
    public ScoreScript scoreScript;
    Text Score;
    public Text HighScore;
    // Start is called before the first frame update
    void Start()
    {
        Score = GetComponent<Text>();
        HighScore.text = "Highscore: " + PlayerPrefs.GetInt("HighScore").ToString();//gets the value for "Highscore" and changes it to a string
    }

    // Update is called once per frame
    void Update()
    {
        SetScores(); //calls the function SetScore() every frame
    }
    public void SetScores()
    {
        int scores = 100 * ScoreScript.total_killed_boars + 50 * ScoreScript.total_killed_cannibals;
        Score.text = "Score: " + scores; //sets text for Score
        Score.fontSize = 60; //sets fontsize for Score
        Score.color = Color.white; //sets font colour for Score

        if (scores > PlayerPrefs.GetInt("HighScore", 0))
        {
            Debug.Log("New Highscore has been set!");
            PlayerPrefs.SetInt("HighScore", scores); // sets the value for "HighScore" as score if the score is greater than HighScore, It saves the highscore even after you close the game.
            HighScore.text = "Highscore: " + scores.ToString(); //changes the value for scores into a string so it works with the HighScore text
        }
    }
}
