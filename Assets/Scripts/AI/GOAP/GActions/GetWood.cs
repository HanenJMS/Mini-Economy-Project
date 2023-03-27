namespace MP.GOAP.Actions
{
    public class GetWood : GAction
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
            return true;
        }
    }
}
