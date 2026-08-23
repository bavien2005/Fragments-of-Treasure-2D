using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplay : DinoBehaviourScript
{
    protected override void Start()
    {
        base.Start();
        this.Close();
    }
    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
