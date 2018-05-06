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
                //    Patronymic = "",
                //    Lastname = "",
                //    Login = "admin",
                //    Password = "admin",
                //    Algorithms = null
                //};

                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ModelContext>());
                Utilities.context.Maps.Add(new MapModel());
                Utilities.context.SaveChanges();

                Settings.GetInstance().SetCurrentUser(Guid.Parse("03B4F988-74B7-4C81-94ED-B2713B859D4E"));
                Settings.GetInstance().SetCurrentMap(Guid.Parse("FB3FB487-A913-4DDC-8071-1FC7A7048564"));

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