using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed=10F;
    //private InputSystem_Actions inputActions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        Vector2 direction= new Vector2(hInput, vInput);
        transform.Translate( new Vector3 (hInput, vInput,0)*Time.deltaTime*moveSpeed,Space.World );
    }
}
