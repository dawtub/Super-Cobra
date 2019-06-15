using UnityEngine;

public class HeliMovement : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    public float joystickSensitivity = 2f;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joystick = GameObject.FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput;
        if (Fuel.FuelLevel > 0 && !PauseMenu.GameIsPaused)
        {
            moveInput = new Vector2(0, joystick.Vertical * joystickSensitivity);
            moveVelocity = moveInput.normalized * speed;
            Fuel.FuelLevel -= 0.05;
        }
        else
        {
            moveInput = new Vector2(30, -75);
            moveVelocity = moveInput.normalized * speed;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
