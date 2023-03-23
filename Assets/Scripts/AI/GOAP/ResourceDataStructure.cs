using UnityEngine;
namespace MP.GOAP
{
    public class ResourceDataStructure : MonoBehaviour
    {

        public virtual object CreateResourceList(GameObject resource)
        {
            ResourceList newList = new ResourceList("", "");
            return newList;
            ResourceQueue newQueue = new ResourceQueue("", "");
            return newQueue;
            
        }
    }
}

