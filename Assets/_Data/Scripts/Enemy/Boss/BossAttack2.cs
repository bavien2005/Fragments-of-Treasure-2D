using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack2 : DinoBehaviourScript
{
    [SerializeField] protected BossAttackCtrl bossAttackCtrl;
    [SerializeField] protected Transform centerPoint;
    [SerializeField] protected PolygonCollider2D collide;
    [SerializeField] protected SpriteRenderer sprite;
    [SerializeField] protected float disToCenter;
    [SerializeField] protected bool attack2;
    public bool Attack2 => attack2;
    public bool isWorking2 = true;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCenterPoint();
        this.LoadBossAttackCtrl();
        this.LoadCollider();
        this.LoadSpriteRenderer();
    }
    protected void LoadCenterPoint()
    {
        if (this.centerPoint != null) return;
        this.centerPoint = GameObject.Find("BossPoint").transform;
        Debug.Log(transform.name + ": LoadCenterPoint", gameObject);
    }
    protected void LoadBossAttackCtrl()
    {
        if (this.bossAttackCtrl != null) return;
        this.bossAttackCtrl = GetComponentInParent<BossAttackCtrl>();
        Debug.Log(transform.name + ": LoadBossAttackCtrl", gameObject);
    }
    protected void LoadCollider()
    {
        if (this.collide != null) return;
        this.collide = GetComponent<PolygonCollider2D>();
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    protected void LoadSpriteRenderer()
    {
        if (this.sprite != null) return;
        this.sprite = GetComponentInChildren<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadSpriteRenderer", gameObject);
    }
    public void Attacking2()
    {
        if (!isWorking2)
        {
            StartCoroutine(DoWork2());
        }
    }
    protected IEnumerator PlayAttack2Sound()
    {
        for (int i = 0; i < 5; i++)
        {
            AudioManagerr.Instance.PlaySFX("Attack2");
            yield return new WaitForSeconds(1);
        }
    }
    protected IEnumerator DoWork2()
    {
        this.isWorking2 = true;
        this.bossAttackCtrl.isMoving = true;
        this.disToCenter = this.bossAttackCtrl.DistanceToTarget(this.centerPoint.position);
        while (disToCenter > 0)
        {
            this.disToCenter = this.bossAttackCtrl.DistanceToTarget(this.centerPoint.position);
            this.bossAttackCtrl.BossCtrl.BossFlipDirect.Flipping(this.centerPoint);
            transform.parent.parent.position = this.bossAttackCtrl.MoveToTarget(this.centerPoint.position);
            yield return null;
        }
        this.bossAttackCtrl.isMoving = false;
        this.bossAttackCtrl.angry = true;
        this.sprite.enabled = true;
        AudioManagerr.Instance.PlaySFX("MonsterBreath");

        yield return new WaitForSeconds(5);

        this.sprite.enabled = false;
        this.bossAttackCtrl.angry = false;
        this.attack2 = true;
        this.collide.enabled = true;
        yield return StartCoroutine(PlayAttack2Sound());

        this.attack2 = false;
        this.collide.enabled = false;
        this.bossAttackCtrl.attackCount = 0;
        this.isWorking2 = true;

        // Chuyển kĩ năng 
        this.bossAttackCtrl.BossAttack1.isWorking1 = false;
        if (this.bossAttackCtrl.BossCtrl.BossDamReceive.Hp <= 30) this.isWorking2 = false;

    }

}
