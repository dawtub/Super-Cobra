using UnityEngine;

public class HeliCollision : MonoBehaviour
{
    public GameObject impactEffect;
    public HeliMovement movement;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            TangoDown();
            GameManager.KilledBy = "Collision with Obstacle";
        }
    }

    public void TangoDown()
    {
        Instantiate(impactEffect, GameObject.FindWithTag("Player").transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().EndGame();
    }
}
