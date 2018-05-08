using System;

namespace FireSafety
{
    public class WorldController
    {
        private World world;

        public WorldController(World world)
        {
            this.world = world;
        }

        public void BuildWorld()
        {
            world.BuildWorld();
        }

        public void LoadMapFromFile(string filename)
        {
            world.LoadMapFromFile(filename);
        }

        public void LoadMapFromDatabase(Guid id)
        {
            world.LoadMapFromDatabase(id);
        }

        public string GetMapProperty(string property)
        {
            return world.map.properties[property];
        }

        public Wind.Direction GetWindDirection()
        {
            return world.terrain.wind.direction;
        }
    }
}