using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogProjectile : MonoBehaviour
{
    public float duration;
    private float startTime;
    public GameObject miniProjectile;
    public int count;
    public int spacingDegrees;
    public GameObject explosion;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startTime > duration)
        {
            Explosion.ExplodeProjectile(explosion, gameObject, transform.position);
            Destroy(gameObject);
            SpawnProjectiles();
        }
    }

    private void SpawnProjectiles()
    {
        var patternGO = new GameObject("projectile pattern");
        patternGO.transform.SetParent(gameObject.transform);
        var pattern = patternGO.AddComponent<ProjectilePattern>();
        pattern.init(miniProjectile, transform.position, Vector2.up);
        pattern.SpawnSpaced(count, spacingDegrees);
    }
}
