using System;
using System.Windows.Forms;

namespace FireSafety
{
    public partial class MapOpenerForm : Form
    {
        FireSafetyForm _fireSafetyForm;

        public MapOpenerForm(FireSafetyForm fireSafetyForm)
        {
            InitializeComponent();

            _fireSafetyForm = fireSafetyForm;

            Init();
        }

        private void Init()
        {
            int i = 0;
            foreach (MapModel map in Utilities.context.Maps)
            {
                Guid id = map.Id;

                dgvMaps.Rows.Add(++i, id);
            }
        }

        private void btnOpenMap_Click(object sender, EventArgs e)
        {
            if (dgvMaps.SelectedRows.Count != 0)
            {
                Guid id = (Guid)dgvMaps.SelectedRows[0].Cells[1].Value;

                // Очищаем алгоритм и окна перед открытием новой карты
                _fireSafetyForm.Clear();

                // Перестраиваем мир по новой карте
                _fireSafetyForm.RebuildWorld(id);

                // Создаем новые окна
                _fireSafetyForm.Init();

                // Применяем компоновку окон
                _fireSafetyForm.SmartLayout();

                // Загружаем тренировочный алгоритм (если он есть)
                //_fireSafetyForm.LoadTrainingAlgorithm();

                this.Close();
            }
        }
    }
}
