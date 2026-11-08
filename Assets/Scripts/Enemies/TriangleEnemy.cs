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


        // we will decide based on distance to player 
        // we will decide based on visibility to player

        //Vector2 direction = (playerTarget.transform.position - transform.position).normalized; // 



    }
}
