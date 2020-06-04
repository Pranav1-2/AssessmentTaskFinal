using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public GameObject CreatureType;
    public static int scoreValueCannibals = 0;
    public static int scoreValueBoars = 0;
    
    public static int total_killed_boars, total_killed_cannibals;

    public string scoreType;
    Text score;

    //runs at the beginning and defines the components needed for this script
    void Start()
    {
        score = GetComponent<Text>();
        CreatureType = GetComponent<GameObject>();
    }

    //checks if the text object's tag is CannibalText or BoarText so that they can run different texts
    // Update is called once per frame
    void Update()
    {
        if (score.tag == "CannibalText")
        {
            score.text = "Cannibals: " + scoreValueCannibals;
        }

        else if (score.tag == "BoarText")
        {
            score.text = "Boars: " + scoreValueBoars;
        }
    }
}
