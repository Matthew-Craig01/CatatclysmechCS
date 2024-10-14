using System;
using UnityEngine;


public class EnemyType : MonoBehaviour
{
    public T enemyType;
    public enum T
    {
        Chicken,
        Snake,
        Frog,
        Bear,
        Rat,
        Dog,
    }

    public const int first = (int)T.Chicken;
    public const int last = (int)T.Dog;

    public string GetColour() => enemyType switch
    {
        EnemyType.T.Chicken => "#FE0000",
        EnemyType.T.Snake => "#34FF00",
        EnemyType.T.Frog => "#FF00FF",
        EnemyType.T.Bear => "#FF7300",
        EnemyType.T.Rat => "#5A6988",
        EnemyType.T.Dog => "#000000",
        EnemyType.T x when (int)x > EnemyType.last => throw new Exception("Invalid Enemy Type"),
        _ => throw new Exception("Forgot to Implement Enemy"),
    };
}
