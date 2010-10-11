namespace AnotherInputRectifier
{
    public class ButtonDirectionControl : IDigitalDirectionControl
    {
        private IDigitalControl left, right, up, down;

        public ButtonDirectionControl(IDigitalControl left,
                                      IDigitalControl right,
                                      IDigitalControl up,
                                      IDigitalControl down)
        {
            this.left = left;
            this.right = right;
            this.up = up;
            this.down = down;
        }

        public bool Up
        {
            get { return up.Pressed; }
        }

        public bool Down
        {
            get { return down.Pressed; }
        }

        public bool Left
        {
            get { return left.Pressed; }
        }

        public bool Right
        {
            get { return right.Pressed; }
        }
    }
}
