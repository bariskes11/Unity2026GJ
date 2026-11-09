using PrimeTween;
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
            
            Tween.Scale(transform, endValue: Vector3.one * 1.3f, duration: 0.15f, ease: Ease.InOutSine, cycles: 2, cycleMode: CycleMode.Yoyo);

            collectable.Collect();
            int collectedNumber = collectable.CollectedNumber;
            int currentNumber = int.Parse(txtCurrentNumber.text);


            if (collectable.BonusType == BonusType.Add)
            {
                int targetNumber = currentNumber + collectedNumber;
                playerHealth.AddNumber(collectedNumber);
                txtCurrentNumber.text = (targetNumber).ToString();
            }
            else if(collectable.BonusType == BonusType.Multiply) // multiply
            {
                int targetNumber = currentNumber * collectedNumber;
                playerHealth.MulitplyNumber(collectedNumber);
                txtCurrentNumber.text = (targetNumber).ToString();
            }
        }
    }
}
