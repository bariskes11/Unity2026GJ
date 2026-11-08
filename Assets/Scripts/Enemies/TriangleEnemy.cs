using UnityEngine;

public class TriangleEnemy : BaseEnemy
{

    protected override  void Awake()
    {
        base.Awake();
        navMeshAgent.destination = playerTarget.transform.position;
    }

    private void Update()
    {
        if (playerTarget == null)
        {

            return;
        }
        // we will decide based on distance to player 
        // we will decide based on visibility to player
        
        //Vector2 direction = (playerTarget.transform.position - transform.position).normalized; // 

        

    }
}
