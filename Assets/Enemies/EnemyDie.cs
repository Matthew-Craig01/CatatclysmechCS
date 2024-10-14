using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using static EnemyType;
using System;

public class EnemyDie : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    public GameObject explosion;
    AudioController audioController;


    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }
    void Start()
    {
        enemySpawner = GameObject.FindWithTag("Enemy Spawner").GetComponent<EnemySpawner>();
    }

    public void Die()
    {
        enemySpawner.Die();
        playDeathSound();
        Explode();
        Destroy(gameObject);
    }

    private void playDeathSound()
    {
        var enemyComponent = GetComponent<EnemyType>();
        T type = enemyComponent.enemyType;
        switch (type)
        {
            case T.Chicken:
                audioController.PlaySFX(audioController.chicken);
                break;
            case T.Snake:
                audioController.PlaySFX(audioController.snake);
                break;
            case T.Frog:
                audioController.PlaySFX(audioController.frog);
                break;
            case T.Bear:
                audioController.PlaySFX(audioController.bear);
                break;
            case T.Rat:
                audioController.PlaySFX(audioController.rat);
                break;
            case T.Dog:
                audioController.PlaySFX(audioController.dog);
                break;
            default:
                Console.WriteLine("Unknown animal.");
                break;
        }
        audioController.PlaySFX(audioController.explosion);
    }
    private void Explode()
    {
        var type = GetComponent<EnemyType>();
        var colour = type.GetColour();
        var go = Instantiate(explosion, transform.position, Quaternion.identity);
        go.GetComponent<Explosion>().Explode(colour);
    }
}
