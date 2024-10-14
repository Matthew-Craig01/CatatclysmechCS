using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePattern : MonoBehaviour
{
    protected GameObject prefab;
    protected Vector2 position;
    protected Vector2 direction;

    public void init(GameObject prefab, Vector2 position, Vector2 direction)
    {
        this.prefab = prefab;
        this.position = position;
        this.direction = direction;
    }


    public void SpawnOne(Vector2 position, Vector2 direction)
    {
        var projectile = Instantiate(prefab, position, new Quaternion());
        var movement = projectile.GetComponent<ProjectileMovement>();
        movement.direction = direction;
    }


    public void SpawnSpaced(int count, int spacing)
    {
        var angle = 0;
        for (int i = 0; i < count; i++) {
            angle = angle*-1;
            if (i % 2 != 0){
                angle += spacing;
            }
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            SpawnOne(position, rotation * direction);
        }
    }
}
