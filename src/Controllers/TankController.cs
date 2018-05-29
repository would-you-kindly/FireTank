using System.Collections.Generic;
using System.Windows.Forms;

namespace FireSafety
{
    public class TankController
    {
        public TankController(Tank tank, AlgorithmForm algorithmForm)
        {
            // При выстреле меняем показатель запасов воды, давления и готовности
            tank.turret.TurretShoot += (sender, e) =>
            {
                algorithmForm.lblCapacity.Text = ((Turret)sender).waterCapacity.ToString();
                algorithmForm.lblPressure.Text = ((Turret)sender).waterPressure.ToString();

                algorithmForm.pbReady.Visible = false;
                algorithmForm.pbUnready.Visible = true;
            };

            // При увеличении давления меняем показатель давления
            tank.turret.TurretPressure += (sender, e) =>
            {
                algorithmForm.lblPressure.Text = ((Turret)sender).waterPressure.ToString();
            };

            // При поднятии/опускании пушки меняем картинку
            tank.turret.TurretUp += (sender, e) =>
            {
                algorithmForm.pbUp.Visible = true;
                algorithmForm.pbDown.Visible = false;
            };
            tank.turret.TurretDown += (sender, e) =>
            {
                algorithmForm.pbUp.Visible = false;
                algorithmForm.pbDown.Visible = true;
            };

            // При заряде пушки меняем картинку
            tank.turret.WeaponCharged += (sender, e) =>
            {
                algorithmForm.pbReady.Visible = true;
                algorithmForm.pbUnready.Visible = false;
            };

            // При пополнении запасов меняем значение запасов
            tank.Refueled += (sender, e) =>
            {
                algorithmForm.lblCapacity.Text = ((Tank)sender).turret.waterCapacity.ToString();
            };
        }
    }
}