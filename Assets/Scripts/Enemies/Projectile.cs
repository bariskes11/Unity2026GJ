using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] int damage;
    [SerializeField] CommonEnums.EnemyType enemyType;
    Rigidbody2D rigidBody2D;
    bool isBulletStarted = false;
    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void InitBullet(Vector3 dir)
    {
        isBulletStarted = true;
        rigidBody2D.linearVelocity = dir * bulletSpeed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isBulletStarted)
            return;
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            player.TakeDamage(this.enemyType, this.damage);
        }
        this.gameObject.SetActive(false);
    }



}
