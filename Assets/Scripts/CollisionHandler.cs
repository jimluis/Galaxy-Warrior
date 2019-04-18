using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("In seconds")] [SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;

    void OnTriggerEnter(Collider collider)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }

    void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");


        //print("StartDeathSequence - after calling OnPlayerDeath");
        //if (collider.gameObject.tag == "Enemies")
        //{
        //    print("OnTriggerEnter - Player hit enemies");
        //}
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
