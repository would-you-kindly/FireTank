using System.Windows.Forms;

namespace FireSafety
{
    public partial class InfoForm : Form
    {
        public TankController tankController;

        public InfoForm()
        {
            InitializeComponent();

            //tankController = new TankController(label3);
        }
    }
}
