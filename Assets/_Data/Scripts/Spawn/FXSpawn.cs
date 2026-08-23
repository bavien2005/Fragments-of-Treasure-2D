using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawn : Spawner
{
    [Header("FX Spawn")]
    protected static FXSpawn instance;
    public static FXSpawn Instance => instance;
    protected static string fxOne = "FX_1";
    public string FXOne => fxOne;
    protected override void Awake()
    {
        base.Awake();
        if (FXSpawn.instance != null) Debug.LogWarning("Only 1 FXSpawn allow to exist");
        FXSpawn.instance = this;
    }


}
