using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for any MonoBehaviour that should exist only once.
/// Usage:  public class GameManager : Singleton<GameManager> { }
/// Access: GameManager.Instance
/// </summary>
public abstract class SingletonCreator<T> : MonoBehaviour where T : SingletonCreator<T>
{
    public static T Instance { get; private set; }

    /// <summary>True if an instance is alive. Use this before touching Instance during shutdown.</summary>
    public static bool Exists => Instance != null;

    /// <summary>Override and return true to survive scene loads.</summary>
    protected virtual bool Persistent => false;

    /// <summary>
    /// Put your startup code here instead of Awake().
    /// It only runs on the one real instance, never on a duplicate.
    /// </summary>
    protected virtual void OnInit() { }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning($"Duplicate {typeof(T).Name} on '{name}'. Destroying it.");
            Destroy(gameObject);
            return;
        }

        Instance = (T)this;

        if (Persistent)
        {
            if (transform.parent != null) transform.SetParent(null); // DontDestroyOnLoad needs a root object
            DontDestroyOnLoad(gameObject);
        }

        OnInit();
    }

    protected virtual void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }
}