using UnityEngine;

public class LevelDoorChecker : MonoBehaviour
{
    [SerializeField] private int doorOpenNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameManager gameManager;
    void Start()
    {
       gameManager= FindAnyObjectByType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("There is no game manager!!");
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            if (playerHealth.CurrentPlayerNumber >= doorOpenNumber)
            {
                // player success
                gameManager.LevelCompleted();
            }
            else
            { 
            // inform you need more number

            }
        }
    }
}
