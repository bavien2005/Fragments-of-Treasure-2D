using UnityEngine;
[CreateAssetMenu(fileName = "ItemProfile", menuName = "SO/ItemProfile")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;
    public ItemType itemType = ItemType.NoItem;
    public string itemName = "";
    public int defaultMaxStack = 7;
}
