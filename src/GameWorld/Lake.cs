namespace FireSafety
{
    public class Lake : Entity
    {
        public Lake(Textures.ID idLake, ResourceHolder resources)
            : base(idLake, resources)
        {
            Utilities.CenterOrigin(sprite);
        }

        public override string ToString()
        {
            return Properties.Resources.Lake;
        }
    }
}