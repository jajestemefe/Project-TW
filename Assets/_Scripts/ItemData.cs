using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ProjectTW/Item")]
public class ItemData : ScriptableObject
{
    [Header("Basic Info")]
    public string itemName;
    public Sprite itemIcon;
    [TextArea] public string description;

    [Header("Economy")]
    public int basePrice; // Ürünün standart fiyatı
    [Range(0, 100)] public int rarity; // Ne kadar nadir? (0-100)
}
