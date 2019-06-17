using UnityEngine;

public class Bonus : MonoBehaviour
{
    public static int BonusCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BonusCounter++;
            Fuel.Refuel();
            Destroy(gameObject);
        } 
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
