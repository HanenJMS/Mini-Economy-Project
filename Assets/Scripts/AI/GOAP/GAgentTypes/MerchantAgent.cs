using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MP.GOAP.AgentTypes
{
    public class MerchantAgent : GAgent
    {
        int buyAmount = 500;
        Inventory inventory;
        private void Start()
        {
            base.Start();
            inventory = GetComponent<Inventory>();
        }
        private void Update()
        {
            if (agentGoals.Count != 0) return;
            Dictionary<string, int> data = new Dictionary<string, int>();
            data = inventory.GetInventoryState();
            if (data == null) return;
            bool needMore = data[objectModState] < buyAmount;
            //add subgoal hasFullInventory, quantity, and boolean
        }
    }
}

