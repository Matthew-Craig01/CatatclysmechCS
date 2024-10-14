using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class PlayerAnimations : MonoBehaviour
{
    private Direction.D current;
    private Animator animator;

    void Start()
    {
        current = Direction.D.Down;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        var movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (movement == Vector2.zero)
        {
            animator.speed = 0;
        }
        else
        {
            animator.speed = 1;
        }
        var mouse = Mouse.getDirection();
        var next = Direction.Closest(mouse);
        if (next != current)
        {
            ChangeDirection(next);
        }
        Look(mouse);
    }

    private void ChangeDirection(Direction.D direction)
    {
        current = direction;
        var animation = "Player" + current;
        animator.Play(animation);
    }

    private void Look(Vector2 direction)
    {
        float angle = Vector2.SignedAngle(Direction.ToV(current), direction);
        transform.rotation = Quaternion.Euler(0, 0, angle/2);
    }
}
