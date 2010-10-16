namespace AnotherInputRectifier
{
    public static class DigitalControlExtensions
    {
        /// <summary>
        /// Convert a digital control into a filtered digital control.
        /// </summary>
        /// <param name="control">The control to filter</param>
        /// <returns>A new digital filter control</returns>
        public static DigitalFilterControl Filter(this IDigitalControl control)
        {
            return new DigitalFilterControl(control);
        }

        /// <summary>
        /// Convert a digital control into a analog control.
        /// </summary>
        /// <param name="control">The control to convert</param>
        /// <returns>A new analog control</returns>
        public static IAnalogControl Analog(this IDigitalControl control)
        {
            return new DigitalToAnalogAdapter(control);
        }
    }
}
