using TMPro;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] protected int enemyNumber;

    [SerializeField] protected NavMeshAgent navMeshAgent;
    [SerializeField] protected CommonEnums.EnemyType enemyType;
    [SerializeField] protected TextMeshProUGUI txtNumber;

    protected Rigidbody2D rigidBody2D;
    protected GameObject playerTarget;

    protected virtual void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        playerTarget = GameObject.FindWithTag("Player");
        navMeshAgent.speed = moveSpeed;
        txtNumber.text = GetDamageType()+ enemyNumber.ToString();
        if (playerTarget == null)
        {
            Debug.LogError(" There is no player in the game put something that has 'Player' tag");
        }
    }

    private string GetDamageType()
    {
        if (this.enemyType == CommonEnums.EnemyType.Substract)
        {
            return "-";
        }

        if (this.enemyType == CommonEnums.EnemyType.Divide)
        {
            return "/";
        }

        if (this.enemyType == CommonEnums.EnemyType.RootSquare)
        {
            return "√";
        }
        else
        {
            Debug.LogError("Unknownn Enemy math operation!!");
            return "";

        }

    }


}



