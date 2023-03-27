using MP.GOAP;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> items = new List<Item>();
    WorldStates inventoryState = new WorldStates();
    [SerializeField] int gold = 0;
    public void PickUpItem(Item item)
    {
        items.Add(item.PickUpItem());
        inventoryState.ModifyState(item.ObjectModState(), item.GetQuantity());
    }
    public void AddItem(Item item)
    {
        items.Add(item);
    }
    public void RemoveItem(Item item)
    {
        items.Remove(item);
        inventoryState.ModifyState(item.ObjectModState(), -item.GetQuantity());
    }
    public Item FindItemWithName(string state)
    {
        if (inventoryState.GetStates().ContainsKey(state))
        {
            int removeIndex = 0;
            for (removeIndex = 0; removeIndex < items.Count; removeIndex++)
            {
                if (items[removeIndex].ObjectModState() == state)
                {
                    break;
                }
            }
            return items[removeIndex];
        }
        return null;
    }
    public bool RequestItemAvailable(Item itemType)
    {
        return (items.Contains(itemType));
    }
    public int GetGold()
    {
        return gold;
    }
    public void AddGold(int itemValue)
    {
        gold += itemValue;
    }
    public List<Item> GetInventoryList()
    {
        return items;
    }

    public Dictionary<string, int> GetInventoryState()
    {
        return inventoryState.GetStates();
    }
}
