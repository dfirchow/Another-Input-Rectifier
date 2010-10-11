namespace AnotherInputRectifier
{
    public class DigitalToAnalogAdapter : IAnalogControl
    {
        private IDigitalControl control;

        public DigitalToAnalogAdapter(IDigitalControl control)
        {
            this.control = control;
        }

        public float Value
        {
            get { return control.Pressed ? 1 : 0; }
        }
    }
}
