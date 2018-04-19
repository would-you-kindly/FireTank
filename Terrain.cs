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
    public class Terrain : IEnumerable
    {
        public List<Tree> trees;
        public List<Lake> lakes;

        public Terrain(List<Object> objects, TextureHolder<Textures.ID> textures) :
            base()
        {
            trees = new List<Tree>();
            lakes = new List<Lake>();

            foreach (Object item in objects)
            {
                // Создаем деревья
                if (item.name == "tree")
                {
                    Tree tree = new Tree(Textures.ID.Tree, textures);
                    tree.Position = new Vector2f(item.rect.Left, item.rect.Top);
                    if (item.GetPropertyBool("burns"))
                    {
                        // TODO: Такое себе место
                        tree.state.currentTimeToSpread = 3;
                        tree.Fire();
                    }
                    trees.Add(tree);
                }

                // Создаем озера
                if (item.name == "lake")
                {
                    Lake lake = new Lake(Textures.ID.Lake, textures);
                    lake.Position = new Vector2f(item.rect.Left, item.rect.Top);
                    lakes.Add(lake);
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

        public void Update(Time deltaTime)
        {
            SpreadFire();

            foreach (Tree tree in trees)
            {
                tree.Update(deltaTime);
            }
            foreach (Lake lake in lakes)
            {
                lake.Update(deltaTime);
            }
        }

        private void SpreadFire()
        {
            // Огонь распространяется через каждые timeToSpread шагов
            // TODO: Ошибка в том, что после тушения иногда дерево загорается на этом же шаге и кажется будто оно вообще не было потушено
            //currentTimeToSpread++;
            //if (currentTimeToSpread != timeToSpread)
            //{
            //    return;
            //}
            //else
            //{
            //    currentTimeToSpread = 0;
            //}

            // Ищем дерево, которое загорится следующим
            List<Tree> burningTrees = new List<Tree>(trees.Where(found => found.state.IsBurning()));
            foreach (Tree tree in burningTrees)
            {
                switch (World.wind.direction)
                {
                    case Wind.Direction.Up:
                        trees.Find(found => found.Position == new Vector2f(tree.Position.X, tree.Position.Y - Utilities.TILE_SIZE))?.Fire();
                        break;
                    case Wind.Direction.Left:
                        trees.Find(found => found.Position == new Vector2f(tree.Position.X - Utilities.TILE_SIZE, tree.Position.Y))?.Fire();
                        break;
                    case Wind.Direction.Down:
                        trees.Find(found => found.Position == new Vector2f(tree.Position.X, tree.Position.Y + Utilities.TILE_SIZE))?.Fire();
                        break;
                    case Wind.Direction.Right:
                        trees.Find(found => found.Position == new Vector2f(tree.Position.X + Utilities.TILE_SIZE, tree.Position.Y))?.Fire();
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
        }
    }
}
