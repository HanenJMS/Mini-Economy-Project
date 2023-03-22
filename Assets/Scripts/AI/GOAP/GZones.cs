using System.Collections.Generic;
using UnityEngine;

namespace MP.GOAP
{
    public class GZones : MonoBehaviour
    {
        //TODO refactor GWorld to be more zone-like feature. i.e. Hospital is a region, as is an island, adventure's guild, castle, and towns, and cities.
        private WorldStates world;
        private AgentList agents;
        public GZones()
        {
            world = new WorldStates();
            agents = new AgentList();
        }
        public WorldStates GetWorld()
        {
            return world;
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<GAgent>(out GAgent agent))
            {
                AddAgent(agent);
            }
            if(other.TryGetComponent<Item>(out Item item))
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
        void AddAgent(GAgent agentEnteredZone)
        {
            agents.AddAgent(agentEnteredZone);
            agentEnteredZone.UpdateCurrentZone(this);
        }
        void RemoveAgent(GAgent agentLeavingZone)
        {
            agents.RemoveAgent(agentLeavingZone);
        }

    }
}
