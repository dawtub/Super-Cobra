using System.Collections;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject impactEffect;

    Rigidbody2D rb;
    Vector2 moveVelocity;
    Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("StartRocket", 2f);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void StartRocket()
    {
        moveInput = new Vector3(-30, 10);
        moveVelocity = moveInput.normalized * 10;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Obstacle")
        {
            Instantiate(impactEffect, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
