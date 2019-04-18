using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        StartDeathSequence(collider);
    }

    void StartDeathSequence(Collider collider)
    {
        SendMessage("OnPlayerDeath");
        //if (collider.gameObject.tag == "Enemies")
        //{
        //    print("OnTriggerEnter - Player hit enemies");
        //}
    }
}
