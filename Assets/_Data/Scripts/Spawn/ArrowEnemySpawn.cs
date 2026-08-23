using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEnemySpawn : Spawner
{
    [Header("Arrow Enemy Spawn")]
    protected static ArrowEnemySpawn instance;
    public static ArrowEnemySpawn Instance => instance;
    protected static string arrowTwo = "Arrow_2";
    public string ArrowTwo => arrowTwo;
    protected override void Awake()
    {
        base.Awake();
        if (ArrowEnemySpawn.instance != null) Debug.LogWarning("Only 1 ArrowEnemySpawn allow to exist");
        ArrowEnemySpawn.instance = this;
    }
    
}
