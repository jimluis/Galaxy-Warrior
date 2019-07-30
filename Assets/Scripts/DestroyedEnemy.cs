using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedEnemy : MonoBehaviour
{

    public delegate void SceneLoader();
    public static event SceneLoader displayWinPanel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy() 
    {
         Debug.Log("I'm gone! (bye, bye)");

        displayWinPanel();

     }
}
