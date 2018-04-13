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
            Red,
            Blue,
            Yellow,
            Green
        }


        private Algorithm _algorithm;
        private Turret turret;
        private Forest _forest;
        private TankColor tankColor;

        public Tank(Textures.ID idTank, Textures.ID idTurret, TextureHolder<Textures.ID> textures, TankColor tankColor, Forest forest) :
            base(idTank, textures)
        {
            turret = new Turret(idTurret, textures);
            this.tankColor = tankColor;
            _forest = forest;

            // Выставляем Origin в центр картинки
            Utilities.CenterOrigin(sprite);
        }

        public void SetAlgorithm(Algorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public void Move(Vector2f move)
        {
            // Перемещаем и танк, и пушку
            sprite.Position += move;
            turret.sprite.Position += move;
        }

        private void MoveTank(MoveCommand.Commands where)
        {
            int sign = where == MoveCommand.Commands.Forward ? 1 : -1;
            const int rotation = 45;

            // Вверх
            if (NormalizedRotation == rotation * 0)
                Move(new Vector2f(0, -Utilities.TILE_SIZE * sign));
            // Вверх-вправо
            if (NormalizedRotation == rotation * 1)
                Move(new Vector2f(Utilities.TILE_SIZE * sign, -Utilities.TILE_SIZE * sign));
            // Вправо
            if (NormalizedRotation == rotation * 2)
                Move(new Vector2f(Utilities.TILE_SIZE * sign, 0));
            // Вправо-вниз
            if (NormalizedRotation == rotation * 3)
                Move(new Vector2f(Utilities.TILE_SIZE * sign, Utilities.TILE_SIZE * sign));
            // Вниз
            if (NormalizedRotation == rotation * 4)
                Move(new Vector2f(0, Utilities.TILE_SIZE * sign));
            // Вниз-влево
            if (NormalizedRotation == rotation * 5)
                Move(new Vector2f(-Utilities.TILE_SIZE * sign, Utilities.TILE_SIZE * sign));
            // Влево
            if (NormalizedRotation == rotation * 6)
                Move(new Vector2f(-Utilities.TILE_SIZE * sign, 0));
            // Влево-вверх
            if (NormalizedRotation == rotation * 7)
                Move(new Vector2f(-Utilities.TILE_SIZE * sign, -Utilities.TILE_SIZE * sign));
        }

        public void RotateTurret(float degrees)
        {
            turret.sprite.Rotation += degrees;
        }

        public void RotateTank(float degrees)
        {
            sprite.Rotation += degrees;
            RotateTurret(degrees);
        }

        public void Move(MoveCommand.Commands command)
        {
            switch (command)
            {
                case MoveCommand.Commands.Forward:
                    MoveTank(MoveCommand.Commands.Forward);
                    break;
                case MoveCommand.Commands.Backward:
                    MoveTank(MoveCommand.Commands.Backward);
                    break;
                case MoveCommand.Commands.Rotate90CW:
                    RotateTank(90);
                    break;
                case MoveCommand.Commands.Rotate90CCW:
                    RotateTank(-90);
                    break;
                case MoveCommand.Commands.Rotate45CW:
                    RotateTank(45);
                    break;
                case MoveCommand.Commands.Rotate45CCW:
                    RotateTank(-45);
                    break;
                default:
                    break;
            }
        }

        public void Shoot(ShootCommand.Commands command)
        {
            switch (command)
            {
                case ShootCommand.Commands.IncreaseWaterPressure:
                    if (turret.waterPressure < turret.maxWaterPressure)
                    {
                        turret.waterPressure++;
                    }
                    Console.WriteLine("ShootCommand.Commands.IncreaseWaterPressure");
                    break;
                case ShootCommand.Commands.Shoot:
                    if (turret.waterPressure != 0)
                    {
                        // Если пушка опущена, то можно потушить ближайшее дерево
                        if (!turret.up)
                        {
                            foreach (Vector2f coords in turret.GetTargetPositions())
                            {
                                Tree treeToExtinguish = _forest.trees.Find(tree => tree.Position == coords);

                                // Если нашли ближайшее дерево, то остальные не проверяем
                                if (treeToExtinguish != null)
                                {
                                    treeToExtinguish.Extinguish();
                                    break;
                                }
                            }
                        }
                        // Если пушка поднята, то можно потушить только одно дальнее дерево
                        else
                        {
                            Tree treeToExtinguish = _forest.trees.Find(tree => tree.Position == turret.GetTargetPositions()[0]);
                            treeToExtinguish?.Extinguish();
                        }

                        turret.waterPressure = 0;
                    }
                    Console.WriteLine("ShootCommand.Commands.Shoot");
                    break;
                default:
                    break;
            }
        }

        public void RotateTurret(TurretCommand.Commands command)
        {
            switch (command)
            {
                case TurretCommand.Commands.Rotate45CW:
                    RotateTurret(45);
                    break;
                case TurretCommand.Commands.Rotate45CCW:
                    RotateTurret(-45);
                    break;
                case TurretCommand.Commands.Rotate90CW:
                    RotateTurret(90);
                    break;
                case TurretCommand.Commands.Rotate90CCW:
                    RotateTurret(-90);
                    break;
                case TurretCommand.Commands.Up:
                    turret.up = true;
                    break;
                case TurretCommand.Commands.Down:
                    turret.up = false;
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
            RectangleShape tankDirection = new RectangleShape(new Vector2f(6, 16));
            Utilities.CenterOrigin(tankDirection, 0, 16);
            tankDirection.FillColor = Color.Yellow;
            tankDirection.Position = sprite.Position;
            tankDirection.Rotation = sprite.Rotation;
            target.Draw(tankDirection);

            // Рисуем башню танка (с направлением)
            target.Draw(turret.sprite, states);
            RectangleShape turretDirection = new RectangleShape(new Vector2f(2, 32));
            Utilities.CenterOrigin(turretDirection, 0, 32);
            if (turret.up)
            {
                turretDirection.FillColor = Color.Blue;
            }
            else
            {
                turretDirection.FillColor = Color.Red;
            }
            turretDirection.Position = turret.sprite.Position;
            turretDirection.Rotation = turret.sprite.Rotation;
            target.Draw(turretDirection);
        }
    }
}
