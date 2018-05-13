using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FireSafety
{
    public partial class OpenMapForm : Form
    {
        private Guid guid;
        public Guid Guid
        {
            get
            {
                if (guid == null)
                {
                    throw new Exception("Guid не задан");
                }

                return guid;
            }
        }

        public OpenMapForm()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            int i = 0;
            foreach (MapModel map in Utilities.GetInstance().context.Maps)
            {
                Guid id = map.Id;

                //XDocument xml = new XDocument();
                //xml.l
                //Parse(map.XmlContent);

                dgvMaps.Rows.Add(++i, id);
            }
        }

        private void btnOpenMap_Click(object sender, EventArgs e)
        {
            if (dgvMaps.SelectedRows.Count != 0)
            {
                guid = (Guid)dgvMaps.SelectedRows[0].Cells[1].Value;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
