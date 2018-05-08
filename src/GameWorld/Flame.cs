namespace FireSafety
{
    class Flame : Entity
    {
        public Flame(Textures.ID id, ResourceHolder resources) :
            base(id, resources)
        {
            Utilities.CenterOrigin(sprite);
        }
    }
}
