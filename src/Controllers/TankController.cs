using System.Collections.Generic;
using System.Windows.Forms;

namespace FireSafety
{
    public class TankController
    {
        public List<Control> controls;

        public TankController(params Control[] controls)
        {
            //this.controls = new List<Control>(controls);

            //foreach (Tank tank in tanks)
            //{
            //    tank.turret.TurretPressure += (sender, e) =>
            //    {
            //        controls[0].Text = ((Turret)sender).waterPressure.ToString();
            //    };
            //}
        }
    }
}