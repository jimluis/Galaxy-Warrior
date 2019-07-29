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
   

    void Start()
    {
  

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DisplayConfigMenu()
    {
        if (!configPanel.activeInHierarchy)
        {
            //soundControl?.Invoke();
            timeline.Pause();
            configPanel.SetActive(true);
        }

        else
        {
            //soundControl?.Invoke();
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
}
