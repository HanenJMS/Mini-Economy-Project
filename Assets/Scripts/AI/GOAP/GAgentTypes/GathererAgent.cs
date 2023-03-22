namespace MP.GOAP.AgentTypes
{
    public class GathererAgent : GAgent
    {
        private void Start()
        {
            base.Start();
            SubGoal s1 = new SubGoal("atTarget", 1, true);
            agentGoals.Add(s1, 1);
        }
    }
}
