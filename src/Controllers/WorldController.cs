namespace FireSafety
{
    public class WorldController
    {
        public World world;

        public WorldController(World world)
        {
            this.world = world;
        }

        public void BuildWorld()
        {
            world.BuildWorld();
        }

        public void LoadMap(IOpenSave openSave)
        {
            world.LoadMap(openSave);
        }

        public string GetMapProperty(string property)
        {
            return world.map.properties[property];
        }

        public Wind GetWind()
        {
            return world.terrain.wind;
        }
    }
}