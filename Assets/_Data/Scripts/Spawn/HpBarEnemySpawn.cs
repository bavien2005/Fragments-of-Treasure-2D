using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarEnemySpawn : Spawner
{
    [Header("HpBar Spawn")]
    protected static HpBarEnemySpawn instance;
    public static HpBarEnemySpawn Instance => instance;
    public static string hpBarEnemy = "HpBarEnemy";
    protected override void Awake()
    {
        base.Awake();
        if (HpBarEnemySpawn.instance != null) Debug.LogWarning("Only 1 HpBarEnemySpawn allow to exist");
        HpBarEnemySpawn.instance = this;
    }


}
