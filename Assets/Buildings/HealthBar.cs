using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour{
    public GameObject healthBarPrefab;
    public Vector3 healthBarOffset = new Vector2(0, 2f);
    public Vector3 scale = Vector3.one;


    private HealthBarController controller;
    private GameObject instance;



    void Start()
    {
        Vector2 healthBarPosition = transform.position + healthBarOffset;
        instance = Instantiate(healthBarPrefab, healthBarPosition, Quaternion.identity);
        instance.transform.localScale = scale;
        controller = instance.GetComponent<HealthBarController>();
        controller.target = transform;
    }

    public void Refresh(int currentHealth, int maxHealth)
    {
        if (controller == null)
        {
            return;
        }
        float percent = (float)currentHealth / maxHealth;
        controller.UpdateHealth(percent);
    }

    public void Die()
    {
        Destroy(instance);
    }
}
