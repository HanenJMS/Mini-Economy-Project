using MP.GOAP;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GZones selectedZone;
    public Action OnSelectedZone;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit[] hits;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hits = Physics.RaycastAll(ray, float.MaxValue);
            foreach(RaycastHit hit in hits)
            {
                GZones select = hit.transform.GetComponent<GZones>();
                if(select != null)
                {
                    selectedZone = select;
                    OnSelectedZone?.Invoke();
                }
            }
        }
    }
    public string ReturnInventoryState()
    {
        return selectedZone.GetZoneInventory();
    }
}
