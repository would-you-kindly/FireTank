using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;

namespace FireSafety
{
    public class Tank : Entity
    {
        public enum TankColor
        {
            Red = 0,
            Blue,
            Yellow,
            Green,
            Pink,
            Grey
        }

        // Классы для передачи параметров событий
        public class CollideEventArgs : EventArgs
        {
            // Объект, с которым столкнулся танк
            public Entity entity;

            public CollideEventArgs(Entity entity)
            {
                this.entity = entity;
            }
        }
        public class MapLeftEventArgs : EventArgs
        {
        }
        public class MoveTankEventArgs : EventArgs
        {
            // Новая позиция танка
            public Vector2f newPosition;

            public MoveTankEventArgs(Vector2f newPosition)
            {
                this.newPosition = newPosition;
            }
        }
        public class RotateTankEventArgs : EventArgs
        {
        }
        public class NearLakeErrorEventArgs : EventArgs
        {
        }
        public class RefueledEventArgs : EventArgs
        {
        }
        public class RefuelErrorEventArgs : EventArgs
        {
        }

        // События танка
        public delegate void CollideEventHandler(object sender, CollideEventArgs e);
        public delegate void MapLeftEventHandler(object sender, MapLeftEventArgs e);
        public delegate void MoveTankEventHandler(object sender, MoveTankEventArgs e);
        public delegate void RotateTankEventHandler(object sender, RotateTankEventArgs e);
        public delegate void NearLakeErrorEventHandler(object sender, NearLakeErrorEventArgs e);
        public delegate void RefuelErrorEventHandler(object sender, RefuelErrorEventArgs e);
        public delegate void RefueledEventHandler(object sender, RefueledEventArgs e);
        public event CollideEventHandler Collided;
        public event MapLeftEventHandler MapLeft;
        public event MoveTankEventHandler TankMoved;
        public event RotateTankEventHandler TankRotated;
        public event NearLakeErrorEventHandler NearLakeError;
        public event RefueledEventHandler Refueled;
        public event RefuelErrorEventHandler RefuelError;

        // Параметры-ссылки
        private Algorithm _algorithm;
        private Terrain _terrain;
        private List<Tank> _tanks;

        // Параметры танка
        public Turret turret;
        public TankColor color;
        private Text number;
        private RectangleShape direction;

        public Tank(Textures.ID idTank, Textures.ID idTurret, ResourceHolder resources, TankColor color) :
            base(idTank, resources)
        {
            // Создаем турель (башню) танка
            turret = new Turret(idTurret, resources, this);

            // Определяем цвет танка
            this.color = color;

            // Определяем номер танка
            number = new Text(((int)color + 1).ToString(), resources.GetFont(Fonts.ID.Sansation), 20);
            number.FillColor = Color.Red;
            number.OutlineThickness = 0.75f;
            Utilities.CenterOrigin(number);
            TankMoved += delegate (object sender, MoveTankEventArgs e)
            {
                number.Position = e.newPosition + new Vector2f(Utilities.GetInstance().TILE_SIZE / 3, Utilities.GetInstance().TILE_SIZE / 3);
            };

            // Создаем полоску для указания направления танка
            direction = new RectangleShape(new Vector2f(6, 16));
            direction.FillColor = Color.Yellow;
            Utilities.CenterOrigin(direction, 0, 16);
            TankMoved += delegate (object sender, MoveTankEventArgs e)
            {
                direction.Position = e.newPosition;
            };
            TankRotated += delegate (object sender, RotateTankEventArgs e)
            {
                direction.Rotation = sprite.Rotation;
            };

            // Выставляем Origin в центр картинки
            Utilities.CenterOrigin(sprite);
        }

