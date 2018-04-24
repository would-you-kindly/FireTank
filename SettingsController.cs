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
        }

        public void InitShortcuts()
        {
            List<Tuple<string, string, Keys>> shortcuts = Settings.GetInstance().GenerateShortcutList();

            foreach (var item in shortcuts)
            {
                settingsForm.dgvShortcuts.Rows.Add(item.Item1, item.Item2, item.Item3);
            }

            settingsForm.nudTimeToHold.Value = Settings.GetInstance().timeToHold;
        }

        public void Default()
        {
            Settings.GetInstance().Default();
        }

        public void SetShortcut(string command, Keys key)
        {
            Settings.GetInstance().SetShortcut(command, key);
        }
    }
}