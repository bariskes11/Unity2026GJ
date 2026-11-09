using TMPro;
using UnityEngine;
using static CommonEnums;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtCurrentNumber;
    [SerializeField] PlayerHealth playerHealth;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<ICollectable>(out var collectable))
        {
            collectable.Collect();
            int collectedNumber = collectable.CollectedNumber;
            int currentNumber = int.Parse(txtCurrentNumber.text);


            if (collectable.BonusType == BonusType.Add)
            {
                int targetNumber = currentNumber + collectedNumber;
                playerHealth.AddNumber(collectedNumber);
                txtCurrentNumber.text = (targetNumber).ToString();
            }
            else // multiply
            {
                int targetNumber = currentNumber * collectedNumber;
                playerHealth.MulitplyNumber(collectedNumber);
                txtCurrentNumber.text = (targetNumber).ToString();
            }
        }
    }
}
