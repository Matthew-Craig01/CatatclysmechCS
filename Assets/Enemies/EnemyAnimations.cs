using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class EnemyAnimations : MonoBehaviour
{
    private Direction.D current;
    private Animator animator;
    private SpriteRenderer sr;
    private EnemyAI ai ;
    private EnemyType.T enemyType;
    public bool horizontal;

    void Start()
    {
        current = Direction.D.Down;
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        ai = GetComponent<EnemyAI>();
        enemyType = GetComponent<EnemyType>().enemyType;
    }

    void Update()
    {
        var next = horizontal
            ? Direction.ClosestLR(ai.direction)
            : Direction.Closest(ai.direction);

        if (ai.attacking && animator.speed != 0)
        {
            var animation = getAnimation(next);
            animator.Play(animation);
            animator.speed = 0;
        }
        else
        {
            animator.speed = 1;
        }
        if (next != current)
        {
            ChangeDirection(next);
        }
        Look(ai.direction);
    }

    private String getAnimation(Direction.D direction)
    {
        var animation = enemyType.ToString() + direction.ToString();
        if (direction == Direction.D.Left)
        {

            animation = enemyType + "Right";
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        return animation;
    }

    private void ChangeDirection(Direction.D direction)
    {
        current = direction;
        var animation = getAnimation(current);
        animator.Play(animation);
    }

    private void Look(Vector2 direction)
    {
        float angle = Vector2.SignedAngle(Direction.ToV(current), direction);
        angle /= horizontal ? 4 : 2;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
