using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{
    //    Invoke("LoadNextLevel", 2f);
    //}

    [SerializeField]  GameObject panel;
    [SerializeField]  Text scoreTextButton;
    [SerializeField]  PlayableDirector timeline;
    ScoreBoard score;

    static GameObject panel1;
    static Text scoreTextButton1;
    static PlayableDirector timeline1;

    private void Start()
    {
        panel1 = panel;
        scoreTextButton1 = scoreTextButton;
        timeline1 = timeline;
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene);
    }

    public static void LoadEndScene()
    {
        Debug.Log("LoadEndScene - timeline:"+ timeline1 + "panel: "+ panel1 + " ScoreBoard._Instance.Score.ToString(): "+ ScoreBoard._Instance.Score.ToString());

        timeline1.Stop();
        panel1.SetActive(true);
        Debug.Log("LoadEndScene - panel: " + panel1);
        Debug.Log("LoadEndScene - ScoreBoard._Instance.Score.ToString(): " + ScoreBoard._Instance.Score.ToString());
        scoreTextButton1.text = ScoreBoard._Instance.Score.ToString();
    }

}
