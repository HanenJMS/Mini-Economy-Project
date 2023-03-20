using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MP.GOAP
{
    public class GAgent : MonoBehaviour
    {
        public List<GAction> actionList = new List<GAction>();
        public Dictionary<SubGoal, int> agentGoals = new Dictionary<SubGoal, int>();
        GPlanner actionPLanner;
        Queue<GAction> actionQueue;
        public GAction currentAction;
        SubGoal currentGoal;
        private void Start()
        {
            GAction[] gActions = GetComponentsInChildren<GAction>();
            foreach(GAction action in gActions)
            {
                actionList.Add(action);
            }
        }
    }
}
