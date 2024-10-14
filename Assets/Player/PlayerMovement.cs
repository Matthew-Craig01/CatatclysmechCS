using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Utils;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed;
        public GameObject grid;
        private Grass grass;
        private PlayerDash dash;
        private LayerMask buildings;

        void Start()
        {
            grass = grid.GetComponent<Grass>();
            dash = GetComponent<PlayerDash>();
            buildings = LayerMask.GetMask("Buildings");
        }

        void Update()
        {
            if (dash.dashing)
            {
                return;
            }
            var old = (Vector2)transform.position;
            var movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            var change = movement * speed * Time.deltaTime;
            var pos = old + change;
            if (IsBuilding(old, pos))
            {
                return;
            }
            if (!grass.CollidesWithBorder(pos))
            {
                transform.position = pos;
            }
            else
            {
                var towardsCenter = (Vector2.zero - pos).normalized * 3 * speed * Time.deltaTime;
                transform.position = old + towardsCenter;
            }
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
