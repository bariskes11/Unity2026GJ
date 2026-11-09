using UnityEngine;

public class PlayerTakeHitFlash:MonoBehaviour
{

    private void Awake()
    {
        EventManager.OnPlayerTakeDamage.AddListener(RunFlashEffect);
    }


    [ContextMenu("Run Flash")]
    public void RunFlashEffect()
    { 
    
    }

    private void OnDestroy()
    {
        EventManager.OnPlayerTakeDamage.RemoveAllListeners();
    }

}
