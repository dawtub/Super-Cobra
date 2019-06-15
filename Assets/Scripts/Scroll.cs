using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed = 0.5f;
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0);
        renderer.material.mainTextureOffset = offset;
    }
}
