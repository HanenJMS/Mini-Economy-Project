using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MP.GOAP
{
    public class GResourceData : MonoBehaviour
    {
        public string resourceNameType;
        public string modState;
        public GResourceData(string nameType, string modState)
        {
            this.resourceNameType = nameType;
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
        public virtual object GetResource()
        {
            return null;
        }
    }
}

