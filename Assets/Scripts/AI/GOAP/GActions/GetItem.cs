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
            GInteractInterface gi = target.GetComponent<GInteractInterface>();
            inventory.PickUpItem(target.GetComponent<Item>());
            currentZone.RemoveResource(target.gameObject);
            AddBelief(gi.ObjectModState(), gi.ObjectStateModifierAmount());
            return true;
        }
    }
}
