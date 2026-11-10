using UnityEngine;
using static CommonEnums;

public class SpeedBonus : BaseBonus, ICollectable
{
    public int CollectedNumber => 0;

    public bool IsCollected => isCollected;

    public BonusType BonusType => this.targetBonusType;
    private bool isCollected = false;
    private PlayerController playerContoller;

    protected override void Start()
    {
        base.Start();
        playerContoller = FindAnyObjectByType<PlayerController>();
    }
    public void Collect()
    {
        Debug.Log("Called speed Collect");
        if (playerContoller == null) return;

        if (isCollected) return;
        isCollected = true;
        playerContoller.EnableSpeedBoost();
        Destroy(this.gameObject);
    }
}
