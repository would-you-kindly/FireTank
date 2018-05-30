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
        private Text hitPoints;

        public Tree(Textures.ID idTree, ResourceHolder resources) :
            base(idTree, resources)
        {
            state = new NormalTreeState();

            flame = new Flame(Textures.ID.Fire, resources);
            burnedTreeSprite = new Sprite(resources.GetTexture(Textures.ID.BurnedTree));

            // Количество жизней дерева
            hitPoints = new Text(state.hitPoints.ToString(), resources.GetFont(Fonts.ID.Sansation), 12);
            hitPoints.FillColor = Color.Blue;
            hitPoints.OutlineThickness = 0.5f;
            Utilities.CenterOrigin(hitPoints);
            hitPoints.Position = sprite.Position + new Vector2f(Utilities.GetInstance().TILE_SIZE / 3, Utilities.GetInstance().TILE_SIZE / 3);

            Utilities.CenterOrigin(burnedTreeSprite);
            Utilities.CenterOrigin(sprite);
        }

        public void SetHitpoints(int hitPoints)
        {
            state.hitPoints = hitPoints;
            this.hitPoints.DisplayedString = hitPoints.ToString();
        }

        // Тушит дерево
        public void Water()
        {
            state.Water(this);
            Extinguished?.Invoke(this, new ExtinguishTreeEventArgs());
        }

        // Поджигает дерево
        public void Fire(int power)
        {
            state.Fire(this, power);
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

            hitPoints.DisplayedString = state.hitPoints.ToString();
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
                target.Draw(hitPoints, states);
            }

            if (state.IsBurned())
            {
                target.Draw(burnedTreeSprite, states);
            }

            if (state.IsWet())
            {
                Sprite wetTree = new Sprite(sprite);
                wetTree.Color = Color.Magenta;
                target.Draw(wetTree, states);
            }
        }

        public override string ToString()
        {
            return Properties.Resources.Tree;
        }
    }
}
