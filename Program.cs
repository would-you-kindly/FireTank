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
                //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ModelContext>());
                //ModelContext context = new ModelContext(Settings.GetInstance().connectionString);
                //context.Maps.Add(new MapModel());
                //context.SaveChanges();

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
            }
        }
    }
}