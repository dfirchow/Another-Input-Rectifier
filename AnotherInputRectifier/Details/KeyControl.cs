using Microsoft.Xna.Framework.Input;

namespace AnotherInputRectifier.Details
{
    /// <summary>
    /// Implements a digital control based on a key from the keyboard
    /// </summary>
    internal class KeyControl : IDigitalControl
    {
        private readonly Keys key;

        public KeyControl(Keys key)
        {
            this.key = key;
        }

        public bool Pressed
        {
            get { return Air.KeyboardState.IsKeyDown(key); }
        }
    }
}
