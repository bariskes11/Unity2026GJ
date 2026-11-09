using UnityEngine;

public class BurstEnemy : BaseEnemy
{
    [SerializeField] float distanceToFollow;
    [SerializeField] float burstTimeOut;

    float elapsedTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > burstTimeOut)
        {
            elapsedTime = 0;
            Debug.Log("Now burst numbers around");
        }
    }
}
