using System;
using UnityEngine;

public class TriangleEnemy : BaseEnemy
{
    [SerializeField] float distanceToFollow = 10;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (playerTarget == null)
        {
            return;
        }
        float distance = Vector2.Distance(playerTarget.transform.position, this.transform.position);
        if (distance < distanceToFollow)
        {
            navMeshAgent.destination = playerTarget.transform.position;
        }
        else
        {
            navMeshAgent.destination = this.transform.position;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {

            playerHealth.TakeDamage(this.enemyType, this.enemyNumber);
            Destroy(this.gameObject);
        }
    }

}
