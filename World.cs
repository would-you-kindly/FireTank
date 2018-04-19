﻿using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    class World : Transformable, Drawable
    {
        public Map map;
        private TextureHolder<Textures.ID> textures;
        private FontHolder<Fonts.ID> fonts;

        public List<Tank> tanks;
        public Terrain terrain;
        public static Wind wind;
        public List<WaterTrace> traces;
        private ParallelAlgorithm _parallelAlgorithm;

        public World(ParallelAlgorithm parallelAlgorithm)
        {
            _parallelAlgorithm = parallelAlgorithm;

            LoadResources();
            BuildWorld();
        }

        // Загружает ресурсы в память (текстуры, звуки, шрифты, карты...)
        private void LoadResources()
        {
            LoadMap();
            LoadTextures();
        }

        public void LoadMap(string filename = "Media/Maps/map6.tmx")
        {
            // Загружаем карту из .xml (.tmx) файла
            map = new Map();
            map.LoadFromFile(filename);
        }

        private void LoadTextures()
        {
            // Загружаем текстуры
            textures = new TextureHolder<Textures.ID>();
            textures.Load(Textures.ID.BurnedTree, "Media/Textures/burnedTree.png");
            textures.Load(Textures.ID.Grass, "Media/Textures/grass.png");
            textures.Load(Textures.ID.House, "Media/Textures/house.png");
            textures.Load(Textures.ID.Fire, "Media/Textures/fire.png");
            textures.Load(Textures.ID.RedTank, "Media/Textures/redtank.png");
            textures.Load(Textures.ID.RedTurret, "Media/Textures/redturret.png");
            textures.Load(Textures.ID.BlueTank, "Media/Textures/bluetank.png");
            textures.Load(Textures.ID.BlueTurret, "Media/Textures/blueturret.png");
            textures.Load(Textures.ID.YellowTank, "Media/Textures/yellowtank.png");
            textures.Load(Textures.ID.YellowTurret, "Media/Textures/yellowturret.png");
            textures.Load(Textures.ID.GreenTank, "Media/Textures/greentank.png");
            textures.Load(Textures.ID.GreenTurret, "Media/Textures/greenturret.png");
            textures.Load(Textures.ID.Tree, "Media/Textures/greentree.png");
            textures.Load(Textures.ID.Lake, "Media/Textures/Lake.png");

            // Загружаем шрифты
            fonts = new FontHolder<Fonts.ID>();
            fonts.Load(Fonts.ID.Sansation, "Media/Sansation.ttf");
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

            traces = new List<WaterTrace>();

            // Устанавливаем направление ветра
            switch (map.properties["wind"])
            {
                case "up":
                    wind = new Wind(Wind.Direction.Up);
                    break;
                case "left":
                    wind = new Wind(Wind.Direction.Left);
                    break;
                case "down":
                    wind = new Wind(Wind.Direction.Down);
                    break;
                case "right":
                    wind = new Wind(Wind.Direction.Right);
                    break;
                default:
                    throw new Exception("Неверно указано направление ветра");
            }

            // Устанавливаем начальное положение объектов местности (деревьев, озер, гор)
            terrain = new Terrain(map.GetAllObjects(), textures);

            // TODO: Добавить проверки на корректные цифры из файла карты (кратные цифры...)
            // Устанавливаем начальное положение танков
            tanks = new List<Tank>();
            for (int i = 0; i < map.GetObjects("tank").Count; i++)
            {
                Object tankObject = map.GetObjects("tank")[i];
                Tank tank = new Tank((Textures.ID)(i * 2), (Textures.ID)(i * 2 + 1), textures, fonts, (Tank.TankColor)i);
                tank.SetTerrain(terrain);
                tank.SetPosition(new Vector2f(tankObject.rect.Left + Utilities.TILE_SIZE / 2, tankObject.rect.Top + Utilities.TILE_SIZE / 2));
                tank.SetRotation(tankObject.rotation);
                tank.SetAlgorithm(_parallelAlgorithm[i]);
                Object turretObject = map.GetObjects("turret").Find(turret => turret.rect.Left == tankObject.rect.Left && turret.rect.Top == tankObject.rect.Top);
                tank.SetTurretRotation(tankObject.rotation - turretObject.rotation);
                tanks.Add(tank);
            }


        }

        public void Update(Time deltaTime)
        {
            foreach (var tank in tanks)
            {
                tank.Update(deltaTime);
            }
            terrain.Update(deltaTime);
            // TODO: Важный момент, кто изменяется первым, новый огонь или действие игрока
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            Game.gui.form.renderWindow.PushGLStates();

            map.Draw(target, states);
            terrain.Draw(target, states);
            foreach (var trace in traces)
            {
                trace.Draw(target, states);
            }
            foreach (var tank in tanks)
            {
                tank.Draw(target, states);
            }

            Game.gui.form.renderWindow.PopGLStates();
        }
    }
}
