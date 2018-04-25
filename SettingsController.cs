using System;
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
            this.settingsForm.dgvShortcuts.ClearSelection();

            Settings.GetInstance().ShortcutUpdated += SettingsController_ShortcutUpdated;
            Settings.GetInstance().Defaulted += SettingsController_Defaulted;
        }

        private void SettingsController_Defaulted(object sender, Settings.DefaultShortcutEventArgs e)
        {
            UpdateControls();
        }

        private void SettingsController_ShortcutUpdated(object sender, Settings.UpdateShortcutEventArgs e)
        {

        }

        private void UpdateControls()
        {
            // Обновляем надписи горячих клавиш
            settingsForm.dgvShortcuts.Rows[0].Cells[2].Value = Settings.GetInstance().none;
        }

        public void InitShortcuts()
        {
            List<Tuple<string, object, Keys>> shortcuts = Settings.GetInstance().GenerateShortcutList();

            foreach (var item in shortcuts)
            {
                settingsForm.dgvShortcuts.Rows.Add(item.Item1, item.Item2, item.Item3);
            }

            settingsForm.nudTimeToHold.Value = Settings.GetInstance().timeToHold;

            settingsForm.tbConnectionString.Text = Settings.GetInstance().connectionString;
            settingsForm.tbUser.Text = Settings.GetInstance().GetUserString();
        }

        public void Default()
        {
            Settings.GetInstance().Default();
        }

        public void SetShortcut(string permormer, object command, Keys key)
        {
            Settings.GetInstance().SetShortcut(permormer, command, key);
        }
    }
}