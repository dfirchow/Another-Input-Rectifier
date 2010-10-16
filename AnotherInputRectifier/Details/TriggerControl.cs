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

        public TriggerControl(PlayerIndex player, Air.GamePad.Triggers trigger)
        {
            this.player = player;
            this.trigger = trigger;
        }

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
