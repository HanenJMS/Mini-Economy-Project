using System.Collections;
using System.Collections.Generic;
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
    }
}
