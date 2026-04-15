using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPort", menuName = "ProjectTW/Port")]
public class PortData : ScriptableObject
{
    [Header("Basic Info")]
    public string portName;
    public Sprite portBackground; // Limana girdiğimizde arkada görünecek resim

    [Header("Market")]
    // Bu limanda hangi ürünler alınıp satılabiliyor?
    public List<ItemData> tradedItems = new List<ItemData>();
}
