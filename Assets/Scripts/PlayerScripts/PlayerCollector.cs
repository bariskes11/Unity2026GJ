using TMPro;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtCurrentNumber;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<ICollectable>(out var collectable))
        {
            collectable.Collect();
            int collectedNumber = collectable.CollectedNumber;
            int currentNumber = int.Parse(txtCurrentNumber.text);
            txtCurrentNumber.text = (currentNumber + collectedNumber).ToString();


        }
    }
}
