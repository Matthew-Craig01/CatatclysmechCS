using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class BuildingCollisions : MonoBehaviour
{
    private BuildingHealth health;
    public GameObject explosion;

    private void Start()
    {
        health = GetComponent<BuildingHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var go = collision.gameObject;
        var tag = go.tag;
        if (!(tag == "Projectile"))
        {
            return;
        }
        health.Reduce();
        Explosion.ExplodeProjectile(explosion, go, transform.position);
        Destroy(go);
    }
}
