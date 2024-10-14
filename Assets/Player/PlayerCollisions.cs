using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace Player
{
    public class PlayerCollisions : MonoBehaviour
    {
        private Rigidbody2D rb;
        private SpriteRenderer sr;
        private PlayerDash dash;
        private PlayerHealth health;
        public GameObject explosion;
        public float immuneTime;
        public float shakeTime;
        private float lastHit;
        public Color flash;
        public CameraShake shake;
        public float shakeAmount;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            dash = GetComponent<PlayerDash>();
            health = GetComponent<PlayerHealth>();
            lastHit = Time.time;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (Time.time - lastHit < immuneTime)
            {
                return;
            }
            lastHit = Time.time;
            if (dash.dashing)
            {
                return;
            }
            var go = collision.gameObject;
            var tag = collision.gameObject.tag;
            if (!(tag == "Enemy" || tag == "Projectile"))
            {
                return;
            }
            if (tag == "Projectile")
            {
                Explosion.ExplodeProjectile(explosion, go, transform.position);
                Destroy(go);
            }
            health.Reduce();
            shake.Shake(shakeAmount, shakeTime);
            Flash();
        }

        private void Flash()
        {
            sr.color = flash;
            StartCoroutine(ResetSprite());
        }

        private IEnumerator ResetSprite()
        {
            yield return new WaitForSeconds(immuneTime);
            sr.color = Color.white;
        }
    }
}
