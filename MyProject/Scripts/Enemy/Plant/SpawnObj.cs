using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    private static SpawnObj instance;
    public static SpawnObj Instance => instance;

    [SerializeField] private List<Transform> pool;
    [SerializeField] private Transform holder;

    private void Awake()
    {
        SpawnObj.instance = this;
    }

    private void Reset()
    {
        LoadHolder();
    }

    private void LoadHolder()
    {
        if (holder != null) return;
        holder = transform.Find("Holder");
    }

    public Transform Spawn(Transform obj)
    {
        Transform newObj = GetObjFromPool(obj);

        newObj.parent = holder;
        newObj.gameObject.SetActive(true);
        return newObj;
    }

    private Transform GetObjFromPool(Transform obj)
    {
        if (pool.Count > 0)
        {
            Transform newObj = pool[0];
            pool.Remove(pool[0]);
            return newObj;
        }    

        return Instantiate(obj);
    }

    public void Despawn(Transform obj)
    {
        obj.gameObject.SetActive(false);
        pool.Add(obj);
    }
}
