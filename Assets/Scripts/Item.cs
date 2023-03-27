using MP.GOAP.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : GInteract
{
    [SerializeField] int value = 0;
    [SerializeField] int qty = 0;
    public Item PickUpItem()
    {
        this.gameObject.SetActive(false);
        return this;
    }
    public int GetValue()
    {
        UpdateModValues();
        return value;
    }
    public int GetQuantity()
    {
        UpdateModValues();
        return qty;
    }
    void UpdateModValues()
    {
        objectModAmount = qty;
    }
}
