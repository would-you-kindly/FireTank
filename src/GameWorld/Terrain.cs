using SFML.Graphics;
using SFML.System;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FireSafety
{
    public class Terrain : Drawable, IUpdatable, IEnumerable
    {
        // Классы для передачи параметров событий
        public class FireOverEventArgs : EventArgs
        {
        }

        // События местности
        public delegate void FireOverEventHandler(object sender, FireOverEventArgs e);
        public event FireOverEventHandler FireOver;

        // Параметры местности
        public List<Tree> trees;
        public List<House> houses;
        public List<Lake> lakes;
        public List<Rock> rocks;
        public Wind wind;

        public Terrain(List<GameObject> objects, ResourceHolder resources, Wind wind)
        {
            trees = new List<Tree>();
            houses = new List<House>();
            lakes = new List<Lake>();
            rocks = new List<Rock>();
            this.wind = wind;

            foreach (GameObject item in objects)
            {
                // Создаем деревья
                if (item.name == "tree")
                {
                    Tree tree = new Tree(Textures.ID.Tree, resources);
                    tree.Position = new Vector2f(item.rect.Left + Utilities.GetInstance().TILE_SIZE / 2, item.rect.Top - Utilities.GetInstance().TILE_SIZE / 2);
                    if (item.GetPropertyBool("burns"))
                    {
                        // TODO: Такое себе место (чтобы подожглось, нужно сделать так)
                        tree.state.currentTimeToSpread = TreeState.timeToSpread;
                        tree.Fire();
                    }
                    trees.Add(tree);
                }

                // Создаем дома
                if (item.name == "house")
                {
                    House house = new House(Textures.ID.House, resources);
                    house.Position = new Vector2f(item.rect.Left + Utilities.GetInstance().TILE_SIZE / 2, item.rect.Top - Utilities.GetInstance().TILE_SIZE / 2);
                    if (item.GetPropertyBool("burns"))
                    {
                        // TODO: Такое себе место (чтобы подожглось, нужно сделать так)
                        house.state.currentTimeToSpread = house.state.timeToSpread;
                        house.Fire();
                    }
                    houses.Add(house);
                }

                // Создаем озера
                if (item.name == "lake")
                {
                    Lake lake = new Lake(Textures.ID.Lake, resources);
                    lake.Position = new Vector2f(item.rect.Left + Utilities.GetInstance().TILE_SIZE / 2, item.rect.Top - Utilities.GetInstance().TILE_SIZE / 2);
                    lakes.Add(lake);
                }

                // Создаем скалы
                if (item.name == "rock")
                {
                    Rock rock = new Rock(Textures.ID.Rock, resources);
                    rock.Position = new Vector2f(item.rect.Left + Utilities.GetInstance().TILE_SIZE / 2, item.rect.Top - Utilities.GetInstance().TILE_SIZE / 2);
                    rocks.Add(rock);
                }
            }
        }

        public Tree GetTree(int index)
        {
            return trees[index];
        }

        public void SetTree(int index, Tree tree)
        {
            trees[index] = tree;
        }

        public House GetHouse(int index)
        {
            return houses[index];
        }

        public void SetHouse(int index, House house)
        {
            houses[index] = house;
        }

        public Lake GetLake(int index)
        {
            return lakes[index];
        }

        public void SetLake(int index, Lake lake)
        {
            lakes[index] = lake;
        }

        public Rock GetRock(int index)
        {
            return rocks[index];
        }

        public void SetRock(int index, Rock rock)
        {
            rocks[index] = rock;
        }

        public void Update(Time deltaTime)
        {
            // Обновляем объекты местности
            foreach (Tree tree in trees)
            {
                tree.Update(deltaTime);
            }
            foreach (House house in houses)
            {
                house.Update(deltaTime);
            }
            foreach (Lake lake in lakes)
            {
                lake.Update(deltaTime);
            }
            foreach (Rock rock in rocks)
            {
                rock.Update(deltaTime);
            }

            // TODO: SpreadFire либо здесь либо перед обновление деревьев
            // Поджигаем новые деревья (и дома)
            SpreadFire();
            // Проверяем состояние местности на наличие пожара
            CheckTerrainState();
            // Если пришло время изменить направление ветра, меняем его
            wind.ChangeDirection();
        }

        private void CheckTerrainState()
        {
            foreach (IFlammable flammable in GetFlammableObjects())
            {
                if (flammable is Tree && ((Tree)flammable).state.IsBurning())
                {
                    return;
                }
                if (flammable is House && ((House)flammable).state.IsBurning())
                {
                    return;
                }
            }

            FireOver?.Invoke(this, new FireOverEventArgs());
        }

        private void SpreadFire()
        {
            // TODO: Если у дерева осталась одна жизнь и оно проверяется первым, то соседнее не загорится (хотя должно)
            // TODO: а если наоборот сначала проверится соседнее, то оно загорится и на этом же шаге сгорит предыдущее

            // Ищем дерево или дом, которые загорятся следующими
            List<IFlammable> burningTrees = new List<IFlammable>(trees.Where(found => found.state.IsBurning()));
            List<IFlammable> burningHouses = new List<IFlammable>(houses.Where(found => found.state.IsBurning()));

            foreach (IFlammable entity in burningTrees.Concat(burningHouses))
            {
                switch (wind.direction)
                {
                    case Wind.Direction.Up:
                        trees.Find(found => found.Position == new Vector2f(((Entity)entity).Position.X, ((Entity)entity).Position.Y - Utilities.GetInstance().TILE_SIZE))?.Fire();
                        houses.Find(found => found.Position == new Vector2f(((Entity)entity).Position.X, ((Entity)entity).Position.Y - Utilities.GetInstance().TILE_SIZE))?.Fire();
                        break;
                    case Wind.Direction.UpLeft:
                        trees.Find(found => found.Position == new Vector2f(((Entity)entity).Position.X - Utilities.GetInstance().TILE_SIZE, ((Entity)entity).Position.Y - Utilities.GetInstance().TILE_SIZE))?.Fire();
                        houses.Find(found => found.Position == new Vector2f(((Entity)entity).Position.X - Utilities.GetInstance().TILE_SIZE, ((Entity)entity).Position.Y - Utilities.GetInstance().TILE_SIZE))?.Fire();
                        break;
                    case Wind.Direction.Left:
                        trees.Find(found => found.Position == new Vector2f(((Entity)entity).Position.X - Utilities.GetInstance().TILE_SIZE, ((Entity)entity).Position.Y))?.Fire();
                        houses.Find(found => found.Position == new Vector2f(((Entity)entity).Position.X - Utilities.GetInstance().TILE_SIZE, ((Entity)entity).Position.Y))?.Fire();
                        break;
                    case Wind.Direction.LeftDown:
                        trees.Find(found => found.Position == new Vector2f(((Entity)entity).Position.X - Utilities.GetInstance().TILE_SIZE, ((Entity)entity).Position.Y + Utilities.GetInstance().TILE_SIZE))?.Fire();
                        houses.Find(found => found.Position == new Vector2f(((Entity)entity).Position.X - Utilities.GetInstance().TILE_SIZE, ((Entity)entity).Position.Y + Utilities.GetInstance().TILE_SIZE))?.Fire();
                        break;
                    case Wind.Direction.Down:
                        trees.Find(found => found.Position == new Vector2f(((Entity)entity).Position.X, ((Entity)entity).Position.Y + Utilities.GetInstance().TILE_SIZE))?.Fire();
                        houses.Find(found => found.Position == new Vector2f(((Entity)entity).Position.X, ((Entity)entity).Position.Y + Utilities.GetInstance().TILE_SIZE))?.Fire();
                        break;
                    case Wind.Direction.DownRight:
                        trees.Find(found => found.Position == new Vector2f(((Entity)entity).Position.X + Utilities.GetInstance().TILE_SIZE, ((Entity)entity).Position.Y + Utilities.GetInstance().TILE_SIZE))?.Fire();
                        houses.Find(found => found.Position == new Vector2f(((Entity)entity).Position.X + Utilities.GetInstance().TILE_SIZE, ((Entity)entity).Position.Y + Utilities.GetInstance().TILE_SIZE))?.Fire();
                        break;
                    case Wind.Direction.Right:
                        trees.Find(found => found.Position == new Vector2f(((Entity)entity).Position.X + Utilities.GetInstance().TILE_SIZE, ((Entity)entity).Position.Y))?.Fire();
                        houses.Find(found => found.Position == new Vector2f(((Entity)entity).Position.X + Utilities.GetInstance().TILE_SIZE, ((Entity)entity).Position.Y))?.Fire();
                        break;
                    case Wind.Direction.RightUp:
                        trees.Find(found => found.Position == new Vector2f(((Entity)entity).Position.X + Utilities.GetInstance().TILE_SIZE, ((Entity)entity).Position.Y - Utilities.GetInstance().TILE_SIZE))?.Fire();
                        houses.Find(found => found.Position == new Vector2f(((Entity)entity).Position.X + Utilities.GetInstance().TILE_SIZE, ((Entity)entity).Position.Y - Utilities.GetInstance().TILE_SIZE))?.Fire();
                        break;
                    default:
                        break;
                }
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (Tree tree in trees)
            {
                target.Draw(tree, states);
            }
            foreach (House house in houses)
            {
                target.Draw(house, states);
            }
            foreach (Lake lake in lakes)
            {
                target.Draw(lake, states);
            }
            foreach (Rock rock in rocks)
            {
                target.Draw(rock, states);
            }
        }

        public List<IFlammable> GetFlammableObjects()
        {
            List<IFlammable> flammables = new List<IFlammable>();

            foreach (Tree tree in trees)
            {
                flammables.Add(tree);
            }
            foreach (House house in houses)
            {
                flammables.Add(house);
            }

            return flammables;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Tree tree in trees)
            {
                yield return tree;
            }
            foreach (House house in houses)
            {
                yield return house;
            }
            foreach (Lake lake in lakes)
            {
                yield return lake;
            }
            foreach (Rock rock in rocks)
            {
                yield return rock;
            }
        }
    }
}
