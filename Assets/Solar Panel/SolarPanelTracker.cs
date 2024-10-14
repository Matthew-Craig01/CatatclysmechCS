using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanelTracker : MonoBehaviour
{
    private CameraController cameraController;
    private SpriteRenderer sr;
    public float borderWidth;
    public float shakeAmount;
    public float shakeDuration;
    private Vector2 shake;
    public int health {private get; set;}
    public int maxHealth {private get; set;}

    void Start()
    {
        cameraController = GameObject.FindWithTag("MainCamera").GetComponent<CameraController>();
        sr = GetComponent<SpriteRenderer>();
        shake = Vector2.zero;
    }

    void Update()
    {
        var cam = cameraController.GetBounds();
        var onScreen = cam.Contains(transform.parent.position);
        if (onScreen)
        {
            sr.enabled = false;
            return;
        }
        sr.enabled = true;
        var percent = ((float)health)/maxHealth;
        var clamped = Mathf.Min(percent + 0.2f, 1);
        sr.color = Color.Lerp(Color.red, Color.white, percent);

        transform.position = GetPos(cam) + shake;
        transform.rotation = GetRotation();
    }

    private Vector2 GetPos(Rect cam)
    {
        var pos = transform.parent.position;
        float x;
        if (pos.x > (cam.xMax - borderWidth))
        {
            x = cam.xMax - borderWidth;
        }
        else if (pos.x < (cam.xMin + borderWidth))
        {
            x = cam.xMin + borderWidth;
        }
        else
        {
            x = pos.x;
        }
        float y;
        if (pos.y > (cam.yMax - borderWidth))
        {
            y = cam.yMax - borderWidth;
        }
        else if (pos.y < (cam.yMin + borderWidth))
        {
            y = cam.yMin + borderWidth;
        }
        else
        {
            y = pos.y;
        }
        return new Vector2(x, y);
    }

    private Quaternion GetRotation()
    {
        var pos = transform.position;
        var spPos = transform.parent.position;
        var direction = (spPos - pos).normalized;
        return Quaternion.FromToRotation(Vector2.down, direction);
    }

    public void Shake()
    {
        StartCoroutine(ShakeAsync());
    }

    private IEnumerator ShakeAsync()
    {
        var t = 0f;
        while (t < shakeDuration)
        {
            var x = Random.Range(-1f, 1f) * shakeAmount;
            var y = Random.Range(-1f, 1f) * shakeAmount;

            shake = new Vector2(x, y);
            t += Time.deltaTime;
            yield return null;
        }
        shake = Vector2.zero;
    }
}
