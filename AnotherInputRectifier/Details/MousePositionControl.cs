using Microsoft.Xna.Framework;

namespace AnotherInputRectifier.Details
{
    /// <summary>
    /// Represents the position of the mouse as an IAnalogDirectionControl
    /// </summary>
    internal class MousePositionControl : IAnalogDirectionControl
    {
        public Vector2 Value
        {
            get { return new Vector2(Air.MouseState.X, Air.MouseState.Y); }
        }
    }
}
