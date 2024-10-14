// BuildingProjectileMovement.cs
using UnityEngine;

public class BuildingProjectileMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 15f;
    public float rotationSpeed = 0f;
    public Vector3 direction { private get; set; }
    public float liveFor = 5f;
    private float startTime;
    public bool overWalls;
    public Explosion explosion;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startTime > liveFor)
        {
            return;
        }

        rb.velocity = direction * speed;
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var go = collision.gameObject;
        if (collision.CompareTag("Enemy"))
        {
            go.GetComponent<EnemyDie>().Die();
            Destroy(gameObject);
        }
        if (!overWalls && collision.CompareTag("Wall"))
        {
            explosion.Explode("#FFFFFF");
            Destroy(gameObject);
        }
    }
}
