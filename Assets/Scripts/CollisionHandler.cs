using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("In seconds")] [SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;

    void OnTriggerEnter(Collider collider)
    {
        //StartDeathSequence();
        //deathFX.SetActive(true);
    }

    void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }

    //void ReloadScene()
    //{
    //    SceneManager.LoadScene(1);
    //}
}
