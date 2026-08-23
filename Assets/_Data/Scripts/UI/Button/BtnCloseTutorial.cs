using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseTutorial : BaseButton
{
    protected override void OnClick()
    {
        UITutorial.Instance.Close();
    }
}
