using System;
using System.Linq;
using System.Windows.Forms;

namespace FireSafety
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Utilities.GetInstance().context.Users.Any(user => user.Login == tbLogin.Text))
            {
                if (Utilities.GetInstance().context.Users.First(user => user.Login == tbLogin.Text).Password == tbPassword.Text)
                {
                    UserModel userModel = Utilities.GetInstance().context.Users.First(user =>
                        user.Login == tbLogin.Text && user.Password == tbPassword.Text);

                    Settings.GetInstance().SetCurrentUser(userModel.Id);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Пароль пользователя введен неверно. Проверьте правильность пароля.",
                        "Ошибка при входе", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Данного логина не существует. Проверьте правильность логина.",
                    "Ошибка при входе", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
