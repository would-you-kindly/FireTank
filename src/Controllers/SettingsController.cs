﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FireSafety
{
    public class SettingsController
    {
        private SettingsForm settingsForm;

        public SettingsController(SettingsForm settingsForm)
        {
            this.settingsForm = settingsForm;

            //Settings.GetInstance().ShortcutUpdated += SettingsController_ShortcutUpdated;
            //Settings.GetInstance().Defaulted += SettingsController_Defaulted;

            settingsForm.dgvShortcuts.CellValueChanged += DgvShortcuts_CellValueChanged;
        }

        private void DgvShortcuts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SetShortcut(settingsForm.dgvShortcuts.SelectedRows[0].Cells[0].Value.ToString(),
                settingsForm.dgvShortcuts.SelectedRows[0].Cells[1].Value.ToString(), (Keys)((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
        }

        private void UpdateControls()
        {
            // Обновляем надписи горячих клавиш
            settingsForm.dgvShortcuts.Rows[0].Cells[2].Value = Settings.GetInstance().none;
        }

        public void InitShortcuts()
        {
            List<Tuple<string, string, Keys>> shortcuts = Settings.GetInstance().GenerateShortcutList();

            foreach (var item in shortcuts)
            {
                settingsForm.dgvShortcuts.Rows.Add(item.Item1, item.Item2, item.Item3);
            }

            settingsForm.tbConnectionString.Text = Settings.GetInstance().connectionString;
            settingsForm.tbUser.Text = Settings.GetInstance().GetUserString();
        }

        public void Default()
        {
            Settings.GetInstance().Default();
        }

        public void SetShortcut(string permormer, string command, Keys key)
        {
            Settings.GetInstance().SetShortcut(permormer, command, key);
        }
    }
}