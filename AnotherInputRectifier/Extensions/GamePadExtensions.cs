using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnotherInputRectifier.Details;
using Microsoft.Xna.Framework;

namespace AnotherInputRectifier
{
    public static class GamePadExtensions
    {
        /// <summary>
        /// Turns a gamepad button into a digital control
        /// </summary>
        /// <param name="button">a gamepad button</param>
        /// <param name="player">player index for a gamepad</param>
        /// <returns>digital control for the button</returns>
        public static IDigitalControl ToControl(this Air.GamePad.Buttons button, PlayerIndex player)
        {
            return new GamePadButtonControl(player, button);
        }

        /// <summary>
        /// Turns a gamepad button for player one into a digital control
        /// </summary>
        /// <param name="button">a gamepad button</param>
        /// <returns>digital control for the button</returns>
        public static IDigitalControl ToControl(this Air.GamePad.Buttons button)
        {
            return new GamePadButtonControl(PlayerIndex.One, button);
        }

        /// <summary>
        /// Turns a gamepad dpad button for a player into a digital control
        /// </summary>
        /// <param name="button">gamepad button</param>
        /// <param name="player">player index for a gamepad</param>
        /// <returns>returns digital control for a dpad direction</returns>
        public static IDigitalControl ToControl(this Air.GamePad.DPad button, PlayerIndex player)
        {
            return new GamePadButtonControl(player, button);
        }

        /// <summary>
        /// Turns a gamepad dpad button for player one into a digital control
        /// </summary>
        /// <param name="button">gamepad button</param>
        /// <returns>returns digital control for a dpad direction</returns>
        public static IDigitalControl ToControl(this Air.GamePad.DPad button)
        {
            return new GamePadButtonControl(PlayerIndex.One, button);
        }

        /// <summary>
        /// Turns a gamepad thumbstick for a player into a IAnalogDirectionControl
        /// </summary>
        /// <param name="button">gamepad thumbstick</param>
        /// <param name="player">player index for a gamepad</param>
        /// <returns>returns IAnalogDirectionControl for a thumbstick</returns>
        public static IAnalogDirectionControl ToControl(
            this Air.GamePad.Thumbsticks thumbstick,
            PlayerIndex player)
        {
            return new ThumbstickControl(player, thumbstick);
        }

        /// <summary>
        /// Turns a gamepad thumbstick for player one
        /// into a IAnalogDirectionControl
        /// </summary>
        /// <param name="button">gamepad thumbstick</param>
        /// <returns>returns IAnalogDirectionControl for a thumbstick</returns>
        public static IAnalogDirectionControl ToControl(
            this Air.GamePad.Thumbsticks thumbstick)
        {
            return new ThumbstickControl(PlayerIndex.One, thumbstick);
        }

        /// <summary>
        /// Turns a gamepad trigger for a player into an analog control
        /// </summary>
        /// <param name="button">gamepad trigger</param>
        /// <param name="player">player index for a gamepad</param>
        /// <returns>returns analog control for a trigger</returns>
        public static IAnalogControl ToControl(
            this Air.GamePad.Triggers trigger,
            PlayerIndex player)
        {
            return new TriggerControl(player, trigger);
        }

        /// <summary>
        /// Turns a gamepad trigger for player one into an analog control
        /// </summary>
        /// <param name="button">gamepad trigger</param>
        /// <returns>returns analog control for a trigger</returns>
        public static IAnalogControl ToControl(
            this Air.GamePad.Triggers trigger)
        {
            return new TriggerControl(PlayerIndex.One, trigger);
        }
    }
}
