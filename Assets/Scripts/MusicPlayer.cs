using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicPlayer : MonoBehaviour
{

    void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
      //  print("FindObjectOfType<MusicPlayer>() "+ FindObjectOfType<MusicPlayer>());
       
         if (numMusicPlayers > 1)
            Destroy(gameObject);

        else
            DontDestroyOnLoad(gameObject);
    }


}
