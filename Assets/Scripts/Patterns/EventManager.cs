using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static readonly UnityEvent OnPlayerTakeDamage = new UnityEvent();
    public static readonly UnityEvent OnPlayerDead = new UnityEvent();
}
