namespace MP.GOAP.Actions
{
    public class RequestItem : GAction
    {
        public override bool PrePerform()
        {
            currentZone.AddResource(this.gameObject, "WoodMerchant", "AvailableWoodMerchant", 1);
            return true;
        }
        public override bool PostPerform()
        {

            return true;
        }
    }
}

