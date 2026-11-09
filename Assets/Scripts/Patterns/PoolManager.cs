using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

/// <summary>
/// Optional: implement this on a prefab's script to reset its state every time it is spawned.
/// </summary>
public interface IPoolable
{
    void OnSpawn();
}

/// <summary>
/// One pool manager for every prefab in the game.
/// Put this on a single GameObject in your scene.
/// </summary>
public class PoolManager : SingletonCreator<PoolManager>
{
    // One dictionary, two kinds of key:
    //   prefab   -> its pool   (used by Spawn)
    //   instance -> its pool   (used by Despawn)
    readonly Dictionary<GameObject, ObjectPool<GameObject>> pools = new();

    // Uncomment if the pools should survive scene changes:
    // protected override bool Persistent => true;

    // ---------- Spawn ----------

    /// <summary>
    /// Generic version: pass a Projectile prefab, get a Projectile back.
    /// </summary>
    public T Spawn<T>(T prefab, Vector3 position, Quaternion rotation) where T : Component
    {
        GameObject go = SpawnInternal(prefab.gameObject, position, rotation);
        return go.GetComponent<T>();
    }

    /// <summary>
    /// Plain GameObject version, for prefabs with no script worth referencing.
    /// </summary>
    public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        return SpawnInternal(prefab, position, rotation);
    }

    // ---------- Despawn ----------

    public void Despawn(Component component)
    {
        Despawn(component.gameObject);
    }

    public void Despawn(GameObject go)
    {
        if (pools.TryGetValue(go, out ObjectPool<GameObject> pool))
        {
            pool.Release(go);
        }
        else
        {
            // This object was never pooled, so just destroy it.
            Destroy(go);
        }
    }

    // ---------- Internals ----------

    GameObject SpawnInternal(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (!pools.TryGetValue(prefab, out ObjectPool<GameObject> pool))
        {
            pool = CreatePool(prefab);
            pools[prefab] = pool;
        }

        GameObject go = pool.Get();                              // comes back inactive
        go.transform.SetPositionAndRotation(position, rotation); // position first...
        go.SetActive(true);                                      // ...so OnEnable sees the right position

        if (go.TryGetComponent<IPoolable>(out IPoolable poolable))
        {
            poolable.OnSpawn();
        }

        return go;
    }

    ObjectPool<GameObject> CreatePool(GameObject prefab)
    {
        ObjectPool<GameObject> pool = null;

        pool = new ObjectPool<GameObject>(
            createFunc: () =>
            {
                GameObject go = Instantiate(prefab, transform);
                go.SetActive(false);
                pools[go] = pool;                                // instance -> same pool
                return go;
            },
            actionOnGet: go => { },                              // Spawn() activates it
            actionOnRelease: go => go.SetActive(false),
            actionOnDestroy: go =>
            {
                pools.Remove(go);
                Destroy(go);
            },
            collectionCheck: true,                               // editor only: catches double release
            defaultCapacity: 20,
            maxSize: 200);

        return pool;
    }
}