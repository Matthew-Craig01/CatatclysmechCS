using UnityEngine;

public class BuildingAnimation : MonoBehaviour{
    private SpriteRenderer sr;
    private Animator animator;
    public string fireAnimation;
    public Transform firePoint;
    private Vector2 originalFirePoint;
    public float fireDistance;
    private bool firing;
    public bool isCatapult;
    private Direction.D current;

    void Update()
    {
        if (firing)
        {
            var state = animator.GetCurrentAnimatorStateInfo(0);

            if (state.normalizedTime >= 1f)
            {
                FirstFrame();
                firing = false;
            }
        }
    }


    void Start()
    {
        originalFirePoint = firePoint.position;
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        FirstFrame();
        firing = false;
        current = Direction.D.Down;
    }

    public void Look(Vector2 target)
    {
        var direction = (target - (Vector2)transform.position).normalized;
        if (isCatapult)
        {
            CatapultLook(direction);
            return;
        }
        transform.rotation = Quaternion.FromToRotation(Vector2.right, direction);
        firePoint.position = originalFirePoint + direction*fireDistance;
    }

    private void CatapultLook(Vector2 direction)
    {
        var next = Direction.Closest(direction);
        if (next != current)
        {
            ChangeDirection(next);
        }
        float angle = Vector2.SignedAngle(Direction.ToV(current), direction);
        angle /= 4;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void ChangeDirection(Direction.D direction)
    {
        current = direction;
        if (direction == Direction.D.Left)
        {

            direction = Direction.D.Right;
            sr.flipX = true;
        }
        else
        {

            sr.flipX = false;
        }
        fireAnimation = "Catapult" + direction;
    }


    public void Shoot()
    {
        firing = true;
        animator.speed = 1;
    }

    private void FirstFrame()
    {
        animator.Play(fireAnimation, -1, 0f);
        animator.speed = 0;
    }
}
