using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class UIController : MonoBehaviour
{

    public delegate void SoundController();
    public static event SoundController soundControl;

    [SerializeField] GameObject instructionsPanel;
    [SerializeField] GameObject configPanel;
    [SerializeField] PlayableDirector timeline;
    // Start is called before the first frame update
    [SerializeField] Sprite muteImage;
    [SerializeField] Sprite playImage;
    [SerializeField] Button muteButton;


    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject lostPanel;
    [SerializeField] Text mainScore;
    [SerializeField] Text winPanelScore;
    [SerializeField] Text lostPanelScore;

    [SerializeField] bool isTest = false;

    void Awake()
    {
        if (timeline != null)
            timeline.Pause();
    }

    private void OnEnable()
    {
        PlayerController.displayLostPanel += DisplayLostPanel;
        ScoreBoard.UpdatedUIScoreOnHit += UpdateScore;
        DestroyedEnemy.displayWinPanel += DisplayWinPanel;
    }

    void Start()
    {
        Debug.Log("SceneController.Start - score: "+ mainScore+ " - lostPanelScore: "+ lostPanelScore);
        Debug.Log("SceneController.Start  - SceneController.isInstructionPanelDisplayed:" + SceneController.isInstructionPanelDisplayed);

        if (SceneController.isInstructionPanelDisplayed)
        {
            instructionsPanel.SetActive(false);
            timeline.Play();
        }


        if (isTest)
            timeline.Play();
    }

    public void DisplayConfigMenu()
    {
        if (!configPanel.activeInHierarchy)
        {
            timeline.Pause();
            configPanel.SetActive(true);
        }

        else
        {
            timeline.Resume();
            configPanel.SetActive(false);
        }

    }


    public void ToggleSoundImage()
    {
        Sprite image = muteButton.GetComponent<Image>().sprite;

        if(image.name == "Play")
        {
            soundControl?.Invoke();
            muteButton.GetComponent<Image>().sprite = muteImage ;
        }
        else
        { 
            soundControl?.Invoke();
            muteButton.GetComponent<Image>().sprite = playImage;
        }
    }

    public void DismissInstructionPanel()
    {
        instructionsPanel.SetActive(false);
        timeline.Play();
        SceneController.isInstructionPanelDisplayed = true;
    }


    public void DisplayLostPanel()
    {
        Debug.Log("UIController.DisplayLostPanel - timeline:" + timeline + "lostPanel: " + lostPanel + " ScoreBoard._Instance.Score.ToString(): " + ScoreBoard._Instance.Score.ToString());

        timeline.Stop();
        lostPanel.SetActive(true);
        lostPanelScore.text = "Score: " + ScoreBoard._Instance.Score.ToString();
    }

    public void DisplayWinPanel()
    {
        Debug.Log("UIController.DisplayWinPanel - timeline:" + timeline + "lostPanel: " + lostPanel + " ScoreBoard._Instance.Score.ToString(): " + ScoreBoard._Instance.Score.ToString());
       
        timeline.Stop();
        winPanel.SetActive(true);
        winPanelScore.text = "Score: " + ScoreBoard._Instance.Score.ToString();
    }

    public void UpdateScore()
    {
        Debug.Log("UIController.UpdateScore - score: "+ mainScore + " timeline "+ timeline + " ScoreBoard._Instance.Score.ToString(): " + ScoreBoard._Instance.Score.ToString());
        mainScore.text = "Score: "+ ScoreBoard._Instance.Score.ToString();
    }

    private void OnDisable()
    {
        PlayerController.displayLostPanel -= DisplayLostPanel;
        ScoreBoard.UpdatedUIScoreOnHit -= UpdateScore;
        DestroyedEnemy.displayWinPanel -= DisplayWinPanel;
    }
}
