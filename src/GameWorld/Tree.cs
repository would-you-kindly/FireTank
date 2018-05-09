using SFML.Graphics;
using SFML.System;
using System;

namespace FireSafety
{
    public class Tree : Entity, IFlammable
    {
        // Классы для передачи параметров событий
        public class ExtinguishTreeEventArgs : EventArgs
        {
        }
        public class FireTreeEventArgs : EventArgs
        {
        }
        public class BurnTreeEventArgs : EventArgs
        {
        }

        // События дерева
        public delegate void ExtinguishTreeEventHandler(object sender, ExtinguishTreeEventArgs e);
        public delegate void FireTreeEventHandler(object sender, FireTreeEventArgs e);
        public delegate void BurnTreeEventHandler(object sender, BurnTreeEventArgs e);
        public event ExtinguishTreeEventHandler Extinguished;
        public event FireTreeEventHandler Fired;
        public event BurnTreeEventHandler Burned;

        // Параметры дерева
        public TreeState state;
        private Flame flame;
        private Sprite burnedTreeSprite;

        public Tree(Textures.ID idTree, ResourceHolder resources) :
            base(idTree, resources)
        {
            state = new NormalTreeState();

            flame = new Flame(Textures.ID.Fire, resources);
            burnedTreeSprite = new Sprite(resources.GetTexture(Textures.ID.BurnedTree));

            Utilities.CenterOrigin(burnedTreeSprite);
            Utilities.CenterOrigin(sprite);
        }

        // Тушит дерево
        public void Extinguish()
        {
            state.Extinguish(this);
            Extinguished?.Invoke(this, new ExtinguishTreeEventArgs());
        }

        // Поджигает дерево
        public void Fire()
        {
            state.Fire(this);
            Fired?.Invoke(this, new FireTreeEventArgs());
        }

        // Уничтожает дерево
        public void Burn()
        {
            state.Burn(this);
            Burned?.Invoke(this, new BurnTreeEventArgs());
        }

        public override void Update(Time deltaTime)
        {
            if (state.IsBurning() && --state.hitPoints == 0)
            {
                Burn();
            }
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            // Рисуем дерево согласно его текущему состоянию
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
                target.Draw(burnedTreeSprite, states);
            }
        }

        public override string ToString()
        {
            return "Дерево";
        }
    }
}
