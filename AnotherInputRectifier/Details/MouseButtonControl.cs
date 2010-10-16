using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace AnotherInputRectifier.Details
{
    /// <summary>
    /// Represents a mouse button as a digital control
    /// </summary>
    internal class MouseButtonControl : IDigitalControl
    {
        private readonly PropertyInfo button;

        public MouseButtonControl(Air.Mouse.Buttons button)
        {
            string buttonName;
            switch (button)
            {
                case Air.Mouse.Buttons.X1:
                    buttonName = "XButton1";
                    break;
                case Air.Mouse.Buttons.X2:
                    buttonName = "XButton2";
                    break;
                default:
                    buttonName = button.ToString() + "Button";
                    break;
            }
            this.button = typeof(MouseState).GetProperty(buttonName);
        }

        public bool Pressed
        {
            get
            {
                return button.GetValue(Air.MouseState, null).Equals(ButtonState.Pressed);
            }
        }
    }
}
