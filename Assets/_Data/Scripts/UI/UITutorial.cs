using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorial : UIDisplay
{
    protected static UITutorial instance;
    public static UITutorial Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        if (UITutorial.instance != null) Debug.LogWarning("Only 1 UITutorial allow to axist");
        UITutorial.instance = this;
    }
    
}
