// HealthBarController.cs
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0, 2f, 0);

    public float updateSpeed = 5f;

    private Transform fillTransform;
    private Vector3 initialFillScale;
    private Vector3 initialFillPosition;
    private SpriteRenderer fillSpriteRenderer;

    public Color healthyColor = Color.green;

    public Color damagedColor = Color.red;

    public float damageThreshold = 0.2f;

    void Start()
    {
        Transform fill = transform.Find("Fill");
        fillTransform = fill;
        initialFillScale = fillTransform.localScale;
        initialFillPosition = fillTransform.localPosition;
        fillSpriteRenderer = fillTransform.GetComponent<SpriteRenderer>();

        UpdateHealth(1f);
    }

    public void UpdateHealth(float healthPercent)
    {
        float clampedHealth = Mathf.Clamp01(healthPercent);

        float newScaleX = initialFillScale.x * clampedHealth;
        float newPositionX = initialFillPosition.x - (initialFillScale.x * (1f - clampedHealth)) / 2f;

        Vector3 targetScale = new Vector3(newScaleX, fillTransform.localScale.y, fillTransform.localScale.z);
        Vector3 targetPosition = new Vector3(newPositionX, fillTransform.localPosition.y, fillTransform.localPosition.z);

        fillTransform.localScale = targetScale;
        fillTransform.localPosition = targetPosition;

        if (clampedHealth > damageThreshold)
        {
            fillSpriteRenderer.color = healthyColor;
        }
        else
        {
            fillSpriteRenderer.color = damagedColor;
        }

    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPosition = target.position + offset;
            transform.position = newPosition;

            transform.rotation = Quaternion.identity;
        }
    }
}
