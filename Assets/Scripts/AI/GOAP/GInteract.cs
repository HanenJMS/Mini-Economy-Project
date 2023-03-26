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
    public GDataStorageType gDataStorageType = GDataStorageType.List;
    public GZones currentZone;

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

    public string ObjectStateModifier()
    {
        return "";
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
