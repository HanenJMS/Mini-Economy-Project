using MP.GOAP.Interfaces;
using UnityEngine;

namespace MP.GOAP.Actions
{
    public class GoToMerchant : GAction
    {
        public override bool PrePerform()
        {
            target = currentZone.GetResource("WoodMerchant");
            if(target == null)
            {
                return false;
            }
            return true;
        }
        public override bool PostPerform()
        {

            currentZone.RemoveResource(target, "WoodMerchant", "AvailableWoodMerchant", 1);
            return true;
        }
    }
}
