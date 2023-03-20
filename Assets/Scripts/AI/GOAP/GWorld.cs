namespace MP.GOAP
{
    public sealed class GWorld
    {
        private static readonly GWorld instance = new GWorld();
        private static WorldStates world;
        public static GWorld Instance => instance;
        static GWorld()
        {
            world = new WorldStates();
        }
        private GWorld()
        {
        }
        public WorldStates GetWorld()
        {
            return world;
        }
    }
}
