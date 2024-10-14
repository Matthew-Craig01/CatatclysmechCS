using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class SolarPanelCollisions : MonoBehaviour
{
    private SolarPanelHealth health;
    public GameObject explosion;

    private void Start()
    {
        health = GetComponent<SolarPanelHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var go = collision.gameObject;
        var tag = go.tag;
        if (!(tag == "Projectile"))
        {
            return;
        }
        Explosion.ExplodeProjectile(explosion, go, transform.position);
        health.Reduce();
        Destroy(go);
    }
}
