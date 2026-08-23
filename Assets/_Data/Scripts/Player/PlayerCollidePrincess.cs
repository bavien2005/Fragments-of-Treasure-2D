using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollidePrincess : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Princess"))
        {
            PlayerCtrl.Instance.PlayerMovement._Rb.constraints = RigidbodyConstraints2D.FreezeAll;
            WinToggle.Instance.WinGameMenu();
        }
    }
}
