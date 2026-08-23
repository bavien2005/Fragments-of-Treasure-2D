using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEnemyDamSender : ArrowDamSender
{
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy")) return;
        base.OnTriggerEnter2D(collider);
    }
}
