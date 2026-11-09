using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10F;

    //private InputSystem_Actions inputActions;
    Rigidbody2D rigidBody2d;
    private Vector2 inputVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        inputVector = new Vector2(hInput, vInput).normalized;
    }
    private void FixedUpdate()
    {
        rigidBody2d.linearVelocity = inputVector * moveSpeed * Time.deltaTime;


    }
}
