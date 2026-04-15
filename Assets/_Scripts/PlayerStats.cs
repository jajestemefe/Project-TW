using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance; // Her yerden erişmek için Singleton

    [Header("Finances")]
    public int currentGold = 1000;

    [Header("Ship Cargo")]
    public int maxCargoSpace = 20;
    public int currentCargoUsed = 0;

    // Hangi üründen elimizde kaç tane var?
    // Key: ItemData (Hangi mal?), Value: int (Kaç adet?)

    public Dictionary<ItemData, int> inventory = new Dictionary<ItemData, int>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AddItem(ItemData item, int amount)
    {
        if (inventory.ContainsKey(item))
            inventory[item] += amount;
        else
            inventory.Add(item, amount);

        currentCargoUsed += amount;
        Debug.Log($"{amount} adet {item.itemName} alindi. Guncel miktar: {inventory[item]}");
    }

    public void RemoveItem(ItemData item, int amount)
    {
        if (inventory.ContainsKey(item) && inventory[item] >= amount)
        {
            inventory[item] -= amount;
            currentCargoUsed -= amount;
            Debug.Log($"{amount} adet {item.itemName} satildi. Kalan: {inventory[item]}");
        }
    }
}
