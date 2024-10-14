using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanelHealth : MonoBehaviour
{
    public int max;
    private int current;
    private BuildingCells buildingCells;
    private SolarPanelSpawner spSpawner;
    private SolarPanelTracker tracker;
    private HealthBar healthBar;
    private bool isFlashing = false;
    public float flashDuration = 0.2f;
    private SpriteRenderer sr;

    void Start()
    {
        tracker = GetComponentInChildren<SolarPanelTracker>();
        spSpawner = GameObject.FindWithTag("Round Controller").GetComponent<SolarPanelSpawner>();
        buildingCells = GameObject.FindWithTag("Grid").GetComponent<BuildingCells>();
        healthBar = GetComponent<HealthBar>();
        sr = GetComponent<SpriteRenderer>();
        tracker.maxHealth = max;
        tracker.health = max;
        Reset();
    }

    void Update()
    {
        if (current <= 0)
        {
            Destroy(gameObject);
            buildingCells.Remove(transform.position);
            spSpawner.Die();
            healthBar.Die();

        }
    }

    public void Reduce(int damage)
    {
        current -= damage;
        healthBar.Refresh(current, max);
        tracker.Shake();
        tracker.health = current;
    }

    public void Reduce()
    {
        Reduce(1);
    }

    public void Reset()
    {
        current = max;
        healthBar.Refresh(current, max);
        tracker.health = current;
    }

    IEnumerator Flash()
    {
        if (!isFlashing)
        {
            isFlashing = true;
            sr.color = Color.red;
            yield return new WaitForSeconds(flashDuration);
            sr.color = Color.white;
            isFlashing = false;
        }
    }
}
