using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Spawner : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public float spawnRate = 2f;

    int prefab1Counter = 0;
    int prefab2Counter = 0;
    int prefab3Counter = 0;

    Transform transform;
    float nextSpawn = 0f;
    int whatToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            resetSpawn();
            whatToSpawn = Random.Range(1, 4);
            switch (whatToSpawn)
            {
                case 1:
                    prefab1Counter++;
                    Instantiate(prefab1, transform.position, Quaternion.identity);
                    break;
                case 2:
                    prefab2Counter++;
                    Instantiate(prefab2, transform.position, Quaternion.identity);
                    break;
                case 3:
                    prefab3Counter++;
                    transform.position += new Vector3(0, 0.3f, 0);
                    Instantiate(prefab3, transform.position, Quaternion.identity);
                    break;
            }
            nextSpawn = Time.time + spawnRate;
        }
    }

    void resetSpawn()
    {
        transform.position = new Vector3(12.9f, -3.5f, -2);
    }

    private void OnDestroy()
    {
        Analytics.CustomEvent("SpawnInfo", new Dictionary<string, object>
        {
            { "tanks", prefab1Counter },
            { "canisters", prefab2Counter },
            { "rockets", prefab3Counter }
        });
    }
}