using SFML.Graphics;
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
        public class UpTurretErrorEventArgs : EventArgs
        {
        }
        public class DownTurretEventArgs : EventArgs
        {
        }
        public class DownTurretErrorEventArgs : EventArgs
        {
        }
        public class ShootTurretEventArgs : EventArgs
        {
            public Tree treeToExtinguish;

            public ShootTurretEventArgs(Tree treeToExtinguish)
            {
                this.treeToExtinguish = treeToExtinguish;
            }
        }
        public class ShootTurretErrorEventArgs : EventArgs
        {
        }
        public class PressureTurretEventArgs : EventArgs
        {
            public int count;

            public PressureTurretEventArgs(int count)
            {
                this.count = count;
            }
        }
        public class PressureTurretErrorEventArgs : EventArgs
        {
        }
        public class InsufficientlyWaterErrorEventArgs : EventArgs
        {
        }
        public class WeaponChargeEventArgs : EventArgs
        {
        }
        public class WeaponAlreadyChargeErrorEventArgs : EventArgs
        {
        }
        public class WeaponUnchargeErrorEventArgs : EventArgs
        {
        }
        public class WeaponUpChargeEventArgs : EventArgs
        {
        }

        // События башни
        public delegate void MoveTurretEventHandler(object sender, MoveTurretEventArgs e);
        public delegate void RotateTurretEventHandler(object sender, RotateTurretEventArgs e);
        public delegate void UpTurretEventHandler(object sender, UpTurretEventArgs e);
        public delegate void UpTurretErrorEventHandler(object sender, UpTurretErrorEventArgs e);
        public delegate void DownTurretEventHandler(object sender, DownTurretEventArgs e);
        public delegate void DownTurretErrorEventHandler(object sender, DownTurretErrorEventArgs e);
        public delegate void ShootTurretEventHandler(object sender, ShootTurretEventArgs e);
        public delegate void ShootTurretErrorEventHandler(object sender, ShootTurretErrorEventArgs e);
        public delegate void PressureTurretEventHandler(object sender, PressureTurretEventArgs e);
        public delegate void PressureTurretErrorEventHandler(object sender, PressureTurretErrorEventArgs e);
        public delegate void InsufficientlyWaterErrorEventHandler(object sender, InsufficientlyWaterErrorEventArgs e);
        public delegate void WeaponChargeEventHandler(object sender, WeaponChargeEventArgs e);
        public delegate void WeaponAlreadyChargeErrorEventHandler(object sender, WeaponAlreadyChargeErrorEventArgs e);
        public delegate void WeaponUnchargeErrorEventHandler(object sender, WeaponUnchargeErrorEventArgs e);
        public delegate void WeaponUpChargeErrorEventHandler(object sender, WeaponUpChargeEventArgs e);
        public event MoveTurretEventHandler TurretMoved;
        public event RotateTurretEventHandler TurretRotated;
        public event UpTurretEventHandler TurretUp;
        public event UpTurretErrorEventHandler TurretUpError;
        public event DownTurretEventHandler TurretDown;
        public event DownTurretErrorEventHandler TurretDownError;
        public event ShootTurretEventHandler TurretShoot;
        public event PressureTurretEventHandler TurretPressure;
        public event PressureTurretErrorEventHandler TurretPressureError;
        public event InsufficientlyWaterErrorEventHandler InsufficientlyWaterError;
        public event WeaponChargeEventHandler WeaponCharged;
        public event WeaponAlreadyChargeErrorEventHandler WeaponAlreadyChargedError;
        public event WeaponUnchargeErrorEventHandler WeaponUnchargedError;
        public event WeaponUpChargeErrorEventHandler WeaponUpChargeError;

        // Параметры-ссылки
        private Terrain _terrain;
        private List<Tank> _tanks;
        public Tank _tank;

        // Параметры турели
        public int minWaterPressure = 1; //
        public int maxWaterPressure = 5;
        public int waterPressure;

        public int minWaterCapacity = 0;
        public int maxWaterCapacity = 8;
        public int waterCapacity;

        public bool up;
        public bool weaponReady;

        private RectangleShape direction;

        public Turret(Textures.ID id, ResourceHolder resources, Tank tank) :
            base(id, resources)
        {
            // Задаем параметры турели
            _tank = tank;
            waterPressure = minWaterPressure;
            waterCapacity = maxWaterCapacity - 3;
            up = false;
            weaponReady = false;

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

        public void SetTerrain(Terrain terrain)
        {
            _terrain = terrain;
        }

        public void SetTanks(List<Tank> tanks)
        {
            _tanks = tanks;
        }

        public void RotateBy(float rotation)
        {
            // Поворачиваем башню
            sprite.Rotation += rotation;

            TurretRotated?.Invoke(this, new RotateTurretEventArgs(NormalizedRotation));
        }

        public void MoveBy(Vector2f move)
        {
            // Перемещаем башню
            sprite.Position += move;

            TurretMoved?.Invoke(this, new MoveTurretEventArgs(sprite.Position));
        }

        public void UpDown(bool up)
        {
            // Проверяем команду на ошибки
            if (this.up == up)
            {
                if (up)
                {
                    TurretUpError?.Invoke(this, new UpTurretErrorEventArgs());
                }
                else
                {
                    TurretDownError?.Invoke(this, new DownTurretErrorEventArgs());
                }

                //return;
            }

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
        private List<Vector2f> GetTargetPositions()
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

                Vector2f target = new Vector2f();

                // Вверх
                if (NormalizedRotation == rotation * 0)
                    target = new Vector2f(sprite.Position.X, sprite.Position.Y - Utilities.TILE_SIZE * (i + 1));
                // Вверх-вправо
                if (NormalizedRotation == rotation * 1)
                    target = new Vector2f(sprite.Position.X + Utilities.TILE_SIZE * (i + 1), sprite.Position.Y - Utilities.TILE_SIZE * (i + 1));
                // Вправо
                if (NormalizedRotation == rotation * 2)
                    target = new Vector2f(sprite.Position.X + Utilities.TILE_SIZE * (i + 1), sprite.Position.Y);
                // Вправо-вниз
                if (NormalizedRotation == rotation * 3)
                    target = new Vector2f(sprite.Position.X + Utilities.TILE_SIZE * (i + 1), sprite.Position.Y + Utilities.TILE_SIZE * (i + 1));
                // Вниз
                if (NormalizedRotation == rotation * 4)
                    target = new Vector2f(sprite.Position.X, sprite.Position.Y + Utilities.TILE_SIZE * (i + 1));
                // Вниз-влево
                if (NormalizedRotation == rotation * 5)
                    target = new Vector2f(sprite.Position.X - Utilities.TILE_SIZE * (i + 1), sprite.Position.Y + Utilities.TILE_SIZE * (i + 1));
                // Влево
                if (NormalizedRotation == rotation * 6)
                    target = new Vector2f(sprite.Position.X - Utilities.TILE_SIZE * (i + 1), sprite.Position.Y);
                // Влево-вверх
                if (NormalizedRotation == rotation * 7)
                    target = new Vector2f(sprite.Position.X - Utilities.TILE_SIZE * (i + 1), sprite.Position.Y - Utilities.TILE_SIZE * (i + 1));

                targets.Add(target);

                // Если на пути выстрела находится танк, цели за ним не добавляем
                if (_tanks.Find(tank => tank.sprite.Position == target) != null && !up)
                {
                    targets.Remove(target);

                    break;
                }
            }

            return targets;
        }

        public void Shoot()
        {
            // Недостаточное количество воды в запасе
            if (waterCapacity == minWaterCapacity)
            {
                InsufficientlyWaterError?.Invoke(this, new InsufficientlyWaterErrorEventArgs());

                return;
            }

            // Пушка не подготовлена
            if (!weaponReady)
            {
                WeaponUnchargedError?.Invoke(this, new WeaponUnchargeErrorEventArgs());

                return;
            }

            // Присваиваем null для случая, когда выстрел не попал ни в какое дерево
            Tree treeToExtinguish = null;

            // Если пушка опущена, то можно потушить только ближайшее дерево
            if (!up)
            {
                foreach (Vector2f coords in GetTargetPositions())
                {
                    treeToExtinguish = _terrain.trees.Find(tree => tree.Position == coords);

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
                treeToExtinguish = _terrain.trees.Find(tree => tree.Position == GetTargetPositions()[0]);
                treeToExtinguish?.Extinguish();
            }

            TurretShoot?.Invoke(this, new ShootTurretEventArgs(treeToExtinguish));

            // После выстрела сбрасываем давление, уменьшаем запасы воды, убираем заряд пушки
            waterPressure = minWaterPressure;
            waterCapacity--;
            weaponReady = false;
        }

        // Увеличение давления воды
        public void Pressure(int count)
        {
            if (waterPressure + count <= maxWaterPressure)
            {
                waterPressure += count;

                TurretPressure?.Invoke(this, new PressureTurretEventArgs(count));
            }
            else
            {
                TurretPressureError?.Invoke(this, new PressureTurretErrorEventArgs());
            }
        }

        // Подготовка заряда
        public void Charge()
        {
            if (weaponReady || up)
            {
                if (weaponReady)
                {
                    WeaponAlreadyChargedError?.Invoke(this, new WeaponAlreadyChargeErrorEventArgs());
                }

                if (up)
                {
                    WeaponUpChargeError?.Invoke(this, new WeaponUpChargeEventArgs());
                }

                return;
            }

            weaponReady = true;

            WeaponCharged?.Invoke(this, new WeaponChargeEventArgs());
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(sprite, states);
            target.Draw(direction, states);
        }
    }
}
