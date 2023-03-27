namespace MP.GOAP.AgentTypes
{
    public class GathererAgent : GAgent
    {
        private void Start()
        {
            base.Start();
            SubGoal hasWood = new SubGoal("hasWood", 1, true);
            agentGoals.Add(hasWood, 1);
        }
    }
}
