using System.Collections.Generic;
using UnityEngine;

namespace MP.GOAP
{
    public class ResourceQueue
    {
        public Queue<IInteractable> queue = new Queue<IInteractable>();
        public string tag;
        public string modState;
        public ResourceQueue(string tag, string modState)
        {
            this.tag = tag;
            this.modState = modState;
        }
        public void AddResource(IInteractable resource)
        {
            queue.Enqueue(resource);
        }
        public IInteractable GetResource()
        {
            if (queue.Count == 0) return null;
            return queue.Dequeue();
        }
    }
}

