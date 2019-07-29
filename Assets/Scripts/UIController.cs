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


    [SerializeField] GameObject lostPanel;
    [SerializeField] Text score;
    [SerializeField] Text lostPanelScore;

    void Awake()
    {
        if (timeline != null)
            timeline.Pause();
    }

    private void OnEnable()
    {
        PlayerController.displayLostPanel += DisplayLostPanel;
        ScoreBoard.UpdatedUIScoreOnHit += UpdateScore;
    }

    void Start()
    {
        Debug.Log("SceneController.Start - score: "+ score+ " - lostPanelScore: "+ lostPanelScore);
        Debug.Log("SceneController.Start  - timeline:" + timeline + "lostPanel: " + lostPanel); 

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

        if(image.name == "Mute")
        {
            soundControl?.Invoke();
            muteButton.GetComponent<Image>().sprite = playImage;
        }
        else
        { 
            soundControl?.Invoke();
            muteButton.GetComponent<Image>().sprite = muteImage;
        }
    }

    public void DismissInstructionPanel()
    {
        instructionsPanel.SetActive(false);
        timeline.Play();
    }


    public void DisplayLostPanel()
    {
        Debug.Log("UIController.DisplayLostPanel - timeline:" + timeline + "lostPanel: " + lostPanel + " ScoreBoard._Instance.Score.ToString(): " + ScoreBoard._Instance.Score.ToString());

        timeline.Stop();
        lostPanel.SetActive(true);
        lostPanelScore.text = "Score: " + ScoreBoard._Instance.Score.ToString();
    }

    public void UpdateScore()
    {
        Debug.Log("UIController.UpdateScore - score: "+ score + " timeline "+ timeline + " ScoreBoard._Instance.Score.ToString(): " + ScoreBoard._Instance.Score.ToString());
        score.text = "Score: "+ ScoreBoard._Instance.Score.ToString();
    }

    private void OnDisable()
    {
        PlayerController.displayLostPanel -= DisplayLostPanel;
        ScoreBoard.UpdatedUIScoreOnHit -= UpdateScore;
    }
}
