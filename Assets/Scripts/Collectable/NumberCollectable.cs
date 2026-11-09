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

        PoolManager.Instance.Spawn(collectedParticle, this.transform.position, this.transform.rotation);
        Debug.Log("Called Collect");
        Destroy(this.gameObject);

    }



}
