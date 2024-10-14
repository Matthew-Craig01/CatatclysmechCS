using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerDash : MonoBehaviour
    {
        public float cooldown;
        private float lastUsed = 0;
        public bool dashing {get; private set;} = false;

        public float distance;
        public float duration;
        private Vector2 direction;
        private float remaining;

        private ParticleSystem trail;

        public GameObject grid;
        private Grass grass;

        private SpriteRenderer sr;
        public Color flash;

        private LayerMask buildings;

        void Start()
        {
            lastUsed = -cooldown;
            trail = GameObject.FindWithTag("DashTrail").GetComponent<ParticleSystem>();
            var main = trail.main;
            main.startLifetime = cooldown + duration;
            grass = grid.GetComponent<Grass>();
            sr = GetComponent<SpriteRenderer>();
            buildings = LayerMask.GetMask("Buildings");
        }

        // Update is called once per frame
        void Update()
        {
            if (dashing)
            {
                ContinueDash();
                return;
            }

            var pressingSpace = Input.GetKeyDown(KeyCode.Space);
            var cooldownExpired = Time.time - lastUsed > cooldown;

            if (pressingSpace && cooldownExpired)
            {
                lastUsed = Time.time;
                dashing = true;
                Dash();
            }
        }

        private void Dash()
        {
            float hor = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");

            direction = Vector2.ClampMagnitude(new Vector2(hor, ver), 1f);
            if (direction == new Vector2(0,0))
            {
                direction = Mouse.getDirection();
            }
            remaining = distance;
            trail.Play();
            sr.color = flash;
            ContinueDash();
        }

        private void ContinueDash()
        {
            float t = Time.deltaTime / duration;
            float d = t*distance;
            if (remaining < d)
            {
                dashing = false;
                trail.Stop();
                Move(remaining);
                sr.color = Color.white;
                return;
            }
            Move(d);
            remaining -= d;
        }

        private void Move(float distance)
        {
            var old = (Vector2)transform.position;
            var change = direction * distance;
            var pos = old + change;
            if (IsBuilding(old, pos))
            {
                return;
            }
            if (grass.CollidesWithBorder(pos))
            {
                direction = (Vector2.zero - pos).normalized;
                transform.position = old + direction*1;
                return;
            }
            transform.position = pos;
        }

        bool IsBuilding(Vector2 oldPos, Vector2 newPos)
        {
            var direction = newPos - oldPos;
            var distance = direction.magnitude;
            var hit = Physics2D.Raycast(oldPos, direction, distance, buildings);
            return hit.collider != null;
        }
    }
}
