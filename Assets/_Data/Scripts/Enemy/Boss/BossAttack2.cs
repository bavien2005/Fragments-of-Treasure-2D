using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack2 : DinoBehaviourScript
{
    [SerializeField] protected BossAttackCtrl bossAttackCtrl;
    [SerializeField] protected Transform centerPoint;
    [SerializeField] protected PolygonCollider2D collide;
    [SerializeField] protected SpriteRenderer sprite;
    [SerializeField] protected BossMeteorRain meteorRain;
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
        this.LoadMeteorRain();
    }
    protected void LoadCenterPoint()
    {
        if (this.centerPoint != null) return;
        this.centerPoint = GameObject.Find("BossPoint").transform;
    }
    protected void LoadBossAttackCtrl()
    {
        if (this.bossAttackCtrl != null) return;
        this.bossAttackCtrl = GetComponentInParent<BossAttackCtrl>();
    }
    protected void LoadCollider()
    {
        if (this.collide != null) return;
        this.collide = GetComponent<PolygonCollider2D>();
    }
    protected void LoadSpriteRenderer()
    {
        if (this.sprite != null) return;
        this.sprite = GetComponentInChildren<SpriteRenderer>();
    }
    protected void LoadMeteorRain()
    {
        if (this.meteorRain != null) return;
        this.meteorRain = GetComponentInChildren<BossMeteorRain>(true);
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
        this.sprite.enabled = true;
        this.sprite.color = new Color(1f, 0.26f, 0.08f, 0.13f);
        // The red area is visual warning only. Damage is now dealt by the
        // individual falling meteors when they land on the player.
        this.collide.enabled = false;
        this.meteorRain?.StartRain();
        yield return StartCoroutine(PlayAttack2Sound());

        this.meteorRain?.StopRain();
        this.attack2 = false;
        this.sprite.enabled = false;
        this.sprite.color = Color.white;
        this.collide.enabled = false;
        this.bossAttackCtrl.attackCount = 0;
        this.isWorking2 = true;

        // Chuyển kĩ năng 
        this.bossAttackCtrl.BossAttack1.isWorking1 = false;
        if (this.bossAttackCtrl.BossCtrl.BossDamReceive.Hp <= 30) this.isWorking2 = false;

    }

}
