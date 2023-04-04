using MP.GOAP.Interfaces;
using System.Collections.Generic;
using System.Net.Sockets;
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
            //foreach (GInteract i in FindObjectsOfType<GInteract>())
            //{
            //    AddResource(i.gameObject);
            //}
            foreach (GameObject i in GameObject.FindGameObjectsWithTag("Wood"))
            {
                AddResource(i, "Wood", "AvailableWood", 1);
            }
        }
        public WorldStates GetWorld()
        {
            return world;
        }
        //private void OnTriggerEnter(Collider other)
        //{
        //    AddResource(other.gameObject);
        //}
        //private void OnTriggerExit(Collider other)
        //{
        //    RemoveResource(other.gameObject);
        //}
        //public void AddResource(GameObject other)
        //{
        //    GInteractInterface gi = other.GetComponent<GInteractInterface>();
        //    if (gi == null) return;
        //    if (!resourceLists.ContainsKey(gi.ObjectName()))
        //    {
        //        GResourceData newList = (GResourceData)ResourceDataStructure.CreateResourceList(gi);
        //        resourceLists.Add(gi.ObjectName(), newList);
        //        world.ModifyState(gi.ObjectModState(), gi.ObjectStateModifierAmount());
        //        gi.UpdateCurrentZone(this);
        //    }
        //    else if (resourceLists.ContainsKey(gi.ObjectName()))
        //    {
        //        resourceLists[gi.ObjectName()].AddResource(other.gameObject);
        //        world.ModifyState(gi.ObjectModState(), gi.ObjectStateModifierAmount());
        //    }
        //}
        //public void RemoveResource(GameObject other)
        //{
        //    GInteractInterface gi = other.GetComponent<GInteractInterface>();
        //    if (gi == null) return;
        //    if (resourceLists.ContainsKey(gi.ObjectName()))
        //    {
        //        resourceLists[gi.ObjectName()].RemoveResource(other.gameObject);
        //        world.ModifyState(gi.ObjectModState(), -gi.ObjectStateModifierAmount());
        //    }
        //}

        public void AddResource(GameObject resourceObject, string resourceName, string modState, int quantity)
        {
            if (!resourceLists.ContainsKey(resourceName))
            {
                ResourceQueue newQueue = new ResourceQueue(resourceName, modState);
                resourceLists.Add(resourceName, newQueue);
                resourceLists[resourceName].AddResource(resourceObject);
                world.ModifyState(modState, quantity);
            }
            else if (resourceLists.ContainsKey(resourceName))
            {
                resourceLists[resourceName].AddResource(resourceObject);
                world.ModifyState(modState, quantity);
            }
        }
        //quantity check has not yet been implemented.Possible error : Gameobject is removed, however the quantity has not.Thus, 
        //the list should still technically contain a reference to a game object inside the resourceLists.
        //TODO Implement Validation : quantity
        public void RemoveResource(GameObject resourceObject, string resourceName, string modState, int quantity)
        {
            if (resourceLists.ContainsKey(resourceName))
            {
                resourceLists[resourceName].RemoveResource(resourceObject);
                world.ModifyState(modState, -quantity);
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
