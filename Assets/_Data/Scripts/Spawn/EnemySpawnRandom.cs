using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnRandom : DinoBehaviourScript
{
    [Header("Enemy Spawn Random")]
    [SerializeField] protected EnemySpawnCtrl enemySpawnCtrl;
    [SerializeField] protected float delaySpawnTime = 3f;
    [SerializeField] protected float spawnTimer = 0f;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySpawnCtrl();
    }
    protected void LoadEnemySpawnCtrl()
    {
        if (this.enemySpawnCtrl != null) return;
        this.enemySpawnCtrl = GetComponent<EnemySpawnCtrl>();
        Debug.Log(transform.name + ": LoadEnemySpawnCtrl", gameObject);
    }
    protected void Update()
    {
        this.EnemySpawning();
    }
    protected void EnemySpawning()
    {
        if (!this.RandomSpawnLimit()) return;

        this.spawnTimer += Time.deltaTime;
        if (this.spawnTimer < this.delaySpawnTime) return;
        this.spawnTimer = 0f;

        Transform spawnPoint = this.enemySpawnCtrl.EnemySpawnPoint.GetRandomPoint();
        Vector3 spawnPointPos = spawnPoint.position;
        Quaternion spawPointRot = spawnPoint.rotation;
        Transform enemy = this.enemySpawnCtrl.EnemySpawn.GetRandomPrefab();
        Transform newEnemy = this.enemySpawnCtrl.EnemySpawn.Spawn(enemy, spawnPointPos, spawPointRot);
        newEnemy.gameObject.SetActive(true);
    }

    protected bool RandomSpawnLimit()
    {
        if (this.enemySpawnCtrl.EnemySpawn.SpawnCount <= 0) return false;
        return true;
    }
}
