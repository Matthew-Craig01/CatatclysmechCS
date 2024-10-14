using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float rotationSpeed;
    public Vector3 direction { private get; set; }
    public float liveFor;
    private float startTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startTime > liveFor)
        {
            Destroy(gameObject);
        }
        rb.velocity = direction * speed;
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

}
