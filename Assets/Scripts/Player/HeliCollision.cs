﻿using UnityEngine;

public class HeliCollision : MonoBehaviour
{
    public GameObject impactEffect;
    public HeliMovement movement;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            TangoDown();
        }
    }

    public void TangoDown()
    {
        Instantiate(impactEffect, GameObject.FindWithTag("Player").transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().EndGame();
    }
}
