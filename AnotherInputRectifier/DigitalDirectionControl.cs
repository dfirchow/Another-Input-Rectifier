namespace AnotherInputRectifier
{
    public class DigitalDirectionControl : IDirectionControl
    {
        private IDigitalDirectionControl control;

        public DigitalDirectionControl(IDigitalDirectionControl control)
        {
            this.control = control;
        }

        public bool Up
        {
            get { return control.Up; }
        }

        public bool Down
        {
            get { return control.Down; }
        }

        public bool Left
        {
            get { return control.Left; }
        }

        public bool Right
        {
            get { return control.Right; }
        }

        /// <summary>
        /// Returns Value.X = -1 for left or +1 for right
        /// and Value.Y = -1 for up or +1 for down. If both or neither
        /// buttons for the same axis are down the corresponding
        /// value will be 0.
        /// </summary>
        public Microsoft.Xna.Framework.Vector2 Value
        {
            get 
            {
                int x = 0, y = 0;

                if (control.Left)  { x -= 1; }
                if (control.Right) { x += 1; }

                if (control.Up)    { y -= 1; }
                if (control.Down)  { y += 1; }

                return new Microsoft.Xna.Framework.Vector2(x, y);
            }
        }
    }
}
