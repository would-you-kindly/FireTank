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
        public enum State
        {
            Normal,
            Burns,
            Burned
        }

        public State state;
        private int hitPoints = 10;
        private Flame flame;
        private Sprite burnedTreeSprite;

        public Tree(Textures.ID idTree, Textures.ID idFlame, TextureHolder<Textures.ID> textures) :
            base(idTree, textures)
        {
            flame = new Flame(idFlame, textures);
            burnedTreeSprite = new Sprite(textures.Get(Textures.ID.BurnedTree));
            state = State.Normal;
        }

        // Тушит дерево
        public void Extinguish()
        {
            if (state == State.Burns)
            {
                state = State.Normal;
            }
        }

        // Поджигает дерево
        public void Fire()
        {
            if (state == State.Normal)
            {
                state = State.Burns;
            }
        }

        // Сжигает дерево
        public void Burn()
        {
            if (state == State.Burns)
            {
                state = State.Burned;
            }
        }

        // Проверяет, не горит ли дерево
        public bool IsNormal()
        {
            return state == State.Normal;
        }

        // Проверяет, горит ли дерево
        public bool IsBurns()
        {
            return state == State.Burns;
        }

        // Проверяет, сгорело ли дерево
        public bool IsBurned()
        {
            return state == State.Burned;
        }

        public override void Update(Time deltaTime)
        {
            if (IsBurns() && --hitPoints == 0)
            {
                // TODO: Дерево сгорело, но в списке леса осталось
                Burn();
            }
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            switch (state)
            {
                case State.Normal:
                    target.Draw(sprite, states);
                    break;
                case State.Burns:
                    target.Draw(sprite, states);
                    target.Draw(flame.sprite, states);
                    break;
                case State.Burned:
                    // TODO: Нужно будет вернуть цвет, если дерево будет потушено
                    target.Draw(burnedTreeSprite, states);
                    break;
                default:
                    break;
            }
        }
    }
}
