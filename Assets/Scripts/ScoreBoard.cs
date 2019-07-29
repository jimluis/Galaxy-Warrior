using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    private static ScoreBoard instance;
    public delegate void UpdateUIScore();
    public static event UpdateUIScore UpdatedUIScoreOnHit;

    private int score;
    Text scoreText;

    public static ScoreBoard _Instance
    {
        get{

            if (instance == null)
                return new ScoreBoard();
            else
                return instance; 
            }
    }

    public int Score 
    { 
        get
        {
            return score;
        }
    }

    void Awake()
    {
        instance = this;
    }


    void Start()
    {
        score = 0;
    }

    public void ScoreHit(int scorePerHit)
    { 
        score = score + scorePerHit;
        Debug.Log("ScoreBoard.score: " + score);
        UpdatedUIScoreOnHit();
    }
}
