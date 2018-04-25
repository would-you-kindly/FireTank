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

        public void LoadMap(string filename)
        {
            world.LoadMap(filename);
        }
    }
}