using Microsoft.Xna.Framework.Input;

namespace AnotherInputRectifier
{
    public static class KeyboardExtensions
    {
        public static IDigitalControl ToDigitalControl(this Keys key)
        {
            return new Details.KeyControl(key);
        }
    }
}
