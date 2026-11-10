using UnityEngine;
using UnityEngine.Rendering;

public class CannonEnemy : BaseEnemy
{
    [SerializeField] float range;
    [SerializeField] float shootTimeOut;
    [SerializeField] float rotateSpeed;
    [SerializeField] Projectile shootProjectile;

    private float elapsedTime = 0;
    private void Update()
    {
        if (Vector2.Distance(this.transform.position, this.playerTarget.transform.position) < range) // player in range
        {
            if (elapsedTime >= shootTimeOut)
            {
                elapsedTime = 0;
                // shoot bullets
                ShootBullet();
            }
            elapsedTime += Time.deltaTime;
            RotateTowardsPlayer();

        }
    }

    void ShootBullet()
    {
      Projectile projectile=   PoolManager.Instance.Spawn(shootProjectile, this.transform.position, this.transform.rotation);
        projectile.transform.up = this.transform.up;
        projectile.InitBullet(transform.up);
    }

    void RotateTowardsPlayer()
    {

        Vector2 direction = playerTarget.transform.position - this.transform.position;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, this.rotateSpeed);
    }
}
