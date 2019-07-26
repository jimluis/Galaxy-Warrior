using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    private static ScoreBoard _instance;

    private int score = 0;
    Text scoreText;

    public static ScoreBoard _Instance
    {
        get{

            if (_instance == null)
                return new ScoreBoard();
            else
                return _instance; 
            }
    }

    public int Score
    {
        get{ return score;}
        //set { score = value; }

    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();

    }

    public void ScoreHit(int scorePerHit)
    { 
        score = score + scorePerHit;
        scoreText.text = "Score: "+score.ToString();
    }
}
