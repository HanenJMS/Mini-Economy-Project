using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] int value = 0;
    [SerializeField] string state = "";
    [SerializeField] string itemIdentifierHere = "";
    [SerializeField] int qty = 0;
    public Item PickUpItem()
    {
        this.gameObject.SetActive(false);
        return this;
    }
    public int GetValue()
    {
        return value;
    }
    public int GetQuantity()
    {
        return qty;
    }
    public string GetState()
    {
        return state;
    }
}
