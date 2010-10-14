using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AnotherInputRectifier.Details
{
    /// <summary>
    /// Represents the position of a gamepad thumbstick
    /// </summary>
    internal class ThumbstickControl : IAnalogDirectionControl
    {
        private readonly PlayerIndex player;
        private readonly Air.Thumbsticks t;

        public ThumbstickControl(PlayerIndex player, Air.Thumbsticks t)
        {
            this.player = player;
            this.t = t;
        }

        public Vector2 Value
        {
            get
            {
                if (t == Air.Thumbsticks.Left)
                {
                    return Air.GamePadState(player).ThumbSticks.Left;
                }
                return Air.GamePadState(player).ThumbSticks.Right;
            }
        }
    }
}
