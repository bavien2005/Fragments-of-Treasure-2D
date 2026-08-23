using UnityEngine;
using UnityEngine.UI;

public class HpBarEnemy : HpBar
{
    [Header("Hp Bar Enemy")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected Spawner spawner;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadFollowTarget();
        this.LoadSpawner();
    }
    protected void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = GetComponent<FollowTarget>();
        Debug.Log(transform.name + ": LoadFollowTarget", gameObject);
    }
    protected void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GameObject.Find("HpBarEnemySpawn").GetComponent<Spawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }
    protected override void HpShowing()
    {
        if (this.enemyCtrl == null) return;

        bool isDead = this.enemyCtrl.EnemyDamReceive.IsDeaded();
        if (isDead)
        {
            this.spawner.Despawn(transform);
            return;
        }

        this.hp = this.enemyCtrl.EnemyDamReceive.Hp;
        this.hpMax = this.enemyCtrl.EnemyDamReceive.HPMax;

        base.HpShowing();
    }

    public void SetObjCtrl(EnemyCtrl enemyCtrl)
    {
        this.enemyCtrl = enemyCtrl;
    }
    public void SetFollowTarget(Transform target)
    {
        this.followTarget.SetTarget(target);
    }
}