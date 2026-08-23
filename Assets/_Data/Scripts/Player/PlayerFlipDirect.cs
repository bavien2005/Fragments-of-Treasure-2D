using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlipDirect : PlayerAbstract
{
    [Header("Player Flip Direct")]
    [SerializeField] protected bool right;
    [SerializeField] protected bool left;
    [SerializeField] protected bool up;
    [SerializeField] protected bool down = true;
    public bool Right => right;
    public bool Down => down;
    public bool Left => left;
    public bool Up => up;
    protected void Update()
    {
        this.SetDirect();
    }
    protected void SetDirect()
    {
        if (this.playerCtrl.PlayerDamReceive.IsHurt) return;
        if (this.playerCtrl.PlayerMovement.TerminateCondition()) return;
        if (this.playerCtrl.PlayerMovement.Vertical < 0)
        {
            this.down = true;
            this.up = this.left = this.right = false;
        }
        if (this.playerCtrl.PlayerMovement.Horizontal > 0)
        {
            this.right = true;
            this.down = this.left = this.up = false;
        }
        if (this.playerCtrl.PlayerMovement.Horizontal < 0)
        {
            this.left = true;
            this.down = this.up = this.right = false;
        }
        if (this.playerCtrl.PlayerMovement.Vertical > 0)
        {
            this.up = true;
            this.down = this.left = this.right = false;
        }
    }
}
