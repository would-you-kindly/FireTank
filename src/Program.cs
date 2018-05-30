using System;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
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
                //Utilities.GetInstance().GetContext().Users.Add(user);
                //Utilities.GetInstance().GetContext().SaveChanges();


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
                MessageBox.Show(e.Message);
                MessageBox.Show(e.InnerException.ToString());
            }
        }
    }
}