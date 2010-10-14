using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AnotherInputRectifier.Details
{
    internal class TriggerControl : IAnalogControl
    {
        private readonly PlayerIndex player;
        private readonly Air.GamePad.Triggers trigger;

        public float Value
        {
            get
            {
                if (trigger == Air.GamePad.Triggers.Left)
                {
                    return Air.GamePadState(player).Triggers.Left;
                }
                return Air.GamePadState(player).Triggers.Right;
            }
        }
    }
}
