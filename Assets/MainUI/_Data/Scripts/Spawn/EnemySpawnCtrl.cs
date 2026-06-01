using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnCtrl : DinoBehaviourScript
{
    [Header("Enemy SpawnCtrl")]
    [SerializeField] protected EnemySpawnPoint enemySpawnPoint;
    public EnemySpawnPoint EnemySpawnPoint => enemySpawnPoint;
    [SerializeField] protected EnemySpawn enemySpawn;
    public EnemySpawn EnemySpawn => enemySpawn;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySpawn();
        this.LoadEnemySpawnPoint();
    }
    protected void LoadEnemySpawn()
    {
        if (this.enemySpawn != null) return;
        this.enemySpawn = GetComponent<EnemySpawn>();
        Debug.Log(transform.name + ": LoadEnemySpawn", gameObject);
    }
    protected void LoadEnemySpawnPoint()
    {
        if (this.enemySpawnPoint != null) return;
        this.enemySpawnPoint = Transform.FindAnyObjectByType<EnemySpawnPoint>();
        Debug.Log(transform.name + ": LoadEnemySpawnPoint", gameObject);
    }
}
