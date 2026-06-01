using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack3 : DinoBehaviourScript
{
    [SerializeField] protected BossAttackCtrl bossAttackCtrl;
    [SerializeField] protected CapsuleCollider2D collide;
    [SerializeField] protected float disNewPlayerPos;
    [SerializeField] protected bool attack3;
    [SerializeField] protected LineRenderer lineRenderer;
    private float warningDuration = 3f;
    public bool Attack3 => attack3;
    public bool isWorking3 = false;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossAttackCtrl();
        this.LoadCollider();
        this.LoadLineRenderer();
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
        this.collide = GetComponent<CapsuleCollider2D>();
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected void LoadLineRenderer()
    {
        if (this.lineRenderer != null) return;
        this.lineRenderer = GetComponentInChildren<LineRenderer>();
        Debug.Log(transform.name + ": LoadLineRenderer", gameObject);
    }

    public void Attacking3()
    {
        if (this.bossAttackCtrl.BossAttack1.isWorking1 || this.bossAttackCtrl.BossAttack2.isWorking2) return;
        if (!isWorking3 && this.bossAttackCtrl.BossCtrl.BossDamReceive.Hp <= 30)
        {
            StartCoroutine(DoWork3());
        }
    }

    protected IEnumerator DoWork3()
    {
        this.isWorking3 = true;
        this.bossAttackCtrl.angry = true;
        AudioManagerr.Instance.PlaySFX("MonsterBreath");
        
        this.lineRenderer.enabled = true;
        float timer = 0f;

        while (timer < warningDuration)
        {
            Vector2 playerPos = this.bossAttackCtrl.BossAttack1.Player.position;
            this.lineRenderer.SetPosition(0, transform.position);
            this.lineRenderer.SetPosition(1, playerPos);
            timer += Time.deltaTime;
            yield return null;
        }


        Vector2 finalPlayerPos = this.bossAttackCtrl.BossAttack1.Player.position;
        this.lineRenderer.SetPosition(1, finalPlayerPos);

        yield return new WaitForSeconds(0.5f);
        this.lineRenderer.enabled = false;

        //Tan cong
        this.bossAttackCtrl.angry = false;
        this.attack3 = true;

        this.disNewPlayerPos = this.bossAttackCtrl.DistanceToTarget(finalPlayerPos);
        while (disNewPlayerPos > 0)
        {
            if (this.bossAttackCtrl.BossCtrl.BossDamReceive.IsDead) yield break;
            this.collide.enabled = true;
            this.disNewPlayerPos = this.bossAttackCtrl.DistanceToTarget(finalPlayerPos);
            this.bossAttackCtrl.BossCtrl.BossFlipDirect.Flipping(this.bossAttackCtrl.BossAttack1.Player);
            transform.parent.parent.position = this.bossAttackCtrl.MoveToTarget(finalPlayerPos);
            yield return null;
        }

        this.collide.enabled = false;
        this.attack3 = false;
        this.isWorking3 = false;
    }
}
