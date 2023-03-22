using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MP.GOAP
{
    public class AgentList
    {
        private List<GAgent> list = new List<GAgent>();
        public AgentList()
        {

        }
        public bool AddAgent(GAgent agent)
        {
            if (agent == null) return false;
            if(list.Contains(agent)) return false;
            list.Add(agent);
            return true;
        }
        public bool RemoveAgent(GAgent agent)
        {
            if (agent == null) return false;
            if (!list.Contains(agent)) return false;
            list.Remove(agent);
            return true;
        }
    }
}
