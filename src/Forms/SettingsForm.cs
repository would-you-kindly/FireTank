using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireSafety
{
    public partial class SettingsForm : Form
    {
        private SettingsController controller;

        public SettingsForm()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            controller = new SettingsController(this);

            controller.InitShortcuts();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите вернуть настройки по умолчанию?", 
                "Восстановаление настроек", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                controller.Default();
            }
        }

        private void dgvShortcuts_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvShortcuts.SelectedRows.Count != 0)
            {
                Keys value = e.KeyCode;

                foreach (DataGridViewRow key in dgvShortcuts.Rows)
                {
                    // Если нашли уже существующий shortcut
                    if (value == (Keys)key.Cells[2].Value || value == Keys.F1)
                    {
                        MessageBox.Show("shortcut exists");
                        return;
                    }
                }

                // TODO: Лучше создать событие и подписаться
                dgvShortcuts.SelectedRows[0].Cells[2].Value = value;
                controller.SetShortcut(dgvShortcuts.SelectedRows[0].Cells[0].Value.ToString(),
                    dgvShortcuts.SelectedRows[0].Cells[1].Value, value);
            }
        }
    }
}
