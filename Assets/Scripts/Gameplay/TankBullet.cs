using UnityEngine;

public class TankBullet : MonoBehaviour
{
    public float speed = 16f;
    public Rigidbody2D rb;
    public Transform fakeTarget;

    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = (fakeTarget.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        HeliCollision heli = hitInfo.GetComponent<HeliCollision>();
        if (heli != null)
        {
            GameManager.KilledBy = "Tank";
            heli.TangoDown();
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
