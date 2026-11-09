using UnityEngine;

public class LevelDoorChecker : MonoBehaviour
{
    [SerializeField] private int doorOpenNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            if (playerHealth.CurrentPlayerNumber >= doorOpenNumber)
            {
                // player success
            }
            else
            { 
            // inform you need more number
            }
        }
    }
}
