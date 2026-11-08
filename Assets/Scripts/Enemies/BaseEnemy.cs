using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] protected NavMeshAgent navMeshAgent;
    

    protected Rigidbody2D rigidBody2D;
    protected GameObject playerTarget;

    protected virtual void Awake()
    {
        rigidBody2D= GetComponent<Rigidbody2D>();
        playerTarget= GameObject.FindWithTag("Player");
        if (playerTarget == null)
        {
            Debug.LogError(" There is no player in the game put something that has 'Player' tag");
        }
    }


}
