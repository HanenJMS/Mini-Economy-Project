using System.Collections.Generic;
using UnityEngine;

namespace MP.GOAP
{
    public class GZones : MonoBehaviour
    {
        //TODO refactor GWorld to be more zone-like feature. i.e. Hospital is a region, as is an island, adventure's guild, castle, and towns, and cities.
        private WorldStates world;
        private ResourceList agents;
        private Dictionary<string, ResourceSeparator> resourceLists = new Dictionary<string, ResourceSeparator>();
        public GZones()
        {
            world = new WorldStates();
            agents = new ResourceList("","");
        }
        public WorldStates GetWorld()
        {
            return world;
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<IInteractable>(out IInteractable interaction))
            {

            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<GAgent>(out GAgent agent))
            {
                RemoveAgent(agent);
            }
        }
        void Add(GAgent agentEnteredZone)
        {
            agents.AddResource(agentEnteredZone.gameObject);
            agentEnteredZone.GetComponent<GAgent>().UpdateCurrentZone(this);
        }
        void RemoveAgent(GAgent agentLeavingZone)
        {
            agents.RemoveResource(agentLeavingZone.gameObject);
        }

    }
}
