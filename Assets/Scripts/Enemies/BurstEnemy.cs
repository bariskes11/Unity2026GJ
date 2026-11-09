using UnityEngine;

public class BurstEnemy : BaseEnemy
{
    [SerializeField] float distanceToFollow;
    [SerializeField] float burstTimeOut;
    [SerializeField] GameObject bulletGameObject;
    [SerializeField] float bulletSpeed=2F;

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
            SpawnBurst();
        }
    }



    public void SpawnBurst()
    {
        float angleStep = 360f / 8; // 45 degrees for 8 directions

        for (int i = 0; i < 8; i++)
        {
            // 1. Calculate angle in radians
            float angleDeg = i * angleStep;
            float angleRad = angleDeg * Mathf.Deg2Rad;

            // 2. Convert angle into a normalized 2D direction vector
            Vector2 dir = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

            // 3. Spawn and rotate the object to face its movement direction
            Quaternion rotation = Quaternion.Euler(0f, 0f, angleDeg);
            GameObject obj = Instantiate(bulletGameObject, transform.position, rotation);
            obj.transform.up = dir;
            // 4. Move it outward
            if (obj.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
            {
                rb.linearVelocity = dir * bulletSpeed;
            }

            // Optional: Destroy after 3 seconds so they don't stay in the scene forever
            //Destroy(obj, 3f);
        }
    }



}
