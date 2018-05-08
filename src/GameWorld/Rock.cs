namespace FireSafety
{
    public class Rock : Entity
    {
        public Rock(Textures.ID idRock, ResourceHolder resources)
            : base(idRock, resources)
        {
            Utilities.CenterOrigin(sprite);
        }

        public override string ToString()
        {
            return "Скала";
        }
    }
}
