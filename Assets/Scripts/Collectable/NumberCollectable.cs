using TMPro;
using UnityEngine;

public class NumberCollectable : MonoBehaviour, ICollectable
{
    [SerializeField] int collectionNumber;
    [SerializeField] TextMeshProUGUI txtTextField; // To DO
    [SerializeField] ParticleSystem collectedParticle;

    public int CollectedNumber => collectionNumber;
    private void Awake()
    {
        this.txtTextField.text = collectionNumber.ToString();
    }

    public void Collect()
    {

        PoolManager.Instance.Spawn(collectedParticle, this.transform.position, this.transform.rotation);
        Debug.Log("Called Collect");
        Destroy(this.gameObject);

    }



}
