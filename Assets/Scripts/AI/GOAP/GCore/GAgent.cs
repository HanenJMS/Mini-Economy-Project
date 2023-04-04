using System.Collections.Generic;
using System.Linq;

namespace MP.GOAP.Core
{
    public class GAgent : GInteract
    {
        public List<GAction> actionList = new List<GAction>();
        public List<WorldState> goalStates = new List<WorldState>();
        public Dictionary<SubGoal, int> agentGoals = new Dictionary<SubGoal, int>();
        public WorldStates agentBeliefs = new WorldStates();
        GPlanner actionPLanner;
        Queue<GAction> actionQueue;
        public GAction currentAction;
        SubGoal currentGoal;
        bool invoked = false;

        AgentState agentState = AgentState.Idle;
        public void Start()
        {
            GAction[] gActions = GetComponentsInChildren<GAction>();
            foreach (GAction action in gActions)
            {
                actionList.Add(action);
            }
            currentZone = FindObjectOfType<GZones>();
            foreach (WorldState state in goalStates)
            {
                SetGoal(state);
            }
        }
        private void LateUpdate()
        {

            GOAPBehaviour();
        }
        private void SetGoal(WorldState goalState)
        {
            SubGoal goal = new SubGoal(goalState.key, goalState.value, goalState.remove);
            agentGoals.Add(goal, goalState.value);
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
                if (currentAction.agent.hasPath && currentAction.agent.remainingDistance < 1f)
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
                foreach (KeyValuePair<SubGoal, int> agentgoals in sortedGoals)
                {
                    actionQueue = actionPLanner.plan(actionList, agentgoals.Key.subGoals, agentBeliefs, currentZone);
                    if (actionQueue != null)
                    {
                        currentGoal = agentgoals.Key;
                        break;
                    }
                }
            }
            if (actionQueue != null && actionQueue.Count == 0)
            {
                if (currentGoal.remove)
                {
                    agentGoals.Remove(currentGoal);
                }
                actionPLanner = null;
            }
            if (actionQueue != null && actionQueue.Count > 0)
            {
                currentAction = actionQueue.Dequeue();
                if (currentAction.PrePerform())
                {
                    if (currentAction.target == null && currentAction.objectiveName != "")
                    {
                        currentAction.UpdateTarget(currentAction.objectiveName);
                    }
                    if (currentAction.target != null)
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
