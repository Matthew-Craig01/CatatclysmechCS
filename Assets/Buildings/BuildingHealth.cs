using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealth : MonoBehaviour
{
    public int max;
    private int current;
    private BuildingCells buildingCells;

    private SpriteRenderer sr;
    private bool isFlashing = false;
    public float flashDuration = 0.2f;

    private HealthBar healthBar;

    void Start()
    {
        healthBar = GetComponent<HealthBar>();
        Reset();
        sr = GetComponent<SpriteRenderer>();
        buildingCells = GameObject.FindWithTag("Grid").GetComponent<BuildingCells>();
    }

    void Update()
    {
        if (current <= 0)
        {
            buildingCells.Remove(transform.position);
            healthBar.Die();
            Destroy(gameObject);
        }
    }

    public void Reduce(int damage)
    {
        current -= damage;
        healthBar.Refresh(current, max);
        StartCoroutine(Flash());
    }

    public void Reduce()
    {
        Reduce(1);
    }

    public void Reset()
    {
        current = max;
        healthBar.Refresh(current, max);
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
