using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioSource backgroundAudio;
    [SerializeField] Button textButton;
    Text text;
    void Awake()
    {
        text = textButton.GetComponent<Text>();
        backgroundAudio.Play();

        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
      //  print("FindObjectOfType<MusicPlayer>() "+ FindObjectOfType<MusicPlayer>());
       
         if (numMusicPlayers > 1)
            Destroy(gameObject);

        else
            DontDestroyOnLoad(gameObject);
    }

    public void Mute()
    {
        if (backgroundAudio.isPlaying)
        {
            backgroundAudio.Stop();
            text.text = "Play Music";
        }

        else
        {
            backgroundAudio.Play();
            text.text = "Stop Music";
        }

    }


}
