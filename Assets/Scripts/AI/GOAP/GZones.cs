using MP.GOAP.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace MP.GOAP
{
    public class GZones : MonoBehaviour
    {
        //TODO refactor GWorld to be more zone-like feature. i.e. Hospital is a region, as is an island, adventure's guild, castle, and towns, and cities.
        private WorldStates world;
        private Dictionary<string, GResourceData> resourceLists = new Dictionary<string, GResourceData>();
        public GZones()
        {
            world = new WorldStates();
        }
        public WorldStates GetWorld()
        {
            return world;
        }
        private void OnTriggerEnter(Collider other)
        {
            GInteractInterface gi = other.GetComponent<GInteractInterface>();
            if (gi == null) return;
            if (!resourceLists.ContainsKey(gi.ObjectName()))
            {
                GResourceData newList = (GResourceData)ResourceDataStructure.CreateResourceList(gi);
                resourceLists.Add(gi.ObjectName(), newList);
                gi.UpdateCurrentZone(this);
            }
            else if(resourceLists.ContainsKey(gi.ObjectName()))
            {
                resourceLists[gi.ObjectName()].AddResource(other.gameObject);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            GInteractInterface gi = other.GetComponent<GInteractInterface>();
            if (gi == null) return;
            if (resourceLists.ContainsKey(gi.ObjectName()))
            {
                resourceLists[gi.ObjectName()].RemoveResource(other.gameObject);
            }
        }
    }
}
