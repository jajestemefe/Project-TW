using UnityEngine;

public class TradeLogic : MonoBehaviour
{
    public static TradeLogic Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void BuyItem(ItemData item, int price, int amount)
    {
        PlayerStats ps = PlayerStats.Instance;

        // 1. Para kontrolü
        if (ps.currentGold < (price * amount))
        {
            Debug.LogWarning("Yeterli altinin yok!");
            return;
        }

        // 2. Kargo alanı kontrolü
        if (ps.currentCargoUsed + amount > ps.maxCargoSpace)
        {
            Debug.LogWarning("Gemide yer yok!");
            return;
        }

        // 3. İşlemi gerçekleştir
        ps.currentGold -= (price * amount);
        ps.AddItem(item, amount);
        Debug.Log($"Basariyla satin alindi! Kalan altin: {ps.currentGold}, Kalan alan: {ps.maxCargoSpace - ps.currentCargoUsed}");
    }

    public void SellItem(ItemData item, int price, int amount)
    {
        PlayerStats ps = PlayerStats.Instance;

        // 1. Envanter kontrolü (Elimizde o maldan var mı?)
        if (!ps.inventory.ContainsKey(item) || ps.inventory[item] < amount)
        {
            Debug.LogWarning("Satacak kadar malin yok!");
            return;
        }

        // 2. İşlemi gerçekleştir
        ps.currentGold += (price * amount);
        ps.RemoveItem(item, amount);
        Debug.Log($"Basariyla satild! Yeni altin: {ps.currentGold}");
    }
}
