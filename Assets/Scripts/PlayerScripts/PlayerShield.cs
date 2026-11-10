using Cysharp.Threading.Tasks;
using PrimeTween;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] float shieldBonusTimeout = 7F;
    [SerializeField] GameObject shieldGameObject;

    public bool IsShieldEnabled { get; private set; }
    private void Start()
    {
        shieldGameObject.SetActive(false);
    }
    public async Task EnableShield()
    {

        IsShieldEnabled = true;
        shieldGameObject.SetActive(IsShieldEnabled);
        shieldGameObject.transform.localScale = Vector3.zero;
        await Tween.Scale(shieldGameObject.transform, 2F, .4F, Ease.OutBounce);
        await TimeoutAndDisable();
    }

    async UniTask TimeoutAndDisable()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(shieldBonusTimeout));
        IsShieldEnabled = false;
        shieldGameObject.SetActive(IsShieldEnabled);


    }

}
