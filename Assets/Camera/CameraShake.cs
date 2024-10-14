using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class CameraShake : MonoBehaviour
{
    private CameraController controller;

    void Start()
    {
        controller = GetComponent<CameraController>();
    }

    public void Shake(float amount, float duration)
    {
        StartCoroutine(ShakeAsync(amount, duration));
    }

    private IEnumerator ShakeAsync(float amount, float duration)
    {
        var t = 0f;
        while (t < duration && Time.timeScale != 0)
        {
            var x = Random.Range(-1f, 1f) * amount;
            var y = Random.Range(-1f, 1f) * amount;

            controller.shake = new Vector2(x, y);
            t += Time.deltaTime;
            yield return null;
        }
        controller.shake = Vector2.zero;
    }
}
