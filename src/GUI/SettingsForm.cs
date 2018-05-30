using System;
using System.Data.SqlClient;
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

            dgvShortcuts.ClearSelection();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите восстановить настройки по умолчанию?",
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
                    if (value == (Keys)key.Cells[2].Value)
                    {
                        MessageBox.Show($"Клавиша {value} уже назначена для другой команды. Выберите другую горячую клавишу.",
                            "Назначение горячей клавиши", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return;
                    }
                }

                dgvShortcuts.SelectedRows[0].Cells[2].Value = value;
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            CheckConnection();
        }

        private bool CheckConnection(bool show = true)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Settings.GetInstance().connectionString))
                {
                    connection.Open();
                    connection.Close();

                    if (show)
                    {
                        MessageBox.Show("Соединение установлено успешно.", "Проверка строки подключения к базе данных",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                return true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            return false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!CheckConnection(false))
            {
                return;
            }

            LoginForm login = new LoginForm();

            if (login.ShowDialog() == DialogResult.OK)
            {
                tbUser.Text = Settings.GetInstance().GetUserString();

                MessageBox.Show($"Вы вошли как пользователь {Settings.GetInstance().GetUserString()}. Чтобы результаты работы алгоритма " +
                    $"сохранились в базе данных, необходимо открыть карту из базы данных.", "Вход в систему", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
