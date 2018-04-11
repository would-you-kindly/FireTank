using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FireSafety
{
    partial class FireSafetyForm : Form
    {
        ParallelAlgorithm _parallelAlgorithm;
        List<AlgorithmForm> algorithmForms;

        public FireSafetyForm(ParallelAlgorithm parallelAlgorithm)
        {
            InitializeComponent();
            _parallelAlgorithm = parallelAlgorithm;
            algorithmForms = new List<AlgorithmForm>();

            for (int i = 0; i < Utilities.TANKS_COUNT; i++)
            {
                AlgorithmForm algorithmForm = new AlgorithmForm(parallelAlgorithm[i]);
                algorithmForm.MdiParent = this;
                algorithmForm.Text = Enum.Parse(typeof(Tank.TankColor), i.ToString()).ToString();
                algorithmForm.Show();
                algorithmForms.Add(algorithmForm);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var algorithmForm in algorithmForms)
            {
                algorithmForm.ExecuteAlgorithm();
            }
            //_parallelAlgorithm.Execute();
            Game.executing = true;
        }

        private void saveAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var algorithmForm in algorithmForms)
            {
                // Не фактическое выполнение, а перенос слов с элементов управления в экземпляры класса Flgorithm
                algorithmForm.ExecuteAlgorithm();
            }

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("ParallelAlgorithm.algo", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, _parallelAlgorithm);
            }
        }

        private void loadAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParallelAlgorithm loadedParallelAlgorithm;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("ParallelAlgorithm.algo", FileMode.Open, FileAccess.Read))
            {
                loadedParallelAlgorithm = (ParallelAlgorithm)formatter.Deserialize(fs);
            }

            // Пишем шаги алгоритма в элементы управления формы
            for (int i = 0; i < algorithmForms.Count; i++)
            {
                int actionCount = loadedParallelAlgorithm.Algorithms[i].Actions.Count;
                for (int j = 0; j < actionCount; j++)
                {
                    Action action = loadedParallelAlgorithm.Algorithms[i].Actions.Dequeue();
                    algorithmForms[i].lbMoveCommands.Items.Add(action.commands[0].ToString());
                    algorithmForms[i].lbShootCommands.Items.Add(action.commands[1].ToString());
                    algorithmForms[i].lbTurretCommands.Items.Add(action.commands[2].ToString());
                }
            }
        }
    }
}
