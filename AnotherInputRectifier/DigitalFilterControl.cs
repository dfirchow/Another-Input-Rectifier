namespace AnotherInputRectifier
{
    /// <summary>
    /// A digital control that filters continuous input.
    /// You must release the button between presses.
    /// </summary>
    public class DigitalFilterControl : IDigitalControl
    {
        private readonly IDigitalControl control;
        private bool wasReleased;

        public DigitalFilterControl(IDigitalControl control)
        {
            this.control = control;
            wasReleased = true;
        }

        /// <summary>
        /// Returns true if the control is pressed now
        /// and was not pressed the last time
        /// </summary>
        public bool Pressed
        {
            get 
            {
                if (wasReleased && control.Pressed)
                {
                    wasReleased = false;
                    return true;
                }
                else
                {
                    // If control.Pressed changed, update wasReleased.
                    wasReleased = !control.Pressed;
                    return false;
                }
            }
        }
    }
}
