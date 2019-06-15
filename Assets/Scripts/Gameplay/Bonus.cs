using UnityEngine;

public class Bonus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handleMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Fuel.Refuel();
            Destroy(gameObject);
        } 
    }

    void handleMove()
    {
        transform.Translate(Vector3.left * Time.deltaTime);
    }
}
