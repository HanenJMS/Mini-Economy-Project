using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MP.GOAP
{
    public class ResourceList : ResourceSeparator
    {
        private List<GameObject> list = new List<GameObject>();

        public ResourceList(string tag, string modState) : base(tag, modState)
        {
        }

        public override void AddResource(GameObject resource)
        {
            base.AddResource(resource);
            if(list.Contains(resource)) return;
            list.Add(resource);
            return;
        }
        public override void RemoveResource(GameObject resource)
        {
            base.RemoveResource(resource);
            if (!list.Contains(resource)) return;
            list.Remove(resource);
            return;
        }
    }
}
