using UnityEngine;

public interface  ICollectable
{
    public void Collect();
    public int CollectedNumber { get;  }
    public bool IsCollected { get; }
    public CommonEnums.BonusType BonusType { get; }

}
