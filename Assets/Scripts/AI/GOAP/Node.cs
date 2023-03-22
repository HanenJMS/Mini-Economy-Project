using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MP.GOAP
{
    public class Node
    {
        public Node parent;
        public float cost;
        public Dictionary<string, int> state;
        public GAction action;

        // Constructor
        public Node(Node parent, float cost, Dictionary<string, int> allStates, GAction action)
        {

            this.parent = parent;
            this.cost = cost;
            this.state = new Dictionary<string, int>(allStates);
            this.action = action;
        }
        public Node(Node parent, float cost, Dictionary<string, int> allStates, Dictionary<string, int> agentStates, GAction action)
        {

            this.parent = parent;
            this.cost = cost;
            this.state = new Dictionary<string, int>(allStates);
            this.action = action;
            LoadAllStates(agentStates);
        }
        void LoadAllStates(Dictionary<string, int> agentStates)
        {
            foreach (KeyValuePair<string, int> states in agentStates)
            {
                if(!state.ContainsKey(states.Key))
                {
                    state.Add(states.Key, states.Value);
                }
            }
        }
    }
}
