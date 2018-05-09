using SFML.Graphics;
using SFML.System;
using System;

namespace FireSafety
{
    public class House : Entity, IFlammable
    {
        // Классы для передачи параметров событий
        public class ExtinguishHouseEventArgs : EventArgs
        {
        }
        public class FireHouseEventArgs : EventArgs
        {
        }
        public class BurnHouseEventArgs : EventArgs
        {
        }

        // События дома
        public delegate void ExtinguishHouseEventHandler(object sender, ExtinguishHouseEventArgs e);
        public delegate void FireHouseEventHandler(object sender, FireHouseEventArgs e);
        public delegate void BurnHouseEventHandler(object sender, BurnHouseEventArgs e);
        public event ExtinguishHouseEventHandler Extinguished;
        public event FireHouseEventHandler Fired;
        public event BurnHouseEventHandler Burned;

        // Параметры дома
        public HouseState state;
        private Flame flame;
        private Sprite burnedHouseSprite;

        public House(Textures.ID id, ResourceHolder resources)
            : base(id, resources)
        {
            state = new NormalHouseState();

            flame = new Flame(Textures.ID.Fire, resources);
            burnedHouseSprite = new Sprite(resources.GetTexture(Textures.ID.BurnedHouse));

            Utilities.CenterOrigin(burnedHouseSprite);
            Utilities.CenterOrigin(sprite);
        }

        // Тушит дом
        public void Extinguish()
        {
            state.Extinguish(this);
            Extinguished?.Invoke(this, new ExtinguishHouseEventArgs());
        }

        // Поджигает дом
        public void Fire()
        {
            state.Fire(this);
            Fired?.Invoke(this, new FireHouseEventArgs());
        }

        // Уничтожает дом
        public void Burn()
        {
            state.Burn(this);
            Burned?.Invoke(this, new BurnHouseEventArgs());
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

            // Рисуем дом согласно его текущему состоянию
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
                target.Draw(burnedHouseSprite, states);
            }
        }

        public override string ToString()
        {
            return "Дом";
        }
    }
}
