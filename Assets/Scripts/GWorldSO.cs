using MP.GOAP;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class GWorldSO : ScriptableObject
{
    [SerializeField] GZones zone;
    public GZones GetZone()
    {
        return zone;
    }
}
