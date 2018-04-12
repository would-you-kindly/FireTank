using SFML.Graphics;
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
        private Map map;
        private TextureHolder<Textures.ID> textures;

        public List<Tank> tanks;
        public Forest forest;
        public static Wind wind;

        public World()
        {
            LoadResources();
            BuildWorld();
        }

        // Загружает ресурсы в память (текстуры, звуки, шрифты, карты...)
        private void LoadResources()
        {
            // Загружаем карту из .xml (.tmx) файла
            map = new Map();
            map.LoadFromFile("Media/Maps/map4.tmx");

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
        }

        // Выполняет построение мира, инициализирует точки старта объектов
        private void BuildWorld()
        {
            // Устанавливаем параметры карты
            Utilities.TILE_SIZE = map.GetTileSize().X;
            Utilities.TANKS_COUNT = map.GetObjects("tank").Count;
            Utilities.WIDTH_TILE_COUNT = (uint)map.width;
            Utilities.HEIGHT_TILE_COUNT = (uint)map.height;
            Utilities.WINDOW_WIDTH = (uint)map.width * (uint)map.tileWidth;
            Utilities.WINDOW_HEIGHT = (uint)map.height * (uint)map.tileHeight;

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

            // Устанавливаем начальное положение деревьев (леса)
            forest = new Forest(map.GetObjects("tree"), textures);

            // TODO: Добавить проверки на корректные цифры из файла карты (кратные цифры...)
            // Устанавливаем начальное положение танков
            tanks = new List<Tank>();
            for (int i = 0; i < map.GetObjects("tank").Count; i++)
            {
                Object tankObject = map.GetObjects("tank")[i];
                Tank tank = new Tank((Textures.ID)(i * 2), (Textures.ID)(i * 2 + 1), textures, (Tank.TankColor)i, forest);
                tank.Move(new Vector2f(tankObject.rect.Left + Utilities.TILE_SIZE / 2, tankObject.rect.Top + Utilities.TILE_SIZE / 2));
                tank.RotateTank(tankObject.rotation);
                Object turretObject = map.GetObjects("turret").Find(turret => turret.rect.Left == tankObject.rect.Left && turret.rect.Top == tankObject.rect.Top);
                tank.RotateTurret(tankObject.rotation - turretObject.rotation);
                tanks.Add(tank);
            }

            // Поджигаем деревья
            foreach (Object burningTree in map.GetObjects("tree").Where(tree => tree.GetPropertyBool("burns")))
            {
                forest.trees.Find(tree => tree.Position == new Vector2f(burningTree.rect.Left, burningTree.rect.Top))?.Fire();
            }
        }

        public void Update(Time deltaTime)
        {
            forest.Update(deltaTime);
            foreach (var tank in tanks)
            {
                tank.Update(deltaTime);
            }
            // TODO: Важный момент, кто изменяется первым, новый огонь или действие игрока
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            map.Draw(target, states);
            forest.Draw(target, states);
            foreach (var tank in tanks)
            {
                tank.Draw(target, states);
            }
        }
    }
}
