namespace MP.GOAP
{
    using UnityEngine;

    public class LootItem : GAction
    {
        public override bool PostPerform()
        {
            target.GetComponent<Item>().PickUpItem();
            return true;
        }

        public override bool PrePerform()
        {
            return true;
        }
    }
}
