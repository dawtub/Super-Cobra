using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject impactEffect;

    Rigidbody2D rb;
    Vector2 moveVelocity;
    Vector2 moveInput;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("StartRocket", 1f);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        rb.MoveRotation(90f);
    }

    void StartRocket()
    {
        moveInput = new Vector3(-15, Random.Range(1, 4));
        moveVelocity = moveInput.normalized * 10;
    }

    void DestroyRocket()
    {
        Instantiate(impactEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DestroyRocket();
            FindObjectOfType<HeliCollision>().TangoDown();
        } else if (collision.gameObject.tag == "Obstacle")
        {
            DestroyRocket();
        }
    }
}
