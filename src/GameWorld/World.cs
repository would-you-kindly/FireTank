using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FireSafety
{
    public class World : Drawable, IUpdatable
    {
        public Map map;
        private ResourceHolder resources;

        public List<Tank> tanks;
        public Terrain terrain;
        public List<WaterTrace> traces;

        public World()
        {
            Load();
            BuildWorld();
        }

        // Загружает ресурсы в память (текстуры, звуки, шрифты, карты...)
        private void Load()
        {
            LoadMap();

            // Загружаем ресурсы
            resources = new ResourceHolder();
            LoadResources();
        }

        public void LoadMap(IOpenSave openSaveMap = null)
        {
            // Открываем карту
            IOpenSave openSave;
            if (openSaveMap == null)
            {
                // По умолчанию открываем карту из базы данных
                //openSave = new DatabaseOpenSave(Guid.Parse("bea49d85-adf7-4a2b-bb9b-7e311afbfb46"));
                openSave = new FileOpenSave("Media/Maps/TrainingExample.tmx");
            }
            else
            {
                openSave = openSaveMap;
            }

            map = openSave.OpenMap();
        }

        private void LoadResources()
        {
            // Загружаем текстуры
            ImageConverter imageConverter = new ImageConverter();

            resources.LoadTexture(Textures.ID.House, (byte[])imageConverter.ConvertTo(Resources.House, typeof(byte[])));
            resources.LoadTexture(Textures.ID.BurnedHouse, (byte[])imageConverter.ConvertTo(Resources.BurnedHouse, typeof(byte[])));
            resources.LoadTexture(Textures.ID.Fire, (byte[])imageConverter.ConvertTo(Resources.Fire, typeof(byte[])));
            resources.LoadTexture(Textures.ID.RedTank, (byte[])imageConverter.ConvertTo(Resources.RedTank, typeof(byte[])));
            resources.LoadTexture(Textures.ID.RedTurret, (byte[])imageConverter.ConvertTo(Resources.RedTurret, typeof(byte[])));
            resources.LoadTexture(Textures.ID.BlueTank, (byte[])imageConverter.ConvertTo(Resources.BlueTank, typeof(byte[])));
            resources.LoadTexture(Textures.ID.BlueTurret, (byte[])imageConverter.ConvertTo(Resources.BlueTurret, typeof(byte[])));
            resources.LoadTexture(Textures.ID.YellowTank, (byte[])imageConverter.ConvertTo(Resources.YellowTank, typeof(byte[])));
            resources.LoadTexture(Textures.ID.YellowTurret, (byte[])imageConverter.ConvertTo(Resources.YellowTurret, typeof(byte[])));
            resources.LoadTexture(Textures.ID.GreenTank, (byte[])imageConverter.ConvertTo(Resources.GreenTank, typeof(byte[])));
            resources.LoadTexture(Textures.ID.GreenTurret, (byte[])imageConverter.ConvertTo(Resources.GreenTurret, typeof(byte[])));
            resources.LoadTexture(Textures.ID.PinkTank, (byte[])imageConverter.ConvertTo(Resources.PinkTank, typeof(byte[])));
            resources.LoadTexture(Textures.ID.PinkTurret, (byte[])imageConverter.ConvertTo(Resources.PinkTurret, typeof(byte[])));
            resources.LoadTexture(Textures.ID.GreyTank, (byte[])imageConverter.ConvertTo(Resources.GreyTank, typeof(byte[])));
            resources.LoadTexture(Textures.ID.GreyTurret, (byte[])imageConverter.ConvertTo(Resources.GreyTurret, typeof(byte[])));
            resources.LoadTexture(Textures.ID.Tree, (byte[])imageConverter.ConvertTo(Resources.Tree, typeof(byte[])));
            resources.LoadTexture(Textures.ID.BurnedTree, (byte[])imageConverter.ConvertTo(Resources.BurnedTree, typeof(byte[])));
            resources.LoadTexture(Textures.ID.Lake, (byte[])imageConverter.ConvertTo(Resources.Lake, typeof(byte[])));
            resources.LoadTexture(Textures.ID.Rock, (byte[])imageConverter.ConvertTo(Resources.Rock, typeof(byte[])));

            // Загружаем шрифты
            resources.LoadFont(Fonts.ID.Sansation, Resources.Sansation);
        }

        // Выполняет построение мира, инициализирует точки старта объектов
        public void BuildWorld()
        {
            // Устанавливаем параметры карты
            Utilities.GetInstance().TILE_SIZE = map.GetTileSize().X;
            Utilities.GetInstance().TANKS_COUNT = map.GetObjects("tank").Count;
            Utilities.GetInstance().WIDTH_TILE_COUNT = (uint)map.width;
            Utilities.GetInstance().HEIGHT_TILE_COUNT = (uint)map.height;
            Utilities.GetInstance().INIT_BURNING_TREES = map.GetObjects("tree").Where(obj => obj.GetPropertyBool("burns")).Count();

            traces = new List<WaterTrace>();

            // Устанавливаем направление ветра
            Wind wind;
            switch (map.properties["wind"])
            {
                case "up":
                    wind = new Wind(Wind.Direction.Up);
                    break;
                case "upleft":
                    wind = new Wind(Wind.Direction.UpLeft);
                    break;
                case "left":
                    wind = new Wind(Wind.Direction.Left);
                    break;
                case "leftdown":
                    wind = new Wind(Wind.Direction.LeftDown);
                    break;
                case "down":
                    wind = new Wind(Wind.Direction.Down);
                    break;
                case "downright":
                    wind = new Wind(Wind.Direction.DownRight);
                    break;
                case "right":
                    wind = new Wind(Wind.Direction.Right);
                    break;
                case "rightup":
                    wind = new Wind(Wind.Direction.RightUp);
                    break;
                default:
                    throw new Exception("Неверно указано направление ветра. Проверьте правильность значений переменных карты.");
            }

            // Устанавливаем начальное положение объектов местности (деревьев, озер, гор)
            terrain = new Terrain(map.GetAllObjects(), resources, wind);

            // TODO: Добавить проверки на корректные цифры из файла карты (кратные цифры...)
            // Устанавливаем начальное положение танков
            tanks = new List<Tank>();
            for (int i = 0; i < map.GetObjects("tank").Count; i++)
            {
                // Создаем экземпляр танка
                GameObject tankObject = map.GetObjects("tank")[i];
                Tank tank = new Tank((Textures.ID)(i * 2), (Textures.ID)(i * 2 + 1), resources, (Tank.TankColor)i);
                tank.SetTerrain(terrain);
                tank.SetTanks(tanks);
                tank.SetAlgorithm(ParallelAlgorithm.GetInstance()[i]);
                switch (Utilities.NormalizedRotation(tankObject.rotation))
                {
                    case 0:
                        tank.SetPosition(new Vector2f(tankObject.rect.Left + Utilities.GetInstance().TILE_SIZE / 2, tankObject.rect.Top - Utilities.GetInstance().TILE_SIZE / 2));
                        break;
                    case 90:
                        tank.SetPosition(new Vector2f(tankObject.rect.Left + Utilities.GetInstance().TILE_SIZE / 2, tankObject.rect.Top + Utilities.GetInstance().TILE_SIZE / 2));
                        break;
                    case 180:
                        tank.SetPosition(new Vector2f(tankObject.rect.Left - Utilities.GetInstance().TILE_SIZE / 2, tankObject.rect.Top + Utilities.GetInstance().TILE_SIZE / 2));
                        break;
                    case 270:
                        tank.SetPosition(new Vector2f(tankObject.rect.Left - Utilities.GetInstance().TILE_SIZE / 2, tankObject.rect.Top - Utilities.GetInstance().TILE_SIZE / 2));
                        break;
                    default:
                        throw new Exception("Неверно указаны координаты танка. Проверьте правильность значений переменных танка.");
                }
                tank.SetRotation(tankObject.rotation);

                // Подписываемся на обработку ошибок танка
                tank.Collided += (sender, e) =>
                {
                    ParallelAlgorithm.GetInstance().errors.Add(new CollidedError((Tank)sender, e.entity));
                };
                tank.MapLeft += (sender, e) =>
                {
                    ParallelAlgorithm.GetInstance().errors.Add(new LeftMapError((Tank)sender));
                };
                tank.NearLakeError += (sender, e) =>
                {
                    ParallelAlgorithm.GetInstance().errors.Add(new NearLakeError((Tank)sender));
                };
                tank.RefuelError += (sender, e) =>
                {
                    ParallelAlgorithm.GetInstance().errors.Add(new RefuelError((Tank)sender));
                };

                // Создаем экземпляр башни танка
                GameObject turretObject = map.GetObjects("turret").Find(turret => turret.rect.Left == tankObject.rect.Left && turret.rect.Top == tankObject.rect.Top);
                tank.SetTurretRotation(tankObject.rotation - turretObject.rotation);
                tank.turret.UpDown(false);

                // Подписываемся на обработку ошибок башни танка
                tank.turret.TurretPressureError += (sender, e) =>
                {
                    ParallelAlgorithm.GetInstance().errors.Add(new PressureError(((Turret)sender).tank));
                };
                tank.turret.TurretUpError += (sender, e) =>
                {
                    ParallelAlgorithm.GetInstance().errors.Add(new UpError(((Turret)sender).tank));
                };
                tank.turret.TurretDownError += (sender, e) =>
                {
                    ParallelAlgorithm.GetInstance().errors.Add(new DownError(((Turret)sender).tank));
                };
                tank.turret.WeaponAlreadyChargedError += (sender, e) =>
                {
                    ParallelAlgorithm.GetInstance().errors.Add(new WeaponAlreadyChargedError(((Turret)sender).tank));
                };
                tank.turret.WeaponUpChargeError += (sender, e) =>
                {
                    ParallelAlgorithm.GetInstance().errors.Add(new WeaponUpChargeError(((Turret)sender).tank));
                };
                tank.turret.WeaponUnchargedError += (sender, e) =>
                {
                    ParallelAlgorithm.GetInstance().errors.Add(new WeaponUnchargedError(((Turret)sender).tank));
                };
                tank.turret.InsufficientlyWaterError += (sender, e) =>
                {
                    ParallelAlgorithm.GetInstance().errors.Add(new InsufficientlyWaterError(((Turret)sender).tank));
                };
                // При выстреле сохраняем след от выстрела
                tank.turret.TurretShoot += (sender, e) =>
                {
                    traces.Add(new WaterTrace(tank.turret.up, tank.turret.sprite.Position,
                        tank.turret.waterPressure, tank.turret.NormalizedRotation));
                };

                tanks.Add(tank);
            }
        }

        public void Update(Time deltaTime)
        {
            // TODO: Важный момент, кто изменяется первым, новый огонь или действие игрока
            foreach (var tank in tanks)
            {
                tank.Update(deltaTime);
            }

            terrain.Update(deltaTime);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            // Рисуем карту (фон рельефа)
            map.Draw(target, states);

            // Рисуем объекты местности (деревья, озера, дома, скалы...)
            terrain.Draw(target, states);

            // Рисуем следы выстрелов
            foreach (var trace in traces)
            {
                trace.Draw(target, states);
            }

            // Рисуем танки
            foreach (var tank in tanks)
            {
                tank.Draw(target, states);
            }
        }
    }
}
