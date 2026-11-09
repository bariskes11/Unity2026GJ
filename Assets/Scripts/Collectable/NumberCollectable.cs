using PrimeTween;
using TMPro;
using UnityEngine;
using static CommonEnums;

public class NumberCollectable : MonoBehaviour, ICollectable
{
    [SerializeField] int collectionNumber;
    [SerializeField] BonusType bonusType;
    [SerializeField] TextMeshProUGUI txtTextField; // To DO
    [SerializeField] ParticleSystem collectedParticle;

    public int CollectedNumber => collectionNumber;

    public BonusType BonusType => bonusType;
    private bool isCollected = false;

    private void Awake()
    {
        this.txtTextField.text = $"{AddBonusOperationSyntax()}{collectionNumber.ToString()}";
    }

    string AddBonusOperationSyntax()
    {
        if (this.bonusType == BonusType.Add)
        {
            return "+";
        }
        else // multipl
        {
            return "*";
        }
    }

    public void Collect()
    {
        if (isCollected)
        {
            return;
        }

        if (!isCollected)
        {
            Debug.Log($"Collecting {this.CollectedNumber}");
            isCollected = true;
            PoolManager.Instance.Spawn(collectedParticle, this.transform.position, this.transform.rotation);
            Tween.Scale(this.transform, Vector3.zero, .3F, Ease.OutQuad).OnComplete(() =>
            {
                Destroy(this.gameObject);
            });
        }
    }



}
