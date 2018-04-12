using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace FireSafety
{
    public class Tree : Entity
    {
        public TreeState state;
        private Flame flame;
        private Sprite burnedTreeSprite;

        public Tree(Textures.ID idTree, TextureHolder<Textures.ID> textures) :
            base(idTree, textures)
        {
            state = new NormalTreeState();

            flame = new Flame(Textures.ID.Fire, textures);
            burnedTreeSprite = new Sprite(textures.Get(Textures.ID.BurnedTree));
        }

        public void Extinguish()
        {
            state.Extinguish(this);
        }

        public void Fire()
        {
            state.Fire(this);
        }

        public void Burn()
        {
            state.Burn(this);
        }

        public override void Update(Time deltaTime)
        {
            if (state.IsBurning() && --state.hitPoints == 0)
            {
                // TODO: Дерево сгорело, но в списке леса осталось
                Burn();
            }
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            if (state.IsNormal())
            {
                target.Draw(sprite, states);
            }

            if (state.IsBurning())
            {
                target.Draw(sprite, states);
                target.Draw(flame.sprite, states);
            }

            if (state.IsBurned())
            {
                // TODO: Нужно будет вернуть цвет, если дерево будет потушено
                target.Draw(burnedTreeSprite, states);
            }
        }
    }
}
