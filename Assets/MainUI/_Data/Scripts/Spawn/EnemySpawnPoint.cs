using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : DinoBehaviourScript
{
    [Header("Enemy Spawn Point")]
    [SerializeField] protected List<Transform> points;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnPoints();
    }

    protected void LoadSpawnPoints()
    {
        if (points.Count > 0) return;
        foreach (Transform point in transform)
        {
            points.Add(point);
        }
        Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
    }
    public Transform GetRandomPoint()
    {
        int rand = Random.Range(0, points.Count);
        return this.points[rand];
    }
}
