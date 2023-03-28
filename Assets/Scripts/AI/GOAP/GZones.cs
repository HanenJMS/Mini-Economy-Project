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
        private void Start()
        {
            foreach (GInteract i in FindObjectsOfType<GInteract>())
            {
                AddResource(i.gameObject);
            }
        }
        public WorldStates GetWorld()
        {
            return world;
        }
        private void OnTriggerEnter(Collider other)
        {
            AddResource(other.gameObject);
        }
        private void OnTriggerExit(Collider other)
        {
            RemoveResource(other.gameObject);
        }
        public void AddResource(GameObject other)
        {
            GInteractInterface gi = other.GetComponent<GInteractInterface>();
            if (gi == null) return;
            if (!resourceLists.ContainsKey(gi.ObjectName()))
            {
                GResourceData newList = (GResourceData)ResourceDataStructure.CreateResourceList(gi);
                resourceLists.Add(gi.ObjectName(), newList);
                world.ModifyState(gi.ObjectModState(), gi.ObjectStateModifierAmount());
                gi.UpdateCurrentZone(this);
            }
            else if (resourceLists.ContainsKey(gi.ObjectName()))
            {
                resourceLists[gi.ObjectName()].AddResource(other.gameObject);
                world.ModifyState(gi.ObjectModState(), gi.ObjectStateModifierAmount());
            }
        }
        public void RemoveResource(GameObject other)
        {
            GInteractInterface gi = other.GetComponent<GInteractInterface>();
            if (gi == null) return;
            if (resourceLists.ContainsKey(gi.ObjectName()))
            {
                resourceLists[gi.ObjectName()].RemoveResource(other.gameObject);
                world.ModifyState(gi.ObjectModState(), -gi.ObjectStateModifierAmount());
            }
        }

        public GameObject GetResource(string resourceName)
        {
            GameObject resource = null;
            if(resourceLists.ContainsKey(resourceName))
            {
                resource = (GameObject)resourceLists[resourceName].GetResource();
            }
            return resource;
        }
        public string GetZoneInventory()
        {
            string zoneInventory = "";
            foreach(KeyValuePair<string, GResourceData> keyValuePair in resourceLists)
            {
                zoneInventory += $"{keyValuePair.Key} \n";
            }
            return zoneInventory;
        }
    }
}
