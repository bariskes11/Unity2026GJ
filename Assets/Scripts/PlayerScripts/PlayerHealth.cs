using TMPro;
using UnityEngine;
using static CommonEnums;

[RequireComponent(typeof(PlayerController))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerNumberIndicator;
    [SerializeField] PlayerShield playerShield;
    private PlayerController playerController;


    public int CurrentPlayerNumber { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        int.TryParse(playerNumberIndicator.text, out int result);
        CurrentPlayerNumber = result;
    }

    public void AddNumber(int number)
    {
        CurrentPlayerNumber += number;
        NumberClamp();
    }
    public void MulitplyNumber(int number)
    {
        CurrentPlayerNumber *= number;
        NumberClamp();
    }

    void NumberClamp()
    {

        CurrentPlayerNumber = Mathf.Clamp(CurrentPlayerNumber, 0, 999);
    }


    public void TakeDamage(EnemyType enemyType, int enemyNumber)
    {
        if (playerShield.IsShieldEnabled)
        {
            return;
        }

        if (enemyType == EnemyType.Divide)
        {
            CurrentPlayerNumber = CurrentPlayerNumber / enemyNumber;

        }
        if (enemyType == EnemyType.Substract)
        {
            CurrentPlayerNumber = CurrentPlayerNumber - Mathf.Abs(enemyNumber);
        }

        if (enemyType == EnemyType.RootSquare)
        {
            float roots = Mathf.Sqrt(CurrentPlayerNumber);
            CurrentPlayerNumber = (int)roots;
        }
        Debug.Log($"Player Final number {CurrentPlayerNumber}");

        if (CurrentPlayerNumber <= 0)
        {
            CurrentPlayerNumber = 0;
            Die();

        }
        else
        {
            EventManager.OnPlayerTakeDamage?.Invoke();
        }
        playerNumberIndicator.text = CurrentPlayerNumber.ToString();


    }

    public void Die()
    {
        this.playerController.enabled = false;
        EventManager.OnPlayerDead?.Invoke();

    }


}
