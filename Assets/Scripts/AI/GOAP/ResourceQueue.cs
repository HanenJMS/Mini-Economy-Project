using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MP.GOAP
{
    public class ResourceQueue : GResourceData
    {
        public Queue<GameObject> queue = new Queue<GameObject>();

        public ResourceQueue(string nameType, string modState) : base(nameType, modState)
        {
            
        }

        public override void AddResource(GameObject resource)
        {
            if (queue.Contains(resource)) return;
            queue.Enqueue(resource);
        }

        public override void RemoveResource(GameObject resource)
        {
            if (!queue.Contains(resource)) return;
            queue = new Queue<GameObject>(queue.Where(x => x != resource));
        }
        public override object GetResource()
        {
            if (queue.Count == 0) return null;
            return (object)queue.Dequeue();
        }
    }
}

