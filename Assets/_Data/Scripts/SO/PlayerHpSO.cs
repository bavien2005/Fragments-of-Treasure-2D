using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerHpSO", menuName = "SO/PlayerHpSO")]
public class PlayerHpSO : ScriptableObject
{
    public int currentHp = 10;
    public int maxHp = 10;
}
