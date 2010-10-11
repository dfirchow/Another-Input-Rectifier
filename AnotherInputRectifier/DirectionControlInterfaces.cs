using Microsoft.Xna.Framework;

namespace AnotherInputRectifier
{
    public interface IDigitalDirectionControl
    {
        bool Up { get; }
        bool Down { get; }
        bool Left { get; }
        bool Right { get; }
    }

    public interface IAnalogDirectionControl
    {
        /// <summary>
        /// Returns the analog values for the X and Y axes.
        /// </summary>
        Vector2 Value { get; }
    }

    /// <summary>
    /// A direction control that provides both analog and digital values.
    /// </summary>
    public interface IDirectionControl : IDigitalDirectionControl, IAnalogDirectionControl
    {
    }
}
