using SFML.Graphics;

namespace FireSafety
{
    public class Lake : Entity
    {
        public Lake(Textures.ID idLake, TextureHolder<Textures.ID> textures) 
            : base(idLake, textures)
        {

        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(sprite, states);
        }
    }
}