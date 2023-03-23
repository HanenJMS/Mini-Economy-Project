using System.Collections.Generic;
using UnityEngine;

namespace MP.GOAP
{
    public class ResourceQueue : ResourceSeparator
    {
        public Queue<GameObject> queue = new Queue<GameObject>();

        public ResourceQueue(string tag, string modState) : base(tag, modState)
        {
            
        }

        public override void AddResource(GameObject resource)
        {
            queue.Enqueue(resource);
        }
    }
}

