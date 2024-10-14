// ArcherTower.cs
using UnityEngine;

public class CannonTower : Building
{
    private BuildingProjectilePattern projectilePattern;
    AudioController audioController;

    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }
    protected override void Start()
    {
        base.Start();

        projectilePattern = GetComponent<BuildingProjectilePattern>();
    }

    protected override void Shoot(GameObject target)
    {
        Vector2 direction = (target.transform.position - firePoint.position).normalized;
        projectilePattern.Init(projectilePrefab, direction);
        audioController.PlaySFX(audioController.cannon);
        projectilePattern.SpawnSingleProjectile();
    }
}
