namespace AnotherInputRectifier
{
    public class AnalogDirectionControl : IDirectionControl
    {
        private IAnalogDirectionControl control;

        public AnalogDirectionControl(IAnalogDirectionControl control)
        {
            this.control = control;
        }

        // In Xna thumbsticks are centered at (0,0)
        // positive values are down and to the right
        // negative values are up and to the left

        public bool Up
        {
            get { return control.Value.Y < 0; }
        }

        public bool Down
        {
            get { return control.Value.Y > 0; }
        }

        public bool Left
        {
            get { return control.Value.X < 0; }
        }

        public bool Right
        {
            get { return control.Value.X > 0; }
        }

        public Microsoft.Xna.Framework.Vector2 Value
        {
            get { return control.Value; }
        }
    }
}
