using UnityEngine;
[CreateAssetMenu(fileName = "ItemConfig", menuName = "Configs/ItemConfig")]
public class ItemConfig : ScriptableObject
{
    public int items;
    public int itemsCleared;
    public int itemsInLevel;
}
