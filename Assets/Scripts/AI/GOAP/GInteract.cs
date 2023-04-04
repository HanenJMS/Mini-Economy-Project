using MP.GOAP;
using MP.GOAP.Interfaces;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GInteract : MonoBehaviour, GInteractInterface
{
    public string objectTypeName = "";
    public string objectModState = "";
    public int objectStateModifierAmount = 1;
    public GDataStorageType gDataStorageType = GDataStorageType.List;
    public GZones currentZone;

    public object ChangeCurrentZone()
    {
        return currentZone;
    }

    public GDataStorageType DataStorageType()
    {
        return gDataStorageType;
    }

    public string ObjectModState()
    {
        return objectModState;
    }

    public string ObjectName()
    {
        return objectTypeName;
    }

    public int ObjectStateModifierAmount()
    {
        return objectStateModifierAmount;
    }

    public string ObjectType()
    {
        return "";
    }


    public void UpdateCurrentZone(object currentZone)
    {
        this.currentZone = (GZones)currentZone;
    }
}
