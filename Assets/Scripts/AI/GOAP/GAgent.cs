using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MP.GOAP
{
    public class GAgent : MonoBehaviour, IInteractable
    {
        public List<GAction> actionList = new List<GAction>();
        public Dictionary<SubGoal, int> agentGoals = new Dictionary<SubGoal, int>();
        public WorldStates agentBeliefs = new WorldStates();
        GPlanner actionPLanner;
        Queue<GAction> actionQueue;
        public GAction currentAction;
        SubGoal currentGoal;
        bool invoked = false;
        public GZones currentZone;
        AgentState agentState = AgentState.Idle;
        public void Start()
        {
            GAction[] gActions = GetComponentsInChildren<GAction>();
            foreach (GAction action in gActions)
            {
                actionList.Add(action);
            }
        }
        private void LateUpdate()
        {
            UpdateCurrentZone(null);
            GOAPBehaviour();
        }
        public void UpdateCurrentZone(GZones receivingZone)
        {
            if(receivingZone != null)
                this.currentZone = receivingZone;
            //else
            //{
            //    Ray agentPosition = Camera.main.ScreenPointToRay(this.transform.position);
            //    RaycastHit[] allHits = Physics.SphereCastAll(agentPosition, 3f);
            //    foreach(RaycastHit hit in allHits)
            //    {
            //        GWorld zone = hit.transform.GetComponent<GWorld>();
            //        if (zone != null)
            //        {
            //            receivingZone = zone;
            //            break;
            //        }
            //    }
            //}
        }
        void CompleteAction()
        {
            currentAction.running = false;
            currentAction.PostPerform();
            invoked = false;
        }
        private void GOAPBehaviour()
        {
            if (currentAction != null && currentAction.running)
            {
                if (currentAction.agent.hasPath && currentAction.agent.remainingDistance > 1f)
                {
                    if (!invoked)
                    {
                        Invoke("CompleteAction", currentAction.duration);
                        invoked = true;
                    }
                }
                return;
            }
            if (actionPLanner == null || actionQueue == null)
            {
                actionPLanner = new GPlanner();
                var sortedGoals = from entry in agentGoals orderby entry.Value descending select entry;
                foreach(KeyValuePair<SubGoal, int> agentgoals in sortedGoals)
                {
                    actionQueue = actionPLanner.plan(actionList, agentgoals.Key.subGoals, agentBeliefs, currentZone);
                    if(actionQueue != null)
                    {
                        currentGoal = agentgoals.Key;
                        break;
                    }
                }
            }
            if(actionQueue != null && actionQueue.Count == 0)
            {
                if(currentGoal.remove)
                {
                    agentGoals.Remove(currentGoal);
                }
                actionPLanner = null;
            }
            if(actionQueue != null && actionQueue.Count > 0)
            {
                currentAction = actionQueue.Dequeue();
                if(currentAction.PrePerform())
                {
                    if(currentAction.target == null && currentAction.targetTag != "")
                    {
                        currentAction.target = UnityEngine.GameObject.FindWithTag(currentAction.targetTag);
                    }
                    if(currentAction.target != null)
                    {
                        currentAction.running = true;
                        currentAction.agent.SetDestination(currentAction.target.transform.position);
                    }
                }
                else
                {
                    actionQueue = null;
                }
            }
        }
    }
}
