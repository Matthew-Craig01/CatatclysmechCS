using UnityEngine;

public class BuildingSpriteLayer : MonoBehaviour{
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        var pos = transform.position;
        sr.sortingOrder = -(int)pos.y*100 + (int)pos.x;
    }
}
