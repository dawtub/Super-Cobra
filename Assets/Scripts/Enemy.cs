using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public float speed = 20f;
    public float fireRate = 1.5f;

    float nextFire;
    Gun gun;

    void Start()
    {
        gun = GetComponent<Gun>();
        nextFire = Time.time;
    }

    void Update()
    {
        Shoot();
        handleMove();
    }
    
    public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Score.ScoreValue += 100;
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Shoot()
    {
        if (Time.time > nextFire)
        {
            gun.Shoot();
            nextFire = Time.time + fireRate;
        }
    }

    void handleMove()
    {
        transform.Translate(Vector3.left * speed); 
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
