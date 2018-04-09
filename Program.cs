using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
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
                Game game = new Game();
                game.Run();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}