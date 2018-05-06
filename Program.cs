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

                Settings.GetInstance().SetCurrentUser(Guid.Parse("A031D871-0553-41A2-924F-E80B6F340784"));
                Settings.GetInstance().SetCurrentMap(Guid.Parse("6B790575-5BE1-4063-87E9-015ADD98D327"));

                Game game = new Game();
                game.Run();
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