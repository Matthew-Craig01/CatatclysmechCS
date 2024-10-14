using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float smoothSpeed;
    public float driftAmount;
    public Vector2 shake {get; set;}

    void Start()
    {
        shake = Vector2.zero;
    }

    void Update()
    {
        var newPos = followPlayer() + (Vector3)Mouse.getRelativePosPercent() * driftAmount;

        var smoothed = Vector3.Lerp(transform.position, newPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothed + (Vector3)shake;
    }

    public Rect GetBounds()
    {
        var camera = GetComponent<Camera>();

        var bottomLeft = (Vector2)camera.ViewportToWorldPoint(new Vector2(0, 0));
        var topRight = (Vector2)camera.ViewportToWorldPoint(new Vector2(1, 1));

        float w = topRight.x - bottomLeft.x;
        float h = topRight.y - bottomLeft.y;

        return Rect.MinMaxRect(bottomLeft.x, bottomLeft.y, topRight.x, topRight.y);
    }

    private Vector3 followPlayer()
    {
        var playerPos = player.transform.position;
        var x = playerPos.x;
        var y = playerPos.y;
        return new Vector3(x, y, -10);
    }

}
