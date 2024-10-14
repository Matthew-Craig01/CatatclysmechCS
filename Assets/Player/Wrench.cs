using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Player
{
    public class Wrench : MonoBehaviour
    {
        public Vector3 direction { private get; set; }
        private Rigidbody2D rb;
        public ThrowWrench throwWrench { private get; set; }
        public GameObject explosion;
        public AudioController audioController;

        private void Awake()
        {
            audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
        }
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            rb.velocity = direction * throwWrench.speed;
            transform.Rotate(0,0, throwWrench.rotationSpeed * Time.deltaTime);

            var wrenchPos = transform.position;
            var playerPos = throwWrench.gameObject.transform.position;
            if ((playerPos - wrenchPos).magnitude > throwWrench.despawnDistance)
            {
                Delete();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var go = collision.gameObject;
            if (go.tag == "Enemy")
            {
                go.GetComponent<EnemyDie>().Die();
                Delete();
            }
            else if (go.tag == "SolarPanel")
            {
                audioController.PlaySFX(audioController.wrench_hit);
                Explode();
                Delete();
                var health = go.GetComponent<SolarPanelHealth>();
                health.Reset();
            }
            else if (go.tag == "Building" || go.tag == "Wall")
            {
                audioController.PlaySFX(audioController.wrench_hit);
                Explode();
                Delete();
                var health = go.GetComponent<BuildingHealth>();
                health.Reset();
            }
            else
            {
                return;
            }
            throwWrench.shake.Shake(throwWrench.shakeAmount, throwWrench.shakeTime);
        }

        public void Delete()
        {
                Destroy(gameObject);
                throwWrench.ReduceWrenchCount();
        }

        private void Explode()
        {
            var yellow = "#FFFF00";
            var go = Instantiate(explosion, transform.position, Quaternion.identity);
            go.GetComponent<Explosion>().Explode(yellow);
        }
    }
}
