using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : DinoBehaviourScript
{
    [Header("Spawner")]
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObj;
    [SerializeField] protected int spawnCount = 0;
    public int SpawnCount => spawnCount;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefab();
        this.LoadHolder();
    }
    protected void LoadPrefab()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefab = transform.Find("Prefab");
        foreach (Transform child in prefab)
        {
            this.prefabs.Add(child);
        }
        this.HidePrefab();
    }
    protected void HidePrefab()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
    protected void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }
    protected Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name != prefabName) continue;
            return prefab;
        }
        return null;
    }
    protected Transform GetObjFromPool(Transform prefab)
    {
        foreach (Transform obj in this.poolObj)
        {
            if (obj.name != prefab.name) continue;
            this.poolObj.Remove(obj);
            return obj;
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    public Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion spawnRot)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.Log("Not exist prefab has name :" + prefabName);
            return null;
        }
        return Spawn(prefab, spawnPos, spawnRot);
    }
    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion spawnRot)
    {
        Transform newPrefab = this.GetObjFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, spawnRot);
        newPrefab.SetParent(this.holder);
        newPrefab.gameObject.SetActive(true);
        this.spawnCount--;
        return newPrefab;
    }
    public void Despawn(Transform obj)
    {
        this.poolObj.Add(obj);
        obj.gameObject.SetActive(false);
    }
    public Transform GetRandomPrefab()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
}
