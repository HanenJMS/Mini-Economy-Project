using MP.GOAP.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MP.GOAP
{
    public abstract class GAction : MonoBehaviour
    {
        public string actionName = "Action";
        public float cost = 1.0f;
        public UnityEngine.GameObject target;
        public string objectiveName;
        public string modState;
        public float duration = 0;
        public WorldState[] preConditions;
        public WorldState[] postConditions;
        public NavMeshAgent agent;
        public WorldStates agentBeliefs;
        public Inventory inventory;
        public Dictionary<string, int> preconditions;
        public Dictionary<string, int> conditions;

        public WorldStates personalWorldStates;
        public GZones currentZone;
        public bool running = false;

        public GAction()
        {
            preconditions = new Dictionary<string, int>();
            conditions = new Dictionary<string, int>();
        }

        public void Awake()
        {
            agent = this.gameObject.GetComponent<NavMeshAgent>();
            inventory = this.gameObject.GetComponent<Inventory>();
            agentBeliefs = this.gameObject.GetComponent<GAgent>().agentBeliefs;
            if (preConditions != null)
                foreach (WorldState w in preConditions)
                {
                    preconditions.Add(w.key, w.value);
                }

            if (postConditions != null)
                foreach (WorldState w in postConditions)
                {
                    conditions.Add(w.key, w.value);
                }
            
        }
        private void Start()
        {
            UpdateTarget(objectiveName);
        }
        public bool IsAchievable()
        {
            return true;
        }

        public bool IsAchievableGiven(Dictionary<string, int> conditions)
        {
            foreach (KeyValuePair<string, int> p in preconditions)
            {
                if (!conditions.ContainsKey(p.Key))
                    return false;
            }
            return true;
        }
        public void UpdateTarget(string objectName)
        {
            if (currentZone == null)
                UpdateCurrentZone();
            if (target == null && this.objectiveName == objectName)
            {
                target = currentZone.GetResource(objectName);
            }
            if (target == null) return;
        }
        public abstract bool PrePerform();
        public abstract bool PostPerform();
        public void UpdateCurrentZone()
        {
            
                currentZone = (GZones)GetComponent<GInteractInterface>().ChangeCurrentZone();
        }
    }
}
