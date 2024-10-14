using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using TMPro;
using UnityEngine;
using Utils;

public class RoundController : MonoBehaviour
{
    public int currentRound { get; private set; }
    public EnemyType.T maxEnemy { get; private set; }
    public float enemySpawnDelay { get; private set; }
    public EnemySpawner enemySpawner;
    public SolarPanelSpawner solarPanelSpawner;
    public Power power;
    public float safeTime;
    public TextMeshProUGUI roundText;
    public int startRound;
    public PlayerHealth health;

    private bool isRoundOver = false;

    public ThrowWrench throwWrench;

    private BuildingPlacementManager bpm;

    void Start()
    {
        bpm = GameObject.FindWithTag("BPM").GetComponent<BuildingPlacementManager>();
        if (throwWrench == null)
        {
            throwWrench = FindObjectOfType<ThrowWrench>();
        }

        currentRound = startRound - 1;
        NextRound();
    }

    void Update()
    {
        if (float.IsNaN(enemySpawner.remaining))
        {
            Debug.Log("Waiting for Round 1");
        }

        if (!isRoundOver && enemySpawner.remaining <= 0 && enemySpawner.enemyCount <= 0)
        {
            RoundOver();
        }
    }

    private void RoundOver()
    {
        isRoundOver = true;
        Debug.Log("RoundOver called.");

        ClearScreen();
        power.RoundEnd(currentRound);
        health.Reset();

        throwWrench.enabled = false;

        Time.timeScale = 0;
        Debug.Log("Game paused.");

        bpm.OpenBuyMenu(OnBuyMenuClosed);
    }

    private void GameOver()
    {
        ClearScreen();
        health.Reset();
    }

    private void OnBuyMenuClosed()
    {

        Time.timeScale = 1;

        throwWrench.enabled = true;

        isRoundOver = false;

        NextRound();
    }
    private void ClearScreen()
    {
        var projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (var p in projectiles)
        {
            Destroy(p);
        }
        var wrenches = GameObject.FindGameObjectsWithTag("Wrench");
        foreach (var w in wrenches)
        {
            w.GetComponent<Wrench>().Delete();
        }
        Debug.Log("Screen cleared.");
    }

    private void NextRound()
    {
        Time.timeScale = 1;
        currentRound++;
        roundText.text = "" + currentRound;
        Debug.Log("Round: " + currentRound);
        int totalEnemies;
        var chicken = EnemyType.T.Chicken;
        var snake = EnemyType.T.Snake;
        var frog = EnemyType.T.Frog;
        var bear = EnemyType.T.Bear;
        var rat = EnemyType.T.Rat;
        var dog = EnemyType.T.Dog;
        var last = (EnemyType.T)EnemyType.last;
        (totalEnemies, enemySpawnDelay, maxEnemy) = currentRound switch
        {
            1 => (5, 2f, chicken),
            2 => (10, 1.5f, snake),
            3 => (25, 1f, frog),
            4 => (40, 0.9f, bear),
            5 => (60, 0.8f, rat),
            6 => (80, 0.7f, dog),
            7 => (100, 0.6f, last),
            8 => (120, 0.5f, last),
            9 => (150, 0.4f, last),
            var x => (15 * x, 0.3f * (10 / x), last),
        };
        enemySpawner.setRemaining(totalEnemies);
        solarPanelSpawner.Spawn();
        enemySpawner.safeTime = safeTime;
        Debug.Log("NextRound executed.");
    }
}
