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
        private readonly bool isDPadButton;

        public GamePadButtonControl(PlayerIndex player, Air.GamePad.Buttons button)
        {
            this.player = player;
            this.button = typeof(GamePadButtons).GetProperty(button.ToString());
            this.isDPadButton = false;
        }

        public GamePadButtonControl(PlayerIndex player, Air.GamePad.DPad dPadButton)
        {
            this.player = player;
            this.button = typeof(GamePadDPad).GetProperty(dPadButton.ToString());
            this.isDPadButton = true;
        }

        public bool Pressed
        {
            get
            {
                if (isDPadButton)
                {
                    return button.GetValue(Air.GamePadState(player).DPad, null).Equals(ButtonState.Pressed);
                }
                return button.GetValue(Air.GamePadState(player).Buttons, null).Equals(ButtonState.Pressed);
            }
        }
    }
}
