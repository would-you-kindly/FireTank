using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGUI;
using FireSafety;
using System.Windows.Forms;

namespace Interface
{
    public class GuiT
    {
        public RenderWindow renderWindow;
        public Gui gui;

        private static GuiT instance;
        public AlgorithmT algorithmT;
        public MenuT menuT;

        private GuiT()
        {
            renderWindow = new RenderWindow(new VideoMode(Utilities.WINDOW_WIDTH, Utilities.WINDOW_HEIGHT), "FireSafety");
            gui = new Gui(renderWindow);
            algorithmT = new AlgorithmT();
            menuT = new MenuT();

            gui.Add(algorithmT.window);
            gui.Add(menuT.menuBar);
        }

        public static GuiT GetInstance()
        {
            if (instance == null)
                instance = new GuiT();
            return instance;
        }

        private ParallelAlgorithm BuildParallelAlgorithm()
        {
            List<Action> listActions = new List<Action>();
            for (int i = 0; i < algorithmT.lbMove.GetItems().Count; i++)
            {
                listActions.Add(new Action());
            }

            for (int i = 0; i < algorithmT.lbMove.GetItems().Count; i++)
            {
                switch (algorithmT.lbMove.GetItems()[i])
                {
                    case "Forward":
                        listActions[i].tankCommands[(int)Action.Types.Move] = new MoveCommand(MoveCommand.Commands.Forward);
                        break;
                    case "Backward":
                        listActions[i].tankCommands[(int)Action.Types.Move] = new MoveCommand(MoveCommand.Commands.Backward);
                        break;
                    case "45 CW":
                        listActions[i].tankCommands[(int)Action.Types.Move] = new MoveCommand(MoveCommand.Commands.Rotate45CW);
                        break;
                    case "45 CCW":
                        listActions[i].tankCommands[(int)Action.Types.Move] = new MoveCommand(MoveCommand.Commands.Rotate45CCW);
                        break;
                    case "90 CW":
                        listActions[i].tankCommands[(int)Action.Types.Move] = new MoveCommand(MoveCommand.Commands.Rotate90CW);
                        break;
                    case "90 CCW":
                        listActions[i].tankCommands[(int)Action.Types.Move] = new MoveCommand(MoveCommand.Commands.Rotate90CCW);
                        break;
                }
            }

            for (int i = 0; i < algorithmT.lbShoot.GetItems().Count; i++)
            {
                switch (algorithmT.lbShoot.GetItems()[i])
                {
                    case "Pressure":
                        listActions[i].tankCommands[(int)Action.Types.Shoot] = new ShootCommand(ShootCommand.Commands.IncreaseWaterPressure);
                        break;
                    case "Shoot":
                        listActions[i].tankCommands[(int)Action.Types.Shoot] = new ShootCommand(ShootCommand.Commands.Shoot);
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < algorithmT.lbTurret.GetItems().Count; i++)
            {
                switch (algorithmT.lbTurret.GetItems()[i])
                {
                    case "45 CW":
                        listActions[i].tankCommands[(int)Action.Types.Turret] = new TurretCommand(TurretCommand.Commands.Rotate45CW);
                        break;
                    case "45 CCW":
                        listActions[i].tankCommands[(int)Action.Types.Turret] = new TurretCommand(TurretCommand.Commands.Rotate45CCW);
                        break;
                    case "90 CW":
                        listActions[i].tankCommands[(int)Action.Types.Turret] = new TurretCommand(TurretCommand.Commands.Rotate90CW);
                        break;
                    case "90 CCW":
                        listActions[i].tankCommands[(int)Action.Types.Turret] = new TurretCommand(TurretCommand.Commands.Rotate90CCW);
                        break;
                    case "Up":
                        listActions[i].tankCommands[(int)Action.Types.Turret] = new TurretCommand(TurretCommand.Commands.Up);
                        break;
                    case "Down":
                        listActions[i].tankCommands[(int)Action.Types.Turret] = new TurretCommand(TurretCommand.Commands.Down);
                        break;
                    default:
                        break;
                }
            }

            Queue<Action> actions = new Queue<Action>();
            foreach (Action action in listActions)
            {
                actions.Enqueue(action);
            }

            Algorithm algorithm = new Algorithm();
            algorithm.Actions = actions;
            ParallelAlgorithm parallelAlgorithm = new ParallelAlgorithm();
            parallelAlgorithm.Algorithms.Add(algorithm);
            return parallelAlgorithm;
        }

        public void LoadParallelAlgorithm()
        {
            // Загружаем параллельный алгоритм из файла
            ParallelAlgorithm parallelAlgorithm = new ParallelAlgorithm();
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                parallelAlgorithm.Load(ofd.FileName);
            }

            // TODO: gkj[j nen
            // Обновляем ComboBox'ы в соответствии с параллельным алгоритмом
            //for (int i = 0; i < algorithmForms.Count; i++)
            {
                for (int j = 0; j < parallelAlgorithm.Algorithms[0].Actions.Count; j++)
                {
                    Action action = parallelAlgorithm.Algorithms[0].Actions.Dequeue();
                    algorithmT.lbMove.AddItem(action.tankCommands[0].ToString());
                    algorithmT.lbShoot.AddItem(action.tankCommands[1].ToString());
                    algorithmT.lbTurret.AddItem(action.tankCommands[2].ToString());
                }
            }
        }

        public void SaveParallelAlgorithm()
        {
            // Сохраняем параллельный алгоритм в файл
            ParallelAlgorithm algorithm = BuildParallelAlgorithm();
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                algorithm.Save(sfd.FileName);
            }
        }

        public void Execute()
        {
            BuildParallelAlgorithm().Execute();
        }

        public void Draw()
        {
            gui.Draw();
        }
    }
}
