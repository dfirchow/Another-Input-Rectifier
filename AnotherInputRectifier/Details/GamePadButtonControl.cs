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
    /// Represents a gamepad button as a digital control
    /// </summary>
    internal class GamePadButtonControl : IDigitalControl
    {
        private readonly PlayerIndex player;
        private readonly PropertyInfo button;

        public GamePadButtonControl(PlayerIndex player, Air.GamePad.Buttons button)
        {
            this.player = player;
            this.button = typeof(GamePadButtons).GetProperty(button.ToString());
        }

        public bool Pressed
        {
            get
            {
                return button.GetValue(Air.GamePadState(player).Buttons, null).Equals(ButtonState.Pressed);
            }
        }
    }
}
