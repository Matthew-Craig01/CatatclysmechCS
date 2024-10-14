
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private bool started;

    void Update()
    {
        if (started && !GetComponent<ParticleSystem>().IsAlive())
        {
            Destroy(gameObject);
        }
    }

    public void Explode(string colourStr)
    {
        var particles = GetComponent<ParticleSystem>();

        var main = particles.main;
        ColorUtility.TryParseHtmlString(colourStr, out Color colour);
        main.startColor = colour;

        particles.Play();
        started = true;
    }


    public static void ExplodeProjectile(GameObject explosion, GameObject projectile, Vector2 pos)
    {
        var type = projectile.GetComponent<EnemyType>();
        var colour = type.GetColour();
        var go = Instantiate(explosion, pos, Quaternion.identity);
        go.GetComponent<Explosion>().Explode(colour);
    }
}
