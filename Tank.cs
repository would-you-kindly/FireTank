using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace FireSafety
{
    public class Tank : Entity
    {
        public enum TankColor
        {
            Red = 0,
            Blue,
            Yellow,
            Green
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

        // События танка
        public delegate void CollideEventHandler(object sender, CollideEventArgs e);
        public delegate void MoveTankEventHandler(object sender, MoveTankEventArgs e);
        public delegate void RotateTankEventHandler(object sender, RotateTankEventArgs e);
        public event CollideEventHandler Collided;
        public event MoveTankEventHandler TankMoved;
        public event RotateTankEventHandler TankRotated;

        // Параметры-ссылки
        private Algorithm _algorithm;
        private Terrain _terrain;

        // Параметры танка
        public Turret turret;
        public TankColor color;
        private Text number;
        private RectangleShape direction;

        public Tank(Textures.ID idTank, Textures.ID idTurret, TextureHolder<Textures.ID> textures, FontHolder<Fonts.ID> fonts, TankColor color) :
            base(idTank, textures)
        {
            // Создаем турель (башню) танка
            turret = new Turret(idTurret, textures);

            // Определяем цвет танка
            this.color = color;

            // Определяем номер танка
            number = new Text(((int)color + 1).ToString(), fonts.Get(Fonts.ID.Sansation), 20);
            number.FillColor = Color.Red;
            number.OutlineThickness = 0.75f;
            Utilities.CenterOrigin(number);
            TankMoved += delegate (object sender, MoveTankEventArgs e)
            {
                number.Position = e.newPosition + new Vector2f(Utilities.TILE_SIZE / 3, Utilities.TILE_SIZE / 3);
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

            // Определяем событие столкновения с объектами сцены
            Collided += delegate (object sender, CollideEventArgs e)
            {
                Game.error = true;
                Game.errorTank = (Tank)sender;
                Game.errorCollideEventArgs = e;
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

        public void SetPosition(Vector2f position)
        {
            MoveBy(position);
        }

        public void SetRotation(float rotation)
        {
            RotateTankBy(rotation);
        }

        public void SetTurretRotation(float rotation)
        {
            RotateTurretBy(rotation);
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
                MoveBy(new Vector2f(0, -Utilities.TILE_SIZE * sign));
            // Вверх-вправо
            if (NormalizedRotation == rotation * 1)
                MoveBy(new Vector2f(Utilities.TILE_SIZE * sign, -Utilities.TILE_SIZE * sign));
            // Вправо
            if (NormalizedRotation == rotation * 2)
                MoveBy(new Vector2f(Utilities.TILE_SIZE * sign, 0));
            // Вправо-вниз
            if (NormalizedRotation == rotation * 3)
                MoveBy(new Vector2f(Utilities.TILE_SIZE * sign, Utilities.TILE_SIZE * sign));
            // Вниз
            if (NormalizedRotation == rotation * 4)
                MoveBy(new Vector2f(0, Utilities.TILE_SIZE * sign));
            // Вниз-влево
            if (NormalizedRotation == rotation * 5)
                MoveBy(new Vector2f(-Utilities.TILE_SIZE * sign, Utilities.TILE_SIZE * sign));
            // Влево
            if (NormalizedRotation == rotation * 6)
                MoveBy(new Vector2f(-Utilities.TILE_SIZE * sign, 0));
            // Влево-вверх
            if (NormalizedRotation == rotation * 7)
                MoveBy(new Vector2f(-Utilities.TILE_SIZE * sign, -Utilities.TILE_SIZE * sign));

            CheckCollisions();
        }

        private void CheckCollisions()
        {
            // Если танк столкнулся с препятствием на местности, инициируем событие столкновения
            foreach (Entity entity in _terrain)
            {
                if (sprite.Position - new Vector2f(Utilities.TILE_SIZE / 2, Utilities.TILE_SIZE / 2) == entity.Position)
                {
                    Collided?.Invoke(this, new CollideEventArgs(entity));
                }
            }

            // Если танк столкнулся с другим танком (исключая себя), инициируем событие столкновения
            foreach (Tank tank in Game.world.tanks)
            {
                if (sprite.Position == tank.sprite.Position && tank != this)
                {
                    Collided?.Invoke(this, new CollideEventArgs(tank));
                }
            }
        }

        private void RotateTurretBy(float degrees)
        {
            turret.RotateBy(degrees);
        }

        private void RotateTankBy(float degrees)
        {
            // Поворачиваем танк и башню
            sprite.Rotation += degrees;
            turret.sprite.Rotation += degrees;

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
                    RotateTankBy(90);
                    break;
                case MoveCommand.Commands.Rotate90CCW:
                    RotateTankBy(-90);
                    break;
                case MoveCommand.Commands.Rotate45CW:
                    RotateTankBy(45);
                    break;
                case MoveCommand.Commands.Rotate45CCW:
                    RotateTankBy(-45);
                    break;
                case MoveCommand.Commands.Forward45CW:
                    if ((NormalizedRotation / 45.0) % 2 == 1)
                    {
                        MoveTo(MoveCommand.Commands.Forward);
                        RotateTankBy(45);
                    }
                    else
                    {
                        RotateTankBy(45);
                        MoveTo(MoveCommand.Commands.Forward);
                    }
                    break;
                case MoveCommand.Commands.Forward45CCW:
                    if ((NormalizedRotation / 45.0) % 2 == 1)
                    {
                        MoveTo(MoveCommand.Commands.Forward);
                        RotateTankBy(-45);
                    }
                    else
                    {
                        RotateTankBy(-45);
                        MoveTo(MoveCommand.Commands.Forward);
                    }
                    break;
                case MoveCommand.Commands.Backward45CW:
                    if ((NormalizedRotation / 45.0) % 2 == 1)
                    {
                        MoveTo(MoveCommand.Commands.Backward);
                        RotateTankBy(45);
                    }
                    else
                    {
                        RotateTankBy(45);
                        MoveTo(MoveCommand.Commands.Backward);
                    }
                    break;
                case MoveCommand.Commands.Backward45CCW:
                    if ((NormalizedRotation / 45.0) % 2 == 1)
                    {
                        MoveTo(MoveCommand.Commands.Backward);
                        RotateTankBy(-45);
                    }
                    else
                    {
                        RotateTankBy(-45);
                        MoveTo(MoveCommand.Commands.Backward);
                    }
                    break;
                default:
                    break;
            }
        }

        public void ChargeCommand(ShootCommand.Commands command)
        {
            switch (command)
            {
                case ShootCommand.Commands.Pressure:
                    turret.Pressure();
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
                    RotateTurretBy(45);
                    break;
                case FireSafety.TurretCommand.Commands.Rotate45CCW:
                    RotateTurretBy(-45);
                    break;
                case FireSafety.TurretCommand.Commands.Rotate90CW:
                    RotateTurretBy(90);
                    break;
                case FireSafety.TurretCommand.Commands.Rotate90CCW:
                    RotateTurretBy(-90);
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

        // Пошагово выполняет алгоритм, заложенный в Algorithm
        public void Execute(Algorithm algorithm)
        {
            if (algorithm.HasCommands())
            {
                Action action = algorithm.GetNextAction();

                foreach (Command command in action.commands)
                {
                    command?.Execute(this);
                }
            }
        }

        public override void Update(Time deltaTime)
        {
            Execute(_algorithm);
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
    }
}
