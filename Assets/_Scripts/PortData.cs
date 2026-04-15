using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MarketItem
{
    public ItemData item;
    public int buyPrice;
    public int sellPrice;
}

[CreateAssetMenu(fileName = "NewPort", menuName = "ProjectTW/Port")]
public class PortData : ScriptableObject
{
    [Header("Basic Info")]
    public string portName;
    public Sprite portBackground; // Limana girdiğimizde arkada görünecek resim

    [Header("Market")]
    // Bu limanda hangi ürünler alınıp satılabiliyor?
    public List<MarketItem> tradedItems = new List<MarketItem>();
}