        public void SetAlgorithm(Algorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public void SetTerrain(Terrain terrain)
        {
            _terrain = terrain;
            turret.SetTerrain(terrain);
        }

        public void SetTanks(List<Tank> tanks)
        {
            _tanks = tanks;
            turret.SetTanks(tanks);
        }

        public void SetPosition(Vector2f position)
        {
            MoveBy(position);
        }

        public void SetRotation(float rotation)
        {
            RotateBy(rotation);
        }

        public void SetTurretRotation(float rotation)
        {
            turret.RotateBy(rotation);
        }

        public bool NearLake()
        {
            foreach (Lake lake in _terrain.lakes)
            {
                // Если рядом с танком (по вертикали или горизонтали) есть озеро, возвращаем true
                if (sprite.Position == lake.Position - new Vector2f(Utilities.GetInstance().TILE_SIZE, 0) ||
                    sprite.Position == lake.Position + new Vector2f(Utilities.GetInstance().TILE_SIZE, 0) ||
                    sprite.Position == lake.Position - new Vector2f(0, Utilities.GetInstance().TILE_SIZE) ||
                    sprite.Position == lake.Position + new Vector2f(0, Utilities.GetInstance().TILE_SIZE))
                {
                    return true;
                }
            }

            return false;
        }

        private void MoveBy(Vector2f move)
        {
            // Перемещаем танк и башню
            sprite.Position += move;
            turret.MoveBy(move);

            TankMoved?.Invoke(this, new MoveTankEventArgs(sprite.Position));
        }

        private void MoveTo(MoveCommand.Commands where)
        {
            int sign = where == MoveCommand.Commands.Forward ? 1 : -1;
            const int rotation = 45;

            // Вверх
            if (NormalizedRotation == rotation * 0)
                MoveBy(new Vector2f(0, -Utilities.GetInstance().TILE_SIZE * sign));
            // Вверх-вправо
            if (NormalizedRotation == rotation * 1)
                MoveBy(new Vector2f(Utilities.GetInstance().TILE_SIZE * sign, -Utilities.GetInstance().TILE_SIZE * sign));
            // Вправо
            if (NormalizedRotation == rotation * 2)
                MoveBy(new Vector2f(Utilities.GetInstance().TILE_SIZE * sign, 0));
            // Вправо-вниз
            if (NormalizedRotation == rotation * 3)
                MoveBy(new Vector2f(Utilities.GetInstance().TILE_SIZE * sign, Utilities.GetInstance().TILE_SIZE * sign));
            // Вниз
            if (NormalizedRotation == rotation * 4)
                MoveBy(new Vector2f(0, Utilities.GetInstance().TILE_SIZE * sign));
            // Вниз-влево
            if (NormalizedRotation == rotation * 5)
                MoveBy(new Vector2f(-Utilities.GetInstance().TILE_SIZE * sign, Utilities.GetInstance().TILE_SIZE * sign));
            // Влево
            if (NormalizedRotation == rotation * 6)
                MoveBy(new Vector2f(-Utilities.GetInstance().TILE_SIZE * sign, 0));
            // Влево-вверх
            if (NormalizedRotation == rotation * 7)
                MoveBy(new Vector2f(-Utilities.GetInstance().TILE_SIZE * sign, -Utilities.GetInstance().TILE_SIZE * sign));

            CheckCollisions();
        }

        private void CheckCollisions()
        {
            // Если танк столкнулся с препятствием на местности, инициируем событие столкновения
            foreach (Entity entity in _terrain)
            {
                if (sprite.Position == entity.Position)
                {
                    Collided?.Invoke(this, new CollideEventArgs(entity));
                }
            }

            // Если танк столкнулся с другим танком (исключая себя), инициируем событие столкновения
            foreach (Tank tank in _tanks)
            {
                if (sprite.Position == tank.sprite.Position && tank != this)
                {
                    Collided?.Invoke(this, new CollideEventArgs(tank));
                }
            }

            // Если танк вышел за пределы карты, инициируем событие 
            if (sprite.Position.X > Utilities.GetInstance().TILE_SIZE * Utilities.GetInstance().WIDTH_TILE_COUNT ||
                sprite.Position.X < 0 ||
                sprite.Position.Y > Utilities.GetInstance().TILE_SIZE * Utilities.GetInstance().HEIGHT_TILE_COUNT ||
                sprite.Position.Y < 0)
            {
                MapLeft?.Invoke(this, new MapLeftEventArgs());
            }
        }

        private void RotateBy(float degrees)
        {
            // Поворачиваем танк и башню
            sprite.Rotation += degrees;
            turret.RotateBy(degrees);

            TankRotated?.Invoke(this, new RotateTankEventArgs());
        }

        public void MovementCommand(MoveCommand.Commands command)
        {
            switch (command)
            {
                case MoveCommand.Commands.Forward:
                    MoveTo(MoveCommand.Commands.Forward);
                    break;
                case MoveCommand.Commands.Backward:
                    MoveTo(MoveCommand.Commands.Backward);
                    break;
                case MoveCommand.Commands.Rotate90CW:
                    RotateBy(90);
                    break;
                case MoveCommand.Commands.Rotate90CCW:
                    RotateBy(-90);
                    break;
                case MoveCommand.Commands.Rotate45CW:
                    RotateBy(45);
                    break;
                case MoveCommand.Commands.Rotate45CCW:
                    RotateBy(-45);
                    break;
                case MoveCommand.Commands.Forward45CW:
                    MoveAndRotate(MoveCommand.Commands.Forward, 45.0f);
                    break;
                case MoveCommand.Commands.Forward45CCW:
                    MoveAndRotate(MoveCommand.Commands.Forward, -45.0f);
                    break;
                case MoveCommand.Commands.Backward45CW:
                    MoveAndRotate(MoveCommand.Commands.Backward, 45.0f);
                    break;
                case MoveCommand.Commands.Backward45CCW:
                    MoveAndRotate(MoveCommand.Commands.Backward, -45.0f);
                    break;
                default:
                    break;
            }
        }

        private void MoveAndRotate(MoveCommand.Commands where, float rotation)
        {
            if ((NormalizedRotation / 45.0) % 2 == 1)
            {
                MoveTo(where);
                RotateBy(rotation);
            }
            else
            {
                RotateBy(rotation);
                MoveTo(where);
            }
        }

        public void ChargeCommand(ChargeCommand.Commands command)
        {
            switch (command)
            {
                case FireSafety.ChargeCommand.Commands.PressureX1:
                    // Увеличить давление на 1
                    turret.Pressure(1);
                    break;
                case FireSafety.ChargeCommand.Commands.PressureX2:
                    // Увеличить давление на 2
                    turret.Pressure(2);
                    break;
                case FireSafety.ChargeCommand.Commands.Refuel:
                    Refuel();
                    break;
                case FireSafety.ChargeCommand.Commands.Charge:
                    turret.Charge();
                    break;
                default:
                    break;
            }
        }

        public void TurretCommand(TurretCommand.Commands command)
        {
            switch (command)
            {
                case FireSafety.TurretCommand.Commands.Rotate45CW:
                    turret.RotateBy(45);
                    break;
                case FireSafety.TurretCommand.Commands.Rotate45CCW:
                    turret.RotateBy(-45);
                    break;
                case FireSafety.TurretCommand.Commands.Rotate90CW:
                    turret.RotateBy(90);
                    break;
                case FireSafety.TurretCommand.Commands.Rotate90CCW:
                    turret.RotateBy(-90);
                    break;
                case FireSafety.TurretCommand.Commands.Up:
                    turret.UpDown(true);
                    break;
                case FireSafety.TurretCommand.Commands.Down:
                    turret.UpDown(false);
                    break;
                case FireSafety.TurretCommand.Commands.Shoot:
                    turret.Shoot();
                    break;
                default:
                    break;
            }
        }

        // Пополнение запасов
        private void Refuel()
        {
            if (!NearLake())
            {
                NearLakeError?.Invoke(this, new NearLakeErrorEventArgs());

                return;
            }

            if (turret.waterCapacity < turret.maxWaterCapacity)
            {
                turret.waterCapacity++;

                Refueled?.Invoke(this, new RefueledEventArgs());
            }
            else
            {
                RefuelError?.Invoke(this, new RefuelErrorEventArgs());
            }
        }

        // Пошагово выполняет алгоритм, заложенный в Algorithm
        private void Execute()
        {
            if (_algorithm.HasActions())
            {
                Action action = _algorithm.GetNextAction();

                foreach (Command command in action.commands)
                {
                    command?.Execute(this);
                }
            }
        }

        public override void Update(Time deltaTime)
        {
            Execute();
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            // Рисуем корпус танка (с направлением)
            target.Draw(sprite, states);
            target.Draw(direction, states);

            // Рисуем башню танка (с направлением)
            target.Draw(turret, states);

            // Рисуем номер танка
            target.Draw(number, states);
        }

        public override string ToString()
        {
            string result = string.Empty;

            switch (color)
            {
                case TankColor.Red:
                    result += $"Красный танк (№{number.DisplayedString})";
                    break;
                case TankColor.Blue:
                    result += $"Синий танк (№{number.DisplayedString})";
                    break;
                case TankColor.Yellow:
                    result += $"Желтый танк (№{number.DisplayedString})";
                    break;
                case TankColor.Green:
                    result += $"Зеленый танк (№{number.DisplayedString})";
                    break;
                case TankColor.Pink:
                    result += $"Розовый танк (№{number.DisplayedString})";
                    break;
                case TankColor.Grey:
                    result += $"Серый танк (№{number.DisplayedString})";
                    break;
            }

            return result;
        }
    }
}
