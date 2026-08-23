using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnOpenTutorial : BaseButton
{
    protected override void OnClick()
    {
        UITutorial.Instance.Open();
    }
}
