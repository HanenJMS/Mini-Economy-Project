using System.Collections.Generic;

namespace MP.GOAP
{
    public class SubGoal
    {
        public Dictionary<string, int> subGoals;
        public bool remove;
        public SubGoal(string sgoal, int qty, bool remove)
        {
            subGoals = new Dictionary<string, int>();
            subGoals.Add(sgoal, qty);
            this.remove = remove;
        }
    }
}
