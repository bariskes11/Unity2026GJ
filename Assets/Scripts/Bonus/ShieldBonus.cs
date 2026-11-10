using Unity.VisualScripting;
using UnityEngine;
using static CommonEnums;

public class ShieldBonus : BaseBonus, ICollectable
{
    public int CollectedNumber => 0;

    public bool IsCollected => isCollected;

    public BonusType BonusType => this.targetBonusType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool isCollected = false;
    PlayerShield playerShieldController;
    protected override void Start()
    {
        base.Start();
        playerShieldController = FindAnyObjectByType<PlayerShield>();


    }

    public void Collect()
    {
        if (playerShieldController == null)
        {
            Debug.LogError("player has no shield controller");
            return;
        }
        if (isCollected)
        {
            return;
        }
        isCollected = true;
        playerShieldController.EnableShield();
        Destroy(this.gameObject);


    }



    // Update is called once per frame
    void Update()
    {

    }
}
