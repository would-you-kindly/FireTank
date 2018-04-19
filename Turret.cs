﻿using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireSafety
{
    public class Turret : Entity
    {
        // Классы для передачи параметров событий
        public class MoveTurretEventArgs : EventArgs
        {
            public Vector2f newPosition;

            public MoveTurretEventArgs(Vector2f newPosition)
            {
                this.newPosition = newPosition;
            }
        }
        public class RotateTurretEventArgs : EventArgs
        {
            public float newRotation;

            public RotateTurretEventArgs(float newRotation)
            {
                this.newRotation = newRotation;
            }
        }
        public class UpTurretEventArgs : EventArgs
        {
        }
        public class DownTurretEventArgs : EventArgs
        {
        }

        // События башни
        public delegate void MoveTurretEventHandler(object sender, MoveTurretEventArgs e);
        public delegate void RotateTurretEventHandler(object sender, RotateTurretEventArgs e);
        public delegate void UpTurretEventHandler(object sender, UpTurretEventArgs e);
        public delegate void DownTurretEventHandler(object sender, DownTurretEventArgs e);
        public event MoveTurretEventHandler TurretMoved;
        public event RotateTurretEventHandler TurretRotated;
        public event UpTurretEventHandler TurretUp;
        public event DownTurretEventHandler TurretDown;

        // Параметры турели
        public int maxWaterPressure = 3;
        public int waterPressure;
        public bool up;
        private RectangleShape direction;

        public Turret(Textures.ID id, TextureHolder<Textures.ID> textures) :
            base(id, textures)
        {
            // Задаем параметры турели
            waterPressure = 0;
            up = false;

            // Создаем полоску для указания направления турели
            direction = new RectangleShape(new Vector2f(2, 32));
            Utilities.CenterOrigin(direction, 0, 32);
            TurretMoved += delegate (object sender, MoveTurretEventArgs e)
            {
                direction.Position = e.newPosition;
            };
            TurretRotated += delegate (object sender, RotateTurretEventArgs e)
            {
                direction.Rotation = e.newRotation;
            };
            TurretUp += delegate (object sender, UpTurretEventArgs e)
            {
                direction.FillColor = Color.Blue;
            };
            TurretDown += delegate (object sender, DownTurretEventArgs e)
            {
                direction.FillColor = Color.Red;
            };

            // Выставляем Origin в центр картинки
            Utilities.CenterOrigin(sprite);
        }

        public void RotateBy(float rotation)
        {
            // Поворачиваем башню
            sprite.Rotation += rotation;

            TurretRotated?.Invoke(this, new RotateTurretEventArgs(NormalizedRotation));
        }

        public void MoveBy(Vector2f move)
        {
            // Поворачиваем башню
            sprite.Position += move;

            TurretMoved?.Invoke(this, new MoveTurretEventArgs(sprite.Position));
        }

        public void UpDown(bool up)
        {
            // Поднимаем/опускаем башню
            this.up = up;

            if (up)
            {
                TurretUp?.Invoke(this, new UpTurretEventArgs());
            }
            else
            {
                TurretDown?.Invoke(this, new DownTurretEventArgs());
            }
        }

        // Возвращает список координат, куда может попасть вода (или одну координату, если пушка поднята)
        public List<Vector2f> GetTargetPositions()
        {
            const int rotation = 45;
            List<Vector2f> targets = new List<Vector2f>();

            // Собираем все координаты, куда может попасть вода
            for (int i = 0; i < waterPressure; i++)
            {
                // Если пушка поднята, ищем дальнюю цель
                if (up && (i + 1 != waterPressure))
                {
                    continue;
                }

                // Вверх
                if (NormalizedRotation == rotation * 0)
                    targets.Add(new Vector2f(sprite.Position.X - Utilities.TILE_SIZE / 2, sprite.Position.Y - Utilities.TILE_SIZE / 2 - Utilities.TILE_SIZE * (i + 1)));
                // Вверх-вправо
                if (NormalizedRotation == rotation * 1)
                    targets.Add(new Vector2f(sprite.Position.X - Utilities.TILE_SIZE / 2 + Utilities.TILE_SIZE * (i + 1), sprite.Position.Y - Utilities.TILE_SIZE / 2 - Utilities.TILE_SIZE * (i + 1)));
                // Вправо
                if (NormalizedRotation == rotation * 2)
                    targets.Add(new Vector2f(sprite.Position.X - Utilities.TILE_SIZE / 2 + Utilities.TILE_SIZE * (i + 1), sprite.Position.Y - Utilities.TILE_SIZE / 2));
                // Вправо-вниз
                if (NormalizedRotation == rotation * 3)
                    targets.Add(new Vector2f(sprite.Position.X - Utilities.TILE_SIZE / 2 + Utilities.TILE_SIZE * (i + 1), sprite.Position.Y - Utilities.TILE_SIZE / 2 + Utilities.TILE_SIZE * (i + 1)));
                // Вниз
                if (NormalizedRotation == rotation * 4)
                    targets.Add(new Vector2f(sprite.Position.X - Utilities.TILE_SIZE / 2, sprite.Position.Y - Utilities.TILE_SIZE / 2 + Utilities.TILE_SIZE * (i + 1)));
                // Вниз-влево
                if (NormalizedRotation == rotation * 5)
                    targets.Add(new Vector2f(sprite.Position.X - Utilities.TILE_SIZE / 2 - Utilities.TILE_SIZE * (i + 1), sprite.Position.Y - Utilities.TILE_SIZE / 2 + Utilities.TILE_SIZE * (i + 1)));
                // Влево
                if (NormalizedRotation == rotation * 6)
                    targets.Add(new Vector2f(sprite.Position.X - Utilities.TILE_SIZE / 2 - Utilities.TILE_SIZE * (i + 1), sprite.Position.Y - Utilities.TILE_SIZE / 2));
                // Влево-вверх
                if (NormalizedRotation == rotation * 7)
                    targets.Add(new Vector2f(sprite.Position.X - Utilities.TILE_SIZE / 2 - Utilities.TILE_SIZE * (i + 1), sprite.Position.Y - Utilities.TILE_SIZE / 2 - Utilities.TILE_SIZE * (i + 1)));
            }

            return targets;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(sprite, states);
            target.Draw(direction, states);
        }
    }
}
