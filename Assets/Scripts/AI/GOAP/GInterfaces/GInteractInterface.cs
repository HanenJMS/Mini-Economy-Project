namespace MP.GOAP.Interfaces
{
    public interface GInteractInterface
    {
        public string ObjectType();
        public string ObjectModState();
        public string ObjectName();
        public int ObjectStateModifierAmount();
        public GDataStorageType DataStorageType();
        public GDataStorageType SetModStateStorageType(GDataStorageType storageType);
        public void UpdateCurrentZone(object currentZone);
        public object ChangeCurrentZone();
    }
}

