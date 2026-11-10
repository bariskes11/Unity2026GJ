using UnityEngine;
using static CommonEnums;

public interface  ICollectable
{
    public void Collect();
    public int CollectedNumber { get;  }
    public bool IsCollected { get; }
    public BonusType BonusType { get; }

}
