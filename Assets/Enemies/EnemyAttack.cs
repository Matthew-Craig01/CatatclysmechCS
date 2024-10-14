using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform target;
    public GameObject projectilePrefab;
    private EnemyAI ai;
    public float delay;
    private float lastAttack;
    public int count;
    public int spacingDegrees;
    public Vector2 direction {get; private set;} = Vector2.up;

    void Start()
    {
        ai = GetComponent<EnemyAI>();
    }

    void Update()
    {
        if (!ai.attacking)
        {
            return;
        }

        if (Time.time - lastAttack > delay)
        {
            lastAttack = Time.time;
            Attack();
        }
    }

    void Attack()
    {
        var patternGO = new GameObject("projectile pattern");
        patternGO.transform.SetParent(gameObject.transform);
        var pattern = patternGO.AddComponent<ProjectilePattern>();

        direction = (Vector2)(target.position - transform.position).normalized;
        pattern.init(projectilePrefab, transform.position, direction);

        pattern.SpawnSpaced(count, spacingDegrees);
    }
}
