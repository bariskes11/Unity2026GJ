using PrimeTween;
using UnityEngine;
using static CommonEnums;

public abstract class BaseBonus : MonoBehaviour
{
    [SerializeField] protected BonusType targetBonusType;

    //protected Player

    protected virtual void Start()
    {
        Tween.Scale(transform, endValue: 1.2f, duration: 0.5f, Ease.InOutSine, cycles: -1, CycleMode.Yoyo);
    }
}
