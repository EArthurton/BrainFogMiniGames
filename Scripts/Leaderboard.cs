using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public static Text carsHiScore, objectsHiScore, speedHiScore;
    //public static Text[] carScores, objectScores, speedScores;
    public static List<int> carScores = new List<int>(), objectScores = new List<int>(), speedScores = new List<int>();

    public static List<int> scores = new List<int>();

    void Start()
    {
        carsHiScore = GameObject.Find("Cars Hi Score").GetComponent<Text>();
        objectsHiScore = GameObject.Find("Objects Hi Score").GetComponent<Text>();
        speedHiScore = GameObject.Find("Speed Hi Score").GetComponent<Text>();
    }

    void Update()
    {
        if (carScores.Count > 0)
        {
            foreach (var score in scores)
            {
                carsHiScore.text += score + "\n";
            }
        }
        else
        {
            carsHiScore.text = "No scores.";
        }

        if (speedScores.Count > 0)
        {

            foreach (var score in scores)
            {
                speedHiScore.text += score + "\n";
            }

            scores.Sort();
        }
        else
        {
            speedHiScore.text = "No scores.";
        }
    }
}
