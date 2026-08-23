using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HpPotionSO", menuName = "SO/HpPotionSO")]
public class HpPotionSO : ScriptableObject
{
    public int defaultHpPotionCount = 100;
    public int hpPotionCount = 100;
}
