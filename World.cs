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
        private List<Tank> tanks;
        private ParallelAlgorithm _parallelAlgorithm;
        private Wind wind;
        private Forest forest;

        public World(ParallelAlgorithm parallelAlgorithm)
        {
            _parallelAlgorithm = parallelAlgorithm;
            tanks = new List<Tank>();

            LoadResources();
            BuildWorld();
        }

        // Загружает ресурсы в память (текстуры, звуки, шрифты, карты...)
        private void LoadResources()
        {
            // Загружаем карту из .xml (.tmx) файла
            map = new Map();
            map.LoadFromFile("../../Media/map4.tmx");

            // Загружаем текстуры
            textures = new TextureHolder<Textures.ID>();
            textures.Load(Textures.ID.BurnedTree, "../../Media/burnedTree.png");
            textures.Load(Textures.ID.Grass, "../../Media/grass.png");
            textures.Load(Textures.ID.House, "../../Media/house.png");
            textures.Load(Textures.ID.Fire, "../../Media/fire.png");
            textures.Load(Textures.ID.Tank, "../../Media/tank.png");
            textures.Load(Textures.ID.Tree, "../../Media/greentree.png");
            textures.Load(Textures.ID.Turret, "../../Media/turret.png");

            // TODO: Проверка на загрузку объектов (можно убрать)
            for (int i = 0; i < map.GetAllObjects().Count; i++)
            {
                Console.WriteLine(i + " - " + map.GetAllObjects()[i].type + " - " + map.GetAllObjects()[i].sprite.Position);
            }
        }

        // Выполняет построение мира, инициализирует точки старта объектов
        private void BuildWorld()
        {
            // Устанавливаем параметры карты
            Utilities.TILE_SIZE = map.GetTileSize().X;
            // TODO: СЧИТАТЬ ИЗ ФАЙЛА !!!!! map.GetObjects("tank").Count
            Utilities.TANKS_COUNT = 2;
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
            forest = new Forest(map.GetObjects("tree"), textures, wind);

            //List<Object> tanksObjects = map.GetObjects("tank");
            //// TODO: Должно быть items.Count (почему-т он считает больше)
            //for (int i = 0; i < Utilities.TANKS_COUNT; i++)
            //{
            //    tanks[i] = new Tank(Textures.ID.Tank, Textures.ID.Turret, textures, forest);
            //    // TODO: +Utilities.TILE_SIZE / 2
            //    tanks[i].Move(new Vector2f(items[i].rect.Left + Utilities.TILE_SIZE / 2, items[i].rect.Top + Utilities.TILE_SIZE / 2));
            //}

            // TODO: Добавить проверки на корректные цифры из файла карты (кратные цифры...)
            // Устанавливаем начальное положение танков
            for (int i = 0; i < Utilities.TANKS_COUNT; i++)
            //foreach (Object tankObject in map.GetObjects("tank"))
            {
                Tank tank = new Tank(Textures.ID.Tank, Textures.ID.Turret, textures, forest);
                tank.Move(new Vector2f(map.GetObjects("tank")[i].rect.Left + Utilities.TILE_SIZE / 2, map.GetObjects("tank")[i].rect.Top + Utilities.TILE_SIZE / 2));
                tank.RotateTank(map.GetObjects("tank")[i].rotation);
                Object turretObject = map.GetObjects("turret").Find(turret => turret.rect.Left == map.GetObjects("tank")[i].rect.Left && turret.rect.Top == map.GetObjects("tank")[i].rect.Top);
                tank.RotateTurret(map.GetObjects("tank")[i].rotation - turretObject.rotation);
                tanks.Add(tank);
            }

            // Поджигаем деревья
            foreach (Object burningTree in map.GetObjects("tree").Where(tree => tree.GetPropertyBool("burns")))
            {
                forest.trees.Find(tree => tree.Position == new Vector2f(burningTree.rect.Left, burningTree.rect.Top)).Fire();
            }
        }

        public void Update(Time deltaTime)
        {
            ExecuteAlgorithm();
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

        public void ExecuteAlgorithm()
        {
            // Каждый танк выполняет свой алгоритм
            for (int i = 0; i < tanks.Count(); i++)
            {
                tanks[i].Execute(_parallelAlgorithm[i]);
            }
        }
    }
}
