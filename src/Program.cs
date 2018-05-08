using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireSafety
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                //UserModel user = new UserModel()
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "Имя",
                //    Patronymic = "Отчество",
                //    Lastname = "Фамилия",
                //    Login = "admin",
                //    Password = "admin",
                //    Algorithms = null
                //};

                //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ModelContext>());
                //Utilities.context.Users.Add(user);
                //Utilities.context.SaveChanges();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                LoginForm login = new LoginForm();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Game game = new Game();
                    game.Run();
                }
                //Settings.GetInstance().SetCurrentUser(Guid.Parse("B7574C35-DEE9-4BCA-AE69-260CAFEB3286"));


            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    MessageBox.Show(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        MessageBox.Show(string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
                MessageBox.Show(e.Message);
            }
        }
    }
}