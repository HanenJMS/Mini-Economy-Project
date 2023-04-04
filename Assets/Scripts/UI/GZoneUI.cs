using MP.GOAP;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GZoneUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI worldstates;
    [SerializeField] GZones selectedZone;
    private void Start()
    {
        worldstates = GetComponent<TextMeshProUGUI>();
    }
    private void LateUpdate()
    {
        Dictionary<string, int> worldStates = selectedZone.GetWorld().GetStates();
        worldstates.text = "";
        foreach (KeyValuePair<string, int> s in worldStates)
        {
            worldstates.text += $"{s.Key}, {s.Value} \n";
        }
    }
}
