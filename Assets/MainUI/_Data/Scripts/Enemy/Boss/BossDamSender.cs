using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamSender : DamageSender
{
    [Header("Boss Dam Sender skill2")]
    [SerializeField] protected float damageTimer = 1.0f;
    [SerializeField] protected float damageTimerCounter = 0f;

    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        damageTimerCounter += Time.deltaTime;

        if (damageTimerCounter < damageTimer) return;
        this.SendToTransform(collision.transform);
        damageTimerCounter = 0f;
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        damageTimerCounter = 0f;
    }
}
