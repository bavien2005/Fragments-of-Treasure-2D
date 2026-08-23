using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack1 : DinoBehaviourScript
{
    [SerializeField] protected BossAttackCtrl bossAttackCtrl;
    [SerializeField] protected Transform player;
    [SerializeField] protected PolygonCollider2D collide1;
    [SerializeField] protected BoxCollider2D collide2;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected float disToPlayer;
    [SerializeField] protected bool attack1;
    public Transform Player => player;
    public bool Attack1 => attack1;
    public bool isWorking1 = false;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
        this.LoadBossAttackCtrl();
        this.LoadPolygonCollider();
        this.LoadBoxCollider();
        this.LoadSpriteRenderer();
    }
    protected void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player").transform;
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
    }
    protected void LoadBossAttackCtrl()
    {
        if (this.bossAttackCtrl != null) return;
        this.bossAttackCtrl = GetComponentInParent<BossAttackCtrl>();
        Debug.Log(transform.name + ": LoadBossAttackCtrl", gameObject);
    }
    protected void LoadPolygonCollider()
    {
        if (this.collide1 != null) return;
        this.collide1 = GetComponent<PolygonCollider2D>();
        Debug.Log(transform.name + ": LoadPolygonCollider", gameObject);
    }
    protected void LoadBoxCollider()
    {
        if (this.collide2 != null) return;
        this.collide2 = GameObject.Find("Blockplayer").transform.GetComponent<BoxCollider2D>();
        Debug.Log(transform.name + ": LoadBoxCollider", gameObject);
    }
    protected void LoadSpriteRenderer()
    {
        if (this.spriteRenderer != null) return;
        this.spriteRenderer = GameObject.Find("Blockplayer").transform.GetComponent<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadSpriteRenderer", gameObject);
    }
    public void Attacking1()
    {
        if (!isWorking1)
        {
            StartCoroutine(DoWork1());
        }
    }
    protected IEnumerator DoWork1()
    {
        this.spriteRenderer.enabled = true;
        this.collide2.enabled = true;
        this.isWorking1 = true;
        this.bossAttackCtrl.angry = true;
        AudioManagerr.Instance.PlaySFX("MonsterBreath");

        yield return new WaitForSeconds(5);
        this.disToPlayer = this.bossAttackCtrl.DistanceToTarget(this.player.position);
        this.bossAttackCtrl.angry = false;
        this.bossAttackCtrl.isMoving = true;

        while (disToPlayer >= 1)
        {
            this.disToPlayer = this.bossAttackCtrl.DistanceToTarget(this.player.position);
            this.bossAttackCtrl.BossCtrl.BossFlipDirect.Flipping(this.player);
            transform.parent.parent.position = this.bossAttackCtrl.MoveToTarget(this.player.position);
            yield return null;
        }
        this.bossAttackCtrl.isMoving = false;

        yield return new WaitForSeconds(0.2f);
        this.attack1 = true;
        AudioManagerr.Instance.PlaySFX("EnemyAttack");
        this.collide1.enabled = true;

        yield return new WaitForSeconds(0.2f);
        this.attack1 = false;
        this.collide1.enabled = false;

        yield return new WaitForSeconds(1);
        this.isWorking1 = false;
        this.bossAttackCtrl.attackCount += 1;

        //Chuyển kĩ năng
        if (this.bossAttackCtrl.attackCount == 3)
        {
            this.isWorking1 = true;
            this.bossAttackCtrl.BossAttack2.isWorking2 = false;
        }

        if (this.bossAttackCtrl.BossCtrl.BossDamReceive.Hp <= 30)
        {
            this.isWorking1 = false;
            this.bossAttackCtrl.BossAttack2.isWorking2 = false;
        }
    }
}
