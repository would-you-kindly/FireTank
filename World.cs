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
        private Tank[] tanks;
        private ParallelAlgorithm _parallelAlgorithm;
        private Wind wind;
        private Forest forest;

        public World(ParallelAlgorithm parallelAlgorithm)
        {
            _parallelAlgorithm = parallelAlgorithm;
            tanks = new Tank[Utilities.TANKS_COUNT];

            LoadResources();
            BuildWorld();
        }

        // Загружает ресурсы в память (текстуры, звуки, шрифты, карты...)
        private void LoadResources()
        {
            // Загружаем карту из .xml (.tmx) файла
            map = new Map();
            map.LoadFromFile("../../Media/map3.tmx");

            // Загружаем текстуры
            textures = new TextureHolder<Textures.ID>();
            textures.Load(Textures.ID.Grass, "../../Media/grass.png");
            //textures.Load(Textures.ID.Tree, "../../Media/tree.png");
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
            // Устанавливаем направление ветра
            wind = new Wind(Wind.Direction.Left);

            // Устанавливаем начальное положение деревьев (леса)
            forest = new Forest(map.GetObjects("tree"), textures, wind);

            // Устанавливаем начальное положение танка
            var items = map.GetObjects("tank");
            // TODO: Должно быть items.Count (почему-т он считает больше)
            for (int i = 0; i < Utilities.TANKS_COUNT; i++)
            {
                tanks[i] = new Tank(Textures.ID.Tank, Textures.ID.Turret, textures, forest);
                // TODO: +16
                tanks[i].Move(new Vector2f(items[i].rect.Left + 16, items[i].rect.Top + 16));
            }

            // Поджигаем деревья
            forest[16].Fire();
            forest[20].Fire();
            forest[28].Fire();
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
                tanks[i].ExecuteAlgorithm(_parallelAlgorithm[i]);
            }
        }
    }
}
