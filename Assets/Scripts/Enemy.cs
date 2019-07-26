using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hits = 3;
    ScoreBoard scoreBoard;

    void Start()
    {
        AddBoxCollider();
        //Getting a reference of the ScoreBoard during runtime
        scoreBoard = FindObjectOfType<ScoreBoard>();

    }

    void Update()
    {
        //transform.LookAt(Camera.main.transform.position);

    }


    void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHits();

        if (hits <= 0)
            KillEnemy();
    }

    private void ProcessHits()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hits--;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
