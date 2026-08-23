using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGoalTutorial : UIDisplay
{
    protected static UIGoalTutorial instance;
    public static UIGoalTutorial Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        if (UIGoalTutorial.instance != null) Debug.LogWarning("Only 1 UITutorial allow to axist");
        UIGoalTutorial.instance = this;
    }
}
