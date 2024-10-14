using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Utils;
using System.Linq;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public float distance;
    private float last;

    public GameObject chicken;
    public GameObject snake;
    public GameObject frog;
    public GameObject bear;
    public GameObject rat;
    public GameObject dog;

    public Grass grass;

    private RoundController round;

    public int remaining {get; private set;}
    public TextMeshProUGUI remainingText;

    public float safeTime {private get; set;}
    public TextMeshProUGUI countdownText;

    public int enemyCount {get; private set;}

    void Start()
    {
        last = 0;
        round = GameObject.FindWithTag("Round Controller").GetComponent<RoundController>();
    }

    void Update()
    {
        if (remaining <= 0)
        {
            return;
        }
        if (float.IsNaN(safeTime))
        {
            Debug.Log("Waiting for Round 1");
            return;
        }
        if (safeTime > 0)
        {
            countdownText.text = "" + (int)safeTime;
            safeTime -= Time.deltaTime;
            return;
        }
        else
        {
            countdownText.text = "";
        }
        if (Time.time - last > round.enemySpawnDelay)
        {
            var random = (EnemyType.T)Random.Range(EnemyType.first, (int)round.maxEnemy+1);
            SpawnEnemy(random);
        }
    }


    private void SpawnEnemy(EnemyType.T type)
    {
        last = Time.time;
        var (prefab, mTarget, aTarget) = type switch
        {
            EnemyType.T.Chicken => (chicken, transform.parent, transform.parent),
            EnemyType.T.Snake => (snake, transform.parent, transform.parent),
            EnemyType.T.Frog => (frog, transform.parent, transform.parent),
            EnemyType.T.Bear => (bear, transform.parent, transform.parent),
            EnemyType.T.Rat => (rat, transform.parent, transform.parent),
            EnemyType.T.Dog => (dog, transform.parent, transform.parent),
            EnemyType.T x when (int)x > EnemyType.last => throw new Exception("Invalid Enemy Type"),
            EnemyType.T _ => throw new Exception("Forgot to implement enemy type")
        };

        var pos = GetPos();
        var clone = Instantiate(prefab, pos, transform.rotation);
        var movement = clone.GetComponent<EnemyMovement>();
        var ai = clone.GetComponent<EnemyAI>();
        movement.target = mTarget;
        if (!ai.melee)
        {
            var attack = clone.GetComponent<EnemyAttack>();
            attack.target = aTarget;
        }
        enemyCount++;
        remaining--;
    }

    private Vector2 GetPos()
    {
        var tiles = grass.tileWorldList;
        var camera = GameObject.FindGameObjectWithTag("MainCamera")
            .GetComponent<CameraController>().GetBounds();

        var outsideCamera = new List<Vector2>();
        foreach (var tile in tiles)
        {
            if (!camera.Contains(tile))
            {
                outsideCamera.Add(tile);
            }
        }
        var random = Random.Range(0, outsideCamera.Count);
        return outsideCamera [random];
    }

    public void Die()
    {
        enemyCount--;
        remainingText.text = "" + (remaining + enemyCount);
    }

    public void setRemaining(int remaining)
    {
        this.remaining = remaining;
        remainingText.text = "" + (remaining + enemyCount);
    }
}
