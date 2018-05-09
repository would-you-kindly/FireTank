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

        public void LoadMap(IOpenSave openSave)
        {
            world.LoadMap(openSave);
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