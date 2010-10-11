using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnotherInputRectifier;
using Microsoft.Xna.Framework;

namespace TestAir
{
    public class PlayerControls
    {
        private DigitalDirectionControl movement;
        private DigitalFilterControl jump;
        private DigitalFilterControl fire;
        private DigitalFilterControl pause;

        public PlayerControls(
            DigitalDirectionControl movement,
            DigitalFilterControl jump,
            DigitalFilterControl fire,
            DigitalFilterControl pause)
        {
            this.movement = movement;
            this.jump = jump;
            this.fire = fire;
            this.pause = pause;
        }
         
        public bool Pause
        {
            get { return pause.Pressed; }
        }

        public bool Fire
        {
            get { return fire.Pressed; }
        }

        public bool Jump
        {
            get { return jump.Pressed; }
        }

        public Vector2 Movement
        {
            get { return movement.Value; }
        }

    }
}
