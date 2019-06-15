using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public float speed = 20f;

    private void Start()
    {

    }

    void Update()
    {
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
    
    void handleMove()
    {
        transform.Translate(Vector3.left * speed);
    }
}
