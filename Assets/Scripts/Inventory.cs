using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] int MaxInventorySpace;
    Dictionary<Item, int> InventoryList = new Dictionary<Item, int>();

    public void AddItem(Item item, int itemCount)
    {
        if (!InventoryList.ContainsKey(item))
        {
            InventoryList.Add(item, itemCount);
        }
        else
        {
            InventoryList[item] += itemCount;
        }
    }
}
