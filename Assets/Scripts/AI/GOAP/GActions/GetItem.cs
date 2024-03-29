using MP.GOAP.Interfaces;
using UnityEngine;

namespace MP.GOAP.Actions
{
    public class GetItem : GAction
    {
        public override bool PrePerform()
        {
            target = currentZone.GetResource(objectiveName);
            if(target == null)
            {
                return false;
            }
            return true;
        }
        public override bool PostPerform()
        {
            inventory.PickUpItem(target.GetComponent<Item>().PickUpItem());
            currentZone.GetWorld().ModifyState("AvailableWood", -quantity);
            agentBeliefs.ModifyState(modState, quantity);
            return true;
        }
    }
}
