using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

namespace MP.GOAP
{
    public class ResourceList : GResourceData
    {
        private List<GameObject> list = new List<GameObject>();

        public ResourceList(string nameType, string modState) : base(nameType, modState)
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
        public override object GetResource()
        {
            if (list.Count == 0) return null;
            return (object)list[0];
        }
    }
}
