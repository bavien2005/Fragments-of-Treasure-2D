using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "InventorySO", menuName = "SO/InventorySO")]
public class InventorySO : ScriptableObject
{
    public List<ItemInventory> currentItems;
}
