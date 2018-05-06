using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Lake> lakes;
        public List<Rock> rocks;
        public Wind wind;

        public Terrain(List<Object> objects, ResourceHolder resources, Wind wind)
        {
            trees = new List<Tree>();
            lakes = new List<Lake>();
            rocks = new List<Rock>();
            this.wind = wind;

            foreach (Object item in objects)
            {
                // Создаем деревья
                if (item.name == "tree")
                {
                    Tree tree = new Tree(Textures.ID.Tree, resources);
                    tree.Position = new Vector2f(item.rect.Left + Utilities.TILE_SIZE / 2, item.rect.Top - Utilities.TILE_SIZE / 2);
                    if (item.GetPropertyBool("burns"))
                    {
                        // TODO: Такое себе место (чтобы подожглось, нужно сделать так)
                        tree.state.currentTimeToSpread = tree.state.timeToSpread;
                        tree.Fire();
                    }
                    trees.Add(tree);
                }

                // Создаем озера
                if (item.name == "lake")
                {
                    Lake lake = new Lake(Textures.ID.Lake, resources);
                    lake.Position = new Vector2f(item.rect.Left + Utilities.TILE_SIZE / 2, item.rect.Top - Utilities.TILE_SIZE / 2);
                    lakes.Add(lake);
                }

                // Создаем скалы
                if (item.name == "rock")
                {
                    Rock rock = new Rock(Textures.ID.Rock, resources);
                    rock.Position = new Vector2f(item.rect.Left + Utilities.TILE_SIZE / 2, item.rect.Top - Utilities.TILE_SIZE / 2);
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
            // Поджигаем новые деревья
            SpreadFire();

            // Обновляем объекты местности
            foreach (Tree tree in trees)
            {
                tree.Update(deltaTime);
            }
            foreach (Lake lake in lakes)
            {
                lake.Update(deltaTime);
            }
            foreach (Rock rock in rocks)
            {
                rock.Update(deltaTime);
            }

            // Проверяем состояние местности на наличие пожара
            CheckTerrainState();
        }

        private void CheckTerrainState()
        {
            foreach (Tree tree in trees)
            {
                if (tree.state.IsBurning())
                {
                    return;
                }
            }

            FireOver?.Invoke(this, new FireOverEventArgs());
        }

        private void SpreadFire()
        {
            // Ищем дерево, которое загорится следующим
            List<Tree> burningTrees = new List<Tree>(trees.Where(found => found.state.IsBurning()));
            foreach (Tree tree in burningTrees)
            {
                switch (wind.direction)
                {
                    case Wind.Direction.Up:
                        trees.Find(found => found.Position == new Vector2f(tree.Position.X, tree.Position.Y - Utilities.TILE_SIZE))?.Fire();
                        break;
                    case Wind.Direction.UpLeft:
                        trees.Find(found => found.Position == new Vector2f(tree.Position.X - Utilities.TILE_SIZE, tree.Position.Y - Utilities.TILE_SIZE))?.Fire();
                        break;
                    case Wind.Direction.Left:
                        trees.Find(found => found.Position == new Vector2f(tree.Position.X - Utilities.TILE_SIZE, tree.Position.Y))?.Fire();
                        break;
                    case Wind.Direction.LeftDown:
                        trees.Find(found => found.Position == new Vector2f(tree.Position.X - Utilities.TILE_SIZE, tree.Position.Y + Utilities.TILE_SIZE))?.Fire();
                        break;
                    case Wind.Direction.Down:
                        trees.Find(found => found.Position == new Vector2f(tree.Position.X, tree.Position.Y + Utilities.TILE_SIZE))?.Fire();
                        break;
                    case Wind.Direction.DownRight:
                        trees.Find(found => found.Position == new Vector2f(tree.Position.X + Utilities.TILE_SIZE, tree.Position.Y + Utilities.TILE_SIZE))?.Fire();
                        break;
                    case Wind.Direction.Right:
                        trees.Find(found => found.Position == new Vector2f(tree.Position.X + Utilities.TILE_SIZE, tree.Position.Y))?.Fire();
                        break;
                    case Wind.Direction.RightUp:
                        trees.Find(found => found.Position == new Vector2f(tree.Position.X + Utilities.TILE_SIZE, tree.Position.Y - Utilities.TILE_SIZE))?.Fire();
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
            foreach (Lake lake in lakes)
            {
                target.Draw(lake, states);
            }
            foreach (Rock rock in rocks)
            {
                target.Draw(rock, states);
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Tree tree in trees)
            {
                yield return tree;
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
