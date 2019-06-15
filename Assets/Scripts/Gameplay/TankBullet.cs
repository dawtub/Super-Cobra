using UnityEngine;

public class TankBullet : MonoBehaviour
{
    public float speed = 30f;
    public int damage = 40;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        HeliCollision heli = hitInfo.GetComponent<HeliCollision>();
        if (heli != null)
        {
            heli.TangoDown();
        }
        Destroy(gameObject);
    }
}
