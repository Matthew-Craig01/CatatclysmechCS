// BuildingProjectilePattern.cs
using UnityEngine;

public class BuildingProjectilePattern : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Vector2 direction = Vector2.right;

    public void Init(GameObject prefab, Vector2 direction)
    {
        this.projectilePrefab = prefab;
        this.direction = direction;
    }

    public void SpawnSingleProjectile()
    {
        SpawnProjectile(firePoint.position, direction);
    }

    public void SpawnSpreadProjectile(int count, float angleSpacing)
    {
        float startingAngle = -((count - 1) * angleSpacing) / 2;
        for (int i = 0; i < count; i++)
        {
            float angle = startingAngle + i * angleSpacing;
            Vector2 rotatedDirection = Quaternion.Euler(0, 0, angle) * direction;
            SpawnProjectile(firePoint.position, rotatedDirection);
        }
    }

    private void SpawnProjectile(Vector2 position, Vector2 direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, position, Quaternion.identity);
        BuildingProjectileMovement movement = projectile.GetComponent<BuildingProjectileMovement>();
        if (movement != null)
        {
            movement.direction = direction.normalized;
        }
    }
}
