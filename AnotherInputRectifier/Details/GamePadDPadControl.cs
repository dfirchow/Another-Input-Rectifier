using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace AnotherInputRectifier.Details
{
    internal class GamePadDPadControl : IDigitalDirectionControl
    {
        private readonly PlayerIndex player;

        public GamePadDPadControl(PlayerIndex player)
        {
            this.player = player;
        }

        public bool Up
        {
            get { return DPad.Up == ButtonState.Pressed; }
        }

        public bool Down
        {
            get { return DPad.Down == ButtonState.Pressed; }
        }

        public bool Left
        {
            get { return DPad.Left == ButtonState.Pressed; }
        }

        public bool Right
        {
            get { return DPad.Right == ButtonState.Pressed; }
        }

        private GamePadDPad DPad
        {
            get { return Air.GamePadState(player).DPad; }
        }
    }
}
