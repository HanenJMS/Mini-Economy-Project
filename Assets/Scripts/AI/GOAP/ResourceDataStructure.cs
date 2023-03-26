using MP.GOAP.Interfaces;
namespace MP.GOAP
{
    public class ResourceDataStructure
    {
        public static object CreateResourceList(GInteractInterface resource)
        {
            GResourceData newList = null;
            if (resource.DataStorageType().Equals(GDataStorageType.List))
            {
                newList = new ResourceList(resource.ObjectName(), resource.ObjectModState());
            }
            if (resource.DataStorageType().Equals(GDataStorageType.Queue))
            {
                newList = new ResourceQueue(resource.ObjectName(), resource.ObjectModState());
            }
            return newList;
        }
    }
}

