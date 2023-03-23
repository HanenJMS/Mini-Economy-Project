using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MP.GOAP
{
    public abstract class ResourceSeparator : MonoBehaviour
    {
        public string tag;
        public string modState;
        public ResourceSeparator(string tag, string modState)
        {
            this.tag = tag;
            this.modState = modState;
        }
        public virtual void AddResource(GameObject resource)
        {
            if (resource == null) return;
        }
        public virtual void RemoveResource(GameObject resource)
        {
            if (resource == null) return;
        }

    }
}

