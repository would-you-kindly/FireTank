namespace FireSafety
{
    public class Gui
    {
        public FireSafetyForm form;

        public Gui(World world)
        {
            form = new FireSafetyForm(world);
            form.Show();
        }
    }
}
