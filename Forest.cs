using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class Forest : Entity
    {
        public List<Tree> trees;
        private Wind _wind;
        private const int timeToSpread = 3;
        private int currentTimeToSpread = 0;

        public Forest() :
            base()
        {
            trees = new List<Tree>();
            _wind = new Wind(Wind.Direction.Down);
        }

        public Forest(List<Object> treesObjects, TextureHolder<Textures.ID> textures, Wind wind) :
            base()
        {
            trees = new List<Tree>();
            _wind = wind;

            foreach (Object item in treesObjects)
            {
                Tree tree = new Tree(Textures.ID.Tree, Textures.ID.Fire, textures);
                tree.Position = new Vector2f(item.rect.Left, item.rect.Top);
                trees.Add(tree);
            }
        }

        public Tree this[int index]
        {
            get
            {
                return trees[index];
            }
            set
            {
                trees[index] = value;
            }
        }

        public override void Update(Time deltaTime)
        {
            SpreadFire();

            foreach (Tree tree in trees)
            {
                tree.Update(deltaTime);
            }
        }

        private void SpreadFire()
        {
            // Огонь распространяется через каждые timeToSpread шагов
            currentTimeToSpread++;
            if (currentTimeToSpread != timeToSpread)
            {
                return;
            }
            else
            {
                currentTimeToSpread = 0;
            }

            // Ищем дерево, которое загорится следующим
            List<Tree> burningTrees = new List<Tree>(trees.Where(found => found.state == Tree.State.Burns));
            foreach (Tree tree in burningTrees)
            {
                switch (_wind.direction)
                {
                    case Wind.Direction.Up:
                        trees.Find(found => found.Position == new Vector2f(tree.Position.X, tree.Position.Y -32))?.Fire();
                        break;
                    case Wind.Direction.Left:
                        trees.Find(found => found.Position == new Vector2f(tree.Position.X - 32, tree.Position.Y))?.Fire();
                        break;
                    case Wind.Direction.Down:
                        trees.Find(found => found.Position == new Vector2f(tree.Position.X, tree.Position.Y + 32))?.Fire();
                        break;
                    case Wind.Direction.Rigth:
                        trees.Find(found => found.Position == new Vector2f(tree.Position.X + 32, tree.Position.Y))?.Fire();
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
        }
    }
}
