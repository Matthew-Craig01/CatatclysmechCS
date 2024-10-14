// Building.cs
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public float range = 1000f;

    public float fireRate = 1f;
    protected float countdown = 0f;

    public GameObject projectilePrefab;
    public Transform firePoint;

    private BuildingAnimation animation;

    protected virtual void Start()
    {
        animation = GetComponentInChildren<BuildingAnimation>();
    }

    protected virtual void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }

        GameObject target = GetNearestEnemy();

        if (target != null)
        {
            animation.Look(target.transform.position);
            if (countdown <= 0f)
            {
                Shoot(target);
                animation.Shoot();
                countdown = 1f / fireRate;
            }
        }
    }

    protected GameObject GetNearestEnemy()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearest = null;
        var shortest = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            var distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < shortest && distance <= range)
            {
                shortest = distance;
                nearest = enemy;
            }
        }

        return nearest;
    }

    protected abstract void Shoot(GameObject target);
}
