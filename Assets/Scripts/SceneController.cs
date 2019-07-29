using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class SceneController : MonoBehaviour
{
    [SerializeField]  GameObject lostPanel;
    [SerializeField]  Text scoreTextButton;
    [SerializeField]  PlayableDirector timeline;
    //public delegate int ScoreChecker();
    //public static event ScoreChecker currentScore;

     void Awake()
    {
        if(timeline != null)
            timeline.Pause();
    }

    void Start()
    {
        Debug.Log("SceneController.Start  - timeline:" + timeline + "lostPanel: " + lostPanel); //+ " ScoreBoard._Instance.Score.ToString(): " + ScoreBoard._Instance.Score.ToString());
       
         PlayerController.displayLostPanel += DisplayLostPanel;
        //panel1 = panel;
        //scoreTextButton1 = scoreTextButton;
        //timeline1 = timeline;
    }
    public void LoadNextLevel()
    {
        int currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if (currentScene == UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
            nextScene = 0;

        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
    }


    public void ReloadLevel()
    {
        int currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene-1);
    }

    public void DisplayLostPanel()
    {
        Debug.Log("LoadEndScene - timeline:" + timeline + "lostPanel: " + lostPanel);// + " ScoreBoard._Instance.Score.ToString(): "+ ScoreBoard._Instance.Score.ToString());

        timeline.Stop();
        lostPanel.SetActive(true);
        //scoreTextButton.text = currentScore.ToString();


    }



}
