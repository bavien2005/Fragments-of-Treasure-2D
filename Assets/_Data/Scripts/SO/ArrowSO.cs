using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ArrowSO", menuName = "SO/ArrowCount")]
public class ArrowSO : ScriptableObject
{
    public int defaultArrowCounts = 100;
    public int arrowCounts = 100;
}
