using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HitEffect : MonoBehaviour
{
    [SerializeField] Image hitBgImage;
    [SerializeField] float maxAlpha;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Color initialColor;

    private void Awake()
    {
        EventManager.OnPlayerTakeDamage.AddListener(OnPlayerTakeDamage);
        initialColor = hitBgImage.color;
    }

    private async void OnPlayerTakeDamage()
    {
         RunHitEffect();
    }
    async UniTaskVoid RunHitEffect()
    {
        Color targetColor = hitBgImage.color;
        targetColor.a = maxAlpha;
        hitBgImage.color = targetColor;
        await UniTask.Delay(TimeSpan.FromSeconds(.1f));
        hitBgImage.color = initialColor;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
