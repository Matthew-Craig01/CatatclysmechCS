using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;


public static class Direction
{
    public enum D
    {
        Up,
        Down,
        Left,
        Right
    }

    public static Vector2 ToV(D direction) => direction switch
    {
        D.Up => Vector2.up,
        D.Down => Vector2.down,
        D.Left => Vector2.left,
        D.Right => Vector2.right,
    };

    public static D Closest(Vector2 direction)
    {
        float angle = Vector2.SignedAngle(direction, Vector2.left);
        if (angle < 0)
        {
            angle += 360;
        }
        if (angle >= 325 || angle < 35)
        {
            return D.Left;
        }
        if (angle >= 35 && angle < 145)
        {
            return D.Up;
        }
        if (angle >= 145 && angle < 215)
        {
            return D.Right;
        }
        return D.Down;
    }

    public static D ClosestLR(Vector2 direction)
    {
        float angle = Vector2.SignedAngle(direction, Vector2.left);
        if (angle < 0)
        {
            angle += 360;}
        if (angle >= 270 || angle < 90)
        {
            return D.Left;
        }
        return D.Right;
    }
}
