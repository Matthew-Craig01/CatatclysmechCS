using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float distanceLeeway;
    public float updateDelay;
    public Vector2 direction {get; private set;} = Vector2.up;

    private Path path;
    private int waypointI = 0;
    private Seeker seeker;
    private Rigidbody2D rb;
    private float lastUpdate = 0;
    private EnemyAI ai;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        ai = GetComponent<EnemyAI>();
    }


    void Update()
    {
        if (ai.attacking)
        {
            return;
        }

        if (path == null)
        {
            UpdatePath(rb.position, target.position);
            return;
        }

        var waypoints = path.vectorPath;
        if (waypointI >= waypoints.Count)
        {
            UpdatePath(rb.position, target.position);
            return;
        }

        var pos = rb.position;
        var nextPos = (Vector2)waypoints[waypointI];
        AddForce(pos, nextPos);

        var distance = Vector2.Distance(pos, nextPos);
        if (distance < distanceLeeway)
        {
            waypointI++;
        }

        if (Time.time - lastUpdate > updateDelay && seeker.IsDone())
        {
            UpdatePath(pos, target.position);
        }
    }

    void UpdatePath(Vector2 pos, Vector2 targetPos)
    {
        lastUpdate = Time.time;
        seeker.StartPath(pos, targetPos, OnPathComplete);
    }

    void AddForce(Vector2 pos, Vector2 nextPos)
    {
        direction = (nextPos - pos).normalized;
        var force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            waypointI = 0;
        }
    }

}
