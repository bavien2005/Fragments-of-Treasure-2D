using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : DinoBehaviourScript
{
    [Header("Enemy Ctrl")]
    [SerializeField] protected Rigidbody2D rigid;
    [SerializeField] protected EnemyMovement enemyMovement;
    [SerializeField] protected EnemyFlipDirect enemyFlipDirect;
    [SerializeField] protected EnemyFollow enemyFollow;
    [SerializeField] protected EnemyDetectPlayer enemyDetect;
    [SerializeField] protected EnemyDamReceive enemyDamReceive;
    [SerializeField] protected EnemySO enemySO;
    public Rigidbody2D Rigid => rigid;
    public EnemyMovement EnemyMovement => enemyMovement;
    public EnemyFlipDirect EnemyFlipDirect => enemyFlipDirect;
    public EnemyFollow EnemyFollow => enemyFollow;
    public EnemyDetectPlayer EnemyDetect => enemyDetect;
    public EnemyDamReceive EnemyDamReceive => enemyDamReceive;
    public EnemySO EnemySO => enemySO;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody();
        this.LoadEnemyMovement();
        this.LoadEnemyFlipDirect();
        this.LoadEnemyFollow();
        this.LoadEnemyDetect();
        this.LoadEnemyDamReceive();
        this.LoadEnemySO();
    }

    protected void LoadRigidbody()
    {
        if (this.rigid != null) return;
        this.rigid = GetComponentInChildren<Rigidbody2D>();
        Debug.Log(transform.name + ":LoadRigidbody", gameObject);
    }
    protected void LoadEnemyMovement()
    {
        if (this.enemyMovement != null) return;
        this.enemyMovement = GetComponentInChildren<EnemyMovement>();
        Debug.Log(transform?.name + ": LoadEnemyMovement", gameObject);
    }
    protected void LoadEnemyFlipDirect()
    {
        if (this.enemyFlipDirect != null) return;
        this.enemyFlipDirect = GetComponentInChildren<EnemyFlipDirect>();
        Debug.Log(transform.name + ": LoadEnemyFlipDirect", gameObject);
    }
    protected void LoadEnemyFollow()
    {
        if (this.enemyFollow != null) return;
        this.enemyFollow = GetComponentInChildren<EnemyFollow>();
        Debug.Log(transform?.name + ":LoadEnemyFollow", gameObject);
    }
    protected void LoadEnemyDetect()
    {
        if (this.enemyDetect != null) return;
        this.enemyDetect = GetComponentInChildren<EnemyDetectPlayer>();
        Debug.Log(transform?.name + ":LoadEnemyDetect", gameObject);
    }
    protected void LoadEnemyDamReceive()
    {
        if (this.enemyDamReceive != null) return;
        this.enemyDamReceive = GetComponentInChildren<EnemyDamReceive>();
        Debug.Log(transform?.name + ":LoadEnemyDamReceive", gameObject);
    }
    protected void LoadEnemySO()
    {
        if (this.enemySO != null) return;
        string resPath = "Enemy/" + transform.name;
        this.enemySO = Resources.Load<EnemySO>(resPath);
        Debug.Log(transform.name + ": LoadEnemySO", gameObject);
    }
}
