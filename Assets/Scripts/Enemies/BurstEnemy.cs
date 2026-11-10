using UnityEngine;

public class BurstEnemy : BaseEnemy
{
    [SerializeField] float distanceToFollow;
    [SerializeField] float burstTimeOut;
    [SerializeField] Projectile bulletGameObject;
    [SerializeField] float bulletSpeed = 2F;

    float elapsedTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= burstTimeOut)
        {
            elapsedTime = 0;
            SpawnBurst();
        }
    }



    public void SpawnBurst()
    {
        float angleStep = 360f / 8; // 45 degrees for 8 directions

        for (int i = 0; i < 8; i++)
        {

            float angleDeg = i * angleStep;
            float angleRad = angleDeg * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
            Quaternion rotation = Quaternion.Euler(0f, 0f, angleDeg);
            Projectile bullet = PoolManager.Instance.Spawn(bulletGameObject, transform.position, rotation);
            bullet.transform.up = dir;
            bullet.InitBullet(dir);
            


        }
    }



}
