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
            resources = new ResourceHolder();

            LoadMapFromDatabase(Guid.Parse("bea49d85-adf7-4a2b-bb9b-7e311afbfb46"));
            LoadResources();
        }

        public void LoadMapFromDatabase(Guid id)
        {
            // Загружаем карту из .xml (.tmx) файла
            map = new Map();
            map.LoadFromDatabase(id);
        }

        public void LoadMapFromFile(string filename = "Media/Maps/Map2.tmx")
        {
            // Загружаем карту из .xml (.tmx) файла
            map = new Map();
            map.LoadFromFile(filename);
        }

        private void LoadResources()
        {
            // Загружаем текстуры
            resources.LoadTexture(Textures.ID.BurnedTree, "Media/Textures/BurnedTree.png");
            resources.LoadTexture(Textures.ID.House, "Media/Textures/House.png");
            resources.LoadTexture(Textures.ID.Fire, "Media/Textures/Fire.png");
            resources.LoadTexture(Textures.ID.RedTank, "Media/Textures/RedTank.png");
            resources.LoadTexture(Textures.ID.RedTurret, "Media/Textures/RedTurret.png");
            resources.LoadTexture(Textures.ID.BlueTank, "Media/Textures/BlueTank.png");
            resources.LoadTexture(Textures.ID.BlueTurret, "Media/Textures/BlueTurret.png");
            resources.LoadTexture(Textures.ID.YellowTank, "Media/Textures/YellowTank.png");
            resources.LoadTexture(Textures.ID.YellowTurret, "Media/Textures/YellowTurret.png");
            resources.LoadTexture(Textures.ID.GreenTank, "Media/Textures/GreenTank.png");
            resources.LoadTexture(Textures.ID.GreenTurret, "Media/Textures/GreenTurret.png");
            resources.LoadTexture(Textures.ID.Tree, "Media/Textures/Tree.png");
            resources.LoadTexture(Textures.ID.Lake, "Media/Textures/Lake.png");
            resources.LoadTexture(Textures.ID.Rock, "Media/Textures/Rock.png");

            // Загружаем шрифты
            resources.LoadFont(Fonts.ID.Sansation, "Media/Sansation.ttf");
        }

        // Выполняет построение мира, инициализирует точки старта объектов
        public void BuildWorld()
        {
            // Устанавливаем параметры карты
            Utilities.TILE_SIZE = map.GetTileSize().X;
            Utilities.TANKS_COUNT = map.GetObjects("tank").Count;
            Utilities.WIDTH_TILE_COUNT = (uint)map.width;
            Utilities.HEIGHT_TILE_COUNT = (uint)map.height;
            Utilities.WINDOW_WIDTH = (uint)map.width * (uint)map.tileWidth;
            Utilities.WINDOW_HEIGHT = (uint)map.height * (uint)map.tileHeight;
            Utilities.INIT_BURNING_TREES = map.GetObjects("tree").Where(obj => obj.GetPropertyBool("burns")).Count();

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
                        tank.SetPosition(new Vector2f(tankObject.rect.Left + Utilities.TILE_SIZE / 2, tankObject.rect.Top - Utilities.TILE_SIZE / 2));
                        break;
                    case 90:
                        tank.SetPosition(new Vector2f(tankObject.rect.Left + Utilities.TILE_SIZE / 2, tankObject.rect.Top + Utilities.TILE_SIZE / 2));
                        break;
                    case 180:
                        tank.SetPosition(new Vector2f(tankObject.rect.Left - Utilities.TILE_SIZE / 2, tankObject.rect.Top + Utilities.TILE_SIZE / 2));
                        break;
                    case 270:
                        tank.SetPosition(new Vector2f(tankObject.rect.Left - Utilities.TILE_SIZE / 2, tankObject.rect.Top - Utilities.TILE_SIZE / 2));
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