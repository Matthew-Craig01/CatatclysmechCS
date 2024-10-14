using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public bool attacking {get; private set;} = false;
    public Vector2 direction {get; private set;} = Vector2.up;
    private EnemyMovement movement;
    private EnemyAttack attack;
    private Rigidbody2D rb;
    public float switchDelay;
    private float lastSwitch;
    public float attackDistance;
    public bool melee;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<EnemyMovement>();
        attack = GetComponent<EnemyAttack>();
    }

    void Update()
    {
        if (melee)
        {
            attacking = false;
            direction = movement.direction;
            return;
        }
        if (Time.time - lastSwitch < switchDelay)
        {
            return;
        }
        lastSwitch = Time.time;

        direction = attacking ? attack.direction : movement.direction;
        var target = attack.target;
        var distance = Vector2.Distance(rb.position, target.position);
        if (attacking && distance > attackDistance)
        {
            attacking = false;
        }
        if (!attacking && distance < attackDistance)
        {
            attacking = true;
        }
    }
}
