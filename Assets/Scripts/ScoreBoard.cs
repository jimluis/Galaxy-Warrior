using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    private static ScoreBoard _instance;

    private int score = 0;
    Text scoreText;

    //public static ScoreBoard _Instance
    //{
    //    get{

    //        if (_instance == null)
    //            return new ScoreBoard();
    //        else
    //            return _instance; 
    //        }
    //}

    public int Score
    {
        get{ return this.score;}
        //set { score = value; }

    }

    void Awake()
    {
        //_instance = this;
        //if (_instance == null)
        //    _instance = this;
        //else if (_instance != this)
            //Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        //SceneController.currentScore += Score;

        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void ScoreHit(int scorePerHit)
    { 
        score = score + scorePerHit;
        scoreText.text = "Score: "+score.ToString();
    }
}
